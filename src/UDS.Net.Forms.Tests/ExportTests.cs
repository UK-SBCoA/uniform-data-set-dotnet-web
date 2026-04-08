using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class ExportTests : TestBase
    {
        [TestMethod]
        public async Task ExportPacketHas1413Colums()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Link, new() { Name = "Packets Index" }).ClickAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "View" }).ClickAsync();

            var download = await Page.RunAndWaitForDownloadAsync(async () =>
            {
                await Page.GetByRole(AriaRole.Link, new() { Name = "UDS_1000_" }).ClickAsync();
            });

            using var stream = await download.CreateReadStreamAsync();
            using var reader = new StreamReader(stream);

            var firstLine = await reader.ReadLineAsync();
            var columns = firstLine?.Split(',');

            Assert.AreEqual(1413, columns?.Length);
        }
    }
}