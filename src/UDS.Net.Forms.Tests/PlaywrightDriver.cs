using Microsoft.Playwright;

public static class PlaywrightDriver
{
    public static IPlaywright Playwright { get; private set; }
    public static IBrowser Browser { get; private set; }

    public static async Task StartAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // Set to true in CI
        });
    }

    public static async Task StopAsync()
    {
        await Browser?.CloseAsync();
        Playwright?.Dispose();
    }
}