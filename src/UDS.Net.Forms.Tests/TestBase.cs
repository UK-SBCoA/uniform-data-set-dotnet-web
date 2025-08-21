using System.Diagnostics;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestBase : PageTest
{
    //protected new IPage? Page;
    //protected new IBrowserContext? Context;
    protected static string BaseUrl = "http://localhost:7110";

    //[ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    //public static async Task GlobalSetup(TestContext context) =>
    //    await PlaywrightDriver.StartAsync();

    //[TestInitialize]
    //public async Task SetUp()
    //{
    //    Context = await PlaywrightDriver.Browser.NewContextAsync();
    //    Page = await Context.NewPageAsync();
    //}

    //[TestCleanup]
    //public async Task TearDown()
    //{
    //    await Context?.CloseAsync();
    //}

    //[ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
    //public static async Task GlobalTeardown() =>
    //    await PlaywrightDriver.StopAsync();

}