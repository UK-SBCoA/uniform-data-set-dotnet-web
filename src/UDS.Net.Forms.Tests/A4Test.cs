using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class A4Tests : TestBase
    {
        [TestMethod]
        public async Task A4SavesInProgressWithNoValidation()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A4");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.GetByLabel("Save status"))
                .ToContainTextAsync("Not started In progress Finalized");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true })
                .ClickAsync();

            // Reopen
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();
        }

        [TestMethod]
        public async Task A4LoadsWithCorrectEnabledAndDisabledFields()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            // ANYMEDS enabled
            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"0\"]").IsEnabledAsync();
            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").IsEnabledAsync();

            // OTC disabled initially
            await Page.Locator("#OTCDrugCodes\\[0\\]").IsDisabledAsync();
            await Page.Locator("#OTCDrugCodes\\[1\\]").IsDisabledAsync();
        }

        [TestMethod]
        public async Task A4AnyMedsEnablesDrugSelection()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").ClickAsync();

            await Page.Locator("#OTCDrugCodes\\[0\\]").IsEnabledAsync();
            await Page.Locator("#OTCDrugCodes\\[1\\]").IsEnabledAsync();
        }

        [TestMethod]
        public async Task A4SelectsOTCDrugsAndPersists()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").ClickAsync();

            await Page.Locator("#OTCDrugCodes\\[0\\]").CheckAsync(); // Aspirin
            await Page.Locator("#OTCDrugCodes\\[1\\]").CheckAsync(); // Ibuprofen

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("#OTCDrugCodes\\[0\\]")).ToBeCheckedAsync();
            await Expect(Page.Locator("#OTCDrugCodes\\[1\\]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task A4RxNormSearchAndSelectPersists()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").ClickAsync();

            // Search Guanfacine
            await Page.GetByPlaceholder("Search by drug or brand name").FillAsync("Guan");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            await Page.Locator("li:has-text(\"Guanfacine\")").ClickAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("text=Guanfacine")).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task A4HandlesMixedDrugSources()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").ClickAsync();

            // OTC
            await Page.Locator("#OTCDrugCodes\\[0\\]").CheckAsync();

            // RxNorm
            await Page.GetByPlaceholder("Search by drug or brand name").FillAsync("Vori");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            await Page.Locator("li:has-text(\"Voriconazole\")").ClickAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("#OTCDrugCodes\\[0\\]")).ToBeCheckedAsync();
            await Expect(Page.Locator("text=Voriconazole")).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsA4Medications()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").ClickAsync();
            await Page.Locator("#OTCDrugCodes\\[0\\]").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Follow-up visit
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("#OTCDrugCodes\\[0\\]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitOverridesAutofillForA4()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A4.ANYMEDS\"][value=\"1\"]").ClickAsync();
            await Page.Locator("#OTCDrugCodes\\[0\\]").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Follow-up
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("#OTCDrugCodes\\[0\\]")).ToBeCheckedAsync();

            // Override
            await Page.Locator("#OTCDrugCodes\\[0\\]").UncheckAsync();
            await Page.Locator("#OTCDrugCodes\\[1\\]").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Reopen
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("#OTCDrugCodes\\[1\\]")).ToBeCheckedAsync();
        }
    }
}