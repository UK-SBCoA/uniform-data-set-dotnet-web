using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class B9Tests : TestBase
    {
        [TestMethod]
        public async Task B9SavesInProgressWithNoValidation()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("B9");
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("Required");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            // reopen the page and see the data persisted
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsAgeFieldsFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Fill in some age fields that should be autofilled on follow-up visit
            // First, answer DECCLIN = Yes to enable cognitive section
            await Page.Locator("input[name=\"B9.DECCLIN\"][value=\"1\"]").ClickAsync();

            await Page.Locator("input[name=\"B9.DECCLCOG\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.COGMEM\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.COGAGE\"]").FillAsync("65");

            await Page.Locator("input[name=\"B9.DECCLBE\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.BEAPATHY\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.BEHAGE\"]").FillAsync("60");

            await Page.Locator("input[name=\"B9.DECCLMOT\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.MOGAIT\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.MOTORAGE\"]").FillAsync("62");
            await Page.Locator("input[name=\"B9.FRSTCHG\"][value=\"1\"]").ClickAsync();

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back to base url and create another follow-up B9
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Check that age fields and section indicators were autofilled
            // The age fields should be populated
            await Expect(Page.Locator("input[name=\"B9.COGAGE\"]")).ToHaveValueAsync("65");
            await Expect(Page.Locator("input[name=\"B9.BEHAGE\"]")).ToHaveValueAsync("60");
            await Expect(Page.Locator("input[name=\"B9.MOTORAGE\"]")).ToHaveValueAsync("62");

            // The section indicators should be set to Yes
            await Expect(Page.Locator("input[name=\"B9.DECCLCOG\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"B9.DECCLBE\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"B9.DECCLMOT\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"B9.DECCLIN\"][value=\"1\"]")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name=\"B9.FRSTCHG\"][value=\"0\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsSleepBehaviorFieldFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Fill in behavioral section with REM sleep behavior disorder
            await Page.Locator("input[name=\"B9.DECCLIN\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.DECCLBE\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.BEREM\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.BEREMAGO\"]").FillAsync("58");

            // Save in progress
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back to base url and create another follow-up B9
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[name=\"B9.BEREMAGO\"]")).ToHaveValueAsync("58");
            await Expect(Page.Locator("input[name=\"B9.BEREM\"][value=\"1\"]")).ToBeCheckedAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitSavesNewDataAfterAutofillFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Fill in initial data
            await Page.Locator("input[name=\"B9.DECCLIN\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.DECCLCOG\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.COGMEM\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"B9.COGAGE\"]").FillAsync("65");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back to base url and create another follow-up B9
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // Verify autofilled data
            await Expect(Page.Locator("input[name=\"B9.COGAGE\"]")).ToHaveValueAsync("65");

            // Change the autofilled age
            await Page.Locator("input[name=\"B9.COGAGE\"]").FillAsync("67");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Go back in to B9 and check that modified data is loaded instead of previous visit data
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B9 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[name=\"B9.COGAGE\"]")).ToHaveValueAsync("67");
        }
    }
}