namespace Booksi.Runner.Helpers;

public class TerminalRunner
{
    public void RunInInternal(string path, string arguments)
    {
        CodeFactory.BashRunInInternalTerminal(path, arguments);
    }
}