using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Help
    {
        public static void Execute()
        {
            Logger.Info("Available commands:");
            Logger.Info("  help             Show this help message");
            Logger.Info("  ls               List files and directories");
            Logger.Info("  mkdir <folder>   Create directory");
            Logger.Info("  rmdir <folder>   Remove directory (recursively)");
            Logger.Info("  cd <path>        Change directory");
            Logger.Info("  pwd              Show current path");
            Logger.Info("  rm <file>        Delete file");
            Logger.Info("  cp <src> <dest>  Copy file");
            Logger.Info("  mv <src> <dest>  Move file or folder");
            Logger.Info("  diskutil list    List available disks");
            Logger.Info("  touch <file>     Create empty file");
            Logger.Info("  exit             Shutdown");
            Logger.Info("  cat <file>       Show file content");
            Logger.Info("  write <file> <text>   Write text to file");
            Logger.Info("  clear            Clear the terminal screen");
            Logger.Info("  echo <text>      Display the text");
            Logger.Info("  date             Display the current date and time");
            Logger.Info("  lua <file.lua>   Execute lua code");
        }
    }
}
