

public class MainMacMenuProvider : IMenuProvider
{
    private readonly EnvironmentType environmentType;

    public MainMacMenuProvider(EnvironmentType environmentType)
    {
        this.environmentType = environmentType;
    }
    
    public string ShowMenu(string[] menuList)
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
            
            consoleInput = (string)Log.Read(environmentType);
        }
        while (!menuList.Contains(consoleInput));
        
        Log.Clear();
        return consoleInput;
    }
}