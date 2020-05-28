﻿namespace TooManyPixels
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
            this.OnlyLargerThanWidthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OnlyLargerThanHeightTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OverallProgressBar
            // 
            this.OverallProgressBar.Location = new System.Drawing.Point(13, 798);
            this.OverallProgressBar.Name = "OverallProgressBar";
            this.OverallProgressBar.Size = new System.Drawing.Size(754, 34);
            this.OverallProgressBar.TabIndex = 0;
            // 
            // OverallProgressLabel
            // 
            this.OverallProgressLabel.AutoSize = true;
            this.OverallProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.OverallProgressLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverallProgressLabel.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OverallProgressLabel.Location = new System.Drawing.Point(13, 765);
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
            this.CurrentFileLabel.Location = new System.Drawing.Point(247, 765);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(520, 22);
            this.CurrentFileLabel.TabIndex = 1;
            this.CurrentFileLabel.Text = "File:";
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.BackColor = System.Drawing.Color.Black;
            this.ConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleTextBox.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleTextBox.ForeColor = System.Drawing.Color.White;
            this.ConsoleTextBox.Location = new System.Drawing.Point(12, 12);
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ConsoleTextBox.Size = new System.Drawing.Size(754, 388);
            this.ConsoleTextBox.TabIndex = 2;
            this.ConsoleTextBox.Text = "";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(13, 691);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(753, 60);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start Processing";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeightTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightTextBox.Location = new System.Drawing.Point(298, 550);
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
            this.WidthTextBox.Location = new System.Drawing.Point(92, 550);
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
            this.label3.Location = new System.Drawing.Point(212, 555);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 555);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Width:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SourceFolderPathTextBox
            // 
            this.SourceFolderPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SourceFolderPathTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceFolderPathTextBox.Location = new System.Drawing.Point(183, 421);
            this.SourceFolderPathTextBox.Multiline = true;
            this.SourceFolderPathTextBox.Name = "SourceFolderPathTextBox";
            this.SourceFolderPathTextBox.PlaceholderText = "Required";
            this.SourceFolderPathTextBox.Size = new System.Drawing.Size(547, 30);
            this.SourceFolderPathTextBox.TabIndex = 4;
            this.SourceFolderPathTextBox.Tag = "";
            this.SourceFolderPathTextBox.WordWrap = false;
            // 
            // DestinationFolderPathTextBox
            // 
            this.DestinationFolderPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DestinationFolderPathTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DestinationFolderPathTextBox.Location = new System.Drawing.Point(183, 457);
            this.DestinationFolderPathTextBox.Multiline = true;
            this.DestinationFolderPathTextBox.Name = "DestinationFolderPathTextBox";
            this.DestinationFolderPathTextBox.PlaceholderText = "Required";
            this.DestinationFolderPathTextBox.Size = new System.Drawing.Size(547, 30);
            this.DestinationFolderPathTextBox.TabIndex = 4;
            this.DestinationFolderPathTextBox.WordWrap = false;
            // 
            // SourceFolderSelectionButton
            // 
            this.SourceFolderSelectionButton.Location = new System.Drawing.Point(736, 421);
            this.SourceFolderSelectionButton.Name = "SourceFolderSelectionButton";
            this.SourceFolderSelectionButton.Size = new System.Drawing.Size(30, 30);
            this.SourceFolderSelectionButton.TabIndex = 3;
            this.SourceFolderSelectionButton.Text = "...";
            this.SourceFolderSelectionButton.UseVisualStyleBackColor = true;
            this.SourceFolderSelectionButton.Click += new System.EventHandler(this.SourceFolderSelectionButton_Click);
            // 
            // DestinationFolderSelectionButton
            // 
            this.DestinationFolderSelectionButton.Location = new System.Drawing.Point(736, 457);
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
            this.IfTransparentDropDown.Location = new System.Drawing.Point(516, 502);
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
            this.ConvertToDropDown.Location = new System.Drawing.Point(120, 502);
            this.ConvertToDropDown.Name = "ConvertToDropDown";
            this.ConvertToDropDown.Size = new System.Drawing.Size(250, 30);
            this.ConvertToDropDown.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Source Folder:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 461);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Destination Folder:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Convert To:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(385, 505);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "If Transparent";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecursiveCheckBox
            // 
            this.RecursiveCheckBox.AutoSize = true;
            this.RecursiveCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RecursiveCheckBox.Location = new System.Drawing.Point(13, 600);
            this.RecursiveCheckBox.Name = "RecursiveCheckBox";
            this.RecursiveCheckBox.Size = new System.Drawing.Size(118, 26);
            this.RecursiveCheckBox.TabIndex = 7;
            this.RecursiveCheckBox.Text = "Recursive";
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
            this.CompressionModeDropDown.Location = new System.Drawing.Point(590, 550);
            this.CompressionModeDropDown.Name = "CompressionModeDropDown";
            this.CompressionModeDropDown.Size = new System.Drawing.Size(176, 30);
            this.CompressionModeDropDown.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(414, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Compression Mode:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UseTransparentFormatCheckBox
            // 
            this.UseTransparentFormatCheckBox.AutoSize = true;
            this.UseTransparentFormatCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UseTransparentFormatCheckBox.Location = new System.Drawing.Point(147, 600);
            this.UseTransparentFormatCheckBox.Name = "UseTransparentFormatCheckBox";
            this.UseTransparentFormatCheckBox.Size = new System.Drawing.Size(251, 26);
            this.UseTransparentFormatCheckBox.TabIndex = 7;
            this.UseTransparentFormatCheckBox.Text = "Force Transparent Format";
            this.UseTransparentFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConvertSquaresOnlyCheckBox
            // 
            this.ConvertSquaresOnlyCheckBox.AutoSize = true;
            this.ConvertSquaresOnlyCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConvertSquaresOnlyCheckBox.Location = new System.Drawing.Point(414, 600);
            this.ConvertSquaresOnlyCheckBox.Name = "ConvertSquaresOnlyCheckBox";
            this.ConvertSquaresOnlyCheckBox.Size = new System.Drawing.Size(269, 26);
            this.ConvertSquaresOnlyCheckBox.TabIndex = 7;
            this.ConvertSquaresOnlyCheckBox.Text = "Convert Square Images Only";
            this.ConvertSquaresOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnlyLargerThanWidthTextBox
            // 
            this.OnlyLargerThanWidthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OnlyLargerThanWidthTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OnlyLargerThanWidthTextBox.Location = new System.Drawing.Point(260, 645);
            this.OnlyLargerThanWidthTextBox.Multiline = true;
            this.OnlyLargerThanWidthTextBox.Name = "OnlyLargerThanWidthTextBox";
            this.OnlyLargerThanWidthTextBox.PlaceholderText = "Optional";
            this.OnlyLargerThanWidthTextBox.Size = new System.Drawing.Size(100, 30);
            this.OnlyLargerThanWidthTextBox.TabIndex = 4;
            this.OnlyLargerThanWidthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OnlyLargerThanWidthTextBox.WordWrap = false;
            this.OnlyLargerThanWidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 649);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Only with larger width than";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(385, 649);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 22);
            this.label9.TabIndex = 5;
            this.label9.Text = "Only with larger height than";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OnlyLargerThanHeightTextBox
            // 
            this.OnlyLargerThanHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OnlyLargerThanHeightTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OnlyLargerThanHeightTextBox.Location = new System.Drawing.Point(640, 645);
            this.OnlyLargerThanHeightTextBox.Multiline = true;
            this.OnlyLargerThanHeightTextBox.Name = "OnlyLargerThanHeightTextBox";
            this.OnlyLargerThanHeightTextBox.PlaceholderText = "Optional";
            this.OnlyLargerThanHeightTextBox.Size = new System.Drawing.Size(100, 30);
            this.OnlyLargerThanHeightTextBox.TabIndex = 4;
            this.OnlyLargerThanHeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OnlyLargerThanHeightTextBox.WordWrap = false;
            this.OnlyLargerThanHeightTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // TooManyPixelsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(778, 844);
            this.Controls.Add(this.OnlyLargerThanHeightTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OnlyLargerThanWidthTextBox);
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
        private System.Windows.Forms.TextBox OnlyLargerThanWidthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox OnlyLargerThanHeightTextBox;
    }
}