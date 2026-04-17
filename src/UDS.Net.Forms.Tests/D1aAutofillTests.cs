using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class D1aAutofillTests : TestBase
    {
        [TestMethod]
        public async Task FollowUpVisitAutofillsD1aNormcogDementedFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill of NORMCOG, DEMENTED, and affected domains
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsD1aMCIPathFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]").CheckAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"1\"]").ClickAsync();


            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill of MCI criteria and selections
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.MCI\"][value=\"1\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsD1aMBIDomainFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]").CheckAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMMOT\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMAFREG\"][value=\"0\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMIMP\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMSOCIAL\"][value=\"0\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMTHTS\"][value=\"1\"]").ClickAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill of MBI domain selections
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMMOT\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMAFREG\"][value=\"0\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMIMP\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMSOCIAL\"][value=\"0\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.BDOMTHTS\"][value=\"1\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsD1aSyndromeDataFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.PREDOMSYN\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[name=\"D1a.AMNDEM\"][type=\"checkbox\"]").CheckAsync();

            await Page.Locator("input[name=\"D1a.SYNINFCLIN\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.SYNINFCTST\"][type=\"checkbox\"]").CheckAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill of syndrome data
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.AMNDEM\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.SYNINFCLIN\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.SYNINFCTST\"][type=\"checkbox\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsD1aEtiologyDiagnosisFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.MBI\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.PREDOMSYN\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[name=\"D1a.MAJDEPDX\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.MAJDEPDIF\"][value=\"1\"]").ClickAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill of etiology diagnosis
            await Expect(Page.Locator("input[name=\"D1a.MAJDEPDX\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.MAJDEPDIF\"][value=\"1\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitDoesNotFillAffectedDomainsFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMLANG\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMATTN\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMEXEC\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMVISU\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMBEH\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMAPRAX\"][type=\"checkbox\"]").CheckAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMLANG\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMATTN\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMEXEC\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMVISU\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMBEH\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMAPRAX\"][type=\"checkbox\"]")).Not.ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitSavesNewDataAfterAutofillFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"1\"]").ClickAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back to base url and create another follow-up D1a
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofilled data
            await Expect(Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"1\"]")).ToBeCheckedAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]").CheckAsync();
            await Page.Locator("input[name=\"D1a.CDOMEXEC\"][type=\"checkbox\"]").CheckAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Reopen and confirm override
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify that the modified data persisted, not the autofilled data
            await Expect(Page.Locator("input[name=\"D1a.CDOMMEM\"][type=\"checkbox\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"D1a.CDOMEXEC\"][type=\"checkbox\"]")).ToBeCheckedAsync();
        }
    }
}