using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Booksi.Runner;
using Booksi.Tools;
public class Program{
    private static string projectPath = PathHelper.ProjectRoot;
    private static readonly string[] menuOptionList = {"Build", "Up", "Run", "AddScripts", "Kill", "Exit"};
    private static readonly string[] menuUpOptionList = {"BooksiCompose", "DbUpdate", "Back"};
    private static EnvironmentType environmentType;
    private delegate string MenuDelegate(string[] menuList);
    private static MenuDelegate Menu; 

    public static void Main(string[] args){
        EnvironmentSetUp(args); 

        string menuOption;

        do{
            menuOption = Menu(menuOptionList);
            Switch(menuOption);
        }
        while (menuOption != "Exit"); 
    }

#region MENU
    private static void EnvironmentSetUp(string[] args){
        string environment = String.Empty; 

        if(args.Length > 0)
            environment.Last(); 

        switch (environment){
            default:
            case null:
            case "Mac":
                environmentType = EnvironmentType.Mac;
                Menu = MenuUploadMac;
                break;
            case "Win":
                environmentType = EnvironmentType.Win;
                Menu = MenuUploadWin;
                break;
        }
    }

    private static string MenuUploadMac(string[] menuList){
        string consoleInput = String.Empty;
        do{
            Log.Clear();
            Log.Write("Write choosen option. Press Enter to go next:\n", LogType.Info);
            Log.Write("Options:\n", LogType.Warning);
            for(int i = 0; i < menuList.Length; i++){
                Log.Write("" + menuList[i], LogType.Info);
            }
            consoleInput = (string)Log.Read(environmentType);
        }
        while(!menuList.Contains(consoleInput));
        Log.Clear();
        return consoleInput;
    }

    private static string MenuUploadWin(string[] menuList){
        ConsoleKey consoleKey; 
        int seclectedOptionIndex = 0;

        do{
            Log.Clear();
            Log.Write("Use Up and Down arrows to navigate. Press Enter to select:\n", LogType.Info);
            Log.Write("Options:", LogType.Info);
            for(int i = 0; i < menuList.Length; i++){
                if(i == seclectedOptionIndex)
                    Log.Write("  " + menuList[i], LogType.Selected);
                else
                    Log.Write("  " + menuList[i], LogType.Log);
            }

            consoleKey = (ConsoleKey)Log.Read(environmentType, true);

            if (consoleKey == ConsoleKey.UpArrow)
            {
                seclectedOptionIndex--;
                if (seclectedOptionIndex < 0) seclectedOptionIndex = menuList.Length - 1;
            }
            else if (consoleKey == ConsoleKey.DownArrow)
            {
                seclectedOptionIndex++;
                if (seclectedOptionIndex >= menuList.Length) seclectedOptionIndex = 0;
            }
        }
        while(consoleKey != ConsoleKey.Enter);
        Log.Clear();
        return menuOptionList[seclectedOptionIndex];
    }

    private static void Switch(string optionMain) {
        switch (optionMain) {
            case "Build":
                Log.Write("Starting building...", LogType.Log);
                BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.BashScriptPath, Scripts.BooksiBuild);
                break;
            case "Up":
                Console.WriteLine("Up\n");
                switch (Menu(menuUpOptionList)){
                    case "BooksiCompose":
                        Log.Write("Start composing Booksi docker image...", LogType.Log);
                        BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, Scripts.BooksiCompose);
                        break;
                    case "DbUpdate":
                        Log.Write("Start updating database...", LogType.Log);
                        BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.GetScriptPath(Scripts.DbUpdate));
                        break;
                    case "Back":
                    default:
                        Menu(menuOptionList);
                        break;
                }         
                break;
            case "Run":
                Log.Write("Start running...", LogType.Log);
                BashSelectEnvironmentAndTerminalAndRun(TerminalType.External, PathHelper.GetScriptPath(Scripts.BooksiRun));
                break;
            case "AddScripts":
                Log.Write("Start running and adding scripts...", LogType.Log);
                BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, Scripts.AddScripts);
                break;
            case "Kill":
                Log.Write("Start killing...", LogType.Log);
                BashSelectEnvironmentAndTerminalAndRun(TerminalType.Internal, PathHelper.BashScriptPath, Scripts.BooksiKill);
                break;
            case "Exit":
                System.Environment.Exit(0);
                break;
            default:
                Menu(menuOptionList);
                break;
        }
    }
#endregion

#region RUNCODE
    public static void BashSelectEnvironmentAndTerminalAndRun(TerminalType terminalType, string path, string arguments = ""){
        switch (environmentType){
            default:
            case EnvironmentType.Mac:
                switch (terminalType){
                    case TerminalType.Internal:
                        BashRunInInternalTerminal(path, arguments);
                        break;
                    case TerminalType.External:
                        BashRunInExternalTerminalMac(PathHelper.GetScriptPath(arguments));
                        break;
                }
                break;
            case EnvironmentType.Win:
                switch (terminalType){
                    case TerminalType.Internal:
                        BashRunInInternalTerminal(path, arguments);
                        break;
                    case TerminalType.External:
                        BashRunInExternalTerminalWin(PathHelper.GetScriptPath(arguments));
                        break;
                }
                break;
        }
    }
    public static void BashRunInInternalTerminal(string path, string arguments){
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"\"{arguments}\"",
            WorkingDirectory = $"{path}", 
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = false
        };
        
        using var process = new Process { StartInfo = processStartInfo };

        process.OutputDataReceived += (sender, e) => Log.Write("Info:" + e.Data, LogType.Info);
        process.ErrorDataReceived += (sender, e) => Log.Write("Warning:" + e.Data, LogType.Warning);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();  
        
        Log.Write($"Build process exited with code {process.ExitCode}", LogType.Error);
    }
    public static void BashRunInExternalTerminalMac(string path){
        Process.Start("open", $"-a Terminal \"{path}\"");
    }

    public static void BashRunInExternalTerminalWin(string path){
        Process.Start("open", $"-a Terminal \"{path}\"");
    }

#endregion

}
