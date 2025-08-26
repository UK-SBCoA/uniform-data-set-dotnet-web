using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    /// <summary>
    /// Path: Impaired optional MBI
    /// 7. Impaired + MBI, IMPNOMCI = 1, MBI = 1
    /// 8. Impaired, IMPNOMCI = 1, not MBI
    ///
    /// NORMCOG = 0
    /// DEMENTED = 0
    /// MCI = 0
    /// IMPNOMCI = 1
    /// MBI = (0,1)
    /// </summary>
    [TestClass]
    public class D1aImpairedTests : TestBase
    {
        [TestMethod]
        public async Task D1aImpairedUIBehaviors()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3 DEMENTED == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]").ClickAsync();

            // Question 4b MCI == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"0\"]").ClickAsync();

            // Question 5
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIFU\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCICG\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCLCD\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIO\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            // Question 5b
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"1\"]")).ToBeEnabledAsync();

            // Question 5b IMPNOMCI == 1 Yes
            await Page.Locator("input[type=\"radio\"][name=\"D1a.IMPNOMCI\"][value=\"1\"]").ClickAsync();

            // Question 7 MBI
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"0\"]").ClickAsync();

            // Question 8 PREDOMSYN
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeEnabledAsync();

        }

        [TestMethod]
        public async Task D1aImpairedValidatesRequiredFields()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3 DEMENTED == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]").ClickAsync();

            // Question 4b MCI == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"0\"]").ClickAsync();

            // Question 5b IMPNOMCI == 1 Yes
            await Page.Locator("input[type=\"radio\"][name=\"D1a.IMPNOMCI\"][value=\"1\"]").ClickAsync();

            // TODO Complete Impaired tests for validation
        }
    }
}

