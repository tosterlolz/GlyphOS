using GlyphOS.Commands;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Shell
    {
        public static void ProcessCommand(string input)
        {
            string[] args = input.Split(' ', 2);
            string command = args[0].ToLower();
            string arguments = args.Length > 1 ? args[1] : string.Empty;

            switch (command)
            {
                case "help":
                    Help.Execute();
                    break;

                case "ls":
                    Ls.Execute();
                    break;

                case "mkdir":
                    Mkdir.Execute(arguments);
                    break;

                case "rmdir":
                    Rmdir.Execute(arguments);
                    break;

                case "cd":
                    Cd.Execute(arguments);
                    break;

                case "pwd":
                    Pwd.Execute();
                    break;

                case "rm":
                    Rm.Execute(arguments);
                    break;

                case "cp":
                    Cp.Execute(arguments);
                    break;

                case "mv":
                    Mv.Execute(arguments);
                    break;

                case "diskutil":
                    DiskUtil.Execute(arguments);
                    break;

                case "touch":
                    Touch.Execute(arguments);
                    break;

                case "exit":
                    Exit.Execute();
                    break;

                case "cat":
                    Cat.Execute(arguments);
                    break;

                case "write":
                    Write.Execute(arguments);
                    break;
               
                case "clear":
                    Clear.Execute();
                    break;

                case "echo":
                    Echo.Execute(arguments);
                    break;

                case "date":
                    Date.Execute();
                    break;

                default:
                    Logger.Error("Unknown command");
                    break;
            }
        }
    }
}