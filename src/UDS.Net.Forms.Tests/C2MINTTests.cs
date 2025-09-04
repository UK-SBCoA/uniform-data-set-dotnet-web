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
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide total count without" })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide semantic number given." })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide semantic number correct with cue." })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide phonemic number given." })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide phonemic number correct with cue." })).ToBeVisibleAsync();

            // Check for correct failure state
            await Page.Locator("input[name=\"C2.MINTTOTW\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTSCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTSCNC\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTPCNG\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.MINTPCNC\"]").FillAsync("0");

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
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide total count without" })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide semantic number given." })).ToBeVisibleAsync();
            await Expect(Page.Locator("span").Filter(new() { HasText = "Provide semantic number correct with cue." })).ToBeVisibleAsync();

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
