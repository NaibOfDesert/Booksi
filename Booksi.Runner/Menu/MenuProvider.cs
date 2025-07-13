using Booksi.Tools;

namespace Booksi.Runner.Menu;

public class MenuProvider
{
    private readonly EnvironmentType _environmentType;
    private DisplayMenuDelegate _displayMenuDelegate;
    private delegate string DisplayMenuDelegate(string[] menuList);

    public MenuProvider(EnvironmentType environmentType)
    {
        _environmentType = environmentType;
        SetMenuDelegate(); 
    }

    public string DisplayMenu(string[] menuList)
    {
        return _displayMenuDelegate(menuList);
    }
    private void SetMenuDelegate()
    {
        _displayMenuDelegate = _environmentType switch
        {
            EnvironmentType.Mac => DisplayTextInputMenu,
            EnvironmentType.Win => DisplayArrowNavigationMenu,
            _ => DisplayTextInputMenu
        };
    }
    
    private string DisplayTextInputMenu(string[] menuList)
    {
        string consoleInput;
        do
        {
            Log.Clear();
            Log.Write("Write chosen option. Press Enter to go next:\n", LogType.Info);
            Log.Write("Options:\n", LogType.Warning);
            
            foreach (var option in menuList)
            {
                Log.Write(option, LogType.Info);
            }
            
            consoleInput = (string)Log.Read(_environmentType);
        }
        while (!menuList.Contains(consoleInput));
        
        Log.Clear();
        return consoleInput;
    }

    private string DisplayArrowNavigationMenu(string[] menuList)
    {
        ConsoleKey consoleKey;
        int selectedOptionIndex = 0;

        do
        {
            Log.Clear();
            Log.Write("Use Up and Down arrows to navigate. Press Enter to select:\n", LogType.Info);
            Log.Write("Options:", LogType.Info);
            
            for (int i = 0; i < menuList.Length; i++)
            {
                var logType = i == selectedOptionIndex ? LogType.Selected : LogType.Log;
                Log.Write("  " + menuList[i], logType);
            }

            consoleKey = (ConsoleKey)Log.Read(_environmentType, true);

            selectedOptionIndex = consoleKey switch
            {
                ConsoleKey.UpArrow => selectedOptionIndex == 0 ? menuList.Length - 1 : selectedOptionIndex - 1,
                ConsoleKey.DownArrow => selectedOptionIndex == menuList.Length - 1 ? 0 : selectedOptionIndex + 1,
                _ => selectedOptionIndex
            };
        }
        while (consoleKey != ConsoleKey.Enter);
        
        Log.Clear();
        return menuList[selectedOptionIndex];
    }

}