using System.Diagnostics;
using Booksi.Tools;

namespace Booksi.Runner.Helpers;

public static class CodeFactory
{
    // private static EnvironmentType environmentType;
    // private static ITerminalRunner terminalRunner;
    
    public static void EnvironmentSetUp(EnvironmentType environmentType){
        CodeFactory.environmentType = environmentType;
    }
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
    
    private static ProcessStartInfo CreateProcessStartInfo(string path, string arguments)
    {
        return new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"\"{arguments}\"",
            WorkingDirectory = path,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = false
        };
    }
    
    public static ITerminalRunner CreateRunner(EnvironmentType environmentType)
    {
        return environmentType switch
        {
            EnvironmentType.Mac => new MainMacTerminalRunner(),
            EnvironmentType.Win => new MainWinTerminalRunner(),
            _ => new MainMacTerminalRunner()
        };
    }
    public static void BashRunInExternalTerminalMac(string path){
        Process.Start("open", $"-a Terminal \"{path}\"");
    }

    public static void BashRunInExternalTerminalWin(string path){
        Process.Start("open", $"-a Terminal \"{path}\"");
    }
    







}