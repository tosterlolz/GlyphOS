using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Write
    {
        public static void Execute(string arguments)
        {
            string[] writeArgs = arguments.Split(' ', 2);
            if (writeArgs.Length < 2)
            {
                Logger.Warning("Usage: write <file> <text>");
                return;
            }

            string filePath = Path.Combine(Env.CurrentPath, writeArgs[0]);
            string text = writeArgs[1];

            try
            {
                File.WriteAllText(filePath, text);
                Logger.Info($"Written to file: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error writing to file: {ex.Message}");
            }
        }
    }
}
