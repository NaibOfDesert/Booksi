using Booksi.Runner.Code;
using Booksi.Tools;
using System.Linq;

namespace Booksi.Runner.Menu;

public class MenuExecute
{
    private readonly MenuProvider _menuProvider;
    private readonly UpMenuOption[] _upMenuOptions = {
        UpMenuOption.Compose, 
        UpMenuOption.DbMigrationAdd,
        UpMenuOption.DbMigrationRemove,
        UpMenuOption.DbUpdate, 
        UpMenuOption.DbUpdateAuto,
        UpMenuOption.Back
    };

    public MenuExecute(MenuProvider menuProvider)
    {
        this._menuProvider = menuProvider;
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
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.Build);
    }

    private void ExecuteUp()
    {
        string upOption;
        do
        {
            Console.WriteLine("Up Menu\n");
            var upOptionsAsStrings = _upMenuOptions.Select(x => x.ToString()).ToArray();
            upOption = _menuProvider.DisplayMenu(upOptionsAsStrings);
        
            if (Enum.TryParse<UpMenuOption>(upOption, out var upMenuOption))
            {
                switch (upMenuOption)
                {
                    case UpMenuOption.Compose:
                        Log.Write("Start composing Booksi docker image...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.Compose);
                        break;
                    case UpMenuOption.DbMigrationAdd:
                        Log.Write("Start adding migration...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.GetScriptPath(CodeScripts.DbMigrationAdd));
                        break; 
                    case UpMenuOption.DbMigrationRemove:
                        Log.Write("Start removing migration...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.GetScriptPath(CodeScripts.DbMigrationRemove));
                        break; 
                    case UpMenuOption.DbUpdate:
                        Log.Write("Start updating database...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.GetScriptPath(CodeScripts.DbUpdate));
                        break;  
                    case UpMenuOption.DbUpdateAuto:
                        Log.Write("Start updating database...", LogType.Log);
                        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.GetScriptPath(CodeScripts.DbUpdateAuto));
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
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.GetScriptPath(CodeScripts.Run));
    }

    private void ExecuteAddScripts()
    {
        Log.Write("Start running and adding scripts...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.AddScripts);
    }

    private void ExecuteKill()
    {
        Log.Write("Start killing...", LogType.Log);
        CodeFactory.BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, CodeScripts.Kill);
    }
}