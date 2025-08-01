using Microsoft.Playwright;

public static class PlaywrightDriver
{
    public static IPlaywright Playwright { get; private set; }
    public static IBrowser Browser { get; private set; }

    public static async Task StartAsync()
    {
        var headedEnv = Environment.GetEnvironmentVariable("HEADED");
        bool headless = true; // default to headless

        if (!string.IsNullOrEmpty(headedEnv) && headedEnv == "1")
        {
            headless = false;
        }

        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = headless // Set to true in CI, false to debug locally
        });
    }

    public static async Task StopAsync()
    {
        await Browser?.CloseAsync();
        Playwright?.Dispose();
    }
}