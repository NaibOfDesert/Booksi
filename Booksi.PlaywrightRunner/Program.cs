using Booksi.PlaywrightRunner.Tests;

// See https://aka.ms/new-console-template for more information
namespace Booksi.PlaywrightRunner;

class Program
{
    public static async Task Main(string[] args)
    {
        Info.Info.InfoRun("Booksi.PlaywrightRunner: up.");

        await TestClick.ClickButton();
    }


}