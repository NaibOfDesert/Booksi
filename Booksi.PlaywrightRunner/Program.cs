using Microsoft.Playwright;

// See https://aka.ms/new-console-template for more information
class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Booksi.PlaywrightRunner Starter");


        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://playwright.dev/dotnet");
        await page.ScreenshotAsync(new()
        {
            Path = "screenshot.png"
        });

    }
}

