using System.Diagnostics;

namespace Booksi.Runner.Helpers;

public class MainWinTerminalRunner : TerminalRunner, ITerminalRunner
{
    public void RunInExternal(string path)
    {
        Process.Start("cmd", $"/c start \"\" \"{path}\"");
    }
}