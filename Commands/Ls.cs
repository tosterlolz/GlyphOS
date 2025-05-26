using System;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Ls
    {
        public static void Execute()
        {
            var filesList = Directory.GetFiles(Env.CurrentPath);
            var directoryList = Directory.GetDirectories(Env.CurrentPath);

            foreach (var file in filesList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(file);
                Console.ResetColor();
            }

            foreach (var directory in directoryList)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(directory);
                Console.ResetColor();
            }
        }
    }
}
