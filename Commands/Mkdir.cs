using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Mkdir
    {
        public static void Execute(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                string dirPath = Path.Combine(Env.CurrentPath, arguments);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    Logger.Info($"Created directory: {dirPath}");
                }
                else
                {
                    Logger.Warning("Directory already exists.");
                }
            }
            else
            {
                Logger.Warning("Usage: mkdir <folder>");
            }
        }
    }
}
