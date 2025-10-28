using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Tests
{
    [TestClass]
    public class PacketSubmissionTests : TestBase
    {
        [TestMethod]
        public async Task NewPacketSubmissionButtonIsDisabled()
        {
            await Page.GotoAsync(BaseUrl);

            // Click the "Submissions" button on the main page
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submissions" }).ClickAsync();

            // Wait for the header to ensure the page is loaded
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Participant 1000 Visit 0 Packet Submission" }))
                .ToBeVisibleAsync();

            // Verify that the "New packet submission" button is disabled
            var newPacketButton = Page.GetByRole(AriaRole.Button, new() { Name = "New packet submission" });
            await Expect(newPacketButton).ToBeDisabledAsync();

            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "View Visit" })).ToBeVisibleAsync();
        }
    }
}
