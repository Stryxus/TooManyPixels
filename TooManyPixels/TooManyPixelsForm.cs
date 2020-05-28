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

            foreach (SupportedNonAlphaFileTypes a in Enum.GetValues(typeof(SupportedNonAlphaFileTypes))) ConvertToDropDown.Items.Add(a.ToString());
            foreach (SupportedAlphaFileTypes a in Enum.GetValues(typeof(SupportedAlphaFileTypes))) IfTransparentDropDown.Items.Add(a.ToString());

            if (Program.Settings.SourceDirectory != null) SourceFolderPathTextBox.Text = Program.Settings.SourceDirectory.FullName;
            if (Program.Settings.DestinationDirectory != null) DestinationFolderPathTextBox.Text = Program.Settings.DestinationDirectory.FullName;
            RecursiveCheckBox.Checked = Program.Settings.IsRecurive;
            UseTransparentFormatCheckBox.Checked = Program.Settings.UseAlphaFormatOnly;
            ConvertSquaresOnlyCheckBox.Checked = Program.Settings.OnlyPassSquareImages;
            DownsizeCheckbox.Checked = Program.Settings.DownsizeLargerResolutionImages;
            CopySkippedFilesCheckbox.Checked = Program.Settings.CopySkippedFiles;
            CompressionModeDropDown.SelectedItem = Program.Settings.CompressionLevel + "%";
            if (Program.Settings.TargetImageWidth != 0) WidthTextBox.Text = Program.Settings.TargetImageWidth.ToString();
            if (Program.Settings.TargetImageHeight != 0) HeightTextBox.Text = Program.Settings.TargetImageHeight.ToString();
            ConvertToDropDown.SelectedIndex = (int)Program.Settings.ConvertToNonAlphaValue;
            IfTransparentDropDown.SelectedIndex = (int)Program.Settings.ConvertToAlphaValue;
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
            if (SourceFolderPathTextBox.Text.IsEmpty() && Program.Settings.SourceDirectory == null)
            {
                MessageBox.Show(this, "You need to specify a source folder path!", "No Source Folder Specified!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!new DirectoryInfo(SourceFolderPathTextBox.Text).Exists)
            {
                MessageBox.Show(this, "The provided source folder path " + SourceFolderPathTextBox.Text + " does not exist!", "Invalid path!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (DestinationFolderPathTextBox.Text.IsEmpty() && Program.Settings.DestinationDirectory == null)
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

            Invoke((MethodInvoker)delegate () 
            {
                if (Program.Settings.SourceDirectory == null) Program.Settings.SourceDirectory = new DirectoryInfo(SourceFolderPathTextBox.Text);
                if (Program.Settings.DestinationDirectory == null) Program.Settings.DestinationDirectory = new DirectoryInfo(DestinationFolderPathTextBox.Text);
                if (Program.Settings.IsRecurive != RecursiveCheckBox.Checked) Program.Settings.IsRecurive = RecursiveCheckBox.Checked;
                if (Program.Settings.UseAlphaFormatOnly != UseTransparentFormatCheckBox.Checked) Program.Settings.UseAlphaFormatOnly = UseTransparentFormatCheckBox.Checked;
                if (Program.Settings.OnlyPassSquareImages != ConvertSquaresOnlyCheckBox.Checked) Program.Settings.OnlyPassSquareImages = ConvertSquaresOnlyCheckBox.Checked;
                if (Program.Settings.DownsizeLargerResolutionImages != DownsizeCheckbox.Checked) Program.Settings.DownsizeLargerResolutionImages = DownsizeCheckbox.Checked;
                if (Program.Settings.CopySkippedFiles != CopySkippedFilesCheckbox.Checked) Program.Settings.CopySkippedFiles = CopySkippedFilesCheckbox.Checked;
                if (Program.Settings.CompressionLevel == 0) Program.Settings.CompressionLevel = int.Parse(CompressionModeDropDown.SelectedItem.ToString().Replace("%", string.Empty));
                if (Program.Settings.TargetImageWidth == 0) Program.Settings.TargetImageWidth = !WidthTextBox.Text.IsEmpty() ? int.Parse(WidthTextBox.Text) : 0;
                if (Program.Settings.TargetImageHeight == 0) Program.Settings.TargetImageHeight = !HeightTextBox.Text.IsEmpty() ? int.Parse(HeightTextBox.Text) : 0;
                if (Program.Settings.ConvertToNonAlphaValue == 0) Program.Settings.ConvertToNonAlphaValue = (SupportedNonAlphaFileTypes)Enum.Parse(typeof(SupportedNonAlphaFileTypes), ConvertToDropDown.SelectedItem.ToString());
                if (Program.Settings.ConvertToAlphaValue == 0) Program.Settings.ConvertToAlphaValue = (SupportedAlphaFileTypes)Enum.Parse(typeof(SupportedAlphaFileTypes), IfTransparentDropDown.SelectedItem.ToString());
            });
            await ImageProcessor.Initiate();
            await ImageProcessor.Run();
            await ImageProcessor.PrintResults();
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void WidthTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void OnlyLargerThanWidthTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);
        private void OnlyLargerThanHeightTextBox_TextChanged(object sender, EventArgs e) => CheckSizeValueIntegrity((TextBox)sender);

        private static void CheckSizeValueIntegrity(TextBox box)
        {
            if (!box.Text.IsEmpty())
            {
                string value = Regex.Match(box.Text, @"-?\d+").Value;
                int parsed = value != null && value.IsEmpty() ? int.Parse(value) : 0;
                if (parsed < 0) box.Text = "0";
            }
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
                OverallProgressLabel.Text = "Overall Progress: " + (OverallProgressPercentage = 100D * ((double)ImageProcessor.ProcessedImageCount / (double)ImageProcessor.SourceFiles.Count)).ToString("0.00") + "%";
            });
        }
    }
}
