using Microsoft.AspNetCore.Authorization;
using UDS.Net.API.Client;
using UDS.Net.Services;
using UDS.Net.Web.MVC.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

var initialScopes = configuration.GetValue<string>("DownstreamApis:Scopes")?.Split(' ');

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
    .AddMicrosoftGraph(configuration.GetSection("DownstreamApis:GraphApi"))
    .AddInMemoryTokenCaches(); // In memory token caching recommended for development only

////*************************************************************************************************
// Replace API and implemented services with your own if you don't want to use the included API here

builder.Services.AddUDSApiClient(configuration.GetValue<string>("DownstreamApis:UDSNetApi:BaseUrl"));

builder.Services.AddSingleton<IVisitService, VisitService>();
builder.Services.AddSingleton<IParticipationService, ParticipationService>();
builder.Services.AddSingleton<ILookupService, LookupService>();

////*************************************************************************************************

var mvcBuilder = builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddRazorPages()
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


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

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