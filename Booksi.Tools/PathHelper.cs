using System;
using System.IO;

namespace Booksi.Tools
{
    public static class PathHelper
    {
        public static string OutputPath =>
            AppContext.BaseDirectory;

        public static string ProjectRoot =>
            Path.GetFullPath(Path.Combine(OutputPath, "../../../"));

        public static string BashScriptPath =>
            Path.Combine(ProjectRoot, "BashScript");

        public static string GetScriptPath(string scriptName) =>
            Path.Combine(BashScriptPath, scriptName);

        public static string SolutionRoot =>
            Path.GetFullPath(Path.Combine(ProjectRoot, ".."));

        public static void DebugPrintAll()
        {
            Console.WriteLine("📁 OutputPath:     " + OutputPath);
            Console.WriteLine("📁 ProjectRoot:    " + ProjectRoot);
            Console.WriteLine("📁 BashScriptPath: " + BashScriptPath);
            Console.WriteLine("📁 SolutionRoot:   " + SolutionRoot);
        }
    }
}
