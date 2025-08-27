using System;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace UDS.Net.Forms.Tests
{
    /// <summary>
    /// Path: Normal Cognition or SCD/Normal
    /// 1. SCD/Normal: NORMCOG = 1, SCD= 1
    /// 2. Normal cognition: NORMCOG = 1, SCD=0
    /// 
    /// NORMCOG = 1
    /// Required variables:
    /// SCD
    /// SCDDXCONF when SCD = 1
    /// </summary>
    [TestClass]
    public class D1aNormalSCDTests : TestBase
    {
        [TestMethod]
        public async Task D1aNormalCognitionUIBehaviors()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();
            // Question 2
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"1\"]").ClickAsync();
            // Check for correct disabling
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 2a
            await Expect(Page.Locator("input[name=\"D1a.SCD\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCD\"][value=\"1\"]")).ToBeEnabledAsync();
            // Question 2b
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"1\"]")).ToBeDisabledAsync();

            // Question 2a
            await Page.Locator("input[type=\"radio\"][name=\"D1a.SCD\"][value=\"0\"]").ClickAsync();
            // Check for correct disabling
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 2b disabled
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"1\"]")).ToBeDisabledAsync();

            // Question 2a
            await Page.Locator("input[type=\"radio\"][name=\"D1a.SCD\"][value=\"1\"]").ClickAsync();
            // Check for correct disabling
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 2b enabled
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCDDXCONF\"][value=\"1\"]")).ToBeEnabledAsync();

        }

        [TestMethod]
        public async Task D1aNormalCognitionValidatesRequiredFields()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");

            // Attempt to save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.Locator("span").Filter(new() { HasText = "The Does the participant have: 1. Unimpaired cognition" })).ToBeVisibleAsync();

            // Select Question 2
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"1\"]").ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Please specify." })).ToBeVisibleAsync();

            // Select Question 2a SCD == 1 requires SCDXCONF
            await Page.Locator("input[type=\"radio\"][name=\"D1a.SCD\"][value=\"1\"]").ClickAsync();
            //Atempt save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Please specify." })).ToBeVisibleAsync();

            // Select Question 2a SCD == 0 ends form
            await Page.Locator("input[type=\"radio\"][name=\"D1a.SCD\"][value=\"0\"]").ClickAsync();
            // Successful save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // TODO check that form is persisted
        }

        [TestMethod]
        public async Task D1aNormalCognitionAfterPreviousSaveOnOtherPath()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1
            await Page.GetByText("Formal consensus panel").ClickAsync();
            // Question 2
            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"0\"]").ClickAsync();
            // Question 2a
            await Page.Locator("input[type=\"radio\"][name=\"D1a.DEMENTED\"][value=\"0\"]").ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back to D1a
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "D1a Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[type=\"radio\"][name=\"D1a.NORMCOG\"][value=\"1\"]").ClickAsync();

            // Check for correct disabling
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeDisabledAsync();

            // Question 2a should be enabled
            await Expect(Page.Locator("input[name=\"D1a.SCD\"][value=\"0\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCD\"][value=\"1\"]")).ToBeEnabledAsync();

            // Other fields should be disabled
            // Question 3
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DEMENTED\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 4
            await Expect(Page.Locator("input[name=\"D1a.MCICRITCLN\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITIMP\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCICRITFUN\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            // Question 4b
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MCI\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 5
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIFU\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCICG\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCLCD\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCIO\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            // Question 5b
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPNOMCI\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 7
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MBI\"][value=\"1\"]")).ToBeDisabledAsync();
            // Question 8
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"0\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PREDOMSYN\"][value=\"1\"]")).ToBeDisabledAsync();
            // Section 3
            await Expect(Page.Locator("input[name=\"D1a.MAJDEPDX\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.OTHDEPDX\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.BIPOLDX\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.SCHIZOP\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.ANXIET\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.PTSDDX\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.NDEVDIS\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.DELIR\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.OTHPSY\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.TBIDX\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.EPILEP\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.HYCEPH\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.NEOP\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.HIV\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.POSTC19\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.APNEADX\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.OTHCOGILL\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.ALCDEM\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.IMPSUB\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.MEDS\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.COGOTH\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.COGOTH2\"][type=\"checkbox\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"D1a.COGOTH3\"][type=\"checkbox\"]")).ToBeDisabledAsync();

            //  SCD = 0 end form here
            await Page.Locator("input[type=\"radio\"][name=\"D1a.SCD\"][value=\"0\"]").ClickAsync();

            // finalize
            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
        }
    }
}

