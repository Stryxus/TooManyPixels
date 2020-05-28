using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TooManyPixels
{
    public partial class TooManyPixelsForm : Form
    {
        private double OverallProgressPercentage { get; set; } = 0;

        public TooManyPixelsForm()
        {
            InitializeComponent();

            ConvertToDropDown.SelectedIndex = 0;
            IfTransparentDropDown.SelectedIndex = 0;
            CompressionModeDropDown.SelectedIndex = 2;
        }

        private void SourceFolderSelectionButton_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) SourceFolderPathTextBox.Text = fbd.SelectedPath;
        }

        private void DestinationFolderSelectionButton_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) DestinationFolderPathTextBox.Text = fbd.SelectedPath;
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

            ProcessorSettings settings = default;
            Invoke((MethodInvoker)delegate () 
            {
                settings = new ProcessorSettings
                {
                    SourceDirectory = new DirectoryInfo(SourceFolderPathTextBox.Text),
                    DestinationDirector = new DirectoryInfo(DestinationFolderPathTextBox.Text),
                    IsRecurive = RecursiveCheckBox.Checked,
                    UseAlphaFormatOnly = UseTransparentFormatCheckBox.Checked,
                    OnlyPassSquareImages = ConvertSquaresOnlyCheckBox.Checked,
                    DownsizeLargerResolutionImages = DownsizeCheckbox.Checked,
                    CopySkippedFiles = CopySkippedFilesCheckbox.Checked,
                    CompressionLevel = int.Parse(CompressionModeDropDown.SelectedItem.ToString().Replace("%", string.Empty)),
                    TargetImageWidth = !WidthTextBox.Text.IsEmpty() ? int.Parse(WidthTextBox.Text) : 0,
                    TargetImageHeight = !HeightTextBox.Text.IsEmpty() ? int.Parse(HeightTextBox.Text) : 0,
                    ConvertToNonAlphaValue = (SupportedNonAlphaFileTypes)Enum.Parse(typeof(SupportedNonAlphaFileTypes), ConvertToDropDown.SelectedItem.ToString()),
                    ConvertToAlphaValue = (SupportedAlphaFileTypes)Enum.Parse(typeof(SupportedAlphaFileTypes), IfTransparentDropDown.SelectedItem.ToString())
                };
            });
            await ImageProcessor.Initiate(settings);
            await ImageProcessor.Run();
            await ImageProcessor.PrintResults();
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void WidthTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void OnlyLargerThanWidthTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void OnlyLargerThanHeightTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);

        private static void CheckSizeValueIntegrity(TextBox box)
        {
            string value = Regex.Match(box.Text, @"-?\d+").Value;
            int parsed = value != null && value.IsEmpty() ? int.Parse(value) : 0;
            box.Text = parsed < 0 ? "0" : parsed.ToString();
        }

        internal void ToggleControls()
        {
            Invoke((MethodInvoker)delegate ()
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

        internal void IncrementOverallProgress()
        {
            Invoke((MethodInvoker)delegate ()
            {
                if (OverallProgressPercentage >= 100) OverallProgressPercentage = 0;
                OverallProgressBar.Value++;
                OverallProgressLabel.Text = "Overall Progress: " + (OverallProgressPercentage = 100D * (ImageProcessor.ProcessedImageCount / ImageProcessor.SourceFiles.Count)).ToString("0.00") + "%";
            });
        }

        internal void AddLog(object log)
        {
            Invoke((MethodInvoker)delegate ()
            {
                ConsoleTextBox.Text += log.ToString() + "\r\n";
                ConsoleTextBox.SelectionStart = ConsoleTextBox.Text.Length;
                ConsoleTextBox.ScrollToCaret();
            });
        }
    }
}
