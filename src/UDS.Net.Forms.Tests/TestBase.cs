using System.Diagnostics;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestBase
{
    protected IPage Page;
    protected IBrowserContext Context;
    protected static string BaseUrl = "https://localhost:7109";

    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static async Task GlobalSetup(TestContext context) =>
        await PlaywrightDriver.StartAsync();

    [TestInitialize]
    public async Task SetUp()
    {
        Context = await PlaywrightDriver.Browser.NewContextAsync();
        Page = await Context.NewPageAsync();
    }

    [TestCleanup]
    public async Task TearDown() => await Context?.CloseAsync();

    [ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
    public static async Task GlobalTeardown() =>
        await PlaywrightDriver.StopAsync();

}