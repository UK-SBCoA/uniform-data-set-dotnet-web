using System;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class C2MINTTests : TestBase
    {
        [TestMethod]
        public async Task C2SavesInProgressWithNoValidation()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("C2");
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("Required");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();
            await Expect(Page.Locator("#modalityselect")).ToHaveValueAsync("1");
            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });

            // reopen the page and see the data persisted
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();
            await Expect(Page.Locator("#modalityselect")).ToHaveValueAsync("1");
            await Expect(Page.GetByLabel("Save status")).ToHaveValueAsync("1");
        }

        /*
         * Section 1 - MOCA
         * Section 2 - Remainder of battery
         * Section 3 - Craft Story 21 Recall
         * Section 4 - Benson Complex Figure
         * Section 5 - Number Span Test: Forward
         * Section 6 - Number Span Test: Backward
         * Section 7 - Category Fluency
         * Section 8 - Trail Making Test
         * Section 9 - Benson Complex Figure
         * Section 10 - Craft Story 21
         * Section 11 - Verbal Fluency: Phonemic Test
         * Section 12 & 13 - Rey Auditory Verbal Learning RAVLT
         * Section 14 & 15 - CERAD
         * Section 16 - MINT
         * Section 17 - Overall
         * Section 18 - Validity
         */
        private async Task SetupValidSections(bool ignoreSection16 = false)
        {
            await Page.Locator("input[type=\"radio\"][name=\"C2.MOCACOMP\"][value=\"0\"]").ClickAsync();
            await Page.Locator("input[name=\"C2.MOCAREAS\"]").FillAsync("95");
            await Page.Locator("input[type=\"radio\"][name=\"C2.NPSYCLOC\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"C2.NPSYLAN\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"C2.CRAFTVRS\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSBENTC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.DIGFORCT\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.DIGBACCT\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.ANIMALS\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.VEG\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.TRAILA\"]").FillAsync("995");
            await Page.Locator("input[name=\"C2.TRAILB\"]").FillAsync("995");
            await Page.Locator("input[name=\"C2.UDSBENTD\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.CRAFTDVR\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("95");
            await Page.Locator("input[type=\"radio\"][name=\"C2.VERBALTEST\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"C2.REY1REC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.REYDREC\"]").FillAsync("95");

            if (!ignoreSection16)
            {
                await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("95");
            }
            // Section 17
            await Page.Locator("input[type=\"radio\"][name=\"C2.COGSTAT\"][value=\"1\"]").ClickAsync();
            // Section 18
            await Page.Locator("input[type=\"radio\"][name=\"C2.RESPVAL\"][value=\"1\"]").ClickAsync();

        }

        [TestMethod]
        public async Task MINTValidatesWithTotalScoreOf32AndNoCues()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("95");
            // if 95 then child inputs are disabled and not required, only check the UI behavior here, we check the persistence in another test
            await Expect(Page.Locator("input[name=\"C2.MINTTOTW\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.MINTSCNG\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.MINTSCNC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.MINTPCNG\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.MINTPCNC\"]")).ToBeDisabledAsync();

            // if 32 then child elements are enabled and required
            await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("32");

            await Expect(Page.Locator("input[name=\"C2.MINTTOTS\"]")).ToBeEnabledAsync();
            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.MINTPCNG\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.MINTPCNC\"]").FillAsync("");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("#C2_MINTTOTW-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#C2_MINTSCNG-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#C2_MINTSCNC-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#C2_MINTPCNG-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#C2_MINTPCNC-error")).ToBeVisibleAsync();

            // Check for correct failure states
            // Some of this is evaluated server side so the entire form must be valid in order for error messages to be displayed
            // When MINTCSNG == 0 then MINTSCNC should = 88
            // When MINTPCNG == 0 then MINTPCNC should = 88
            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTPCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTPCNC\"]").FillAsync("0");

            // set up entire form with valid values except for MINT
            await SetupValidSections(true);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "If no semantic cues were" })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "If no phonemic cues were" })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("88");
            await Page.Locator("input[name=\"C2.MINTPCNC\"]").FillAsync("88");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.Locator("span").Filter(new() { HasText = "If MINTTOTS (mint total) is between 0 and 32" })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("32");
            // TODO  form should not have any further MINT errors

        }

        [TestMethod]
        public async Task MINTValidatesWithTotalScoreOf32And2Cues()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // set up entire form with valid values except for MINT
            await SetupValidSections(true);

            // set context with 2 cues given, but incorrect values
            await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("32");
            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("32");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("88");
            await Page.Locator("input[name=\"C2.MINTPCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTPCNC\"]").FillAsync("88");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "If MINTSCNG (mint number semantic cues given) is > 0 then" })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("2");
            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "If MINTTOTS is between 0 and 32" })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("30");
            // TODO form should not have any further MINT errors


        }

        [TestMethod]
        public async Task MINTValidatesImperfectScore()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            // set up entire form with valid values except for MINT
            await SetupValidSections(true);

            // set context with only 30 correct
            await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("30");
            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("");
            // phonemic cues are separate from the scoring that we are testing
            await Page.Locator("input[name=\"C2.MINTPCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTPCNC\"]").FillAsync("88");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("#C2_MINTTOTW-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#C2_MINTSCNG-error")).ToBeVisibleAsync();
            await Expect(Page.Locator("#C2_MINTSCNC-error")).ToBeVisibleAsync();

            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "If MINTTOTS is between 0 and 32" })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "If no semantic cues were given" })).ToBeVisibleAsync();

            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("30");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("2");

            await Expect(Page.Locator("span").Filter(new() { HasText = "If no semantic cues were given" })).ToBeVisibleAsync();
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("0");

            // TODO form should not have any further MINT errors


        }
    }
}
