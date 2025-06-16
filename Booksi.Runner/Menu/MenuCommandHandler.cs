using Booksi.Runner.Helpers;
using Booksi.Runner.Menu;
using Booksi.Tools;

public class MenuCommandHandler
{
    private readonly MenuProvider menuProvider;
    private static readonly UpMenuOption[] UpMenuOptions = { UpMenuOption.BooksiCompose, UpMenuOption.DbUpdate, UpMenuOption.Back };

    public MenuCommandHandler(MenuProvider menuProvider)
    {
        this.menuProvider = menuProvider;
    }

    public void ExecuteCommand(string command)
    {
        switch (command)
        {
            case MainMenuOption.Build.ToString():
                ExecuteBuild();
                break;
            case "UP":
                ExecuteUp();
                break;
            case "RUN":
                ExecuteRun();
                break;
            case "AddScripts":
                ExecuteAddScripts();
                break;
            case "Kill":
                ExecuteKill();
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }

    private void ExecuteBuild()
    {
        Log.Write("Starting building...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.BashScriptPath, CodeScripts.BooksiBuild);
    }

    private void ExecuteUp()
    {
        Console.WriteLine("Up\n");
        var upOption = menuProvider.DisplayMenu(UpMenuOptions);
        
        switch (upOption)
        {
            case "BooksiCompose":
                Log.Write("Start composing Booksi docker image...", LogType.Log);
                CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.BooksiCompose);
                break;
            case "DbUpdate":
                Log.Write("Start updating database...", LogType.Log);
                CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.GetScriptPath(CodeScripts.DbUpdate));
                break;
        }
    }

    private void ExecuteRun()
    {
        Log.Write("Start running...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.GetScriptPath(CodeScripts.BooksiRun));
    }

    private void ExecuteAddScripts()
    {
        Log.Write("Start running and adding scripts...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.AddScripts);
    }

    private void ExecuteKill()
    {
        Log.Write("Start killing...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.BooksiKill);
    }
}