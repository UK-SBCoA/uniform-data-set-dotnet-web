using System;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UDS.Net.Web.MVC.Services.Test
{
    public class Startup : PageTest
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            await Page.GotoAsync("Identity/Account/Login?ReturnUrl=%2F");

            var loginButton = Page.GetByRole(AriaRole.Link, new() { Name = "Login" });

            if (loginButton != null)
            {

            }
            else
            {
                // already authenticated
            }
        }
    }
}

