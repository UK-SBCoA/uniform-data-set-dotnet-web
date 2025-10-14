using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    /// <summary>
    /// Path:  MBI
    /// 4. MBI, MCI = 0, IMPNOMCI = 0, MBI = 1
    /// (Other paths where MCI = 1 in D1aMCITests)
    /// (Other paths where IMPNOMCI = 1 in D1aImpairedTests)
    ///
    /// NORMCOG = 0
    /// DEMENTED = 0
    /// MCI = 0 (other option is 1 can be found in D1aMCITests)
    /// IMPNOMCI = 0 (other option is 1 can be found in D1aImpairedTests)
    /// MBI = 1
    /// </summary>
    [TestClass]
    public class D1aMBITests : TestBase
    {
        [TestMethod]
        public async Task D1aMBIUIBehaviors()
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

            // Question 5b IMPNOMCI == 0 No (IMPNOMCI == 1 in D1aImpairedTests)
            await Page.Locator("input[type=\"radio\"][name=\"D1a.IMPNOMCI\"][value=\"0\"]").ClickAsync();

            // Question 7 MBI
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"1\"]").ClickAsync();

            // Question 8 PREDOMSYN
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task D1aMBIValidatesRequiredFields()
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

            // Question 5b IMPNOMCI == 0 No (IMPNOMCI == 1 in D1aImpairedTests)
            await Page.Locator("input[type=\"radio\"][name=\"D1a.IMPNOMCI\"][value=\"0\"]").ClickAsync();

            // TODO Complete MBI tests for validation
        }
    }
}

