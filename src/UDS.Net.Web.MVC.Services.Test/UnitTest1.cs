using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UDS.Net.Web.MVC.Services.Test;

[TestClass]
public class ParticipationTests : PageTest
{
    [TestMethod]
    public async Task ParticipationHasCreateButton()
    {
        await Page.GotoAsync("https://localhost:4811/Participations");

        //var createButton = Page.GetByRole(AriaRole.Link, new() { Name = "New participation" });

        //await Expect(createButton).ToHaveAttributeAsync("href", "/Create");

        //createButton.ClickAsync();
        //await page.GetByLabel("NACC IdParticipation.LegacyId").ClickAsync();
        //await page.GetByLabel("NACC IdParticipation.LegacyId").FillAsync("2000");
        //await page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
        //await page.GetByLabel("NACC IdParticipation.LegacyId").ClickAsync();
        //await page.GetByLabel("NACC IdParticipation.LegacyId").FillAsync("2001");
        //await page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
        //await page.GetByLabel("NACC IdParticipation.LegacyId").ClickAsync();
        //await page.GetByLabel("NACC IdParticipation.LegacyId").FillAsync("5000");
        //await page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
    }
}
