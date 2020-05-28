namespace TooManyPixels
{
    partial class TooManyPixelsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OverallProgressBar = new System.Windows.Forms.ProgressBar();
            this.OverallProgressLabel = new System.Windows.Forms.Label();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.ConsoleTextBox = new System.Windows.Forms.RichTextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SourceFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.DestinationFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.SourceFolderSelectionButton = new System.Windows.Forms.Button();
            this.DestinationFolderSelectionButton = new System.Windows.Forms.Button();
            this.IfTransparentDropDown = new System.Windows.Forms.ComboBox();
            this.ConvertToDropDown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RecursiveCheckBox = new System.Windows.Forms.CheckBox();
            this.CompressionModeDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UseTransparentFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.ConvertSquaresOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.DownsizeCheckbox = new System.Windows.Forms.CheckBox();
            this.CopySkippedFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OverallProgressBar
            // 
            this.OverallProgressBar.Location = new System.Drawing.Point(13, 1098);
            this.OverallProgressBar.Name = "OverallProgressBar";
            this.OverallProgressBar.Size = new System.Drawing.Size(1153, 34);
            this.OverallProgressBar.TabIndex = 0;
            // 
            // OverallProgressLabel
            // 
            this.OverallProgressLabel.AutoSize = true;
            this.OverallProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.OverallProgressLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverallProgressLabel.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OverallProgressLabel.Location = new System.Drawing.Point(13, 1065);
            this.OverallProgressLabel.Name = "OverallProgressLabel";
            this.OverallProgressLabel.Size = new System.Drawing.Size(149, 22);
            this.OverallProgressLabel.TabIndex = 1;
            this.OverallProgressLabel.Text = "Overall Progress";
            this.OverallProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentFileLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentFileLabel.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentFileLabel.Location = new System.Drawing.Point(240, 1065);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(925, 22);
            this.CurrentFileLabel.TabIndex = 1;
            this.CurrentFileLabel.Text = "File:";
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.BackColor = System.Drawing.Color.Black;
            this.ConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleTextBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleTextBox.ForeColor = System.Drawing.Color.White;
            this.ConsoleTextBox.Location = new System.Drawing.Point(12, 12);
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ConsoleTextBox.Size = new System.Drawing.Size(1154, 710);
            this.ConsoleTextBox.TabIndex = 2;
            this.ConsoleTextBox.Text = "";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(13, 993);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(1153, 69);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start Processing";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeightTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightTextBox.Location = new System.Drawing.Point(1065, 957);
            this.HeightTextBox.Multiline = true;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.PlaceholderText = "Optional";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 30);
            this.HeightTextBox.TabIndex = 4;
            this.HeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HeightTextBox.WordWrap = false;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WidthTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthTextBox.Location = new System.Drawing.Point(1066, 921);
            this.WidthTextBox.Multiline = true;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.PlaceholderText = "Optional";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 30);
            this.WidthTextBox.TabIndex = 4;
            this.WidthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WidthTextBox.WordWrap = false;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(913, 961);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Resize to height:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(915, 926);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Resize to width:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SourceFolderPathTextBox
            // 
            this.SourceFolderPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SourceFolderPathTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceFolderPathTextBox.Location = new System.Drawing.Point(182, 741);
            this.SourceFolderPathTextBox.Multiline = true;
            this.SourceFolderPathTextBox.Name = "SourceFolderPathTextBox";
            this.SourceFolderPathTextBox.PlaceholderText = "Required";
            this.SourceFolderPathTextBox.Size = new System.Drawing.Size(948, 30);
            this.SourceFolderPathTextBox.TabIndex = 4;
            this.SourceFolderPathTextBox.Tag = "";
            this.SourceFolderPathTextBox.WordWrap = false;
            // 
            // DestinationFolderPathTextBox
            // 
            this.DestinationFolderPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DestinationFolderPathTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DestinationFolderPathTextBox.Location = new System.Drawing.Point(182, 777);
            this.DestinationFolderPathTextBox.Multiline = true;
            this.DestinationFolderPathTextBox.Name = "DestinationFolderPathTextBox";
            this.DestinationFolderPathTextBox.PlaceholderText = "Required";
            this.DestinationFolderPathTextBox.Size = new System.Drawing.Size(948, 30);
            this.DestinationFolderPathTextBox.TabIndex = 4;
            this.DestinationFolderPathTextBox.WordWrap = false;
            // 
            // SourceFolderSelectionButton
            // 
            this.SourceFolderSelectionButton.Location = new System.Drawing.Point(1136, 741);
            this.SourceFolderSelectionButton.Name = "SourceFolderSelectionButton";
            this.SourceFolderSelectionButton.Size = new System.Drawing.Size(30, 30);
            this.SourceFolderSelectionButton.TabIndex = 3;
            this.SourceFolderSelectionButton.Text = "...";
            this.SourceFolderSelectionButton.UseVisualStyleBackColor = true;
            this.SourceFolderSelectionButton.Click += new System.EventHandler(this.SourceFolderSelectionButton_Click);
            // 
            // DestinationFolderSelectionButton
            // 
            this.DestinationFolderSelectionButton.Location = new System.Drawing.Point(1136, 777);
            this.DestinationFolderSelectionButton.Name = "DestinationFolderSelectionButton";
            this.DestinationFolderSelectionButton.Size = new System.Drawing.Size(30, 30);
            this.DestinationFolderSelectionButton.TabIndex = 3;
            this.DestinationFolderSelectionButton.Text = "...";
            this.DestinationFolderSelectionButton.UseVisualStyleBackColor = true;
            this.DestinationFolderSelectionButton.Click += new System.EventHandler(this.DestinationFolderSelectionButton_Click);
            // 
            // IfTransparentDropDown
            // 
            this.IfTransparentDropDown.DisplayMember = "0";
            this.IfTransparentDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IfTransparentDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IfTransparentDropDown.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IfTransparentDropDown.FormattingEnabled = true;
            this.IfTransparentDropDown.Items.AddRange(new object[] {
            "PNG",
            "GIF"});
            this.IfTransparentDropDown.Location = new System.Drawing.Point(915, 849);
            this.IfTransparentDropDown.Name = "IfTransparentDropDown";
            this.IfTransparentDropDown.Size = new System.Drawing.Size(250, 30);
            this.IfTransparentDropDown.TabIndex = 6;
            // 
            // ConvertToDropDown
            // 
            this.ConvertToDropDown.DisplayMember = "0";
            this.ConvertToDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConvertToDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConvertToDropDown.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConvertToDropDown.FormattingEnabled = true;
            this.ConvertToDropDown.Items.AddRange(new object[] {
            "JPG",
            "BMP"});
            this.ConvertToDropDown.Location = new System.Drawing.Point(915, 813);
            this.ConvertToDropDown.Name = "ConvertToDropDown";
            this.ConvertToDropDown.Size = new System.Drawing.Size(250, 30);
            this.ConvertToDropDown.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 745);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Source Folder:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 781);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Destination Folder:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(686, 816);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "If alpha is not present use";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(715, 852);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "If alpha is present use";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecursiveCheckBox
            // 
            this.RecursiveCheckBox.AutoSize = true;
            this.RecursiveCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RecursiveCheckBox.Location = new System.Drawing.Point(13, 823);
            this.RecursiveCheckBox.Name = "RecursiveCheckBox";
            this.RecursiveCheckBox.Size = new System.Drawing.Size(216, 26);
            this.RecursiveCheckBox.TabIndex = 7;
            this.RecursiveCheckBox.Text = "Recursive File Search";
            this.RecursiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // CompressionModeDropDown
            // 
            this.CompressionModeDropDown.DisplayMember = "0";
            this.CompressionModeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompressionModeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompressionModeDropDown.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompressionModeDropDown.FormattingEnabled = true;
            this.CompressionModeDropDown.Items.AddRange(new object[] {
            "0%",
            "10%",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%"});
            this.CompressionModeDropDown.Location = new System.Drawing.Point(989, 885);
            this.CompressionModeDropDown.Name = "CompressionModeDropDown";
            this.CompressionModeDropDown.Size = new System.Drawing.Size(176, 30);
            this.CompressionModeDropDown.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(813, 890);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Compression Rate:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UseTransparentFormatCheckBox
            // 
            this.UseTransparentFormatCheckBox.AutoSize = true;
            this.UseTransparentFormatCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UseTransparentFormatCheckBox.Location = new System.Drawing.Point(13, 918);
            this.UseTransparentFormatCheckBox.Name = "UseTransparentFormatCheckBox";
            this.UseTransparentFormatCheckBox.Size = new System.Drawing.Size(319, 26);
            this.UseTransparentFormatCheckBox.TabIndex = 7;
            this.UseTransparentFormatCheckBox.Text = "Force Conversion To Alpha Format";
            this.UseTransparentFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConvertSquaresOnlyCheckBox
            // 
            this.ConvertSquaresOnlyCheckBox.AutoSize = true;
            this.ConvertSquaresOnlyCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConvertSquaresOnlyCheckBox.Location = new System.Drawing.Point(13, 886);
            this.ConvertSquaresOnlyCheckBox.Name = "ConvertSquaresOnlyCheckBox";
            this.ConvertSquaresOnlyCheckBox.Size = new System.Drawing.Size(269, 26);
            this.ConvertSquaresOnlyCheckBox.TabIndex = 7;
            this.ConvertSquaresOnlyCheckBox.Text = "Convert Square Images Only";
            this.ConvertSquaresOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // DownsizeCheckbox
            // 
            this.DownsizeCheckbox.AutoSize = true;
            this.DownsizeCheckbox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DownsizeCheckbox.Location = new System.Drawing.Point(12, 950);
            this.DownsizeCheckbox.Name = "DownsizeCheckbox";
            this.DownsizeCheckbox.Size = new System.Drawing.Size(427, 26);
            this.DownsizeCheckbox.TabIndex = 7;
            this.DownsizeCheckbox.Text = "Downsize Images Above Specified Width/Height";
            this.DownsizeCheckbox.UseVisualStyleBackColor = true;
            // 
            // CopySkippedFilesCheckbox
            // 
            this.CopySkippedFilesCheckbox.AutoSize = true;
            this.CopySkippedFilesCheckbox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CopySkippedFilesCheckbox.Location = new System.Drawing.Point(13, 854);
            this.CopySkippedFilesCheckbox.Name = "CopySkippedFilesCheckbox";
            this.CopySkippedFilesCheckbox.Size = new System.Drawing.Size(235, 26);
            this.CopySkippedFilesCheckbox.TabIndex = 7;
            this.CopySkippedFilesCheckbox.Text = "Copy Over Skipped Files";
            this.CopySkippedFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // TooManyPixelsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1178, 1144);
            this.Controls.Add(this.CopySkippedFilesCheckbox);
            this.Controls.Add(this.DownsizeCheckbox);
            this.Controls.Add(this.ConvertSquaresOnlyCheckBox);
            this.Controls.Add(this.UseTransparentFormatCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompressionModeDropDown);
            this.Controls.Add(this.RecursiveCheckBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConvertToDropDown);
            this.Controls.Add(this.IfTransparentDropDown);
            this.Controls.Add(this.DestinationFolderSelectionButton);
            this.Controls.Add(this.SourceFolderSelectionButton);
            this.Controls.Add(this.DestinationFolderPathTextBox);
            this.Controls.Add(this.SourceFolderPathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ConsoleTextBox);
            this.Controls.Add(this.CurrentFileLabel);
            this.Controls.Add(this.OverallProgressLabel);
            this.Controls.Add(this.OverallProgressBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TooManyPixelsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TooManyPixels";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar OverallProgressBar;
        private System.Windows.Forms.Label OverallProgressLabel;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.RichTextBox ConsoleTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SourceFolderPathTextBox;
        private System.Windows.Forms.TextBox DestinationFolderPathTextBox;
        private System.Windows.Forms.Button SourceFolderSelectionButton;
        private System.Windows.Forms.Button DestinationFolderSelectionButton;
        private System.Windows.Forms.ComboBox IfTransparentDropDown;
        private System.Windows.Forms.ComboBox ConvertToDropDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox RecursiveCheckBox;
        private System.Windows.Forms.ComboBox CompressionModeDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox UseTransparentFormatCheckBox;
        private System.Windows.Forms.CheckBox ConvertSquaresOnlyCheckBox;
        private System.Windows.Forms.CheckBox DownsizeCheckbox;
        private System.Windows.Forms.CheckBox CopySkippedFilesCheckbox;
    }
}