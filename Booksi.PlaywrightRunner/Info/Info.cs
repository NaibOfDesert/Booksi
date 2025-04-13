using System;

public static class Info{
    public static void InfoRun(string text) {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Info: ");
        Console.ResetColor();
        Console.WriteLine(text);


    }

    public static void InfoTest(string text) {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Test: ");
        Console.ResetColor();
        Console.WriteLine(text);


    }

        public static void InfoTestPass(string text) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Test: ");
        Console.ResetColor();
        Console.WriteLine(text);


    }

        public static void InfoTestFail(string text) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Test: ");
        Console.ResetColor();
        Console.WriteLine(text);


    }
}