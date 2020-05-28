using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

using BSL.FileSystem;

using Image = SixLabors.ImageSharp.Image;

namespace TooManyPixels
{
    internal static class ImageProcessor
    {
        internal static int ProcessedImageCount { get; private set; } = 0;
        internal static int IncompatibleFilesCopiedOver { get; private set; } = 0;
        internal static List<FileInfo> SourceFiles { get; private set; } = new List<FileInfo>();

        private static Stopwatch TimeTaken { get; } = new Stopwatch();

        internal static Task Initiate()
        {
            AddLog("Beginning...\r\n");
            if (!Program.CommandMode) Program.Form.ToggleControls();

            SourceFiles = Program.Settings.SourceDirectory.EnumerateFiles("*", Program.Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();

            if (!Program.CommandMode)
            {
                Program.Form.Invoke((MethodInvoker)delegate ()
                {
                    Program.Form.OverallProgressBar.Maximum = SourceFiles.Count;
                    Program.Form.OverallProgressBar.Value = 0;
                });
            }
            return Task.CompletedTask;
        }

        internal static async Task Run()
        {
            TimeTaken.Start();
            foreach (FileInfo inFile in SourceFiles)
            {
                FileInfo outFile = new FileInfo(inFile.FullName.Replace(inFile.DirectoryName, Program.Settings.DestinationDirectory.FullName)
                    .Replace(inFile.Extension, "." + Program.Settings.ConvertToNonAlphaValue.ToString().ToLower()));

                if (!inFile.Extension.ContainsAny(".png", ".jpg", ".bmp", ".gif"))
                {
                    if (Program.Settings.CopySkippedFiles) await FileSystemHelper.Copy(inFile, new FileInfo(outFile.FullName.Replace(outFile.Extension, inFile.Extension)), true);
                    IncompatibleFilesCopiedOver++;
                    if (!Program.CommandMode) Program.Form.IncrementOverallProgress();
                    continue;
                }

                if (!Program.CommandMode)
                {
                    Program.Form.Invoke((MethodInvoker)delegate ()
                    {
                        Program.Form.CurrentFileLabel.Text = "File: " + inFile.Name;
                    });
                }

                using (FileStream inStream = await FileIOHelper.OpenStream(inFile))
                {
                    byte[] imgData = new byte[inStream.Length];
                    await inStream.ReadAsync(imgData);
                    using MemoryStream memStr = new MemoryStream(imgData);
                    using Bitmap map = new Bitmap(memStr);
                    bool isAlphaPresent = map.PixelFormat == PixelFormat.Format16bppArgb1555 || map.PixelFormat == PixelFormat.Format32bppArgb ||
                                     map.PixelFormat == PixelFormat.Format32bppPArgb || map.PixelFormat == PixelFormat.Format64bppArgb ||
                                     map.PixelFormat == PixelFormat.Format64bppPArgb;

                    if (Program.Settings.DownsizeLargerResolutionImages && (map.Width <= Program.Settings.TargetImageWidth || map.Height <= Program.Settings.TargetImageHeight))
                    {
                        if (Program.Settings.CopySkippedFiles) await FileSystemHelper.Copy(inFile, new FileInfo(outFile.FullName.Replace(outFile.Extension, inFile.Extension)), true);
                        if (!Program.CommandMode) Program.Form.IncrementOverallProgress();
                        continue;
                    }

                    if (map.Width != map.Height && Program.Settings.OnlyPassSquareImages)
                    {
                        if (!Program.CommandMode) Program.Form.IncrementOverallProgress();
                        continue;
                    }

                    if (Program.Settings.UseAlphaFormatOnly || isAlphaPresent)
                    {
                        outFile = new FileInfo(inFile.FullName.Replace(inFile.DirectoryName, Program.Settings.DestinationDirectory.FullName)
                            .Replace(inFile.Extension, "." + Program.Settings.ConvertToAlphaValue.ToString().ToLower()));
                    }

                    using FileStream outStream = outFile.Create();
                    using (Image image = Image.Load(imgData, out IImageFormat format))
                    {
                        string ConvertToAlphaString = Program.Settings.ConvertToAlphaValue.ToString();
                        string ConvertToNonAlphaString = Program.Settings.ConvertToNonAlphaValue.ToString();

                        image.Mutate(c =>
                        {
                            c.Resize(Program.Settings.TargetImageWidth != 0 ? Program.Settings.TargetImageWidth : map.Width, Program.Settings.TargetImageHeight != 0 ? Program.Settings.TargetImageHeight : map.Height);
                        });

                        if (Program.Settings.UseAlphaFormatOnly || isAlphaPresent) ConvertTransparentFormat();
                        else ConvertNonTransparentFormat();
                        ProcessedImageCount++;

                        void ConvertNonTransparentFormat()
                        {
                            if (ConvertToNonAlphaString == "JPG")
                            {
                                image.SaveAsJpeg(outStream, new JpegEncoder
                                {
                                    Quality = 100 - Program.Settings.CompressionLevel
                                });
                                LogConversionState();
                            }
                            else if (ConvertToNonAlphaString == "BMP")
                            {
                                image.SaveAsBmp(outStream);
                                LogConversionState();
                            }
                        }

                        void ConvertTransparentFormat()
                        {
                            if (ConvertToAlphaString == "PNG")
                            {
                                image.SaveAsPng(outStream, new PngEncoder
                                {
                                    CompressionLevel = Program.Settings.CompressionLevel == 0 ? PngCompressionLevel.Level0 :
                                                       Program.Settings.CompressionLevel == 10 ? PngCompressionLevel.Level1 :
                                                       Program.Settings.CompressionLevel == 20 ? PngCompressionLevel.Level2 :
                                                       Program.Settings.CompressionLevel == 30 ? PngCompressionLevel.Level3 :
                                                       Program.Settings.CompressionLevel == 40 ? PngCompressionLevel.Level4 :
                                                       Program.Settings.CompressionLevel == 50 ? PngCompressionLevel.Level5 :
                                                       Program.Settings.CompressionLevel == 60 ? PngCompressionLevel.Level6 :
                                                       Program.Settings.CompressionLevel == 70 ? PngCompressionLevel.Level7 :
                                                       Program.Settings.CompressionLevel == 80 ? PngCompressionLevel.Level8 :
                                                       Program.Settings.CompressionLevel == 90 ? PngCompressionLevel.Level9 : PngCompressionLevel.Level9
                                });
                                LogConversionState();
                            }
                            else if (ConvertToAlphaString == "GIF")
                            {
                                image.SaveAsGif(outStream);
                                LogConversionState();
                            }
                        }

                        void LogConversionState()
                        {
                            if (Program.Settings.TargetImageWidth != 0 || Program.Settings.TargetImageHeight != 0 && outFile.Extension != inFile.Extension)
                                AddLog("Resized " + inFile.Name + " to " + Program.Settings.TargetImageWidth + "x" + Program.Settings.TargetImageHeight + " & converted to " + outFile.Extension.ToUpper()[1..] + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                            else if (Program.Settings.TargetImageWidth != 0 || Program.Settings.TargetImageHeight != 0)
                                AddLog("Resized " + inFile.Name + " to " + Program.Settings.TargetImageWidth + "x" + Program.Settings.TargetImageHeight + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                            else if (outFile.Extension != inFile.Extension)
                                AddLog("Converted " + inFile.Name + " to " + outFile.Extension.ToUpper()[1..] + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                        }

                        double GetPercentageReduction() => 100D - (100D * ((double)outFile.Length / (double)inFile.Length));
                    }
                }
                if (!Program.CommandMode) Program.Form.IncrementOverallProgress();
            }
            TimeTaken.Stop();
        }

        public static Task PrintResults()
        {
            if (!Program.CommandMode)
            {
                Program.Form.Invoke((MethodInvoker)delegate ()
                {
                    Program.Form.OverallProgressBar.Value = SourceFiles.ToList().Count;
                    Program.Form.OverallProgressLabel.Text = "Overall Progress: 100%";
                });
            }

            double sourceLength = 0L;
            double destinationLength = 0L;

            IEnumerable<FileInfo> destinationFiles = Program.Settings.DestinationDirectory.EnumerateFiles("*", Program.Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            foreach (FileInfo inf in Program.Settings.SourceDirectory.GetFiles("*", Program.Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) sourceLength += inf.Length;
            foreach (FileInfo inf in Program.Settings.DestinationDirectory.GetFiles("*", Program.Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) destinationLength += inf.Length;

            AddLog(Program.CommandMode ? string.Empty : "\r\n" + "Status of " + Program.Settings.SourceDirectory.FullName);
            AddLog("    - "
                + SourceFiles.Count(o => o.Extension.ToLower() == ".png") + " of PNG | "
                + SourceFiles.Count(o => o.Extension.ToLower() == ".gif") + " of GIF | " + SourceFiles.Count(o => o.Extension.ToLower() == ".jpg") + " of JPG | "
                + SourceFiles.Count(o => o.Extension.ToLower() == ".bmp") + " of BMP");
            AddLog("    - " + "Size: " + GetMegaBytes(sourceLength));

            AddLog(Program.CommandMode ? string.Empty : "\r\n" + "Status of " + Program.Settings.DestinationDirectory.FullName);
            AddLog("    - "
                + destinationFiles.Count(o => o.Extension.ToLower() == ".png") + " of PNG | "
                + destinationFiles.Count(o => o.Extension.ToLower() == ".gif") + " of GIF | " + destinationFiles.Count(o => o.Extension.ToLower() == ".jpg") + " of JPG | "
                + destinationFiles.Count(o => o.Extension.ToLower() == ".bmp") + " of BMP");
            AddLog("    - " + "Size: " + GetMegaBytes(destinationLength) + " | Reduction: " + (100D - ((destinationLength / sourceLength) * 100D)).ToString("0.00") + "%");
            AddLog("    - Images Converted: " + ProcessedImageCount);
            AddLog("    - Incompatible Files" + (Program.Settings.CopySkippedFiles ? " Copied Over" : string.Empty) + ": " + IncompatibleFilesCopiedOver);

            AddLog(Program.CommandMode ? string.Empty : "\r\n" + "Time taken: " + TimeTaken.ElapsedMilliseconds / 1000 + " seconds");
            if (!Program.CommandMode) Program.Form.ToggleControls();
            return Task.CompletedTask;

            static string GetMegaBytes(double bytes) => (bytes / 1024D / 1024D).ToString("0.00") + "MB";
        }

        private static async void AddLog(object log)
        {
            if (Program.CommandMode) await Logger.Log(LogLevel.Info, log);
            else
            {
                Program.Form.Invoke((MethodInvoker)delegate ()
                {
                    Program.Form.ConsoleTextBox.Text += log.ToString() + "\r\n";
                    Program.Form.ConsoleTextBox.SelectionStart = Program.Form.ConsoleTextBox.Text.Length;
                    Program.Form.ConsoleTextBox.ScrollToCaret();
                });
            }
        }
    }
}
