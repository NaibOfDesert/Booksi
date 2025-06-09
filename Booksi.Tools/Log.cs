using System;

public static class Log {

    private static readonly ConsoleColor logForegroundColor  = ConsoleColor.Green;
    private static readonly ConsoleColor infoForegroundColor  = ConsoleColor.Blue;
    private static readonly ConsoleColor warningForegroundColor  = ConsoleColor.Yellow;
    private static readonly ConsoleColor successForegroundColor  = ConsoleColor.Green;
    private static readonly ConsoleColor errorForegroundColor  = ConsoleColor.Red;
    private static readonly ConsoleColor selectedForegroundColor  = ConsoleColor.Green;
    private static readonly ConsoleColor selectedBackgroundColor  = ConsoleColor.White;

    public static void Clear(){
        Console.Clear();
    }
    public static void Write(string message, LogType logType) {
        switch(logType){
            default:
            case LogType.Log:
                Console.ForegroundColor = logForegroundColor;
                break;
            case LogType.Info:
                Console.ForegroundColor = infoForegroundColor;
                break;
            case LogType.Warning:
                Console.ForegroundColor = warningForegroundColor;
                break;
            case LogType.Success:
                Console.ForegroundColor = successForegroundColor;
                break;
            case LogType.Error:
                Console.ForegroundColor = errorForegroundColor;
                break;
            case LogType.Selected:
                Console.ForegroundColor = selectedForegroundColor;
                Console.BackgroundColor = selectedBackgroundColor;
                break;
        }
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static object Read(EnvironmentType setUp = EnvironmentType.Mac, bool clicked = false){
        switch(setUp){
            default:
            case EnvironmentType.Mac:
                return Console.ReadLine();
            case EnvironmentType.Win:
                return Console.ReadKey(clicked).Key;
        }
    }
    public static ConsoleKeyInfo ReadLine(){
        return Console.ReadKey();
    }

}