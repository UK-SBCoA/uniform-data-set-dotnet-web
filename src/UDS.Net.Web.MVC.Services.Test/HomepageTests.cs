using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UDS.Net.Web.MVC.Services.Test;

[TestClass]
public class HomepageTests : PageTest
{
    [TestMethod]
    public async Task HomepageRedirectsIfNotAuthenticated()
    {
        await Page.GotoAsync("");

        await Expect(Page).ToHaveURLAsync("");
    }
}

