using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Cd
    {
        public static void Execute(string arguments)
        {
            if (string.IsNullOrEmpty(arguments))
            {
                Logger.Warning("Usage: cd <path>");
                return;
            }

            string target = arguments.Trim();
            string newPath;

            if (target == @"\" || target.ToLower() == "root")
            {
                newPath = @"0:\";
            }
            else if (target == "..")
            {
                newPath = Path.GetDirectoryName(Env.CurrentPath.TrimEnd('\\'));
                if (string.IsNullOrEmpty(newPath) || newPath.Length < 3)
                {
                    newPath = @"0:\";
                }
            }
            else
            {
                newPath = Path.Combine(Env.CurrentPath, target);
            }

            newPath = Path.GetFullPath(newPath);

            if (Directory.Exists(newPath))
            {
                Env.CurrentPath = newPath;
            }
            else
            {
                Logger.Error("Directory not found: " + newPath);
            }
        }
    }
}
