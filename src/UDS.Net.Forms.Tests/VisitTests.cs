using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Tests;

[TestClass]
public class VisitTest : TestBase
{
    private string _visitId = "1";

    [TestInitialize]
    public async Task TestInitialize()
    {
        // use the url from the testbase

        //await Page.WaitForURLAsync("**/Visits/Details/*"); // this fails in headless mode
    }

    [TestMethod]
    public async Task CheckForForms()
    {
        await Page.GotoAsync(BaseUrl);
        await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
        await Page.WaitForRequestFinishedAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A1", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A1a", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A2", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A3", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A4", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A4a", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "A5D2", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B1", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B3", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B4", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B5", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B6", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B7", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B8", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "B9", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "C2", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "D1a", Exact = true })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "D1b", Exact = true })).ToBeVisibleAsync();

    }

    [TestMethod]
    public async Task CheckForRequired()
    {
        await Page.GotoAsync(BaseUrl);
        await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
        await Page.WaitForRequestFinishedAsync();

        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A1 Required Participant" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required Participant" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required Participant" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a Required AD–Specific Drug" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A5D2 Required Participant" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B4 Required CDR Plus NACC" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B8 Required Evaluation Form:" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required Clinician" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required Clinical" }).Locator("span").ClickAsync();
        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1b Required Biomarker and" }).Locator("span").ClickAsync();
    }


}
