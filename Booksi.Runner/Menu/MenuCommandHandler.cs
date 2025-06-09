using Booksi.Runner.Helpers;
using Booksi.Tools;

public class MenuCommandHandler
{
    private readonly IMenuProvider menuProvider;
    private static readonly string[] UpMenuOptions = { "BooksiCompose", "DbUpdate", "Back" };

    public MenuCommandHandler(IMenuProvider menuProvider)
    {
        this.menuProvider = menuProvider;
    }

    public void ExecuteCommand(string command)
    {
        switch (command)
        {
            case "Build":
                ExecuteBuild();
                break;
            case "Up":
                ExecuteUp();
                break;
            case "Run":
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
        var upOption = menuProvider.ShowMenu(UpMenuOptions);
        
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