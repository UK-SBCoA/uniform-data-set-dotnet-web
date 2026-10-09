using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class FVPExportTests : TestBase
    {
        //TODO: is it worth running fixtures or setting a download file class property that can be set if needed? Or just redownload in every test.
        //Apparently the internet suggest against reusing the download. Instead, I could use a fixture, but that just runs it before every test run

        [TestMethod]
        public async Task FVPExportFileHas1413Colums()
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
        public async Task ValidateDataForA1Export()
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

            var headerRow = await reader.ReadLineAsync();
            List<string> headerData = headerRow?.Split(',').ToList();

            //ReadToEndAsync to close stream after completion
            var packetRow = await reader.ReadToEndAsync();
            List<string> packetData = packetRow?.Split(',').ToList();

            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "BIRTHMO", "3"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "BIRTHYR", "1950"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "CHLDHDCTRY", "USA"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "RACEASIAN", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "ETHCHINESE", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "GENNOANS", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "BIRTHSEX", "8"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INTERSEX", "8"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "SEXORNNOAN", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "PREDOMLAN", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "HANDED", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EDUC", "99"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "LVLEDUC", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "MARISTAT", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "LIVSITUA", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "RESIDENC", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "SERVED", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EXRTIME", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "MEMWORS", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "MEMTROUB", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "MEMTEN", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "SOURCENW", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "REFERSC", "2"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "REFLEARNED", "2"));
        }

        [TestMethod]
        public async Task ValidateDataForA1aExport()
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

            var headerRow = await reader.ReadLineAsync();
            List<string> headerData = headerRow?.Split(',').ToList();

            //ReadToEndAsync to close stream after completion
            var packetRow = await reader.ReadToEndAsync();
            List<string> packetData = packetRow?.Split(',').ToList();

            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "OWNSCAR", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "TRSPACCESS", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "TRANSPROB", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "TRANSWORRY", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "TRSPMED", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INCOMEYR", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "FINSATIS", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "BILLPAY", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "FINUPSET", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EATLESS", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EATLESSYR", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "LESSMEDS", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "LESSMEDSYR", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "COMPCOMM", "10"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "GUARDEDU", "9"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EMPTINESS", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "MISSPEOPLE", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "FRIENDS", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "ABANDONED", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "CLOSEFRND", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "PARENTCOMM", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "CHILDCOMM", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "FRIENDCOMM", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "PARTICIPATE", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "SAFEHOME", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "SAFECOMM", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "DELAYMED", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "SCRIPTPROB", "2"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "MISSEDFUP", "3"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "DOCADVICE", "4"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "HEALTHACC", "3"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "LESSCOURT", "2"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "POORSERV", "3"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "NOTSMART", "3"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "ACTAFRAID", "2"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "THREATENED", "4"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "POORMEDTRT", "3"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EXPSKIN", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "EXPSTRS", "1"));
        }

        [TestMethod]
        public async Task ValidateDataForA2Export()
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

            var headerRow = await reader.ReadLineAsync();
            List<string> headerData = headerRow?.Split(',').ToList();

            //ReadToEndAsync to close stream after completion
            var packetRow = await reader.ReadToEndAsync();
            List<string> packetData = packetRow?.Split(',').ToList();

            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INRELTO", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INKNOWN", "999"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INLIVWTH", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INCNTMOD", "5"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INCNTFRQ", "1"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INCNTTIM", "2"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INRELY", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INMEMWORS", "0"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INMEMTROUB", "2"));
            Assert.IsTrue(await ValidateDataColumn(headerData, packetData, "INMEMTEN", "1"));
        }

        private async Task<bool> ValidateDataColumn(List<string> headerData, List<string> packetData, string columnHeader, string expectedValue)
        {
            int headerIndex = headerData.IndexOf(columnHeader.ToLower());
            string packetDataCell = packetData[headerIndex];

            if (packetDataCell == expectedValue)
            {
                return true;
            }

            return false;
        }
    }
}