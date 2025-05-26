﻿using System;
using System.IO;
using GlyphOS.Resources;
using Sys = Cosmos.System;

namespace GlyphOS.Resources
{
    public class Kernel : Sys.Kernel
    {
        public static string file;
        protected override void BeforeRun()
        {
            Console.SetWindowSize(90, 30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            Logger.Info("Loaded Font.");
            FileSystem.Init();
            Logger.Info("Initialized Filesystem.");
            Logger.Info($"Welcome to GlyphOS {Env.Version}!");
            Logger.Info("Type 'help' for a list of commands.");
        }

        protected override void Run()
        {
            Console.Write($"{Env.CurrentPath} $ ");
            string input = Console.ReadLine();
            Shell.ProcessCommand(input);
        }
    }
}