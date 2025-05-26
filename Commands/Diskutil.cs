using Cosmos.System.FileSystem.VFS;
using System.IO;
using GlyphOS.Resources;

namespace GlyphOS
{
    public static class DiskUtil
    {
        public static void Execute(string arguments)
        {
            string[] diskArgs = arguments.Split(' ', 2);
            if (diskArgs.Length < 1)
            {
                Logger.Warning("Usage: diskutil <action> (<index>)");
                return;
            }

            string action = diskArgs[0].ToLower();
            string index = diskArgs.Length > 1 ? diskArgs[1] : string.Empty;

            if (action == "format")
            {
                string diskPath = $"{index}:\\";

                if (Directory.Exists(diskPath))
                {
                    FileSystem.FormatDisk(diskPath);
                }
                else
                {
                    Logger.Error($"Disk {index} not found.");
                }
            }
            else if (action == "info")
            {
                string diskPath = $"{index}:\\";

                if (Directory.Exists(diskPath))
                {
                    FileSystem.PrintDiskInfo(diskPath);
                }
                else
                {
                    Logger.Error($"Disk {index} not found.");
                }
            }
            else if (action == "list")
            {
                Logger.Info("Available disks:");
                VFSManager.GetDisks();
            }
            else
            {
                Logger.Warning("Unknown diskutil action. Only 'format' is supported.");
            }
        }
    }
}
