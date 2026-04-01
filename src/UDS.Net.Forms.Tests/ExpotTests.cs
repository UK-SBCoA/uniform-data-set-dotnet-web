using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class ExpotTests : TestBase
    {
        [TestMethod]
        public async Task ExportSinglePacket()
        {
            //await Page.GotoAsync(BaseUrl);
            //await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            //await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A3");
            //await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("Required");
            //await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            //await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            //await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            //// reopen the page and see the data persisted
            //await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            //await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A3 Required" }).GetByRole(AriaRole.Link).ClickAsync();


        }
    }
}