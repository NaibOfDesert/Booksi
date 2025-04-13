using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Playwright;
public class TestClick : Test{
    public string Description {get; set;} = "";
    public static async Task ClickButton(){
        Info.InfoTest("Test ClickButtonStarted");


        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // set to false if you want to see the action
        });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://localhost:5231/"); // replace with your test page URL

        // Simulate a click
        await page.ClickAsync("#Details");

        // Wait for the result to appear (optional, depends on your page)
        await page.WaitForSelectorAsync("#result");

        // Check result text
        var resultText = await page.InnerTextAsync("#result");
    
        if (resultText.Contains("You clicked the button"))
        {
            Info.InfoTestPass("Test ClickButtonStarted passed");
        }
        else
        {
            Info.InfoTestFail("Test ClickButtonStarted vailed");
        }

        
    }
}