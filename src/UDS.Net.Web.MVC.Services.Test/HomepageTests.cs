using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UDS.Net.Web.MVC.Services.Test;

[TestClass]
public class HomepageTests : PageTest
{

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            StorageStatePath = "../../../.auth/state.json"
        };
    }

    // Test initialize runs before each TestMethod
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync("https://localhost:4811/Identity/Account/Register");

        Random random = new Random();
        int _salt = random.Next(1, 1000);

        string emailAddress = $"test{_salt}@test.com";
        string password = $"Password_{_salt}";

        await Page.GetByLabel("Email").ClickAsync();
        await Page.GetByLabel("Email").FillAsync(emailAddress);

        // Click ensures that the element is visible
        await Page.GetByLabel("Password", new() { Exact = true }).ClickAsync();
        await Page.GetByLabel("Password", new() { Exact = true }).FillAsync(password);

        await Page.GetByLabel("Confirm Password").ClickAsync();
        await Page.GetByLabel("Confirm Password").FillAsync(password);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Register" }).ClickAsync();
        await Page.WaitForRequestFinishedAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Click here to confirm your" }).ClickAsync();
        await Page.WaitForRequestFinishedAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Page.GetByPlaceholder("name@example.com").ClickAsync();
        await Page.GetByPlaceholder("name@example.com").FillAsync(emailAddress);
        await Page.GetByPlaceholder("name@example.com").PressAsync("Tab");
        await Page.GetByPlaceholder("password").FillAsync(password);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

        await Context.StorageStateAsync(new()
        {
            Path = "../../../.auth/state.json"
        });
    }

    [TestMethod]
    public async Task HomepageHasNavigationToParticipations()
    {
        await Page.Locator("#desktop-menu").GetByRole(AriaRole.Link, new() { Name = "Participation" }).ClickAsync();
    }

    [TestMethod]
    public async Task HomepageHasNavigationToVisits()
    {
        await Page.Locator("#desktop-menu").GetByRole(AriaRole.Link, new() { Name = "Visits" }).ClickAsync();
    }
}

