using System;


public class Program{
    private static string[] menuOptionList = {"Build", "Up", "Run", "Exit"};
    private static string[] menuUpOptionList = {"Build", "Up", "Run", "Back"};
    private static int seclectedOptionIndex = 0;
    private static ConsoleKey consoleKey; 

    static void Main(string[] args){
        string option = "";
        do{
            option = Menu(menuOptionList);
            Switch(option);

        }
        while (option != "Exit"); 


    }

    private static string Menu(string[] menuList){
        seclectedOptionIndex = 0;
        do{
            Console.Clear();
            Console.WriteLine("Use Up and Down arrows to navigate. Press Enter to select:\n");

            for(int i = 0; i < menuList.Length; i++){
                if(i == seclectedOptionIndex){
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(menuList[i]);
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
    private static void Switch(string input1, string input2 = "") {
        switch (input1) {
            case "Build":
                Console.WriteLine("Build\n");
                System.Diagnostics.Process.Start("dotnet", "build --project ../Booksi.csproj");
                break;
            case "Up":
                Console.WriteLine("Up\n");
                Menu(menuUpOptionList);
                switch (input2){
                    case "1":
                    break;


                    default:
                    break;
                }
                
                // System.Diagnostics.Process.Start("dotnet", "run --project ../Booksi.PlaywrightRunner/Booksi.PlaywrightRunner.csproj");
                break;
            case "Run":
                Console.WriteLine("Run");
                break;
            case "Back":
                Console.WriteLine("Back");
                Menu(menuOptionList);
                break;
            case "Exit":
                break;
            default:
                break;
        }


    }

    void Clear() {
        System.Diagnostics.Process.Start("clear");
    }
}
