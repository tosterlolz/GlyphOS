using System;

namespace GlyphOS.Resources
{
    public static class Logger
    {
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ Info ] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[ Warning ] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ Error ] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }
    }
}