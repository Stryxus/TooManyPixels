using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using BSL;

namespace TooManyPixels
{
    internal static class Program
    {
        internal static bool CommandMode { get; private set; } = false;
        internal static ProcessorSettings Settings { get; private set; } = new ProcessorSettings();
        internal static TooManyPixelsForm Form { get; private set; }

        [STAThread]
        internal static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();
        private static async Task MainAsync(string[] args)
        {
            await Logger.Log(LogLevel.Info, "Parsing arguments...");
            await ArgumentHandler.ParseArgumentsFromArray(args, out List<ParsedArgument> parsedArgs);
            CommandMode = !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            foreach (ParsedArgument a in parsedArgs)
            {
                await Logger.Log(LogLevel.Debug, a.Command + " | " + a.Value);
                if (a.Command == "noui") CommandMode = true;
                if (a.Command == "source") Settings.SourceDirectory = new DirectoryInfo(a.Value);
                if (a.Command == "destination") Settings.DestinationDirectory = new DirectoryInfo(a.Value);
                if (a.Command == "onlyAlpha") Settings.UseAlphaFormatOnly = true;
                if (a.Command == "recursive") Settings.IsRecurive = true;
                if (a.Command == "onlySquare") Settings.OnlyPassSquareImages = true;
                if (a.Command == "downsize") Settings.DownsizeLargerResolutionImages = true;
                if (a.Command == "copy") Settings.CopySkippedFiles = true;
                if (a.Command == "compression") Settings.CompressionLevel = int.Parse(a.Value);
                if (a.Command == "targetWidth") Settings.TargetImageWidth = int.Parse(a.Value);
                if (a.Command == "targetHeight") Settings.TargetImageHeight = int.Parse(a.Value);
                if (a.Command == "nonAlphaFormat") Settings.ConvertToNonAlphaValue = (SupportedNonAlphaFileTypes)int.Parse(a.Value);
                if (a.Command == "alphaFormat") Settings.ConvertToAlphaValue = (SupportedAlphaFileTypes)int.Parse(a.Value);
            }
            if (!CommandMode)
            {
                await Logger.Log(LogLevel.Info, "Starting Application UI.");
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Form = new TooManyPixelsForm());
            } 
            else
            {
                await Logger.Log(LogLevel.Info, "Starting Application.");
                await ImageProcessor.Initiate();
                await ImageProcessor.Run();
                await ImageProcessor.PrintResults();
            }
        }
    }
}
