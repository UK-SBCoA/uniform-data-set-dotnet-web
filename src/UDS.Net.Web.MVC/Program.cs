using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UDS.Net.API.Client;
using UDS.Net.Services;
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
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Get the scopes from the configuration (appsettings.json)
var initialScopes = configuration.GetValue<string>("DownstreamApi:Scopes")?.Split(' ');


// Add sign-in with Microsoft
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"))

        // Add the possibility of acquiring a token to call a protected web API
        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)

            // Enables controllers and pages to get GraphServiceClient by dependency injection
            // And use an in memory token cache
            .AddMicrosoftGraph(configuration.GetSection("DownstreamApi"))
            .AddInMemoryTokenCaches();

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Enables a UI and controller for sign in and sign out.
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

var mvcBuilder = builder.Services.AddControllersWithViews();


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

////*************************************************************************************************
// Replace API and implemented services with your own if you don't want to use the included API here

builder.Services.AddUDSApiClient(configuration.GetValue<string>("DownstreamApis:UDSNetApi:BaseUrl"));

builder.Services.AddSingleton<IVisitService, VisitService>();
builder.Services.AddSingleton<IParticipationService, ParticipationService>();
builder.Services.AddSingleton<ILookupService, LookupService>();

////*************************************************************************************************

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

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