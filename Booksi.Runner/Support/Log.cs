public static class Log {

    private static ConsoleColor logForegroundColor  = ConsoleColor.White;
    private static ConsoleColor infoForegroundColor  = ConsoleColor.Blue;
    private static ConsoleColor warningForegroundColor  = ConsoleColor.Yellow;
    private static ConsoleColor errorForegroundColor  = ConsoleColor.Red;
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
            case LogType.Error:
                    Console.ForegroundColor = errorForegroundColor;
                break;
        }
        Console.WriteLine(message + "\n");
        Console.ResetColor();
    }
}