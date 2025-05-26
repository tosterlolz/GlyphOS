using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Cat
    {
        public static void Execute(string arguments)
        {
            if (string.IsNullOrEmpty(arguments))
            {
                Logger.Warning("Usage: cat <file>");
                return;
            }

            string filePath = Path.Combine(Env.CurrentPath, arguments);

            if (File.Exists(filePath))
            {
                try
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error reading file: {ex.Message}");
                }
            }
            else
            {
                Logger.Warning("File not found.");
            }
        }
    }
}
