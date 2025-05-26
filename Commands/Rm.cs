using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Rm
    {
        public static void Execute(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                string filePath = Path.Combine(Env.CurrentPath, arguments);
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                        Logger.Info($"Removed file: {filePath}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to delete file: {ex.Message}");
                    }
                }
                else
                {
                    Logger.Warning("File not found.");
                }
            }
            else
            {
                Logger.Warning("Usage: rm <file>");
            }
        }
    }
}
