using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class C2RAVLTests : TestBase
    {
        //Private method for setting up the _C2 form valid sections to allow finalize save
        private async Task SetupForRAVLC2()
        {
            //Set 12a for 95 and 13a for null
            //section 1
            await Page.Locator("input[type=\"radio\"][name=\"C2.MOCACOMP\"][value=\"0\"]").ClickAsync();
            await Page.Locator("input[name=\"C2.MOCAREAS\"]").FillAsync("95");
            //section 2 
            await Page.Locator("input[type=\"radio\"][name=\"C2.NPSYCLOC\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"C2.NPSYLAN\"][value=\"1\"]").ClickAsync();
            //section 3
            await Page.Locator("input[name=\"C2.CRAFTVRS\"]").FillAsync("95");
            //section 4
            await Page.Locator("input[name=\"C2.UDSBENTC\"]").FillAsync("95");
            // section 5
            await Page.Locator("input[name=\"C2.DIGFORCT\"]").FillAsync("95");
            //section 6
            await Page.Locator("input[name=\"C2.DIGBACCT\"]").FillAsync("95");
            //section 7
            await Page.Locator("input[name=\"C2.ANIMALS\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.VEG\"]").FillAsync("95");
            //section 8
            await Page.Locator("input[name=\"C2.TRAILA\"]").FillAsync("995");
            await Page.Locator("input[name=\"C2.TRAILB\"]").FillAsync("995");
            //section 9
            await Page.Locator("input[name=\"C2.UDSBENTD\"]").FillAsync("95");
            //section 10
            await Page.Locator("input[name=\"C2.CRAFTDVR\"]").FillAsync("95");
            //section 11
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("95");
            await Page.Locator("input[type=\"radio\"][name=\"C2.VERBALTEST\"][value=\"1\"]").ClickAsync();
            //section 12
            await Page.Locator("input[name=\"C2.REY1REC\"]").FillAsync("95");
            //section 13
            await Page.Locator("input[name=\"C2.REYDREC\"]").FillAsync("");
            //section 16
            await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("95");
            //section 17
            await Page.Locator("input[type=\"radio\"][name=\"C2.COGSTAT\"][value=\"1\"]").ClickAsync();
            //section 18
            await Page.Locator("input[type=\"radio\"][name=\"C2.RESPVAL\"][value=\"1\"]").ClickAsync();
        }

        private async Task SetupForRAVLC2T()
        {
            //Set REY1REC for 95 and REYDREC for null
            //section 1
            await Page.Locator("input[type=\"radio\"][name=\"C2.MOCACOMP\"][value=\"0\"]").ClickAsync();
            await Page.Locator("input[name=\"C2.MOCAREAS\"]").FillAsync("95");
            //section 2 
            await Page.Locator("input[type=\"radio\"][name=\"C2.NPSYLAN\"][value=\"1\"]").ClickAsync();
            //section 3
            await Page.Locator("input[name=\"C2.CRAFTVRS\"]").FillAsync("95");
            //section 4
            await Page.Locator("input[name=\"C2.DIGFORCT\"]").FillAsync("95");
            // section 5
            await Page.Locator("input[name=\"C2.DIGBACCT\"]").FillAsync("95");
            await Page.Locator("input[type=\"radio\"][name=\"C2.VERBALTEST\"][value=\"1\"]").ClickAsync();
            // section 6
            await Page.Locator("input[name=\"C2.REY1REC\"]").FillAsync("95");
            //section 8
            await Page.Locator("input[name=\"C2.ANIMALS\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.VEG\"]").FillAsync("95");
            //section 10
            await Page.Locator("input[name=\"C2.OTRAILA\"]").FillAsync("995");
            await Page.Locator("input[name=\"C2.OTRAILB\"]").FillAsync("995");
            //section 11
            await Page.Locator("input[name=\"C2.CRAFTDVR\"]").FillAsync("95");
            //section 12
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("95");
            // section 13
            await Page.Locator("input[name=\"C2.REYDREC\"]").FillAsync("");
            //section 14
            await Page.Locator("input[name=\"C2.VNTTOTW\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.VNTPCNC\"]").FillAsync("95");
            //section 15
            await Page.Locator("input[type=\"radio\"][name=\"C2.COGSTAT\"][value=\"1\"]").ClickAsync();
            //section 16
            await Page.Locator("input[type=\"radio\"][name=\"C2.RESPVAL\"][value=\"1\"]").ClickAsync();
            //save form section
            await Page.GetByLabel("If remote, specify reason").SelectOptionAsync("TooCognitivelyImpaired");
        }

        [TestMethod]
        public async Task RAVLC2ImmediateNotComplete()
        {
            //Navigate to the C2 form
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            //Select in person view (C2)
            await Page.Locator("#modalityselect").SelectOptionAsync("InPerson");

            await SetupForRAVLC2();

            await Expect(Page.Locator("input[name=\"C2.REY1INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY2REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY2INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY3REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY3INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY4REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY4INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY5REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY5INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYBREC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYBINT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY6REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY6INT\"]")).ToBeDisabledAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Expect error from 13a value
            await Expect(Page.Locator("span").Filter(new() { HasText = "A value of 95 - 98 is required for 13a. Total delayed recall when 12a. is 95 - 98" })).ToBeVisibleAsync();

            //Change 13a value to valid value
            await Page.Locator("input[name=\"C2.REYDREC\"]").FillAsync("95");

            //check for the rest of section 13 to be disabled when REYDREC = 95
            await Expect(Page.Locator("input[name=\"C2.REYDINT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYDTI\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"C2.REYMETHOD\"][value=\"1\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"radio\"][name=\"C2.REYMETHOD\"][value=\"2\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYTCOR\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYFPOS\"]")).ToBeDisabledAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for successful path to forms index on finalized save
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("C2");
            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task RAVLC2TImmediateNotComplete()
        {
            //Navigate to the _C2 view
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2" }).GetByRole(AriaRole.Link).ClickAsync();

            //Select the remote - telephone view (C2T)
            await Page.Locator("#modalityselect").SelectOptionAsync("Remote");
            await Page.Locator("#remote").SelectOptionAsync("Telephone");

            await SetupForRAVLC2T();

            //check for the rest of section 6 to be disabled
            await Expect(Page.Locator("input[name=\"C2.REY1INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY2REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY2INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY3REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY3INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY4REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY4INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY5REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY5INT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYBREC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYBINT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY6REC\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REY6INT\"]")).ToBeDisabledAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Expect error from 13a value
            await Expect(Page.Locator("span").Filter(new() { HasText = "A value of 95 - 98 is required for 13a. Total delayed recall when 6a. is 95 - 98" })).ToBeVisibleAsync();

            //Change 13a value to valid value
            await Expect(Page.Locator("input[name=\"C2.REYDREC\"]")).ToHaveCountAsync(1);
            await Page.Locator("input[name=\"C2.REYDREC\"]").FillAsync("95");

            //check for the rest of section 13 to be disabled when REYDREC = 95
            await Expect(Page.Locator("input[name=\"C2.REYDINT\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYDTI\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYTCOR\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[name=\"C2.REYFPOS\"]")).ToBeDisabledAsync();

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for successful path to forms index on finalized save
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Go" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("C2");
            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }
    }
}
