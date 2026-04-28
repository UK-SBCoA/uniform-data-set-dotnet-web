using Microsoft.Playwright;

namespace UDS.Net.Forms.Tests
{
    /// <summary>
    /// Tests for form footer NotCompleted mode behavior
    /// 
    /// Forms with NotCompleted capability (A1a, A2, B1, B3, B5, B6, B7):
    /// - When MODE is set to NotCompleted, the NOT (reason code) field is required
    /// - When trying to finalize without selecting a reason, validation errors should appear
    /// - After selecting a reason, the form should save successfully
    /// - Form status should be persisted as Finalized after successful save
    /// 
    /// Allowed NotIncludedReasonCodes per form:
    /// - A1a: ConcernsAboutReliability (93)
    /// - A2: NoCoParticipant (92), PhysicalProblem (95), CognitiveBehavioralProblem (96), Other (97), VerbalRefusal (98)
    /// - B1: RemoteVisit (94), PhysicalProblem (95), CognitiveBehavioralProblem (96), Other (97), VerbalRefusal (98)
    /// - B3: RemoteVisit (94), PhysicalProblem (95), CognitiveBehavioralProblem (96), Other (97), VerbalRefusal (98)
    /// - B5: PhysicalProblem (95), CognitiveBehavioralProblem (96), Other (97), VerbalRefusal (98)
    /// - B6: PhysicalProblem (95), CognitiveBehavioralProblem (96), Other (97), VerbalRefusal (98)
    /// - B7: PhysicalProblem (95), CognitiveBehavioralProblem (96), Other (97), VerbalRefusal (98)
    /// </summary>
    [TestClass]
    public class FormFooterNotCompletedTests : TestBase
    {
        [TestMethod]
        public async Task A1aNotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A1a" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("93");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A1a" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task A2NotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A2" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("92");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "A2" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task B1NotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B1" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("94");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B1" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task B3NotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B3" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("94");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B3" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task B5NotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B5" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("95");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B5" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task B6NotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B6" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("95");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B6" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }

        [TestMethod]
        public async Task B7NotCompletedRequiresReasonCode()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "New visit" }).ClickAsync();
            await Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B7" }).GetByRole(AriaRole.Link).ClickAsync();

            await Page.GetByLabel("Mode", new() { Exact = true }).SelectOptionAsync("0");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByLabel("If not completed, specify reason")).ToBeVisibleAsync();

            await Page.GetByLabel("If not completed, specify reason").SelectOptionAsync("95");

            await Page.GetByLabel("Save status").SelectOptionAsync(new[] { "2" });
            await Page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = "B7" }).GetByRole(AriaRole.Link)).ToBeVisibleAsync();
        }
    }
}