using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    /// <summary>
    /// Path: Dementia
    /// 3. Dementia: DEMENTED = 1
    ///
    /// NORMCOG = 0
    /// DEMENTED = 1
    /// </summary>
    [TestClass]
    public class D1aDementiaTests : TestBase
    {
        [TestMethod]
        public async Task D1aDementiaUIBehaviors()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3 DEMENTED == 1 Yes
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            // Question 6a must have checkboxes enabled except for Question 6f CDOMBEH
            await Expect(Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMLANG\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMATTN\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMEXEC\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMVISU\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMBEH\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMAPRAX\"][type=\"checkbox\"]")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task D1aDementiaValidatesRequiredFields()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3 DEMENTED == 1 Yes
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();


        }

        [TestMethod]
        public async Task D1aDementiaDisplaysQuestion6()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3 DEMENTED == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            // Question 6a-6g
            await Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMLANG\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMATTN\"][type=\"checkbox\"]").CheckAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync("In progress");

            // Attempt to save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Re-load
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMLANG\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMATTN\"][type=\"checkbox\"]")).ToBeCheckedAsync();
        }
    }
}

