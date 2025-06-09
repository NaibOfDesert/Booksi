namespace Booksi.Runner.Helpers;

public interface ITerminalRunner
{
    void RunInInternal(string path, string arguments);
    void RunInExternal(string path);
}
