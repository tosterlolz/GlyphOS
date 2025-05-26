using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Touch
    {
        public static void Execute(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                string filePath = Path.Combine(Env.CurrentPath, arguments);
                if (!File.Exists(filePath))
                {
                    try
                    {
                        using (File.Create(filePath)) { }
                        Logger.Info($"Created file: {filePath}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to create file: {ex.Message}");
                    }
                }
                else
                {
                    Logger.Warning("File already exists.");
                }
            }
            else
            {
                Logger.Warning("Usage: touch <file>");
            }
        }
    }
}
