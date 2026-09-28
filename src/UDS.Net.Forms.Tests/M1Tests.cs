using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class M1Tests : TestBase
    {
        [TestMethod]
        public async Task MILESTONETYPE1()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();
            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            // Box A
            await Expect(Page.Locator("input[name='CHANGEMO']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='CHANGEDY']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='CHANGEYR']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='PROTOCOL'][value='1']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='PROTOCOL'][value='2']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='ACONSENT'][value='0']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='ACONSENT'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='PROTOCOL'][value='3']")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("RECOGIM")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("REPHYILL")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("REREFUSE")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("RENAVAIL")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("RENURSE")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='NURSEMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='NURSEDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='NURSEYR']")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("REJOIN")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("FTLDDISC")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='1']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='2']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='3']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='4']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAX']")).ToBeDisabledAsync();

            // Box B
            await Expect(Page.GetByLabel("DECEASED")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("DISCONT")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DEATHMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DEATHDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DEATHYR']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='AUTOPSY'][value='0']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='AUTOPSY'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DISCMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DISCDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DISCYR']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DROPREAS'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DROPREAS'][value='2']")).ToBeDisabledAsync();
        }

        [TestMethod]
        public async Task MILESTONETYPE0()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();
            await Page.Locator("input[name='MILESTONETYPE'][value='0']").CheckAsync();

            // Box A
            await Expect(Page.Locator("input[name='CHANGEMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='CHANGEDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='CHANGEYR']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='PROTOCOL'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='PROTOCOL'][value='2']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='ACONSENT'][value='0']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='ACONSENT'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='PROTOCOL'][value='3']")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("RECOGIM")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("REPHYILL")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("REREFUSE")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("RENAVAIL")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("RENURSE")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='NURSEMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='NURSEDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='NURSEYR']")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("REJOIN")).ToBeDisabledAsync();
            await Expect(Page.GetByLabel("FTLDDISC")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='2']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='3']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='4']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='FTLDREAX']")).ToBeDisabledAsync();

            // Box B
            await Expect(Page.GetByLabel("DECEASED")).ToBeEnabledAsync();
            await Expect(Page.GetByLabel("DISCONT")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DEATHMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DEATHDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DEATHYR']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='AUTOPSY'][value='0']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='AUTOPSY'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DISCMO']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DISCDY']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DISCYR']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DROPREAS'][value='1']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='DROPREAS'][value='2']")).ToBeDisabledAsync();
        }

        [TestMethod]
        public async Task Test_ACONSENT_Behavior()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            // Autopsy consent is only enabled when protocol 3 is selected.
            await Expect(Page.Locator("input[name='ACONSENT'][value='0']")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name='ACONSENT'][value='1']")).ToBeDisabledAsync();

            await Page.Locator("input[name='PROTOCOL'][value='3']").CheckAsync();

            await Expect(Page.Locator("input[name='ACONSENT'][value='0']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='ACONSENT'][value='1']")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task Test_RENURSE_Behavior()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();
            var nurse = Page.Locator("#RENURSE");
            await Expect(nurse).ToBeEnabledAsync();
            await nurse.CheckAsync();
            await Expect(nurse).ToBeCheckedAsync();
            await Expect(Page.Locator("#NURSEMO")).ToBeEnabledAsync();
            await Expect(Page.Locator("#NURSEDY")).ToBeEnabledAsync();
            await Expect(Page.Locator("#NURSEYR")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task Test_FTLDREAS_Behavior()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();
            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();
            await Page.Locator("input[name='FTLDREAS'][value='4']").CheckAsync();
            await Expect(Page.Locator("input[name='FTLDREAS'][value='4']")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name='FTLDREAX']")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task Test_DECEASED_Behavior()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();
            await Page.Locator("input[name='MILESTONETYPE'][value='0']").CheckAsync();
            await Page.Locator("input#DECEASED[type='checkbox']").CheckAsync();
            await Expect(Page.Locator("input#DECEASED[type='checkbox']")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name='DEATHMO']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DEATHDY']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DEATHYR']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='AUTOPSY'][value='0']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='AUTOPSY'][value='1']")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task Test_DISCONT_Behavior()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='0']").CheckAsync();
            await Page.Locator("input#DISCONT[type='checkbox']").CheckAsync();
            await Expect(Page.Locator("input#DISCONT[type='checkbox']")).ToBeCheckedAsync();
            await Expect(Page.Locator("input[name='DISCMO']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DISCDY']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DISCYR']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DROPREAS'][value='1']")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[name='DROPREAS'][value='2']")).ToBeEnabledAsync();
        }

        [TestMethod]
        public async Task MILESTONETYPE1_Requires_Status_Change_Date_And_Protocol()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='CHANGEMO']")).ToContainTextAsync("Must have a value for month");

            await Expect(Page.Locator("[data-valmsg-for='CHANGEDY']")).ToContainTextAsync("Must have a value for day");

            await Expect(Page.Locator("[data-valmsg-for='CHANGEYR']")).ToContainTextAsync("Must have a value for year");

            await Expect(Page.Locator("[data-valmsg-for='PROTOCOL']")).ToContainTextAsync("Must have a value when indicating continued contact");

            await Expect(Page.Locator("[data-valmsg-for='ProtocolReasonValidation']")).ToContainTextAsync("Must select AT LEAST ONE reason for change as indicated in 2a");
        }

        [TestMethod]
        public async Task MILESTONETYPE0_Requires_Deceased_Or_Discontinued()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='0']").CheckAsync();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='DECEASED']")).ToContainTextAsync("When indicating no further contact, Deceased OR Discontinued must be select");

            await Expect(Page.Locator("[data-valmsg-for='DISCONT']")).ToContainTextAsync("When indicating no further contact, Deceased OR Discontinued must be select");
        }

        [TestMethod]
        public async Task RENURSE_Requires_Nurse_Date()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            await Page.Locator("#RENURSE").CheckAsync();

            await Expect(Page.Locator("#RENURSE")).ToBeCheckedAsync();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='NURSEMO']")).ToContainTextAsync("Must have a value for month");

            await Expect(Page.Locator("[data-valmsg-for='NURSEDY']")).ToContainTextAsync("Must have a value for day");

            await Expect(Page.Locator("[data-valmsg-for='NURSEYR']")).ToContainTextAsync("Must have a value for year");
        }

        [TestMethod]
        public async Task PROTOCOL3_Requires_Autopsy_Consent()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            await Page.Locator("input[name='PROTOCOL'][value='3']").CheckAsync();

            await Expect(Page.Locator("input[name='PROTOCOL'][value='3']")).ToBeCheckedAsync();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='ACONSENT']")).ToContainTextAsync("Autopsy status required");
        }

        [TestMethod]
        public async Task FTLDREASOther_Requires_Reason()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            await Page.Locator("input[name='FTLDREAS'][value='4']").CheckAsync();

            await Expect(Page.Locator("input[name='FTLDREAS'][value='4']")).ToBeCheckedAsync();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='FTLDREAX']")).ToContainTextAsync("Must have a value when indicating reason of other");
        }

        [TestMethod]
        public async Task MILESTONETYPE1_Rejects_Invalid_Change_Year()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            await Page.Locator("#CHANGEYR").FillAsync("2014");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='CHANGEYR']")).ToContainTextAsync("Provide a valid year between 2015 - 2999");
        }

        [TestMethod]
        public async Task RENURSE_Rejects_Invalid_Nurse_Year()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='1']").CheckAsync();

            await Page.Locator("#RENURSE").CheckAsync();

            await Expect(Page.Locator("#RENURSE")).ToBeCheckedAsync();

            await Page.Locator("#NURSEYR").FillAsync("2000");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='NURSEYR']")).ToContainTextAsync("Provide a valid year between 2015 - 2999");
        }

        [TestMethod]
        public async Task DECEASED_Rejects_Invalid_Death_Year()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='0']").CheckAsync();

            await Page.Locator("#DECEASED[type='checkbox']").CheckAsync();

            await Expect(Page.Locator("#DECEASED[type='checkbox']")).ToBeCheckedAsync();

            await Page.Locator("#DEATHYR").FillAsync("2000");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='DEATHYR']")).ToContainTextAsync("Provide a valid year between 2005 and current year");
        }

        [TestMethod]
        public async Task DISCONT_Rejects_Invalid_Discontinue_Year()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Milestones", Exact = true }).ClickAsync();

            await Page.Locator("input[name='MILESTONETYPE'][value='0']").CheckAsync();

            await Page.Locator("#DISCONT[type='checkbox']").CheckAsync();

            await Expect(Page.Locator("#DISCONT[type='checkbox']")).ToBeCheckedAsync();

            await Page.Locator("#DISCYR").FillAsync("2000");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true }).ClickAsync();

            await Expect(Page.Locator("[data-valmsg-for='DISCYR']")).ToContainTextAsync("Provide a valid year between 2015 - 2999");
        }
    }
}