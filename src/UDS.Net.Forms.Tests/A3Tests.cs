using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class A3Tests : TestBase
    {
        [TestMethod]
        public async Task A3SavesInProgressWithNoValidation()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A3");
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("Required");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            // reopen the page and see the data persisted
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();
        }

        [TestMethod]
        public async Task SiblingChildrenCountsRequired()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A3.MOMYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.MOMDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.MOMETPR\"]").FillAsync("00");

            await Page.Locator("input[name=\"A3.DADYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.DADDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.DADETPR\"]").FillAsync("00");

            // Clear required fields
            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("");
            await Page.Locator("input[name=\"A3.KIDS\"]").FillAsync("");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Sibling and children count
            await Expect(Page.Locator("#A3_SIBS-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#A3_KIDS-error")).ToBeVisibleAsync();

            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("0");
            await Page.Locator("input[name=\"A3.KIDS\"]").FillAsync("0");

            // finalize
            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
        }

        [TestMethod]
        public async Task SiblingFieldsRequiredWhenCountGreaterThan0()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A3.MOMYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.MOMDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.MOMETPR\"]").FillAsync("00");

            await Page.Locator("input[name=\"A3.DADYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.DADDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.DADETPR\"]").FillAsync("00");

            //In case previous data is loaded, change twice to clear previous sib row
            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("0");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.KIDS\"]").FillAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // Sibling required fields:
            // 1. Birth year
            await Expect(Page.Locator("#A3_Siblings_0__YOB-error")).ToBeVisibleAsync();

            await Page.Locator("input[name=\"A3.Siblings[0].YOB\"]").FillAsync("9999");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            // 2. Age of death
            // 3. Primary dx
            //await Expect(Page.Locator("[data-valmsg-for=\"A3.Siblings[0].AGD\"]")).ToBeVisibleAsync();
            //await Expect(Page.Locator("[data-valmsg-for=\"A3.Siblings[0].ETPR\"]")).ToBeVisibleAsync();
            //await Expect(Page.Locator("span").Filter(new() { HasText = "Please provide a value for age at death." })).ToBeVisibleAsync();
            //await Expect(Page.Locator("span").Filter(new() { HasText = "Please provide a value for primary dx." })).ToBeVisibleAsync();
            //await Expect(Page.Locator("#UDSForm")).ToContainTextAsync("Please provide a value for age at death.");
            //await Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "Please provide a value for age at death." }).Locator("span")).ToBeVisibleAsync();
            //await Expect(Page.GetByRole(AriaRole.Cell, new() { Name = "Please provide a value for primary dx." }).Locator("span")).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task AgeAtDeathNotGreaterThanCurrentYearMinusBirthYear()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A3.MOMYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.MOMDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.MOMETPR\"]").FillAsync("00");

            await Page.Locator("input[name=\"A3.DADYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.DADDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.DADETPR\"]").FillAsync("00");

            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.KIDS\"]").FillAsync("0");

            await Page.Locator("input[name=\"A3.Siblings[0].YOB\"]").FillAsync("1950");

            int yob = 1950;
            int current = DateTime.Now.Year;
            int tooBig = current - yob + 5;

            await Page.Locator("input[name=\"A3.Siblings[0].AGD\"]").FillAsync(tooBig.ToString());

            await Page.Locator("input[name=\"A3.Siblings[0].ETPR\"]").FillAsync("00");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.Locator("#UDSForm")).ToContainTextAsync("Age of death cannot be greater than the current year minus the birth year");

            await Page.Locator("input[name=\"A3.Siblings[0].AGD\"]").FillAsync("888");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
        }

        [TestMethod]
        public async Task UnknownYearOfBirthAndKnownAgeAtDeathAllowed()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"A3.MOMYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.MOMDAGE\"]").FillAsync("85");
            await Page.Locator("input[name=\"A3.MOMETPR\"]").FillAsync("00");

            await Page.Locator("input[name=\"A3.DADYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.DADDAGE\"]").FillAsync("85");
            await Page.Locator("input[name=\"A3.DADETPR\"]").FillAsync("00");

            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.KIDS\"]").FillAsync("0");

            await Page.Locator("input[name=\"A3.Siblings[0].YOB\"]").FillAsync("9999");

            await Page.Locator("input[name=\"A3.Siblings[0].AGD\"]").FillAsync("85");

            await Page.Locator("input[name=\"A3.Siblings[0].ETPR\"]").FillAsync("00");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();
        }

        [TestMethod]
        public async Task FollowUpVisitAutofillsDataFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            //Write data to form
            await WriteFormData();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Go back to base url and create another follow-up A3
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            //Check that data loaded into form
            //1a. Mother
            await Expect(Page.Locator("input[name=\"A3.MOMYOB\"]")).ToHaveValueAsync("9999");
            await Expect(Page.Locator("input[name=\"A3.MOMDAGE\"]")).ToHaveValueAsync("888");
            await Expect(Page.Locator("input[name=\"A3.MOMETPR\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.MOMETSEC\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.MOMMEVAL\"]")).ToHaveValueAsync("1");
            await Expect(Page.Locator("input[name=\"A3.MOMAGEO\"]")).ToHaveValueAsync("999");

            //1b.Father
            await Expect(Page.Locator("input[name=\"A3.DADYOB\"]")).ToHaveValueAsync("9999");
            await Expect(Page.Locator("input[name=\"A3.DADDAGE\"]")).ToHaveValueAsync("888");
            await Expect(Page.Locator("input[name=\"A3.DADETPR\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.DADETSEC\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.DADMEVAL\"]")).ToHaveValueAsync("1");
            await Expect(Page.Locator("input[name=\"A3.DADAGEO\"]")).ToHaveValueAsync("999");

            //section 2. SIBS
            await Expect(Page.Locator("input[name=\"A3.SIBS\"]")).ToHaveValueAsync("1");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].YOB\"]")).ToHaveValueAsync("9999");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].AGD\"]")).ToHaveValueAsync("888");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].ETPR\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].ETSEC\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].MEVAL\"]")).ToHaveValueAsync("1");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].AGO\"]")).ToHaveValueAsync("999");

            //section 3. KIDS
            await Expect(Page.Locator("input[name=\"A3.KIDS\"]")).ToHaveValueAsync("1");
            await Expect(Page.Locator("input[name=\"A3.Children[0].YOB\"]")).ToHaveValueAsync("9999");
            await Expect(Page.Locator("input[name=\"A3.Children[0].AGD\"]")).ToHaveValueAsync("888");
            await Expect(Page.Locator("input[name=\"A3.Children[0].ETPR\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.Children[0].ETSEC\"]")).ToHaveValueAsync("01");
            await Expect(Page.Locator("input[name=\"A3.Children[0].MEVAL\"]")).ToHaveValueAsync("1");
            await Expect(Page.Locator("input[name=\"A3.Children[0].AGO\"]")).ToHaveValueAsync("999");
        }

        [TestMethod]
        public async Task FollowUpVisitSavesNewDataAfterAutofillFromPreviousVisit()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New Visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            //Write data to form
            await WriteFormData();

            //Change some inputs after data load
            await Page.Locator("input[name=\"A3.MOMYOB\"]").FillAsync("1992");
            await Page.Locator("input[name=\"A3.DADYOB\"]").FillAsync("1992");
            await Page.Locator("input[name=\"A3.Siblings[0].YOB\"]").FillAsync("1992");
            await Page.Locator("input[name=\"A3.Children[0].YOB\"]").FillAsync("1992");


            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Go back in to A3 and check that modified data is loaded instead of previous visit data
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Expect(Page.Locator("input[name=\"A3.MOMYOB\"]")).ToHaveValueAsync("1992");
            await Expect(Page.Locator("input[name=\"A3.DADYOB\"]")).ToHaveValueAsync("1992");
            await Expect(Page.Locator("input[name=\"A3.Siblings[0].YOB\"]")).ToHaveValueAsync("1992");
            await Expect(Page.Locator("input[name=\"A3.Children[0].YOB\"]")).ToHaveValueAsync("1992");

        }

        private async Task WriteFormData()
        {
            //Setup field values for next visit
            //1a. Mother
            await Page.Locator("input[name=\"A3.MOMYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.MOMDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.MOMETPR\"]").FillAsync("01");
            //DEVNOTE: Using tab key presses to unfocus input and trigger JS field enables
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.MOMETSEC\"]").FillAsync("01");
            await Page.Locator("input[name=\"A3.MOMMEVAL\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.MOMAGEO\"]").FillAsync("999");

            //1b.Father
            await Page.Locator("input[name=\"A3.DADYOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.DADDAGE\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.DADETPR\"]").FillAsync("01");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.DADETSEC\"]").FillAsync("01");
            await Page.Locator("input[name=\"A3.DADMEVAL\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.DADAGEO\"]").FillAsync("999");

            //section 2. SIBS
            await Page.Locator("input[name=\"A3.SIBS\"]").FillAsync("1");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.Siblings[0].YOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.Siblings[0].AGD\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.Siblings[0].ETPR\"]").FillAsync("01");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.Siblings[0].ETSEC\"]").FillAsync("01");
            await Page.Locator("input[name=\"A3.Siblings[0].MEVAL\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.Siblings[0].AGO\"]").FillAsync("999");

            //section 3. KIDS
            await Page.Locator("input[name=\"A3.KIDS\"]").FillAsync("1");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.Children[0].YOB\"]").FillAsync("9999");
            await Page.Locator("input[name=\"A3.Children[0].AGD\"]").FillAsync("888");
            await Page.Locator("input[name=\"A3.Children[0].ETPR\"]").FillAsync("01");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A3.Children[0].ETSEC\"]").FillAsync("01");
            await Page.Locator("input[name=\"A3.Children[0].MEVAL\"]").FillAsync("1");
            await Page.Locator("input[name=\"A3.Children[0].AGO\"]").FillAsync("999");
        }
    }
}

