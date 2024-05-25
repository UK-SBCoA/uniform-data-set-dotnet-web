using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UDS.Net.Web.MVC.Services.Test;

[TestClass]
public class HomepageTests : PageTest
{
    [TestMethod]
    public async Task HomepageHasNavigationToParticipations()
    {
        await Page.GotoAsync("/");

        //var participation = Page.GetByRole(AriaRole.Link, new() { Name = "Participation" });

        //await Expect(participation).ToHaveAttributeAsync("href", "/Participations");

        //var createButton = Page.GetByRole(AriaRole.Link, new() { Name = "New participation" });

        //await Expect(createButton).ToHaveAttributeAsync("href", "/Participations/Create");

        //await participation.ClickAsync();
    }
}

