using Microsoft.Playwright;
using UDS.Net.Forms.Models.UDS4;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class A5D2Tests : TestBase
    {
        [TestMethod]
        public async Task A5D2_Form_Submits()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Expect(Page.GetByRole(AriaRole.List)).ToContainTextAsync("A5D2");
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A5D2" }).GetByRole(AriaRole.Link).ClickAsync();


            //await FillFormAsync(Page, model);
            await WriteFormData();

            await Expect(Page.GetByLabel("Save status")).ToContainTextAsync("Not started In progress Finalized");
            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "1" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();


            //Go back in to A5D2 and check that modified data is loaded instead of previous visit data
           await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A5D2 Required" }).GetByRole(AriaRole.Link).ClickAsync();
           await CheckAutoPopulatedValuesOnFollowUp();
        }
        private async Task WriteFormData()
        {
            //Setup field values for next visit
            await Page.Locator("input[name=\"A5D2.TOBAC100\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.SMOKYRS\"]").FillAsync("50");
            await Page.Locator("input[name=\"A5D2.PACKSPER\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.TOBAC30\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.QUITSMOK\"]").FillAsync("888");
            await Page.Locator("input[name=\"A5D2.ALCFREQYR\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ALCDRINKS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ALCBINGE\"][value=\"2\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.SUBSTYEAR\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.SUBSTPAST\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANNABIS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HRTATTACK\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HRTATTMULT\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HRTATTAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CARDARREST\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CARDARRAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CVAFIB\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CVANGIO\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CVBYPASS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.BYPASSAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CVPACDEF\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PACDEFAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CVCHF\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CVHVALVE\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.VALVEAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CVOTHR\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CVOTHRX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.CBSTROKE\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.STROKMUL\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.STROKAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.STROKSTAT\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ANGIOCP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CAROTIDAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CBTIA\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.TIAAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.PD\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PDAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.PDOTHR\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PDOTHRAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.SEIZURES\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.SEIZNUM\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.SEIZAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HEADACHE\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.MS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HYDROCEPH\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HEADIMP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPAMFOOT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPSOCCER\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPHOCKEY\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPBOXING\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPSPORT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPIPV\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPMILIT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPASSAULT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPOTHER\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.IMPOTHERX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.IMPYEARS\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HEADINJURY\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HEADINJUNC\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HEADINJCON\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HEADINJNUM\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.FIRSTTBI\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.LASTTBI\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.DIABETES\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABTYPE\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABINS\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABMEDS\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABGLP1\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABRECACT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABDIET\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABUNK\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DIABAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HYPERTEN\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HYPERTAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HYPERCHO\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HYPERCHAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.B12DEF\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.THYROID\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHRIT\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHRRHEUM\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHROSTEO\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHROTHR\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHTYPX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.ARTHTYPUNK\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHUPEX\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHLOEX\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHSPIN\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ARTHUNK\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.INCONTU\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.APNEA\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CPAP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.APNEAORAL\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.RBD\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.INSOMN\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OTHSLEEP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HYPERCHAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.CANCERACTV\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCERPRIM\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCERMETA\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCMETBR\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCMETOTH\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCERUNK\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCBLOOD\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCBREAST\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCCOLON\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCLUNG\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCPROST\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCOTHER\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCRAD\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCRESECT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCIMMUNO\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCBONE\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCCHEMO\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCHORM\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCTROTH\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.CANCTROTHX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.COVID19\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.COVIDHOSP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PULMONARY\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.KIDNEY\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.LIVER\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.LIVERAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.PVD\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PVDAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HIVDIAG\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HIVAGE\"]").FillAsync("999");;
            await Page.Locator("input[name=\"A5D2.OTHERCOND\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OTHCONDX\"]").FillAsync("999");;
            await Page.Locator("input[name=\"A5D2.MAJORDEP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OTHERDEP\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.DEPRTREAT\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.BIPOLAR\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.SCHIZ\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.ANXIETY\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.GENERALANX\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PANICDIS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OCD\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OTHANXDIS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OTHANXDISX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.PTSD\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NPSYDEV\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.PSYCDIS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.OTHANXDISX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.NOMENSAGE\"]").FillAsync("999");
            await Page.Keyboard.PressAsync("Tab");
            await Page.Locator("input[name=\"A5D2.NOMENSNAT\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSHYST\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSSURG\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSCHEM\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSRAD\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSHORM\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSESTR\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSUNK\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSOTH\"][value=\"true\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.NOMENSOTHX\"]").FillAsync("Test");
            await Page.Locator("input[name=\"A5D2.HRT\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.HRTYEARS\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HRTSTRTAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.HRTENDAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.BCPILLS\"][value=\"1\"]").CheckAsync();
            await Page.Locator("input[name=\"A5D2.BCPILLSYR\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.BCSTARTAGE\"]").FillAsync("999");
            await Page.Locator("input[name=\"A5D2.BCENDAGE\"]").FillAsync("999");

            //DEVNOTE: Using tab key presses to unfocus input and trigger JS field enables
            // await Page.Keyboard.PressAsync("Tab");
        }

        private async Task CheckAutoPopulatedValuesOnFollowUp()
        {
        await Expect(Page.Locator("input[name=\"A5D2.TOBAC100\"][value=\"1\"]")).ToBeCheckedAsync();

            
        }


        public static async Task FillFormAsync<T>(IPage page, T model)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(model)?.ToString() ?? string.Empty;

                var locator = page.Locator($"input[name=\"A5D2.{property.Name}\"]").First;
                var inputType = await locator.GetAttributeAsync("type");
                if (inputType == "radio")
                {
                    var radio = page.Locator($"input[name=\"A5D2.{property.Name}\"][value=\"{value}\"]");
                    await radio.CheckAsync();
                    continue;
                }

                if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    if (bool.TryParse(value, out bool boolValue))
                    {
                        if (boolValue)
                        {
                            await locator.CheckAsync();
                        }
                        else
                        {
                            await locator.UncheckAsync();
                        }
                    }
                    continue;
                }
                else
                {
                    await locator.FillAsync(value);
                }
            }
        }
    }
}
