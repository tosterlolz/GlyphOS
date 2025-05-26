using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Mv
    {
        public static void Execute(string arguments)
        {
            string[] mvArgs = arguments.Split(' ', 2);
            if (mvArgs.Length == 2)
            {
                string src = Path.Combine(Env.CurrentPath, mvArgs[0]);
                string dest = Path.Combine(Env.CurrentPath, mvArgs[1]);

                if (File.Exists(src))
                {
                    try
                    {
                        File.Copy(src, dest);
                        File.Delete(src);
                        Logger.Info($"Moved {src} to {dest}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to move file: {ex.Message}");
                    }
                }
                else
                {
                    Logger.Warning("Source file not found.");
                }
            }
            else
            {
                Logger.Warning("Usage: mv <src> <dest>");
            }
        }
    }
}
