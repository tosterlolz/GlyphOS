using System;
using MoonSharp.Interpreter;

namespace GlyphOS
{
    public static class Lua
    {
        public static int Execute(string[] arguments)
        {
            if (arguments.Length < 1)
            {
                Console.WriteLine("Usage: lua <file.lua>");
                return 1;
            }

            string filePath = arguments[0];
            try
            {
                string scriptCode = System.IO.File.ReadAllText(filePath);
                Script script = new Script();
                DynValue result = script.DoString(scriptCode);

                if (result != null && result.Type != DataType.Void && result.Type != DataType.Nil)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
            return 0;
        }
    }
}