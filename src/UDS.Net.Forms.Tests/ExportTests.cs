using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class ExportTests : TestBase
    {
        //frmdate positions in export file
        static int[] formDateIndexes = [6, 121, 182, 201, 434, 481, 607, 780, 800, 861, 877, 910, 934, 951, 995, 1074, 1204, 1313];

        //Forms 
        static string[] formKinds = ["a1", "a1a", "a2", "a3", "a4", "a4a", "a5d2", "b1", "b3", "b4", "b5", "b6", "b7", "b8", "b9", "c2c2t", "d1a", "d1b"];

        //base form header properties
        static string[] headerColumns = ["frmdate", "initials", "lang", "mode"];

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
        public async Task BasePropDataIsCorrectlyWrittenToColumns()
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

        [TestMethod]
        public async Task HeadersForBasePropsAreCorrectlyLabeled()
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

            var row = firstLine?.Split(',');

            //Check base packet property headers
            Assert.AreEqual("ptid", row?[0]);
            Assert.AreEqual("adcid", row?[1]);
            Assert.AreEqual("visitnum", row?[2]);
            Assert.AreEqual("packet", row?[3]);
            Assert.AreEqual("formver", row?[4]);
            Assert.AreEqual("visitdate", row?[5]);

            //Check that base property headers are the correct strings for each form in the correct columns
            var formKindIndex = 0;
            foreach (var index in formDateIndexes)
            {
                Assert.AreEqual($"{headerColumns[0]}{formKinds[formKindIndex]}", row?[index]);
                Assert.AreEqual($"{headerColumns[1]}{formKinds[formKindIndex]}", row?[index + 1]);
                Assert.AreEqual($"{headerColumns[2]}{formKinds[formKindIndex]}", row?[index + 2]);

                //D1a and D1b records do not contain mode properties
                if (index != 1204 && index != 1313)
                {
                    Assert.AreEqual($"{headerColumns[3]}{formKinds[formKindIndex]}", row?[index + 3]);
                }

                formKindIndex++;
            }
        }
    }
}