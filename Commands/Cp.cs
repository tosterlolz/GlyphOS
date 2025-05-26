using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS.Commands
{
    public static class Cp
    {
        public static void Execute(string arguments)
        {
            string[] cpArgs = arguments.Split(' ', 2);
            if (cpArgs.Length == 2)
            {
                string src = Path.Combine(Env.CurrentPath, cpArgs[0]);
                string dest = Path.Combine(Env.CurrentPath, cpArgs[1]);

                if (File.Exists(src))
                {
                    try
                    {
                        File.Copy(src, dest);
                        Logger.Info($"Copied {src} to {dest}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to copy file: {ex.Message}");
                    }
                }
                else
                {
                    Logger.Warning("Source file not found.");
                }
            }
            else
            {
                Logger.Warning("Usage: cp <src> <dest>");
            }
        }
    }
}
