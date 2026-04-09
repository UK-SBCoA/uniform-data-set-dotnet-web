using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class ExportTests : TestBase
    {
        [TestMethod]
        public async Task ExportFileHas1413Colums()
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

            var header = await reader.ReadLineAsync();
            var columns = header?.Split(',');

            Assert.AreEqual(1413, columns?.Length);
        }

        [TestMethod]
        public async Task BasePropsAreWrittenToExport()
        {
            //frmdate positions in export file
            int[] formDateIndexes = [6, 121, 182, 201, 434, 481, 607, 780, 800, 861, 877, 910, 934, 951, 995, 1074, 1204, 1313];

            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Link, new() { Name = "Packets Index" }).ClickAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "View" }).ClickAsync();

            var download = await Page.RunAndWaitForDownloadAsync(async () =>
            {
                await Page.GetByRole(AriaRole.Link, new() { Name = "UDS_1000_" }).ClickAsync();
            });

            using var stream = await download.CreateReadStreamAsync();
            using var reader = new StreamReader(stream);

            await reader.ReadLineAsync();
            var secondLine = await reader.ReadLineAsync();

            var row = secondLine?.Split(',');

            //Check base packet properties by export file index
            Assert.AreEqual("1000", row?[0]);
            Assert.AreEqual("19", row?[1]);
            Assert.AreEqual("1", row?[2]);
            Assert.AreEqual("I", row?[3]);
            Assert.AreEqual("4", row?[4]);
            Assert.AreEqual(DateTime.Now.ToString("MM-dd-yyyy"), row?[5]);

            //Check base form properties
            foreach (var index in formDateIndexes)
            {
                Assert.AreEqual(DateTime.Now.ToString("MM-dd-yyyy"), row?[index]);
                Assert.AreEqual("TT", row?[index + 1]);
                Assert.AreEqual("1", row?[index + 2]);
                //D1a and D1b records do not contain mode properties
                if (index != 1204 && index != 1313)
                {
                    Assert.AreEqual("1", row?[index + 3]);
                }
            }
        }
    }
}