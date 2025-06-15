using Booksi.Runner.Helpers;
using Booksi.Runner.MenuProviders;;

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
            menuOption = menuProvider.ShowMenu(MenuOptions);
            menuCommandHandler.ExecuteCommand(menuOption);
        }
        while (menuOption != "Exit");
    }

    private IMenuProvider CreateMenuProvider(string[] args)
    {
        var environment = args.Length > 0 && args.Contains(MenuProviderOptions.Win.ToString().ToUpper()) 
            ? MenuProviderOptions.Win
            : MenuProviderOptions.Mac;
        
        CodeFactory.EnvironmentSetUp(environment);
        return new MenuProvider(EnvironmentType.Mac);
    }
}