using System;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Echo
    {
        public static void Execute(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                Console.WriteLine(arguments);
            }
            else
            {
                Logger.Warning("Usage: echo <text>");
            }
        }
    }
}
