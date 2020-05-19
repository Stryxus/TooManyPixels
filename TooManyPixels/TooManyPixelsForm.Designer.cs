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
            this.CurrentFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // OverallProgressBar
            // 
            this.OverallProgressBar.Location = new System.Drawing.Point(12, 698);
            this.OverallProgressBar.Name = "OverallProgressBar";
            this.OverallProgressBar.Size = new System.Drawing.Size(754, 34);
            this.OverallProgressBar.TabIndex = 0;
            // 
            // CurrentFileProgressBar
            // 
            this.CurrentFileProgressBar.Location = new System.Drawing.Point(12, 620);
            this.CurrentFileProgressBar.Name = "CurrentFileProgressBar";
            this.CurrentFileProgressBar.Size = new System.Drawing.Size(754, 34);
            this.CurrentFileProgressBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 665);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overall Progress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 590);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "File:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.BackColor = System.Drawing.Color.Black;
            this.ConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.StartButton.Location = new System.Drawing.Point(566, 550);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(200, 30);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start Processing";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeightTextBox.Location = new System.Drawing.Point(298, 550);
            this.HeightTextBox.Multiline = true;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 30);
            this.HeightTextBox.TabIndex = 4;
            this.HeightTextBox.WordWrap = false;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WidthTextBox.Location = new System.Drawing.Point(92, 550);
            this.WidthTextBox.Multiline = true;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 30);
            this.WidthTextBox.TabIndex = 4;
            this.WidthTextBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 555);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
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
            this.SourceFolderPathTextBox.Location = new System.Drawing.Point(183, 421);
            this.SourceFolderPathTextBox.Multiline = true;
            this.SourceFolderPathTextBox.Name = "SourceFolderPathTextBox";
            this.SourceFolderPathTextBox.Size = new System.Drawing.Size(547, 30);
            this.SourceFolderPathTextBox.TabIndex = 4;
            this.SourceFolderPathTextBox.WordWrap = false;
            // 
            // DestinationFolderPathTextBox
            // 
            this.DestinationFolderPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DestinationFolderPathTextBox.Location = new System.Drawing.Point(183, 457);
            this.DestinationFolderPathTextBox.Multiline = true;
            this.DestinationFolderPathTextBox.Name = "DestinationFolderPathTextBox";
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
            // 
            // DestinationFolderSelectionButton
            // 
            this.DestinationFolderSelectionButton.Location = new System.Drawing.Point(736, 457);
            this.DestinationFolderSelectionButton.Name = "DestinationFolderSelectionButton";
            this.DestinationFolderSelectionButton.Size = new System.Drawing.Size(30, 30);
            this.DestinationFolderSelectionButton.TabIndex = 3;
            this.DestinationFolderSelectionButton.Text = "...";
            this.DestinationFolderSelectionButton.UseVisualStyleBackColor = true;
            // 
            // IfTransparentDropDown
            // 
            this.IfTransparentDropDown.FormattingEnabled = true;
            this.IfTransparentDropDown.Location = new System.Drawing.Point(443, 504);
            this.IfTransparentDropDown.Name = "IfTransparentDropDown";
            this.IfTransparentDropDown.Size = new System.Drawing.Size(150, 30);
            this.IfTransparentDropDown.TabIndex = 6;
            // 
            // ConvertToDropDown
            // 
            this.ConvertToDropDown.FormattingEnabled = true;
            this.ConvertToDropDown.Location = new System.Drawing.Point(131, 504);
            this.ConvertToDropDown.Name = "ConvertToDropDown";
            this.ConvertToDropDown.Size = new System.Drawing.Size(150, 30);
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
            this.label7.Location = new System.Drawing.Point(13, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Convert To:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 507);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "If Transparent";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TooManyPixelsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(778, 744);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentFileProgressBar);
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
        private System.Windows.Forms.ProgressBar CurrentFileProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
    }
}