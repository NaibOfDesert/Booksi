using Microsoft.Playwright;

// See https://aka.ms/new-console-template for more information
class Program
{
    public static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("info: ");
        Console.ResetColor();
        Console.WriteLine("Booksi.PlaywrightRunner: up.");


        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();


        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://localhost:5231/"); // replace with your test page URL
        await page.ClickAsync("#Details");

        // Wait for the result to appear (optional, depends on your page)
        await page.WaitForSelectorAsync("#result");

        // Check result text
        var resultText = await page.InnerTextAsync("#result");

        if (resultText.Contains("You clicked the button"))
        {
            Console.WriteLine("✅ Click test passed!");
        }
        else
        {
            Console.WriteLine("❌ Click test failed.");
        }
        /*
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://playwright.dev/dotnet");
        await page.ScreenshotAsync(new()
        {
            Path = "screenshot.png"
        });
        */

        // Tests.ClickButton(); 
    }
}

