using System;
using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class A4Tests : TestBase
    {
        private async Task CheckDrugAsync(string rxNormId)
        {
            var locator = Page.Locator($"input[type='checkbox'][name='SelectedDrugs'][value='{rxNormId}']");
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await locator.CheckAsync();
        }

        private async Task UncheckDrugAsync(string rxNormId)
        {
            var locator = Page.Locator($"input[type='checkbox'][name='SelectedDrugs'][value='{rxNormId}']");
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await locator.UncheckAsync();
        }

        private async Task ExpectDrugCheckedAsync(string rxNormId)
        {
            var locator = Page.Locator($"input[type='checkbox'][name='SelectedDrugs'][value='{rxNormId}']");
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await Expect(locator).ToBeCheckedAsync();
        }

        private async Task ExpectDrugNotCheckedAsync(string rxNormId)
        {
            var locator = Page.Locator($"input[type='checkbox'][name='SelectedDrugs'][value='{rxNormId}']");
            if (await locator.CountAsync() > 0)
            {
                await Expect(locator).Not.ToBeCheckedAsync();
            }
        }

        private async Task SelectAndCheckUncommonDrugAsync(string drugName, string rxNormId)
        {
            var searchBox = Page.Locator("input[data-autocomplete-target='searchBox']");
            await searchBox.FillAsync(drugName);

            var searchButton = Page.Locator("input[name='RxNormSearch'][type='submit']");
            await searchButton.ClickAsync();

            var selectButton = Page.Locator($"button[data-action='a4#selectDrug'][value='{rxNormId}']");
            await selectButton.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await selectButton.ClickAsync();

            var drugCheckbox = Page.Locator($"input[type='checkbox'][name='SelectedDrugs'][value='{rxNormId}']");
            await drugCheckbox.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });

            await drugCheckbox.CheckAsync();
        }

        [TestMethod]
        public async Task A4SavesInProgressWithNoValidation()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A4");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsCommonDrug()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name='A4.ANYMEDS'][value='1']").CheckAsync();
            await CheckDrugAsync("12345");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await ExpectDrugCheckedAsync("12345");
        }

        [TestMethod]
        public async Task FollowUpVisitSelectsUncommonDrugViaSearch()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name='A4.ANYMEDS'][value='1']").CheckAsync();
            await SelectAndCheckUncommonDrugAsync("Acetazolamide", "34567");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await ExpectDrugCheckedAsync("34567");
        }

        [TestMethod]
        public async Task FollowUpVisitOverridesAutofillForDrugs()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name='A4.ANYMEDS'][value='1']").CheckAsync();
            await SelectAndCheckUncommonDrugAsync("Guanfacine", "56789");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await ExpectDrugCheckedAsync("56789");

            await UncheckDrugAsync("56789");
            await CheckDrugAsync("23456");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await ExpectDrugCheckedAsync("23456");
            await ExpectDrugNotCheckedAsync("56789");
        }
    }
}