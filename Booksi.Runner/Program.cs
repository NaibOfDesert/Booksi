using Booksi.Runner.Helpers;

public class Program
{
    private static readonly string[] MenuOptions = { "Build", "Up", "Run", "AddScripts", "Kill", "Exit" };

    public static void Main(string[] args)
    {
        var menuProvider = CreateMenuProvider(args);
        var menuCommandHandler = new MenuCommandHandler(menuProvider);
        
        string menuOption;
        do
        {
            menuOption = menuProvider.ShowMenu(MenuOptions);
            menuCommandHandler.ExecuteCommand(menuOption);
        }
        while (menuOption != "Exit");
    }

    private static IMenuProvider CreateMenuProvider(string[] args)
    {
        var environment = args.Length > 0 ? args.Last() : "Mac";
        
        return environment switch
        {
            "Win" => CreateWindowsProvider(),
            _ => CreateMacProvider()
        };
    }

    private static IMenuProvider CreateMacProvider()
    {
        CodeFactory.EnvironmentSetUp(EnvironmentType.Mac);
        return new MainMacMenuProvider(EnvironmentType.Mac);
    }

    private static IMenuProvider CreateWindowsProvider()
    {
        CodeFactory.EnvironmentSetUp(EnvironmentType.Win);
        return new MainWinMenuProvider(EnvironmentType.Win);
    }
}