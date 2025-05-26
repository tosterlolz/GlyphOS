using System;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Date
    {
        public static void Execute()
        {
            Logger.Info($"Current date and time: {DateTime.Now}");
        }
    }
}
