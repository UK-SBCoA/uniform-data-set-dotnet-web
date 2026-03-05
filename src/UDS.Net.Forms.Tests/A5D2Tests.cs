using Microsoft.Playwright;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class A5D2Tests : TestBase
    {
        [TestMethod]
        public async Task A5D2_Form_Submits()
        {
            await Page.GotoAsync("/Forms/A5D2");

            var model = FormModelGenerator.CreateFormModel<A5D2FormFields>();

            await FillFormAsync(Page, model);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
        }


        public static async Task FillFormAsync<T>(IPage page, T model)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(model)?.ToString() ?? string.Empty;

                var locator = page.Locator($"input[name='{property.Name}']");

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
                }
                else
                {
                    await locator.FillAsync(value);
                }
            }
        }
    }
}
