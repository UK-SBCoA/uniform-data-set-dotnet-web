using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    /// Diagnoses
    /// 1. SCD/Normal SCD= 1, Normal = 1
    /// 2. SCD=0, NORMCOG = 1 normal cognition
    /// 3. DEMENTED = 1 dementia
    /// 4. MCI + MBI, MCI = 1 and MBI = 1
    /// 5. MCI, only MCI
    /// 6. Impaired + MBI, IMPNOMCI =1, MBI = 1
    /// 7. Impaired, IMPNOMCI = 1, not MBI
    /// 8. MBI, MCI = 0, IMPNOMCI = 0, MBI = 1
    ///
    /// 
    /// <summary>
    /// Path: Unknown
    /// NORMCOG = 0
    /// DEMENTED = 0
    /// MCI = 0
    /// IMPNOMCI = 0
    /// MBI = 0
    /// PREDOMSYN = 0
    /// </summary>
    [TestClass]
    public class D1aUnknownDiagosisTests : TestBase
    {
        [TestMethod]
        public async Task D1aUnknownDiagnosisUIBehaviors()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeEnabledAsync();

            // DEMENTED == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]").ClickAsync();
            // Question 4 checkboxes enabled
            await Expect(Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            // Question 4b
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"1\"]")).ToBeEnabledAsync();
            // if all 3 checked, MCI = 1
            // if less, MCI = 0

            // MCI = 0
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"0\"]").ClickAsync();

            // Question 5 checkboxes enabled
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIFU\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCICG\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCLCD\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIO\"][type=\"checkbox\"]")).ToBeEnabledAsync();

            // Question 5b
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"1\"]")).ToBeEnabledAsync();

            // if only the 3rd option IMPNOMCI = 1
            // otherwise IMPNOMCI = 0

            // IMPNOMCI = 0
            await Page.Locator("input[type=\"radio\"][name=\"D1a.IMPNOMCI\"][value=\"0\"]").ClickAsync();

            // Question 7 enabled
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"1\"]")).ToBeEnabledAsync();

            // MBI = 0
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"0\"]").ClickAsync();

            // Question 8 enabled
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeEnabledAsync();

            // PREDOMSYN = 0
            await Page.Locator("input[type=\"radio\"][name=\"D1a.PREDOMSYN\"][value=\"0\"]").ClickAsync();

            // Save

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Check state on reload
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Expect(Page.Locator("input[name=\"D1a.NORMCOG\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.NORMCOG\"][value=\"1\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"]:checked")).ToHaveValueAsync("0");

            await Expect(Page.Locator("input[name=\"D1a.SCD\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCD\"][value=\"1\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"1\"]")).ToBeDisabledAsync();

            // DEMENTED == 0 No
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"]:checked")).ToHaveValueAsync("0");

            // MCI = 0
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"]:checked")).ToHaveValueAsync("0");

            // IMPNOMCI = 0
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.IMPNOMCI\"]:checked")).ToHaveValueAsync("0");

            // MBI = 0
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"]:checked")).ToHaveValueAsync("0");

            // PREDOMSYN = 0
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.PREDOMSYN\"]:checked")).ToHaveValueAsync("0");
        }
    }
}

