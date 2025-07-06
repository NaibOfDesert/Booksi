using Booksi.Runner.Code;
using Booksi.Tools;

namespace Booksi.Runner.Menu;
public class MainMenu
{
    private readonly MainMenuOption[] MenuOptions = { 
        MainMenuOption.Build, 
        MainMenuOption.Up, 
        MainMenuOption.Run, 
        MainMenuOption.AddScripts, 
        MainMenuOption.Kill, 
        MainMenuOption.Exit 
    };

    public void StartMenu(string[] args)
    {
        var environment = DetectEnvironment(args);
        var menuProvider = new MenuProvider(environment);
        var menuCommandHandler = new MenuExecute(menuProvider);
        
        string menuOption;
        do
        {
            var menuOptionsAsStrings = MenuOptions.Select(x => x.ToString()).ToArray();
            menuOption = menuProvider.DisplayMenu(menuOptionsAsStrings);
            menuCommandHandler.ExecuteCommand(menuOption);
        }
        while (menuOption != MainMenuOption.Exit.ToString());
    }
    
    private EnvironmentType DetectEnvironment(string[] args)
    {
        return args.Length > 0 && args.Contains(EnvironmentType.Win.ToString().ToUpper()) 
            ? EnvironmentType.Win
            : EnvironmentType.Mac;
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