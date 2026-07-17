using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class C2VerbalFluencyTests : TestBase
    {
        private async Task SetUpC2Form()
        {
            await NavigateToC2View();

            await Page.Locator("input[type=\"radio\"][name=\"C2.MOCACOMP\"][value=\"0\"]").ClickAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.MOCAREAS\"]")).ToBeEnabledAsync();
            await Page.Locator("input[type=\"number\"][name=\"C2.MOCAREAS\"]").FillAsync("95");
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
            await Page.Locator("input[type=\"radio\"][name=\"C2.VERBALTEST\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[name=\"C2.REY1REC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.REYDREC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.MINTTOTS\"]").FillAsync("95");
            await Page.Locator("input[type=\"radio\"][name=\"C2.COGSTAT\"][value=\"1\"]").ClickAsync();
            await Page.Locator("input[type=\"radio\"][name=\"C2.RESPVAL\"][value=\"1\"]").ClickAsync();
        }

        private async Task NavigateToC2View()
        {
            //Navigate to the C2 form
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2 Required" }).GetByRole(AriaRole.Link).ClickAsync();

            //Select in person view (C2)
            await Page.Locator("#modalityselect").SelectOptionAsync("InPerson");

            //Wait for javascript to finish loading by identifying a C2 input
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.MOCATOTS\"]")).ToBeDisabledAsync();
        }

        //Using both UDSVERFC and UDSVERLC error codes should disable all fields following them within section
        [TestMethod]
        public async Task UDSVERFCAndUDSVERLReasonCodesDisableFollowingFields()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("95");

            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERFN\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERNF\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERLR\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERLN\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERTN\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERTE\"]")).ToBeDisabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERTI\"]")).ToBeDisabledAsync();
        }

        //Using valid values for UDSVERFC and UDSVERLC should enable all fields following them within section
        [TestMethod]
        public async Task UDSVERFCAndUDSVERLCValuesEnableFollowingFields()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("2");

            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERFN\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERNF\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERLR\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERLN\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERTN\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERTE\"]")).ToBeEnabledAsync();
            await Expect(Page.Locator("input[type=\"number\"][name=\"C2.UDSVERTI\"]")).ToBeEnabledAsync();
        }

        //If UDSVERFC (correct f-words) is between 95 and 98 or UDSVERLC (I-words correct) is between 95 and 98, then UDSVERTN, UDSVERTE, and UDSVERTI must be blank
        [TestMethod]
        public async Task UDSVERFCReasonCodeRequiresTotalFieldsToBeNull()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERLR\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERLN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTE\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTI\"]").FillAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for validation message to appear on properties
            var blankInputErrorMessageLocator = Page.Locator("span").Filter(new() { HasText = "If UDSVERFC (correct f-words) is between 95 and 98 or UDSVERLC (I-words correct) is between 95 and 98, then UDSVERTN, UDSVERTE, and UDSVERTI must be blank" });

            await Expect(blankInputErrorMessageLocator).ToHaveCountAsync(3);
        }

        //If UDSVERFC not 95-98 and UDSVERLC not 95-98, UDSVERTN must be the total of UDSVERFC and UDSVERLC
        [TestMethod]
        public async Task UDSVERTNRequiresSumOfUDSVERFCAndUDSVERLCWhenBothAreValues()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERFN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERNF\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERLR\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERLN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTE\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTI\"]").FillAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for validation message to appear on properties
            await Expect(Page.Locator("span").Filter(new() { HasText = "If UDSVERFC not 95-98 and UDSVERLC not 95-98, UDSVERTN must be the total of UDSVERFC and UDSVERLC" })).ToBeVisibleAsync();
        }

        //When UDSVERFC and UDSVERLC are values, All questions can be given a value and save the form
        [TestMethod]
        public async Task UDSVERFCAndUDSVERLCWithValuesAcceptsSectionCompletion()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERFN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERNF\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERLR\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERLN\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTN\"]").FillAsync("4");
            await Page.Locator("input[name=\"C2.UDSVERTE\"]").FillAsync("0");
            await Page.Locator("input[name=\"C2.UDSVERTI\"]").FillAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for successful path to forms index on finalized save
            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2" })).ToBeVisibleAsync();
        }

        //When UDSVERFC and UDSVERLC are reason codes, the form saves with null values for the rest of the section
        [TestMethod]
        public async Task UDSVERFCAndUDSVERLCWithReasonCodesAcceptsNullValues()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("95");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("95");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for successful path to forms index on finalized save
            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "C2" })).ToBeVisibleAsync();
        }

        //If UDSVERNF and UDSVERLN are both within valid ranges (0-15) then UDSVERTI should equal the sum of UDSVERNF and UDSVERLN.
        [TestMethod]
        public async Task UDSVERTIRequiresSumOfUDSVERNFAndUDSVERLNWhenBothAreValues()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERFN\"]").FillAsync("3");
            await Page.Locator("input[name=\"C2.UDSVERNF\"]").FillAsync("4");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERLR\"]").FillAsync("5");
            await Page.Locator("input[name=\"C2.UDSVERLN\"]").FillAsync("6");
            await Page.Locator("input[name=\"C2.UDSVERTN\"]").FillAsync("7");
            await Page.Locator("input[name=\"C2.UDSVERTE\"]").FillAsync("8");
            await Page.Locator("input[name=\"C2.UDSVERTI\"]").FillAsync("9");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for validation message to appear on properties
            await Expect(Page.Locator("span").Filter(new() { HasText = "If UDSVERNF and UDSVERLN are both within valid ranges (0-15) then UDSVERTI should equal the sum of UDSVERNF and UDSVERLN." })).ToBeVisibleAsync();
        }

        //If UDSVERFN (f-words repeated) is between 0 and 15 and UDSVERLR (l-words repeated) is between 0 and 15, then UDSVERTE must be the total of UDSVERFN and UDSVERLR
        [TestMethod]
        public async Task UDSVERTERequiresSumOfUDSVERFNAndUDSVERLRWhenBothAreValues()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("1");
            await Page.Locator("input[name=\"C2.UDSVERFN\"]").FillAsync("2");
            await Page.Locator("input[name=\"C2.UDSVERNF\"]").FillAsync("3");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("4");
            await Page.Locator("input[name=\"C2.UDSVERLR\"]").FillAsync("5");
            await Page.Locator("input[name=\"C2.UDSVERLN\"]").FillAsync("6");
            await Page.Locator("input[name=\"C2.UDSVERTN\"]").FillAsync("5");
            await Page.Locator("input[name=\"C2.UDSVERTE\"]").FillAsync("8");
            await Page.Locator("input[name=\"C2.UDSVERTI\"]").FillAsync("9");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for validation message to appear on properties
            await Expect(Page.Locator("span").Filter(new() { HasText = "If UDSVERFN (f-words repeated) is between 0 and 15 and UDSVERLR (l-words repeated) is between 0 and 15, then UDSVERTE must be the total of UDSVERFN and UDSVERLR" })).ToBeVisibleAsync();
        }

        //When UDSVERFC and UDSVERLC are values, All questions can be given a value and save the form
        [TestMethod]
        public async Task UDSVERFCAndUDSVERLCWithValuesRequiresSectionCompletion()
        {
            await SetUpC2Form();

            //Provide values for verbal fluency section
            await Page.Locator("input[name=\"C2.UDSVERFC\"]").FillAsync("40");
            await Page.Locator("input[name=\"C2.UDSVERFN\"]").FillAsync("15");
            await Page.Locator("input[name=\"C2.UDSVERNF\"]").FillAsync("15");
            await Page.Locator("input[name=\"C2.UDSVERLC\"]").FillAsync("40");
            await Page.Locator("input[name=\"C2.UDSVERLR\"]").FillAsync("15");
            await Page.Locator("input[name=\"C2.UDSVERLN\"]").FillAsync("15");
            await Page.Locator("input[name=\"C2.UDSVERTN\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.UDSVERTE\"]").FillAsync("");
            await Page.Locator("input[name=\"C2.UDSVERTI\"]").FillAsync("30");

            await Page.GetByLabel("Save status").SelectOptionAsync("Finalized");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            //Look for validation message to appear on properties
            var valueRequiredErrorMessageLocator = Page.Locator("span").Filter(new() { HasText = "Value Required" });

            await Expect(valueRequiredErrorMessageLocator).ToHaveCountAsync(2);
        }
    }
}
