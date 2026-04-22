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
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='12345']")
                .WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='12345']").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='12345']")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitSelectsUncommonDrugViaSearch()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name='A4.ANYMEDS'][value='1']").CheckAsync();

            await Page.Locator("input[data-autocomplete-target='searchBox']").FillAsync("Acetazolamide");
            await Page.Locator("input[name='RxNormSearch'][type='submit']").ClickAsync();
            await Page.Locator("button[data-action='a4#selectDrug'][value='34567']")
                .WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await Page.Locator("button[data-action='a4#selectDrug'][value='34567']").ClickAsync();
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='34567']")
                .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='34567']").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='34567']")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitOverridesAutofillForDrugs()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name='A4.ANYMEDS'][value='1']").CheckAsync();

            await Page.Locator("input[data-autocomplete-target='searchBox']").FillAsync("Guanfacine");
            await Page.Locator("input[name='RxNormSearch'][type='submit']").ClickAsync();
            await Page.Locator("button[data-action='a4#selectDrug'][value='56789']")
                .WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await Page.Locator("button[data-action='a4#selectDrug'][value='56789']").ClickAsync();
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='56789']")
                .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='56789']").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='56789']")).ToBeCheckedAsync();

            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='56789']").UncheckAsync();
            await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='23456']").CheckAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A4 Required" })
                .GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='23456']")).ToBeCheckedAsync();
            if (await Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='56789']").CountAsync() > 0)
            {
                await Expect(Page.Locator("input[type='checkbox'][name='SelectedDrugs'][value='56789']")).Not.ToBeCheckedAsync();
            }
        }
    }
}