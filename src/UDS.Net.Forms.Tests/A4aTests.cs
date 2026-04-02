using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class A4aTests : TestBase
    {
        [TestMethod]
        public async Task A4aSavesInProgressWithNoValidation()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A4a");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            // reopen the page and see the data persisted
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();
        }

        [TestMethod]
        public async Task A4aLoadsWithCorrectEnabledAndDisabledFields()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A4a");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1 TRTBIOMARK should be enabled
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"0\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"9\"]").IsEnabledAsync();

            // All sub-questions should be disabled
            // 8 possible treatments
            for (int i = 0; i < 8; i++)
            {
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETAB\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETTAU\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETINF\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETSYN\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETOTH\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TARGETOTX\"]").IsDisabledAsync();
                // Specific treatment and/or trial
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRTTRIAL\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].NCTNUM\"]").IsDisabledAsync();
                // Start and end dates
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].STARTMO\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].STARTYEAR\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].ENDMO\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].ENDYEAR\"]").IsDisabledAsync();
                // How was the treatment provided?
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"1\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"2\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"3\"]").IsDisabledAsync();
                // If clinical trial, in which group was the participant?
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"1\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"2\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"9\"]").IsDisabledAsync();
            }

            // Question 3 ADVENVENT
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"0\"]").IsDisabledAsync();
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"1\"]").IsDisabledAsync();
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"9\"]").IsDisabledAsync();
            // Question 3a checkboxes and other text field
            await Page.Locator("input[type=\"checkbox\"][name=\"A4a.ARIAE\"]").IsDisabledAsync();
            await Page.Locator("input[type=\"checkbox\"][name=\"A4a.ARIAH\"]").IsDisabledAsync();
            await Page.Locator("input[type=\"checkbox\"][name=\"A4a.ADVERSEOTH\"]").IsDisabledAsync();
            await Page.Locator("input[name=\"A4a.ADVERSEOTX\"]").IsDisabledAsync();

        }

        [TestMethod]
        public async Task A4aTreatmentsWithCorrectEnableDisableState()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A4a");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1 TRTBIOMARK should be enabled
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"0\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"9\"]").IsEnabledAsync();

            // Question 1 TRTBIOMARK
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]").ClickAsync();

            // Up-to-two treatments/trials should be enabled
            for (int i = 0; i < 2; i++)
            {
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETAB\"]").IsEnabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETTAU\"]").IsEnabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETINF\"]").IsEnabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETSYN\"]").IsEnabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETOTH\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TARGETOTX\"]").IsDisabledAsync();
                // Specific treatment and/or trial
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRTTRIAL\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].NCTNUM\"]").IsEnabledAsync();
                // Start and end dates
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].STARTMO\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].STARTYEAR\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].ENDMO\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].ENDYEAR\"]").IsEnabledAsync();
                // How was the treatment provided?
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"1\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"2\"]").IsEnabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"3\"]").IsEnabledAsync();
                // If clinical trial, in which group was the participant?
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"1\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"2\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"9\"]").IsDisabledAsync();
            }

            // Question 3 ADVENVENT
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"0\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"1\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"9\"]").IsEnabledAsync();

            // Question 3a checkboxes and other text field
            await Page.Locator("input[type=\"checkbox\"][name=\"A4a.ARIAE\"]").IsDisabledAsync();
            await Page.Locator("input[type=\"checkbox\"][name=\"A4a.ARIAH\"]").IsDisabledAsync();
            await Page.Locator("input[type=\"checkbox\"][name=\"A4a.ADVERSEOTH\"]").IsDisabledAsync();
            await Page.Locator("input[name=\"A4a.ADVERSEOTX\"]").IsDisabledAsync();

            // Remaining treatments/trials should be disabled until ADVEVENT
            for (int i = 2; i < 8; i++)
            {
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETAB\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETTAU\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETINF\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETSYN\"]").IsDisabledAsync();
                await Page.Locator($"input[type=\"checkbox\"][name=\"A4a.Treatments[{i}].TARGETOTH\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TARGETOTX\"]").IsDisabledAsync();
                // Specific treatment and/or trial
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRTTRIAL\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].NCTNUM\"]").IsDisabledAsync();
                // Start and end dates
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].STARTMO\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].STARTYEAR\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].ENDMO\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].ENDYEAR\"]").IsDisabledAsync();
                // How was the treatment provided?
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"1\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"2\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].CARETRIAL\"][value=\"3\"]").IsDisabledAsync();
                // If clinical trial, in which group was the participant?
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"1\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"2\"]").IsDisabledAsync();
                await Page.Locator($"input[name=\"A4a.Treatments[{i}].TRIALGRP\"][value=\"9\"]").IsDisabledAsync();
            }

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            // Save
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back to form
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A4a");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Question 1 TRTBIOMARK
            await Expect(Page.Locator("input[name=\"A4a.TRTBIOMARK\"]:checked")).ToHaveValueAsync("1");
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsA4aTreatmentsFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Enable treatments
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]").ClickAsync();

            // Fill first treatment
            await Page.Locator("input[name=\"A4a.Treatments[0].TARGETAB\"]").CheckAsync();
            await Page.Locator("input[name=\"A4a.Treatments[0].TRTTRIAL\"]").FillAsync("Trial A");
            await Page.Locator("input[name=\"A4a.Treatments[0].NCTNUM\"]").FillAsync("NCT123");
            await Page.Locator("input[name=\"A4a.Treatments[0].STARTMO\"]").FillAsync("01");
            await Page.Locator("input[name=\"A4a.Treatments[0].STARTYEAR\"]").FillAsync("2020");

            // Save
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Create follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill
            await Expect(Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].TARGETAB\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].TRTTRIAL\"]")).ToHaveValueAsync("Trial A");
            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].NCTNUM\"]")).ToHaveValueAsync("NCT123");
            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].STARTMO\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].STARTYEAR\"]")).ToHaveValueAsync("2020");
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsA4aAdverseEvents()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Enable treatments first (required for ADVEVENT)
            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]").ClickAsync();

            // Set adverse events
            await Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"A4a.ARIAE\"]").CheckAsync();
            await Page.Locator("input[name=\"A4a.ADVERSEOTH\"]").CheckAsync();
            await Page.Locator("input[name=\"A4a.ADVERSEOTX\"]").FillAsync("Other event");

            // Save
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill
            await Expect(Page.Locator("input[name=\"A4a.ADVEVENT\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"A4a.ARIAE\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"A4a.ADVERSEOTH\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"A4a.ADVERSEOTX\"]")).ToHaveValueAsync("Other event");
        }

        [TestMethod]
        public async Task FollowUpVisitOverridesAutofillForA4a()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4a.TRTBIOMARK\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"A4a.Treatments[0].TRTTRIAL\"]").FillAsync("Original Trial");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Follow-up
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofill
            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].TRTTRIAL\"]")).ToHaveValueAsync("Original Trial");

            // Change value
            await Page.Locator("input[name=\"A4a.Treatments[0].TRTTRIAL\"]").FillAsync("Updated Trial");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Reopen and confirm override
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4a" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[name=\"A4a.Treatments[0].TRTTRIAL\"]")).ToHaveValueAsync("Updated Trial");
        }

    }
}

