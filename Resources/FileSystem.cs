using System;
using System.IO;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace GlyphOS.Resources
{
    public static class FileSystem
    {
        private static CosmosVFS vfs;
        public static string CurrentDirectory { get; private set; } = "0:";

        public static void Init()
        {
            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);
            Logger.Info("Filesystem initialized.");
        }

        public static void ListFiles()
        {
            var files = Directory.GetFiles(CurrentDirectory);
            foreach (var file in files)
            {
                Logger.Info(file);
            }
        }

        public static void ReadFile(string path)
        {
            string fullPath = Path.Combine(CurrentDirectory, path);
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                Console.WriteLine(content);
            }
            else
            {
                Logger.Error("File not found.");
            }
        }

        public static void WriteFile(string path, string content)
        {
            string fullPath = Path.Combine(CurrentDirectory, path);
            File.WriteAllText(fullPath, content);
            Logger.Info("File written successfully.");
        }

        public static void FormatDisk(string rootPath)
        {
            Logger.Info($"Gathering info for disk {rootPath}");

            int fileCount = 0;
            int dirCount = 0;

            GetDiskInfoRecursive(rootPath, ref fileCount, ref dirCount);

            Logger.Info($"Disk info:");
            Logger.Info($"  Files: {fileCount}");
            Logger.Info($"  Folders: {dirCount}");

            Logger.Warning("Formatting disk...");

            try
            {
                FormatDirectoryRecursive(rootPath);
                Logger.Info("Disk formatted successfully.");
            }
            catch (Exception ex)
            {
                Logger.Error("Format failed: " + ex.Message);
            }
        }

        private static void GetDiskInfoRecursive(string path, ref int fileCount, ref int dirCount)
        {
            var files = Directory.GetFiles(path);
            fileCount += files.Length;

            var dirs = Directory.GetDirectories(path);
            dirCount += dirs.Length;

            foreach (var dir in dirs)
            {
                GetDiskInfoRecursive(dir, ref fileCount, ref dirCount);
            }
        }

        private static void FormatDirectoryRecursive(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                File.Delete(file);
            }

            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                FormatDirectoryRecursive(dir);
                Directory.Delete(dir);
            }
        }
        public static void PrintDiskInfo(string rootPath)
        {
            Logger.Info($"Gathering info for disk {rootPath}");

            int fileCount = 0;
            int dirCount = 0;
            var fs_type = vfs.GetFileSystemType(rootPath);

            GetDiskInfoRecursive(rootPath, ref fileCount, ref dirCount);

            Logger.Info($"Disk info:");
            Logger.Info($"  Files: {fileCount}");
            Logger.Info($"  Folders: {dirCount}");
            Logger.Info($"  FileSystem: {fs_type}");
        }


    }
}