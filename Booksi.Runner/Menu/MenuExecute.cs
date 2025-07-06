using Booksi.Runner.Code;
using Booksi.Tools;
using System.Linq;

namespace Booksi.Runner.Menu;

public class MenuExecute
{
    private readonly MenuProvider menuProvider;
    private static readonly UpMenuOption[] UpMenuOptions = {
        UpMenuOption.Compose, 
        UpMenuOption.DbUpdate, 
        UpMenuOption.DbUpdateAuto,
        UpMenuOption.Back
    };

    public MenuExecute(MenuProvider menuProvider)
    {
        this.menuProvider = menuProvider;
    }

    public void ExecuteCommand(string command)
    {
        if (Enum.TryParse<MainMenuOption>(command, out var mainOption))
        {
            switch (mainOption)
            {
                case MainMenuOption.Build:
                    ExecuteBuild();
                    break;
                case MainMenuOption.Up:
                    ExecuteUp();
                    break;
                case MainMenuOption.Run:
                    ExecuteRun();
                    break;
                case MainMenuOption.AddScripts:
                    ExecuteAddScripts();
                    break;
                case MainMenuOption.Kill:
                    ExecuteKill();
                    break;
                case MainMenuOption.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private void ExecuteBuild()
    {
        Log.Write("Starting building...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.BashScriptPath, CodeScripts.BooksiBuild);
    }

    private void ExecuteUp()
    {
        string upOption;
        do
        {
            Console.WriteLine("Up Menu\n");
            var upOptionsAsStrings = UpMenuOptions.Select(x => x.ToString()).ToArray();
            upOption = menuProvider.DisplayMenu(upOptionsAsStrings);
        
            if (Enum.TryParse<UpMenuOption>(upOption, out var upMenuOption))
            {
                switch (upMenuOption)
                {
                    case UpMenuOption.Compose:
                        Log.Write("Start composing Booksi docker image...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.BooksiCompose);
                        break;
                    case UpMenuOption.DbUpdate:
                        Log.Write("Start updating database...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.GetScriptPath(CodeScripts.BooksiDbUpdate));
                        break;  
                    case UpMenuOption.DbUpdateAuto:
                        Log.Write("Start updating database...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.GetScriptPath(CodeScripts.BooksiDbUpdateAuto));
                        break;
                    case UpMenuOption.Back:
                        Log.Write("Returning to main menu...", LogType.Info);
                        return;
                }
            }
        } while (upOption != UpMenuOption.Back.ToString());
        
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