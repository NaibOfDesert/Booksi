public static class Log {

    private static ConsoleColor logForegroundColor  = ConsoleColor.Black;
    private static ConsoleColor infoForegroundColor  = ConsoleColor.Blue;
    private static ConsoleColor warningForegroundColor  = ConsoleColor.Yellow;
    private static ConsoleColor successForegroundColor  = ConsoleColor.Green;
    private static ConsoleColor errorForegroundColor  = ConsoleColor.Red;
    private static ConsoleColor selectedForegroundColor  = ConsoleColor.Green;
    private static ConsoleColor selectedBackgroundColor  = ConsoleColor.Black;


    public static void LogWrite(string message, LogType logType) {
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
            case LogType.Succes:
                Console.ForegroundColor = warningForegroundColor;
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
}