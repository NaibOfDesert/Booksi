using System.Diagnostics;

namespace Booksi.Runner.Helpers;

public class MainMacTerminalRunner : TerminalRunner, ITerminalRunner
{
    public void RunInExternal(string path)
    {
        Process.Start("open", $"-a Terminal \"{path}\"");
    }
}