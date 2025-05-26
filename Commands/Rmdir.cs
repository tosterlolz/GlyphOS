using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Rmdir
    {
        public static void Execute(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                string dirPath = Path.Combine(Env.CurrentPath, arguments);
                if (Directory.Exists(dirPath))
                {
                    try
                    {
                        Directory.Delete(dirPath, recursive: true);
                        Logger.Info($"Removed directory: {dirPath}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to delete directory: {ex.Message}");
                    }
                }
                else
                {
                    Logger.Warning("Directory not found.");
                }
            }
            else
            {
                Logger.Warning("Usage: rmdir <folder>");
            }
        }
    }
}
