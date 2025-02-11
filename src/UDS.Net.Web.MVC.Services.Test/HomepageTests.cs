using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UDS.Net.Web.MVC.Services.Test;

[TestClass]
public class HomepageTests : PageTest
{
    protected string _emailAddress = "";
    protected string _password = "";

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            StorageStatePath = "../../../.auth/state.json"
        };
    }

    // Test initialize runs before each TestMethod
    [TestInitialize]
    public async Task TestInitialize()
    {
        if (string.IsNullOrWhiteSpace(_emailAddress) || string.IsNullOrWhiteSpace(_password))
        {
            await Page.GotoAsync("https://localhost:4811/Identity/Account/Register");

            Random random = new Random();
            int _salt = random.Next(1, 1000);

            _emailAddress = $"test{_salt}@test.com";
            _password = $"Password_{_salt}";

            await Page.GetByLabel("Email").ClickAsync();
            await Page.GetByLabel("Email").FillAsync(_emailAddress);

            // Click ensures that the element is visible
            await Page.GetByLabel("Password", new() { Exact = true }).ClickAsync();
            await Page.GetByLabel("Password", new() { Exact = true }).FillAsync(_password);

            await Page.GetByLabel("Confirm Password").ClickAsync();
            await Page.GetByLabel("Confirm Password").FillAsync(_password);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Register" }).ClickAsync();
            await Page.WaitForRequestFinishedAsync();

            await Page.GetByRole(AriaRole.Link, new() { Name = "Click here to confirm your" }).ClickAsync();
            await Page.WaitForRequestFinishedAsync();

        }

        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Page.GetByPlaceholder("name@example.com").ClickAsync();
        await Page.GetByPlaceholder("name@example.com").FillAsync(_emailAddress);
        await Page.GetByPlaceholder("name@example.com").PressAsync("Tab");
        await Page.GetByPlaceholder("password").FillAsync(_password);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

        await Context.StorageStateAsync(new()
        {
            Path = "../../../.auth/state.json"
        });
    }

    [TestMethod]
    public async Task HomepageHasNavigationToParticipations()
    {
        await Page.Locator("#desktop-menu").GetByRole(AriaRole.Link, new() { Name = "Participation" }).ClickAsync();
    }

    [TestMethod]
    public async Task EasyPathToFinalize()
    {
        // TODO replace selectors with input locators

        await Page.Locator("#desktop-menu").GetByRole(AriaRole.Link, new() { Name = "Participation" }).ClickAsync();

        await Page.Locator("table tbody tr td:nth-child(4) a").ClickAsync();

        // Visits index page
        // Create new visit
        await Page.GetByRole(AriaRole.Link, new() { Name = "New visit" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

        //await Page.Locator("table tbody tr td:nth-child(8) a").ClickAsync();

        await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A1 Required Participant" }).GetByRole(AriaRole.Link).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Month A1.BIRTHMO" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Month A1.BIRTHMO" }).FillAsync("1");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Month A1.BIRTHMO" }).PressAsync("Tab");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Year A1.BIRTHYR" }).FillAsync("1950");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Year A1.BIRTHYR" }).PressAsync("Tab");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "In which country or region" }).FillAsync("USA");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "In which country or region" }).PressAsync("Tab");
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Black or African American A1." }).CheckAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "White A1.RACEWHITE" }).CheckAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Man A1.GENMAN" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Male" }).CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "0 No 1 Yes 9 Don't know 8" }).GetByLabel("0 No").CheckAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Straight/heterosexual A1." }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "English" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Right-handed" }).CheckAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "How many years of education" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "How many years of education" }).FillAsync("18");
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Bachelor's degree" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Married" }).CheckAsync();
        await Page.Locator("div:nth-child(15) > div > .mt-4 > div:nth-child(2) > .flex").ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Single- or multi-family" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (IF NO, SKIP TO QUESTION 17)" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 hour or less" }).CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "0 No 1 Yes, but this does not" }).GetByLabel("0 No").CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Rarely" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "The same" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Participant is supported" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Self" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "ADRC sponsored event" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();


        await Page.Locator("input[name=\"A1a\\.OWNSCAR\"]").Nth(1).CheckAsync();
        await Page.Locator("input[name=\"A1a\\.TRSPACCESS\"]").Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Never" }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Never" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Never" }).Nth(2).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Never" }).Nth(3).CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "1 $0 - $14,999 2 $15,000 - $" }).GetByLabel("Prefer not to answer").CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "1 Completely satisfied 2" }).GetByLabel("Prefer not to answer").CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "1 Not at all 2 Slightly 3" }).GetByLabel("Prefer not to answer").CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "1 No financial problems for" }).GetByLabel("Prefer not to answer").CheckAsync();
        await Page.Locator("input[name=\"A1a\\.EATLESS\"]").Nth(2).CheckAsync();
        await Page.Locator("input[name=\"A1a\\.EATLESSYR\"]").Nth(2).CheckAsync();
        await Page.Locator("input[name=\"A1a\\.LESSMEDS\"]").Nth(2).CheckAsync();
        await Page.Locator("input[name=\"A1a\\.LESSMEDSYR\"]").Nth(2).CheckAsync();
        await Page.GetByRole(AriaRole.Rowgroup).Filter(new() { HasText = "Where would you place yourself on this ladder compared to others in your" }).GetByLabel("9").CheckAsync();
        await Page.GetByRole(AriaRole.Rowgroup).Filter(new() { HasText = "Where would you place yourself on this ladder compared to others in the U.S.?" }).GetByLabel("8").CheckAsync();
        await Page.Locator("div:nth-child(3) > .table-auto > tbody > tr:nth-child(2) > td:nth-child(2) > .relative > .flex").ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Grades 9 through 11 (some" }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Parent (biological," }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Grades 9 through 11 (some" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Parent (biological," }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "2 Disagree" }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "4 Agree" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "2 Disagree" }).Nth(2).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Strongly disagree" }).Nth(3).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Neither disagree or agree" }).Nth(4).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Parents not living" }).CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "0 Do not have children 1 Once" }).GetByLabel("Several times a month").CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "0 Do not have close friends 1" }).GetByLabel("Several times a week").CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "0 Do not participate in" }).GetByLabel("Several times a week").CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Mostly safe" }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Mostly safe" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "None or almost none of the time" }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "3 Sometimes" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "None or almost none of the time" }).Nth(2).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Most of the time" }).Nth(3).CheckAsync();
        await Page.Locator("div:nth-child(12) > div:nth-child(5) > div > .max-w-lg > .mt-4 > div:nth-child(3) > .flex").ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "At least once a week" }).First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "A few times a year" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "6 Never" }).Nth(2).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "6 Never" }).Nth(3).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "6 Never" }).Nth(4).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Not applicable" }).Nth(4).CheckAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Prefer not to answer A1a." }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Not stressful" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();

        // A2
        await Page.Locator("input[name=\"A2\\.INRELTO\"]").Nth(1).CheckAsync();
        //await Page.Locator("#A2_INRELTO[0]").CheckAsync();
        await Page.Locator("#A2_INKNOWN").ClickAsync();
        await Page.Locator("#A2_INKNOWN").FillAsync("999");

        await Page.Locator("[id=\"A2_INLIVWTHOptions\\[0\\]\"]").CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Telephone" }).CheckAsync();
        await Page.Locator(".subcounterreset > div > div > .mt-4 > div:nth-child(3) > .flex").First.ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "15-30 minutes" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "0 No" }).Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Group).Filter(new() { HasText = "0 No 1 Yes, but this does not" }).GetByLabel("0 No").CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Rarely" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "The same" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Row, new() { Name = "Mother MOMDAGE MOMETPR" }).GetByPlaceholder("YYYY").ClickAsync();
        await Page.GetByRole(AriaRole.Row, new() { Name = "Mother MOMDAGE MOMETPR" }).GetByPlaceholder("YYYY").FillAsync("9999");
        await Page.GetByRole(AriaRole.Row, new() { Name = "Mother MOMDAGE MOMETPR" }).GetByPlaceholder("YYYY").PressAsync("Tab");
        await Page.Locator("#A3_MOMDAGE").FillAsync("999");
        await Page.Locator("#A3_MOMDAGE").PressAsync("Tab");
        await Page.Locator("#A3_MOMETPR").FillAsync("00");
        await Page.Locator("#A3_MOMETPR").PressAsync("Tab");
        await Page.Locator("body").PressAsync("Tab");
        await Page.GetByRole(AriaRole.Row, new() { Name = "Father" }).GetByPlaceholder("YYYY").FillAsync("9999");
        await Page.GetByRole(AriaRole.Row, new() { Name = "Father" }).GetByPlaceholder("YYYY").PressAsync("Tab");
        await Page.Locator("#A3_DADDAGE").FillAsync("999");
        await Page.Locator("#A3_DADDAGE").PressAsync("Tab");
        await Page.Locator("#A3_DADETPR").FillAsync("00");
        await Page.Locator("#A3_DADETPR").PressAsync("Tab");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "How many full siblings does" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "How many full siblings does" }).FillAsync("0");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "How many known biological" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "How many known biological" }).FillAsync("0");
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (end form here)" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (end form here)" }).First.CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator("input[name=\"A5D2\\.TOBAC100\"]").First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Never" }).First.CheckAsync();
        await Page.Locator("input[name=\"A5D2\\.SUBSTYEAR\"]").First.CheckAsync();
        await Page.Locator("input[name=\"A5D2\\.SUBSTPAST\"]").First.CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Never" }).Nth(2).CheckAsync();
        await Page.Locator("td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(3) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(5) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(6) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(7) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(9) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(11) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(12) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(14) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator(".subsubcounterreset > tr > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tbody:nth-child(4) > tr:nth-child(2) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(7) > div > .subcounterreset > .table-fixed > tbody > tr > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("div:nth-child(7) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(3) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(7) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(5) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(8) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("div:nth-child(7) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(9) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(10) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "Repetitive head impacts (e.g" }).Locator("label").Nth(1).ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "Head injury (e.g. in a" }).Locator("label").Nth(1).ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(5) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(7) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(9) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(10) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(11) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(10) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(14) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(15) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(16) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(19) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(20) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(21) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(23) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(28) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(30) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(31) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(33) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(35) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(37) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(39) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(2) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(3) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(5) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(6) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(7) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(13) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(14) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("div:nth-child(13) > div > .subcounterreset > .table-fixed > tbody > tr:nth-child(15) > td:nth-child(2) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Participant height (inches)" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Participant height (inches)" }).FillAsync("88.8");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Participant weight (lbs) B1." }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Participant weight (lbs) B1." }).FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Waist circumference measurements (inches): Measurement 1 B1.WAIST1" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Waist circumference measurements (inches): Measurement 1 B1.WAIST1" }).FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Waist circumference measurements (inches): Measurement 2 B1.WAIST2" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Waist circumference measurements (inches): Measurement 2 B1.WAIST2" }).FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Hip circumference measurements (inches): Measurement 1 B1.HIP1" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Hip circumference measurements (inches): Measurement 1 B1.HIP1" }).FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Hip circumference measurements (inches): Measurement 2 B1.HIP2" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Hip circumference measurements (inches): Measurement 2 B1.HIP2" }).FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 1 B1.BPSYSL1" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 1 B1.BPSYSL1" }).FillAsync("888");
        await Page.Locator("input[name=\"B1\\.BPDIASL1\"]").ClickAsync();
        await Page.Locator("input[name=\"B1\\.BPDIASL1\"]").FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 2 B1.BPSYSL2" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 2 B1.BPSYSL2" }).FillAsync("888");
        await Page.Locator("input[name=\"B1\\.BPDIASL2\"]").ClickAsync();
        await Page.Locator("input[name=\"B1\\.BPDIASL2\"]").FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 1 B1.BPSYSR1" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 1 B1.BPSYSR1" }).FillAsync("888");
        await Page.Locator("input[name=\"B1\\.BPDIASR1\"]").ClickAsync();
        await Page.Locator("input[name=\"B1\\.BPDIASR1\"]").FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 2 B1.BPSYSR2" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Reading 2 B1.BPSYSR2" }).FillAsync("888");
        await Page.Locator("input[name=\"B1\\.BPDIASR2\"]").ClickAsync();
        await Page.Locator("input[name=\"B1\\.BPDIASR2\"]").FillAsync("888");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Participant resting heart" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Participant resting heart" }).FillAsync("888");
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator("#pdNormalCheckbox").CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator(".ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(4) > td > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(6) > td > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(8) > td > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(10) > td > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.GetByRole(AriaRole.Row, new() { Name = "0 1 2" }).Locator("span").First.ClickAsync();
        await Page.GetByText("0 None").ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "CDR sum of boxes B4.CDRSUM" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "CDR sum of boxes B4.CDRSUM" }).FillAsync("0");
        await Page.Locator("table:nth-child(7) > .subcounterreset > tr:nth-child(2) > td > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("table:nth-child(7) > .subcounterreset > tr:nth-child(4) > td > .relative > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Spouse" }).CheckAsync();
        await Page.Locator("td:nth-child(4) > .relative > .flex > .ml-3").First.ClickAsync();
        await Page.Locator("tr:nth-child(2) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(3) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(4) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(5) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(6) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(7) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(8) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(9) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(10) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(11) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(12) > td:nth-child(4) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Check this box and enter “88" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator(".ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("td:nth-child(3) > .relative > .flex").First.ClickAsync();
        await Page.Locator("tr:nth-child(3) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(2) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(4) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(5) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(7) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(6) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(8) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(9) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.Locator("tr:nth-child(10) > td:nth-child(3) > .relative > .flex > .ml-3 > .inline-flex").ClickAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "0 No neurologic examination (" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator("input[name=\"B9\\.DECCOG\"]").First.CheckAsync();
        await Page.Locator("div:nth-child(3) > div > .mt-4 > div > .flex > .ml-3").First.ClickAsync();
        await Page.Locator("div:nth-child(4) > div > .mt-4 > div > .flex > .ml-3 > .inline-flex").First.ClickAsync();
        await Page.Locator("div:nth-child(6) > div > .mt-4 > div > .flex > .ml-3").First.ClickAsync();
        await Page.Locator("div:nth-child(7) > div > .mt-4 > div > .flex > .ml-3").First.ClickAsync();
        await Page.Locator("div:nth-child(8) > div > .mt-4 > div > .flex > .ml-3").First.ClickAsync();
        await Page.Locator("label").Filter(new() { HasText = "No (END FORM HERE)" }).Locator("span").ClickAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator("#modalityselect").SelectOptionAsync(new[] { "1" });
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (skip to question 2a)" }).CheckAsync();
        await Page.GetByText("In ADC/clinic").Nth(1).ClickAsync();
        await Page.GetByText("English").Nth(1).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, verbatim scoring C2.CRAFTVRS" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, verbatim scoring C2.CRAFTVRS" }).FillAsync("20");
        await Page.Locator("turbo-frame div").Filter(new() { HasText = "Total story units recalled, verbatim scoring C2.CRAFTVRS (If test not completed" }).Nth(3).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, paraphrase scoring C2.CRAFTURS" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, paraphrase scoring C2.CRAFTURS" }).FillAsync("2");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total Score for copy of" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total Score for copy of" }).FillAsync("2");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct trials C2.DIGFORCT" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct trials C2.DIGFORCT" }).FillAsync("2");
        await Page.GetByText("Longest span forwardC2.DIGFORSL (0, 3-9)").ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Longest span forward C2." }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Longest span forward C2." }).FillAsync("2");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct trials C2.DIGBACCT" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct trials C2.DIGBACCT" }).FillAsync("2");
        await Page.GetByText("(If test not completed, enter reason code, 95–98, and SKIP TO QUESTION 7a.)").ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Longest span backward C2." }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Longest span backward C2." }).FillAsync("2");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Animals: Total number of" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Animals: Total number of" }).FillAsync("2");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Vegetables: Total number of" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Vegetables: Total number of" }).FillAsync("2");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Part A: Total number of" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Part A: Total number of" }).FillAsync("995");
        await Page.Locator("turbo-frame div").Filter(new() { HasText = "Part A: Total number of" }).Nth(3).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Part B: Total number of" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Part B: Total number of" }).FillAsync("995");
        await Page.Locator("#UDSForm div").Filter(new() { HasText = "Part B: Total number of" }).Nth(3).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total score for drawing of" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total score for drawing of" }).FillAsync("10");
        await Page.GetByText("(If test not completed, enter reason code, 95–98, and SKIP TO QUESTION 10a.").ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Yes" }).Nth(3).CheckAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, verbatim scoring C2.CRAFTDVR" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, verbatim scoring C2.CRAFTDVR" }).FillAsync("40");
        await Page.GetByText("(If test not completed, enter reason code, 95–98, and SKIP TO QUESTION 11a.)").ClickAsync();
        await Page.Locator("turbo-frame div").Filter(new() { HasText = "Total story units recalled, verbatim scoring C2.CRAFTDVR (If test not completed" }).Nth(3).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, paraphrase scoring C2.CRAFTDRE" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total story units recalled, paraphrase scoring C2.CRAFTDRE" }).FillAsync("5");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Delay time (minutes) C2.CRAFTDTI" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Delay time (minutes) C2.CRAFTDTI" }).FillAsync("99");
        await Page.GetByRole(AriaRole.Radio, new() { Name = "0 No" }).Nth(4).CheckAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct F-words generated in 1 minute C2.UDSVERFC" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct F-words generated in 1 minute C2.UDSVERFC" }).FillAsync("95");
        await Page.GetByText("(If test not completed, enter reason code, 95–98, and SKIP TO QUESTION 11d.)").ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct L-words" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Number of correct L-words" }).FillAsync("95");
        await Page.GetByText("Number of non-F-words and rule violation errors in 1 minuteC2.UDSVERNF (0-15)").ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Rey AVLT (COMPLETE SECTIONS" }).CheckAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "(0-15,95-98) (If test was not" }).GetByLabel("").ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "(0-15,95-98) (If test was not" }).GetByLabel("").FillAsync("97");
        await Page.GetByRole(AriaRole.Cell, new() { Name = "(0-15,95-98) (If test was not" }).Locator("div").First.ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "(0-15,95-98) (If test was not" }).Locator("div").First.ClickAsync();
        await Page.GetByRole(AriaRole.Row, new() { Name = "Trial 2 (0-15) (No limit)" }).Locator("label").First.ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total score C2.MINTTOTS" }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total score C2.MINTTOTS" }).FillAsync("95");
        await Page.Locator("turbo-frame div").Filter(new() { HasText = "(0-32, 95-98)" }).Nth(4).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Better than normal for age" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "1 Very valid, probably" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.Locator("turbo-frame div").Filter(new() { HasText = "Total delayed recall C2." }).Nth(3).ClickAsync();
        await Page.GetByText("C2.REYDREC").ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Longest span forward C2." }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Longest span forward C2." }).FillAsync("0");
        await Page.GetByText("C2.DIGFORSL").ClickAsync();
        await Page.GetByText("If No, enter reason code, 95–98C2.MOCAREAS Provide reason code.").ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "If No, enter reason code, 95–" }).FillAsync("95");
        await Page.GetByText("MoCA was administeredC2.MOCALOC 1 In ADC/clinic 2 In home 3 In person - other").ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "97 (0-15,95-98) (If test was" }).GetByLabel("").ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "97 (0-15,95-98) (If test was" }).GetByLabel("").FillAsync("10");
        await Page.GetByRole(AriaRole.Cell, new() { Name = "97 (0-15,95-98) (If test was" }).GetByLabel("").PressAsync("Tab");
        await Page.Locator("input[name=\"C2\\.REY2REC\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY2REC\"]").FillAsync("6");
        await Page.Locator("input[name=\"C2\\.REY3REC\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY3REC\"]").FillAsync("6");
        await Page.Locator("input[name=\"C2\\.REY4REC\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY4REC\"]").FillAsync("6");
        await Page.Locator("input[name=\"C2\\.REY5REC\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY5REC\"]").FillAsync("6");
        await Page.GetByRole(AriaRole.Cell, new() { Name = "(0-15", Exact = true }).GetByLabel("").ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "(0-15", Exact = true }).GetByLabel("").FillAsync("6");
        await Page.Locator("input[name=\"C2\\.REY1INT\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY1INT\"]").FillAsync("0");
        await Page.Locator("input[name=\"C2\\.REY2INT\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY2INT\"]").FillAsync("0");
        await Page.Locator("input[name=\"C2\\.REY3INT\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY3INT\"]").FillAsync("0");
        await Page.Locator("input[name=\"C2\\.REY4INT\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY4INT\"]").FillAsync("0");
        await Page.Locator("input[name=\"C2\\.REY5INT\"]").ClickAsync();
        await Page.Locator("input[name=\"C2\\.REY5INT\"]").FillAsync("0");
        await Page.Locator("#C2_REYBINT").ClickAsync();
        await Page.Locator("#C2_REYBINT").FillAsync("0");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total delayed recall C2." }).ClickAsync();
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Total delayed recall C2." }).FillAsync("95");
        await Page.GetByRole(AriaRole.Spinbutton, new() { Name = "Intrusions C2.REYDINT" }).ClickAsync();
        await Page.GetByText("IntrusionsC2.REYDINT (No").ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "Provide trial 6 total recall" }).GetByLabel("").ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "Provide trial 6 total recall" }).GetByLabel("").FillAsync("7");
        await Page.GetByRole(AriaRole.Cell, new() { Name = "Provide trial 6 intrusions. (" }).GetByLabel("").ClickAsync();
        await Page.GetByRole(AriaRole.Cell, new() { Name = "Provide trial 6 intrusions. (" }).GetByLabel("").FillAsync("0");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Single clinician" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (SKIP TO QUESTION 3)" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (CONTINUE TO QUESTION 4)" }).CheckAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Largely preserved functional" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (CONTINUE TO QUESTION 5)" }).CheckAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Longstanding cognitive" }).CheckAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (SKIP TO QUESTION 7)" }).CheckAsync();
        await Page.Locator("label").Filter(new() { HasText = "No (SKIP TO QUESTION 8)" }).Locator("span").ClickAsync();
        await Page.GetByText("No (SKIP TO QUESTION 10)").ClickAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Anxiety disorder D1a.ANXIET" }).CheckAsync();
        await Page.GetByRole(AriaRole.Row, new() { Name = "Anxiety disorder D1a.ANXIET 1 2" }).GetByLabel("1").Nth(1).CheckAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Checkbox, new() { Name = "Generalized Anxiety Disorder" }).CheckAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save and go next" }).ClickAsync();
        await Page.GetByRole(AriaRole.Radio, new() { Name = "No (SKIP TO QUESTION 12)" }).CheckAsync();
        await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
        await Page.Locator(".mt-5").ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Ready for submission" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Back" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Visits" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "View" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Finalize packet" }).ClickAsync();
    }
}


