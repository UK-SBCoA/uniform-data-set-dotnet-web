using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    /// <summary>
    /// Path: MCI and/or MBI
    /// 5. MCI + MBI, MCI = 1 and MBI = 1
    /// 6. MCI, MCI = 1 and MBI = 0
    ///
    /// NORMCOG = 0
    /// DEMENTED = 0
    /// MCI = 1
    /// IMPNOMCI = 0
    /// MBI = (0,1)
    /// </summary>
    [TestClass]
    public class D1aMCITests : TestBase
    {
        [TestMethod]
        public async Task D1aMCIUIBehaviors()
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

            // Question 4
            await Expect(Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]")).ToBeEnabledAsync();

            // Question 4b
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"1\"]").ClickAsync();

            // Question 5
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIFU\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCICG\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCLCD\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIO\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            // Question 5b
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"1\"]")).ToBeDisabledAsync();

            // Questions 6a-6g
            await Expect(Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMLANG\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMATTN\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMEXEC\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMVISU\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMBEH\"][type=\"checkbox\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMAPRAX\"][type=\"checkbox\"]")).ToBeEnabledAsync();

            // Question 7 MBI = 0
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"1\"]")).ToBeEnabledAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"0\"]").ClickAsync();

            // Question 8
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeEnabledAsync();

            // Question 7 MBI = 1
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"1\"]").ClickAsync();

            // Question 8
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeEnabledAsync();



        }

        [TestMethod]
        public async Task D1aMCIValidatesRequiredFields()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            // Question 2 NORMCOG == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            // Question 3 DEMENTED == 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]").ClickAsync();

            // Question 4b MCI = 1 Yes
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"1\"]").ClickAsync();

            // Question 7 MBI = 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"0\"]").ClickAsync();

            // Question 8 PREDOMSYN = 0 No
            await Page.Locator("input[type=\"radio\"][name=\"D1a.PREDOMSYN\"][value=\"0\"]").ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");

            // Attempt to save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // All Question 4 checkboxes must be checked for MCI = 1
            await Expect(Page.Locator("span").Filter(new() { HasText = "If all three criteria in question 4 are checked, choose 1=MCI. If less than 3 criteria are met, choose 0=No." })).ToBeVisibleAsync();

            // Question 4
            await Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]").CheckAsync();

            // Attempt to save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // All Question 4 checkboxes must be checked for MCI = 1
            await Expect(Page.Locator("span").Filter(new() { HasText = "If all three criteria in question 4 are checked, choose 1=MCI. If less than 3 criteria are met, choose 0=No." })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]").CheckAsync();

            // Attempt to save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // All Question 4 checkboxes must be checked for MCI = 1
            await Expect(Page.Locator("span").Filter(new() { HasText = "If all three criteria in question 4 are checked, choose 1=MCI. If less than 3 criteria are met, choose 0=No." })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]").CheckAsync();

            // Attempt to save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Question 6a must have a checkbox selected

            // The issue with the locator is that PlayWright is finding several elements, so let's filter it. Previous error message:
            // 9 × locator resolved to <span data-valmsg-replace="true" data-valmsg-for="D1a.AffectedDomainsIndicated" class="mt-2 text-sm text-red-600 field-validation-valid"></span

            await Expect(Page.Locator("span[data-valmsg-for=\"D1a.AffectedDomainsIndicated\"]").Filter(new LocatorFilterOptions { HasText = "Please check one or more Affected Domain." })).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task D1aMCIDisplaysQuestion6()
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

            // Question 4
            await Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]").CheckAsync();

            await Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]").CheckAsync();

            await Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]").CheckAsync();

            // Question 4b MCI = 1 Yes
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"1\"]").ClickAsync();

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

