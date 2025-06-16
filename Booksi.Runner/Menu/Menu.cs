using Booksi.Runner.Helpers;
using Booksi.Runner.Menu;
using Booksi.Tools;

public class Menu
{
    private readonly string[] MenuOptions = { "Build", "Up", "Run", "AddScripts", "Kill", "Exit" };

    public void StartMenu(string[] args)
    {
        var menuProvider = CreateMenuProvider(args);
        var menuCommandHandler = new MenuCommandHandler(menuProvider);
        
        string menuOption;
        do
        {
            menuOption = menuProvider.DisplayMenu(MenuOptions);
            menuCommandHandler.ExecuteCommand(menuOption);
        }
        while (menuOption != "Exit");
    }

    private MenuProvider CreateMenuProvider(string[] args)
    {
        var environment = args.Length > 0 && args.Contains(EnvironmentType.Win.ToString().ToUpper()) 
            ? EnvironmentType.Win
            : EnvironmentType.Mac;
        
        CodeFactory.EnvironmentSetUp(environment);
        return new MenuProvider(EnvironmentType.Mac);
    }
}