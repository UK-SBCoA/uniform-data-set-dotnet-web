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

    }
}

