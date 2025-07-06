using Booksi.Tools;
using Booksi.Runner.Menu;
using Booksi.Runner.Code;

namespace Booksi.Runner;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            new MainMenu().StartMenu(args);
        }
        catch (Exception ex)
        {
            Log.Write($"Application error: {ex.Message}", LogType.Error);
            Environment.Exit(1);
        }
    }
}
