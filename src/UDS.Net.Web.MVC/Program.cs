using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UDS.Net.API.Client;
using UDS.Net.Services;
using UDS.Net.Web.MVC.Data;
using UDS.Net.Web.MVC.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web.UI;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Caching.Cosmos;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Replace identity service with your preferred provider rather than using this one. Roles required:
// Administrator
// SuperUser
// Examiner
//var connectionString = configuration.GetConnectionString("AuthServiceConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

if (builder.Environment.IsProduction())
{
    builder.Services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
    {
        cacheOptions.DatabaseName = configuration["Cosmos:CacheDatabase"];
        cacheOptions.ContainerName = configuration["Cosmos:CacheContainer"];
        cacheOptions.ClientBuilder = new Microsoft.Azure.Cosmos.Fluent.CosmosClientBuilder(configuration.GetConnectionString("CosmosCache"));
        cacheOptions.CreateIfNotExists = true;
    });
}

builder.Services
       .AddMicrosoftIdentityWebAppAuthentication(configuration, "AzureAd")
       .EnableTokenAcquisitionToCallDownstreamApi()
       .AddMicrosoftGraph(configuration.GetSection("DownstreamApis:UDSNetApi"))
       .AddDistributedTokenCaches();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.IsEssential = true;
});

// MicrosoftIdentityWebChallengeUserException https://aka.ms/ms-id-web/ca_incremental-consent
builder.Services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            options.ReturnUrlParameter = "returnUrl";
            if (!builder.Environment.IsProduction())
                options.Events = new RejectSessionCookieWhenAccountNotInCacheEvents();
        });

builder.Services.AddHttpContextAccessor();


////*************************************************************************************************
// Replace API and implemented services with your own if you don't want to use the included API here

builder.Services.AddUDSApiClient(configuration.GetValue<string>("DownstreamApis:UDSNetApi:BaseUrl"));

builder.Services.AddSingleton<IVisitService, VisitService>();
builder.Services.AddSingleton<IParticipationService, ParticipationService>();
builder.Services.AddSingleton<ILookupService, LookupService>();

////*************************************************************************************************

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages(); // Enables UDS.Net.Forms razor class library. More here: https://learn.microsoft.com/en-us/aspnet/core/razor-pages/

//var mvcBuilder = builder.Services.AddControllersWithViews();
var mvcBuilder = builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
})
.AddMicrosoftIdentityUI();

////*************************************************************************************************
// Only used during development
// Runtime compilation of razor assets. Read more here: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-7.0&tabs=visual-studio#enable-runtime-compilation-conditionally

if (builder.Environment.IsDevelopment() && Debugger.IsAttached)
{
    mvcBuilder.AddRazorRuntimeCompilation(); // this can't be configured in startup assembly for RCL runtime compilation, it must be here. The fix is available soon in .NET 7 https://github.com/dotnet/aspnetcore/issues/38465

    // Is also required for runtime compilation of Razor Class Library UDS.Net.Forms
    builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
    {
        var libraryPath = "";

        if (System.Environment.OSVersion.Platform != PlatformID.Win32NT)
        {
            libraryPath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "UDS.Net.Forms"));
        }

        if (!String.IsNullOrWhiteSpace(libraryPath))
        {
            options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
        }
    });

}

////*************************************************************************************************

// Uncomment to remove enforced authentication
//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//    using (var scope = app.Services.CreateScope())
//    {
//        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//        db.Database.Migrate();
//    }
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles(); // A must for using content from referenced UDS.Net.Forms RCL

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages(); // enables UDS.Net.Forms endpoints

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();

// Workaround for in memory token caching on dev and non-production environments
// https://github.com/AzureAD/microsoft-identity-web/issues/13#issuecomment-878528492
internal class RejectSessionCookieWhenAccountNotInCacheEvents : CookieAuthenticationEvents
{
    public async override Task ValidatePrincipal(CookieValidatePrincipalContext context)
    {
        try
        {
            var tokenAcquisition = context.HttpContext.RequestServices.GetRequiredService<ITokenAcquisition>();
            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var token = await tokenAcquisition.GetAccessTokenForUserAsync(
                scopes: config.GetValue<string>("DownstreamApis:GraphApi:Scopes")?.Split(' '),
                user: context.Principal);
        }
        catch (MicrosoftIdentityWebChallengeUserException ex)
            when (AccountDoesNotExitInTokenCache(ex))
        {
            context.RejectPrincipal();
        }
    }

    private bool AccountDoesNotExitInTokenCache(MicrosoftIdentityWebChallengeUserException ex)
    {
        return ex.InnerException is MsalUiRequiredException
                                  && (ex.InnerException as MsalUiRequiredException).ErrorCode == MsalError.UserNullError;
    }
}