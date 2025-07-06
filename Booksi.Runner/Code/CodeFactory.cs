using System.Diagnostics;
using Booksi.Tools;

namespace Booksi.Runner.Code;

public static class CodeFactory
{
    private static EnvironmentType _environmentType;
    
    public static void EnvironmentSetUp(EnvironmentType environmentType){
        CodeFactory._environmentType = environmentType;
    }
    public static void BashSelectEnvironmentAndTerminalAndRun(TerminalType terminalType, string path, string arguments = ""){
        try
        {
            switch (_environmentType)
            {
                case EnvironmentType.Mac:
                    ExecuteMacCommand(terminalType, path, arguments);
                    break;
                case EnvironmentType.Win:
                    ExecuteWinCommand(terminalType, path, arguments);
                    break;
                default:
                    Log.Write($"Unsupported environment: {_environmentType}", LogType.Error);
                    break;
            }
        }
        catch (Exception ex)
        {
            Log.Write($"Error executing command: {ex.Message}", LogType.Error);
        }
    }
    
    private static void ExecuteMacCommand(TerminalType terminalType, string path, string arguments)
    {
        switch (terminalType)
        {
            case TerminalType.Internal:
                RunInternalTerminal(path, arguments);
                break;
            case TerminalType.External:
                RunExternalTerminalMac(path, arguments);
                break;
        }
    }

    private static void ExecuteWinCommand(TerminalType terminalType, string path, string arguments)
    {
        switch (terminalType)
        {
            case TerminalType.Internal:
                RunInternalTerminal(path, arguments);
                break;
            case TerminalType.External:
                RunExternalTerminalWin(path, arguments);
                break;
        }
    }
   
    private static void RunInternalTerminal(string path, string arguments)
    {
        var scriptPath = Path.Combine(path, $"{arguments}");
        
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"\"{scriptPath}\"",
            WorkingDirectory = path,
            UseShellExecute = false,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            CreateNoWindow = false
        };

        using var process = Process.Start(processStartInfo);
        if (process != null)
        {
            // INFO: to read output from process use:
            // var output = process.StandardOutput.ReadToEnd();
            // var error = process.StandardError.ReadToEnd();
            
            process.WaitForExit();
            
            // if (!string.IsNullOrEmpty(output))
            //     Log.Write(output, LogType.Log);
            //
            // if (!string.IsNullOrEmpty(error))
            //     Log.Write(error, LogType.Error);
                
            Log.Write($"Process exited with code: {process.ExitCode}", LogType.Info);
        }
    }

    private static void RunExternalTerminalMac(string path, string arguments)
    {
        var scriptPath = Path.Combine(path, $"{arguments}");
        
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "open",
            Arguments = $"-a Terminal \"{scriptPath}\"",
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        Process.Start(processStartInfo);
        Log.Write($"Started external terminal with script: {scriptPath}", LogType.Info);
    }

    private static void RunExternalTerminalWin(string path, string arguments)
    {
        var scriptPath = Path.Combine(path, $"{arguments}");
        
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c start \"Booksi Runner\" bash \"{scriptPath}\"",
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        Process.Start(processStartInfo);
        Log.Write($"Started external terminal with script: {scriptPath}", LogType.Info);
    }
}