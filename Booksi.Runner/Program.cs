using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
public class Program{
    private static string path => Path.GetFullPath("Booksi.Runner").Replace("/Booksi.Runner", "");
    private static string environment = string.Empty;

    private static string[] menuOptionList = {"Build", "Up", "Run", "Exit"};
    private static string[] menuUpOptionList = {"DockerCompose", "DbAdd", "DbUpdate", "Back"};
    static void Main(string[] args){
        string menuOption;

        if (args.Length > 0)
            environment = args[0].ToLower();

        do{
            menuOption = Menu(menuOptionList);
            Switch(menuOption);
        }
        while (menuOption != "Exit"); 
    }

#region MENU
    private static string Menu(string[] menuList){
        string menuOption;

        switch (environment){
            case "MAC":
                menuOption = MenuInput(menuList);
                break;
            case "WIN":
            case null:
            default:
                menuOption = MenuKey(menuList);
                break;
        }
        return menuOption;
    }

    private static string MenuKey(string[] menuList){
        ConsoleKey consoleKey; 
        int seclectedOptionIndex = 0;

        do{
            Console.Clear();
            Log.LogWrite("Use Up and Down arrows to navigate. Press Enter to select:\n", LogType.Info);
            Console.WriteLine("Options:\n");
            for(int i = 0; i < menuList.Length; i++){
                if(i == seclectedOptionIndex){
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("" + menuList[i]);
                Console.ResetColor();
            }

            consoleKey = Console.ReadKey(true).Key;

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
        Console.Clear();
        return menuOptionList[seclectedOptionIndex];
    }

    private static string MenuInput(string[] menuList){
        string consoleInput = String.Empty;
        do{
            Console.Clear();
            Console.WriteLine("Write choosen option. Press Enter to go next:\n");
            Console.WriteLine("Options:\n");
            for(int i = 0; i < menuList.Length; i++){
                Console.WriteLine("" + menuList[i]);
            }
            consoleInput = Console.ReadLine();
        }
        while(!menuList.Contains(consoleInput));
        Console.Clear();
        return consoleInput;
    }

    private static void Switch(string optionMain) {
        switch (optionMain) {
            case "Build":
                Console.WriteLine("Starting build...");
                BashRun("/bin/bash", "BashBuild.sh", "");
                Console.ReadKey();
                break;
            case "Up":
                Console.WriteLine("Up\n");
                switch (Menu(menuUpOptionList)){
                    case "DockerCompose":
                        Console.WriteLine("Starting building docker image...");

                        break;

                    case "DbAdd":
                        Console.WriteLine("Starting adding database...");

                        break;

                    case "DbUpdate":
                        Console.WriteLine("Starting updating database...");

                        break;
                    case "Back":
                        Menu(menuOptionList);
                        break;
                    default:
                        break;
                }         
                break;
            case "Run":
                Console.WriteLine("Run");
                break;
            case "Exit":
                System.Environment.Exit(0);
                break;
            default:
                break;
        }
    }
#endregion

#region RUNCODE

    //TODO: delete
    public static void BuildProject(){
        var projectPath = $"{path}/Booksi/Booksi.csproj";

        var process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"build {projectPath}";
        process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
        process.ErrorDataReceived += (sender, e) => Console.WriteLine("ERROR: " + e.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();  
        
        Console.WriteLine($"Build process exited with code {process.ExitCode}");
    }
    public static void BashRun(string fileName, string arguments, string projectPath){
        var process = new Process();
        process.StartInfo.FileName = $"{fileName}";
        process.StartInfo.Arguments = $"{arguments}";
        process.StartInfo.WorkingDirectory = $"{path}{projectPath}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = false;

        process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
        process.ErrorDataReceived += (sender, e) => Console.WriteLine("ERROR: " + e.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();  
        
        Console.WriteLine($"Build process exited with code {process.ExitCode}");
    }
#endregion

}
