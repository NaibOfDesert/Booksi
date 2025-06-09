public interface IMenuProvider
{
    string ShowMenu(string[] options);
}

public class MainWinMenuProvider : IMenuProvider
{
    private readonly EnvironmentType environmentType;

    public MainWinMenuProvider(EnvironmentType environmentType)
    {
        this.environmentType = environmentType;
    }

    public string ShowMenu(string[] menuList)
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

            consoleKey = (ConsoleKey)Log.Read(environmentType, true);

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