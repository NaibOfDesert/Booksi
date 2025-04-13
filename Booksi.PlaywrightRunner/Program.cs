using Microsoft.Playwright;

// See https://aka.ms/new-console-template for more information
class Program
{
    public static async Task Main(string[] args)
    {
        Info.InfoRun("Booksi.PlaywrightRunner: up.");

       await TestClick.ClickButton();
    }


}

