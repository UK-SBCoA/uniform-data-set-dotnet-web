using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Tests;

[TestClass]
public class VisitTest : TestBase
{
    [TestMethod]
    public async Task Test()
    {
        //using var playwright = await Playwright.CreateAsync();
        //await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //{
        //    Headless = false,
        //});
        //var context = await browser.NewContextAsync();
        //var page = await context.NewPageAsync();
        await Page.GotoAsync("https://localhost:7109/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
        //await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Participant 1000 Visit 1" })).ToBeVisibleAsync();
        //await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A1", Exact = true })).ToBeVisibleAsync();
        //await Expect(Page.GetByRole(AriaRole.Main)).ToContainTextAsync("Pending");
    }




}
