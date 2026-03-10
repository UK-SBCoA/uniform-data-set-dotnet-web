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

            var model = FormModelGenerator.CreateFormModel<A5D2>();

            await FillFormAsync(Page, model);

            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();
        }


        public static async Task FillFormAsync<T>(IPage page, T model)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(model)?.ToString() ?? string.Empty;

                var locator = page.Locator($"input[name=\"A5D2.{property.Name}\"]");
                var inputType = await locator.GetAttributeAsync("type");
                if (inputType == "radio")
                {
                    var radio = page.Locator($"input[name=\"A5D2.{property.Name}\"][value=\"{value}\"]");
                    await radio.CheckAsync();
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
                }
                else
                {
                    await locator.FillAsync(value);
                }
            }
        }
    }
}
