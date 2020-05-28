using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

using BSL.FileSystem;

using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.Advanced;
using System.Diagnostics;

namespace TooManyPixels
{
    public partial class TooManyPixelsForm : Form
    {
        public TooManyPixelsForm()
        {
            InitializeComponent();

            ConvertToDropDown.SelectedIndex = 0;
            IfTransparentDropDown.SelectedIndex = 0;
            CompressionModeDropDown.SelectedIndex = 2;
        }

        private void SourceFolderSelectionButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) SourceFolderPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void DestinationFolderSelectionButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) DestinationFolderPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (SourceFolderPathTextBox.Text.IsEmpty())
            {
                MessageBox.Show(this, "You need to specify a source folder path!", "No Source Folder Specified!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!new DirectoryInfo(SourceFolderPathTextBox.Text).Exists)
            {
                MessageBox.Show(this, "The provided source folder path " + SourceFolderPathTextBox.Text + " does not exist!", "Invalid path!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (DestinationFolderPathTextBox.Text.IsEmpty())
            {
                MessageBox.Show(this, "You need to specify a destination folder path!", "No Destination Folder Specified!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!new DirectoryInfo(DestinationFolderPathTextBox.Text).Exists)
            {
                MessageBox.Show(this, "The provided destination folder path " + DestinationFolderPathTextBox.Text + " does not exist!", "Invalid path!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (SourceFolderPathTextBox.Text == DestinationFolderPathTextBox.Text)
            {
                MessageBox.Show(this, "The source folder path and destination folder path cannot be the same!", "The Same Is Lame", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            await Task.Run(async () => 
            {
                AddLog("Beginning...\r\n");
                ToggleControls();

                DirectoryInfo source = null;
                DirectoryInfo destination = null;
                Invoke((MethodInvoker) delegate ()
                {
                    source = new DirectoryInfo(SourceFolderPathTextBox.Text);
                    destination = new DirectoryInfo(DestinationFolderPathTextBox.Text);
                });

                bool isRecursive = false;
                bool isAlphaPresent = false;
                bool useTransparentFormatOnly = false;
                bool convertSquareImagesOnly = false;
                bool downsizeLargerImages = false;
                bool copySkippedFiles = false;
                double overallProgressPercentage = 0;
                int filesProcessed = 0;
                int compressionLevel = 0;
                int incompatibleFilesCopied = 0;
                int imageWidth = 0;
                int imageHeight = 0;
                string convertToValue = string.Empty;
                string ifTransparentValue = string.Empty;
                int imagesConverted = 0;
                IEnumerable<FileInfo> sourceFiles = source.EnumerateFiles("*", isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                Invoke((MethodInvoker) delegate ()
                { 
                    OverallProgressBar.Maximum = sourceFiles.ToList().Count;
                    isRecursive = RecursiveCheckBox.Checked;
                    useTransparentFormatOnly = UseTransparentFormatCheckBox.Checked;
                    convertSquareImagesOnly = ConvertSquaresOnlyCheckBox.Checked;
                    convertToValue = ConvertToDropDown.SelectedItem.ToString();
                    ifTransparentValue = IfTransparentDropDown.SelectedItem.ToString();
                    downsizeLargerImages = DownsizeCheckbox.Checked;
                    copySkippedFiles = CopySkippedFilesCheckbox.Checked;
                    imageWidth = !WidthTextBox.Text.IsEmpty() ? int.Parse(WidthTextBox.Text) : 0;
                    imageHeight = !HeightTextBox.Text.IsEmpty() ? int.Parse(HeightTextBox.Text) : 0;
                    compressionLevel = int.Parse(CompressionModeDropDown.SelectedItem.ToString().Replace("%", string.Empty));
                    OverallProgressBar.Value = 0;
                });

                Stopwatch watch = new Stopwatch();
                watch.Start();
                foreach (FileInfo inFile in sourceFiles)
                {
                    Invoke((MethodInvoker) delegate ()
                    { 
                        CurrentFileLabel.Text = "File: " + inFile.Name;
                    });
                    FileInfo outFile = new FileInfo(inFile.FullName.Replace(inFile.DirectoryName, destination.FullName)
                        .Replace(inFile.Extension, "." + convertToValue.ToLower()));
                    if (!inFile.Extension.ContainsAny(".png", ".jpg", ".bmp", ".gif"))
                    {
                        if (copySkippedFiles) await FileSystemHelper.Copy(inFile, new FileInfo(outFile.FullName.Replace(outFile.Extension, inFile.Extension)), true);
                        incompatibleFilesCopied++;
                        IncrementOverallProgress();
                        continue;
                    }

                    using (FileStream inStream = await FileIOHelper.OpenStream(inFile))
                    {
                        byte[] imgData = new byte[inStream.Length];
                        await inStream.ReadAsync(imgData);
                        using (MemoryStream memStr = new MemoryStream(imgData))
                        {
                            using (Bitmap map = new Bitmap(memStr))
                            {
                                isAlphaPresent = map.PixelFormat == PixelFormat.Format16bppArgb1555 || map.PixelFormat == PixelFormat.Format32bppArgb ||
                                                 map.PixelFormat == PixelFormat.Format32bppPArgb || map.PixelFormat == PixelFormat.Format64bppArgb || 
                                                 map.PixelFormat == PixelFormat.Format64bppPArgb;
                                if (downsizeLargerImages && (map.Width <= imageWidth || map.Height <= imageHeight))
                                {
                                    if (copySkippedFiles) await FileSystemHelper.Copy(inFile, new FileInfo(outFile.FullName.Replace(outFile.Extension, inFile.Extension)), true);
                                    IncrementOverallProgress();
                                    continue;
                                }
                                if (map.Width != map.Height && convertSquareImagesOnly)
                                {
                                    IncrementOverallProgress();
                                    continue;
                                }
                                if (useTransparentFormatOnly || isAlphaPresent)
                                {
                                    outFile = new FileInfo(inFile.FullName.Replace(inFile.DirectoryName, destination.FullName)
                                        .Replace(inFile.Extension, "." + ifTransparentValue.ToLower()));
                                }
                                using (FileStream outStream = outFile.Create())
                                {
                                    using (Image image = Image.Load(imgData, out IImageFormat format))
                                    {
                                        bool resized = imageWidth != 0 || imageHeight != 0;
                                        image.Mutate(c =>
                                        {
                                            c.Resize(imageWidth != 0 ? imageWidth : map.Width, imageHeight != 0 ? imageHeight : map.Height);
                                        });
                                        if (useTransparentFormatOnly || isAlphaPresent) ConvertTransparentFormat();
                                        else ConvertNonTransparentFormat();
                                        imagesConverted++;

                                        void ConvertNonTransparentFormat()
                                        {
                                            if (convertToValue == "JPG")
                                            {
                                                image.SaveAsJpeg(outStream, new JpegEncoder
                                                {
                                                    Quality = 100 - compressionLevel
                                                });
                                                LogConversionState("JPG");
                                            }
                                            else if (convertToValue == "BMP")
                                            {
                                                image.SaveAsBmp(outStream);
                                                LogConversionState("BMP");
                                            }
                                        }

                                        void ConvertTransparentFormat()
                                        {
                                            if (ifTransparentValue == "PNG")
                                            {
                                                image.SaveAsPng(outStream, new PngEncoder
                                                {
                                                    CompressionLevel = compressionLevel == 0 ? PngCompressionLevel.Level0 :
                                                                       compressionLevel == 10 ? PngCompressionLevel.Level1 :
                                                                       compressionLevel == 20 ? PngCompressionLevel.Level2 :
                                                                       compressionLevel == 30 ? PngCompressionLevel.Level3 :
                                                                       compressionLevel == 40 ? PngCompressionLevel.Level4 :
                                                                       compressionLevel == 50 ? PngCompressionLevel.Level5 :
                                                                       compressionLevel == 60 ? PngCompressionLevel.Level6 :
                                                                       compressionLevel == 70 ? PngCompressionLevel.Level7 :
                                                                       compressionLevel == 80 ? PngCompressionLevel.Level8 :
                                                                       compressionLevel == 90 ? PngCompressionLevel.Level9 : PngCompressionLevel.Level9
                                                });
                                                LogConversionState("PNG");
                                            }
                                            else if (ifTransparentValue == "GIF")
                                            {
                                                image.SaveAsGif(outStream);
                                                LogConversionState("GIF");
                                            }
                                        }

                                        void LogConversionState(string format) 
                                        {
                                            if (resized && "." + convertToValue.ToLower() == inFile.Extension.ToLower())
                                                AddLog("Resized " + inFile.Name + " to " + imageWidth + "x" + imageHeight + " & converted to " + format + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                                            else if (resized)
                                                AddLog("Resized " + inFile.Name + " to " + imageWidth + "x" + imageHeight + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                                            else if ("." + convertToValue.ToLower() == inFile.Extension.ToLower())
                                                AddLog("Converted " + inFile.Name + " to " + format + " | Reduction " + GetPercentageReduction().ToString("0.00") + "%.");
                                        }

                                        double GetPercentageReduction() => 100D - (100D * ((double)outFile.Length / (double)inFile.Length));
                                    }
                                }
                            }
                        }
                    }
                    IncrementOverallProgress();
                }
                watch.Stop();
                Invoke((MethodInvoker) delegate ()
                {
                    OverallProgressBar.Value = sourceFiles.ToList().Count;
                    OverallProgressLabel.Text = "Overall Progress: 100%"; 
                });

                double sourceLength = 0L;
                double destinationLength = 0L;

                IEnumerable<FileInfo> destinationFiles = destination.EnumerateFiles("*", isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                foreach (FileInfo inf in source.GetFiles("*", isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) sourceLength += inf.Length;
                foreach (FileInfo inf in destination.GetFiles("*", isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)) destinationLength += inf.Length;

                AddLog("\r\nStatus of " + source.FullName);
                AddLog("    - "
                    + sourceFiles.Count(o => o.Extension.ToLower() == ".png") + " of PNG | "
                    + sourceFiles.Count(o => o.Extension.ToLower() == ".gif") + " of GIF | " + sourceFiles.Count(o => o.Extension.ToLower() == ".jpg") + " of JPG | "
                    + sourceFiles.Count(o => o.Extension.ToLower() == ".bmp") + " of BMP");
                AddLog("    - " + "Size: " + GetMegaBytes(sourceLength));

                AddLog("\r\nStatus of " + destination.FullName);
                AddLog("    - "
                    + destinationFiles.Count(o => o.Extension.ToLower() == ".png") + " of PNG | "
                    + destinationFiles.Count(o => o.Extension.ToLower() == ".gif") + " of GIF | " + destinationFiles.Count(o => o.Extension.ToLower() == ".jpg") + " of JPG | "
                    + destinationFiles.Count(o => o.Extension.ToLower() == ".bmp") + " of BMP");
                AddLog("    - " + "Size: " + GetMegaBytes(destinationLength) + " | Reduction: " + (100D - ((destinationLength / sourceLength) * 100D)).ToString("0.00") + "%");
                AddLog("    - Images Converted: " + imagesConverted);
                AddLog("    - Incompatible Files" + (copySkippedFiles ? " Copied Over" : string.Empty) + ": " + incompatibleFilesCopied);

                AddLog("\r\nTime taken: " + watch.ElapsedMilliseconds / 1000 + " seconds");
                ImageCodecInfo.GetImageEncoders().First();

                ToggleControls();

                void IncrementOverallProgress()
                {
                    Invoke((MethodInvoker) delegate ()
                    {
                        if (overallProgressPercentage == 100) overallProgressPercentage = 0;
                        OverallProgressBar.Value++;
                        OverallProgressLabel.Text = "Overall Progress: " + (overallProgressPercentage = 100D * ((double)filesProcessed++ / (double)sourceFiles.ToList().Count)).ToString("0.00") + "%";
                    });
                }

                void ToggleControls()
                {
                    Invoke((MethodInvoker) delegate ()
                    {
                        SourceFolderPathTextBox.Enabled = !SourceFolderPathTextBox.Enabled;
                        DestinationFolderPathTextBox.Enabled = !DestinationFolderPathTextBox.Enabled;
                        ConvertToDropDown.Enabled = !ConvertToDropDown.Enabled;
                        IfTransparentDropDown.Enabled = !IfTransparentDropDown.Enabled;
                        WidthTextBox.Enabled = !WidthTextBox.Enabled;
                        HeightTextBox.Enabled = !HeightTextBox.Enabled;
                        RecursiveCheckBox.Enabled = !RecursiveCheckBox.Enabled;
                        StartButton.Enabled = !StartButton.Enabled;
                        CompressionModeDropDown.Enabled = !CompressionModeDropDown.Enabled;
                        DownsizeCheckbox.Enabled = !DownsizeCheckbox.Enabled;
                        UseTransparentFormatCheckBox.Enabled = !UseTransparentFormatCheckBox.Enabled;
                        ConvertSquaresOnlyCheckBox.Enabled = !ConvertSquaresOnlyCheckBox.Enabled;
                        CopySkippedFilesCheckbox.Enabled = !CopySkippedFilesCheckbox.Enabled;
                    });
                }

                string GetMegaBytes(double bytes) => (bytes / 1024D / 1024D).ToString("0.00") + "MB";
            });

            void AddLog(object log)
            {
                Invoke((MethodInvoker) delegate ()
                {
                    ConsoleTextBox.Text += log.ToString() + "\r\n";
                    ConsoleTextBox.SelectionStart = ConsoleTextBox.Text.Length;
                    ConsoleTextBox.ScrollToCaret();
                });
            }
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void WidthTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void OnlyLargerThanWidthTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void OnlyLargerThanHeightTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);

        private void CheckSizeValueIntegrity(TextBox box)
        {
            string value = Regex.Match(box.Text, @"-?\d+").Value;
            int parsed = value != null && value != string.Empty ? int.Parse(value) : 0;
            box.Text = parsed < 0 ? "0" : parsed.ToString();
        }
    }
}
