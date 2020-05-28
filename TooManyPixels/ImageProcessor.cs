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
        private static ProcessorSettings Settings { get; set; }
        internal static int ProcessedImageCount { get; private set; } = 0;
        internal static int IncompatibleFilesCopiedOver { get; private set; } = 0;
        internal static List<FileInfo> SourceFiles { get; private set; }

        private static Stopwatch TimeTaken { get; } = new Stopwatch();

        internal static Task Initiate(ProcessorSettings settings)
        {
            Program.Form.AddLog("Beginning...\r\n");
            Program.Form.ToggleControls();

            Settings = settings;
            SourceFiles = Settings.SourceDirectory.EnumerateFiles("*", Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();

            Program.Form.Invoke((MethodInvoker)delegate ()
            {
                Program.Form.OverallProgressBar.Maximum = SourceFiles.Count;
                Program.Form.OverallProgressBar.Value = 0;
            });
            return Task.CompletedTask;
        }

        internal static async Task Run()
        {
            TimeTaken.Start();
            foreach (FileInfo inFile in SourceFiles)
            {
                FileInfo outFile = new FileInfo(inFile.FullName.Replace(inFile.DirectoryName, Settings.DestinationDirector.FullName)
                    .Replace(inFile.Extension, "." + Settings.ConvertToNonAlphaValue.ToString().ToLower()));

                if (!inFile.Extension.ContainsAny(".png", ".jpg", ".bmp", ".gif"))
                {
                    if (Settings.CopySkippedFiles) await FileSystemHelper.Copy(inFile, new FileInfo(outFile.FullName.Replace(outFile.Extension, inFile.Extension)), true);
                    IncompatibleFilesCopiedOver++;
                    Program.Form.IncrementOverallProgress();
                    continue;
                }

                Program.Form.Invoke((MethodInvoker)delegate ()
                {
                    Program.Form.CurrentFileLabel.Text = "File: " + inFile.Name;
                });

                using (FileStream inStream = await FileIOHelper.OpenStream(inFile))
                {
                    byte[] imgData = new byte[inStream.Length];
                    await inStream.ReadAsync(imgData);
                    using MemoryStream memStr = new MemoryStream(imgData);
                    using Bitmap map = new Bitmap(memStr);
                    bool isAlphaPresent = map.PixelFormat == PixelFormat.Format16bppArgb1555 || map.PixelFormat == PixelFormat.Format32bppArgb ||
                                     map.PixelFormat == PixelFormat.Format32bppPArgb || map.PixelFormat == PixelFormat.Format64bppArgb ||
                                     map.PixelFormat == PixelFormat.Format64bppPArgb;

                    if (Settings.DownsizeLargerResolutionImages && (map.Width <= Settings.TargetImageWidth || map.Height <= Settings.TargetImageHeight))
                    {
                        if (Settings.CopySkippedFiles) await FileSystemHelper.Copy(inFile, new FileInfo(outFile.FullName.Replace(outFile.Extension, inFile.Extension)), true);
                        Program.Form.IncrementOverallProgress();
                        continue;
                    }

                    if (map.Width != map.Height && Settings.OnlyPassSquareImages)
                    {
                        Program.Form.IncrementOverallProgress();
                        continue;
                    }

                    if (Settings.UseAlphaFormatOnly || isAlphaPresent)
                    {
                        outFile = new FileInfo(inFile.FullName.Replace(inFile.DirectoryName, Settings.DestinationDirector.FullName)
                            .Replace(inFile.Extension, "." + Settings.ConvertToAlphaValue.ToString().ToLower()));
                    }

                    using FileStream outStream = outFile.Create();
                    using (Image image = Image.Load(imgData, out IImageFormat format))
                    {
                        string ConvertToAlphaString = Settings.ConvertToAlphaValue.ToString();
                        string ConvertToNonAlphaString = Settings.ConvertToNonAlphaValue.ToString();
                        bool resized = Settings.TargetImageWidth != 0 || Settings.TargetImageHeight != 0;

                        image.Mutate(c =>
                        {
                            c.Resize(Settings.TargetImageWidth != 0 ? Settings.TargetImageWidth : map.Width, Settings.TargetImageHeight != 0 ? Settings.TargetImageHeight : map.Height);
                        });

                        if (Settings.UseAlphaFormatOnly || isAlphaPresent) ConvertTransparentFormat();
                        else ConvertNonTransparentFormat();
                        ProcessedImageCount++;

                        void ConvertNonTransparentFormat()
                        {
                            if (ConvertToNonAlphaString == "JPG")
                            {
                                image.SaveAsJpeg(outStream, new JpegEncoder
                                {
                                    Quality = 100 - Settings.CompressionLevel
                                });
                                LogConversionState(ConvertToNonAlphaString);
                            }
                            else if (ConvertToNonAlphaString == "BMP")
                            {
                                image.SaveAsBmp(outStream);
                                LogConversionState(ConvertToNonAlphaString);
                            }
                        }

                        void ConvertTransparentFormat()
                        {
                            if (ConvertToAlphaString == "PNG")
                            {
                                image.SaveAsPng(outStream, new PngEncoder
                                {
                                    CompressionLevel = Settings.CompressionLevel == 0 ? PngCompressionLevel.Level0 :
                                                       Settings.CompressionLevel == 10 ? PngCompressionLevel.Level1 :
                                                       Settings.CompressionLevel == 20 ? PngCompressionLevel.Level2 :
                                                       Settings.CompressionLevel == 30 ? PngCompressionLevel.Level3 :
                                                       Settings.CompressionLevel == 40 ? PngCompressionLevel.Level4 :
                                                       Settings.CompressionLevel == 50 ? PngCompressionLevel.Level5 :
                                                       Settings.CompressionLevel == 60 ? PngCompressionLevel.Level6 :
                                                       Settings.CompressionLevel == 70 ? PngCompressionLevel.Level7 :
                                                       Settings.CompressionLevel == 80 ? PngCompressionLevel.Level8 :
                                                       Settings.CompressionLevel == 90 ? PngCompressionLevel.Level9 : PngCompressionLevel.Level9
                                });
                                LogConversionState(ConvertToAlphaString);
                            }
                            else if (ConvertToAlphaString == "GIF")
                            {
                                image.SaveAsGif(outStream);
                                LogConversionState(ConvertToAlphaString);
                            }
                        }

                        void LogConversionState(string format)
                        {
                            if (resized && "." + format.ToLower() == inFile.Extension.ToLower())
                                Program.Form.AddLog("Resized " + inFile.Name + " to " + Settings.TargetImageWidth + "x" + Settings.TargetImageHeight + " & converted to " + format + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                            else if (resized)
                                Program.Form.AddLog("Resized " + inFile.Name + " to " + Settings.TargetImageWidth + "x" + Settings.TargetImageHeight + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                            else if ("." + format.ToLower() == inFile.Extension.ToLower())
                                Program.Form.AddLog("Converted " + inFile.Name + " to " + format + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                        }

                        double GetPercentageReduction() => 100D - (100D * ((double)outFile.Length / (double)inFile.Length));
                    }
                }
                Program.Form.IncrementOverallProgress();
            }
            TimeTaken.Stop();
        }

        public static Task PrintResults()
        {
            Program.Form.Invoke((MethodInvoker)delegate ()
            {
                Program.Form.OverallProgressBar.Value = SourceFiles.ToList().Count;
                Program.Form.OverallProgressLabel.Text = "Overall Progress: 100%";
            });

            double sourceLength = 0L;
            double destinationLength = 0L;

            IEnumerable<FileInfo> destinationFiles = Settings.DestinationDirector.EnumerateFiles("*", Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            foreach (FileInfo inf in Settings.SourceDirectory.GetFiles("*", Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) sourceLength += inf.Length;
            foreach (FileInfo inf in Settings.DestinationDirector.GetFiles("*", Settings.IsRecurive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) destinationLength += inf.Length;

            Program.Form.AddLog("\r\nStatus of " + Settings.SourceDirectory.FullName);
            Program.Form.AddLog("    - "
                + SourceFiles.Count(o => o.Extension.ToLower() == ".png") + " of PNG | "
                + SourceFiles.Count(o => o.Extension.ToLower() == ".gif") + " of GIF | " + SourceFiles.Count(o => o.Extension.ToLower() == ".jpg") + " of JPG | "
                + SourceFiles.Count(o => o.Extension.ToLower() == ".bmp") + " of BMP");
            Program.Form.AddLog("    - " + "Size: " + GetMegaBytes(sourceLength));

            Program.Form.AddLog("\r\nStatus of " + Settings.DestinationDirector.FullName);
            Program.Form.AddLog("    - "
                + destinationFiles.Count(o => o.Extension.ToLower() == ".png") + " of PNG | "
                + destinationFiles.Count(o => o.Extension.ToLower() == ".gif") + " of GIF | " + destinationFiles.Count(o => o.Extension.ToLower() == ".jpg") + " of JPG | "
                + destinationFiles.Count(o => o.Extension.ToLower() == ".bmp") + " of BMP");
            Program.Form.AddLog("    - " + "Size: " + GetMegaBytes(destinationLength) + " | Reduction: " + (100D - ((destinationLength / sourceLength) * 100D)).ToString("0.00") + "%");
            Program.Form.AddLog("    - Images Converted: " + ProcessedImageCount);
            Program.Form.AddLog("    - Incompatible Files" + (Settings.CopySkippedFiles ? " Copied Over" : string.Empty) + ": " + IncompatibleFilesCopiedOver);

            Program.Form.AddLog("\r\nTime taken: " + TimeTaken.ElapsedMilliseconds / 1000 + " seconds");
            Program.Form.ToggleControls();
            return Task.CompletedTask;

            static string GetMegaBytes(double bytes) => (bytes / 1024D / 1024D).ToString("0.00") + "MB";
        }
    }
}
