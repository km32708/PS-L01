namespace CustomBase64
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.outputFileLabel = new System.Windows.Forms.Label();
            this.autoConvertButton = new System.Windows.Forms.Button();
            this.convertToB64Button = new System.Windows.Forms.Button();
            this.convertToBinaryButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Any file | *.*";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(397, 47);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Enabled = false;
            this.inputFileTextBox.Location = new System.Drawing.Point(42, 49);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.ReadOnly = true;
            this.inputFileTextBox.Size = new System.Drawing.Size(349, 20);
            this.inputFileTextBox.TabIndex = 1;
            this.inputFileTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Enabled = false;
            this.outputFileTextBox.Location = new System.Drawing.Point(42, 112);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.ReadOnly = true;
            this.outputFileTextBox.Size = new System.Drawing.Size(349, 20);
            this.outputFileTextBox.TabIndex = 2;
            this.outputFileTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(397, 109);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileButton.TabIndex = 3;
            this.saveFileButton.Text = "...";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(39, 33);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(47, 13);
            this.inputFileLabel.TabIndex = 4;
            this.inputFileLabel.Text = "Input file";
            // 
            // outputFileLabel
            // 
            this.outputFileLabel.AutoSize = true;
            this.outputFileLabel.Location = new System.Drawing.Point(39, 96);
            this.outputFileLabel.Name = "outputFileLabel";
            this.outputFileLabel.Size = new System.Drawing.Size(55, 13);
            this.outputFileLabel.TabIndex = 5;
            this.outputFileLabel.Text = "Output file";
            // 
            // autoConvertButton
            // 
            this.autoConvertButton.Location = new System.Drawing.Point(42, 161);
            this.autoConvertButton.Name = "autoConvertButton";
            this.autoConvertButton.Size = new System.Drawing.Size(125, 50);
            this.autoConvertButton.TabIndex = 6;
            this.autoConvertButton.Text = "Convert\r\nAutomatically\r\n(by extension)";
            this.autoConvertButton.UseVisualStyleBackColor = true;
            this.autoConvertButton.Click += new System.EventHandler(this.autoConvertButton_Click);
            // 
            // convertToB64Button
            // 
            this.convertToB64Button.Location = new System.Drawing.Point(248, 161);
            this.convertToB64Button.Name = "convertToB64Button";
            this.convertToB64Button.Size = new System.Drawing.Size(109, 50);
            this.convertToB64Button.TabIndex = 7;
            this.convertToB64Button.Text = "Force\r\nconvert to b64\r\n";
            this.convertToB64Button.UseVisualStyleBackColor = true;
            this.convertToB64Button.Click += new System.EventHandler(this.convertToB64Button_Click);
            // 
            // convertToBinaryButton
            // 
            this.convertToBinaryButton.Location = new System.Drawing.Point(363, 161);
            this.convertToBinaryButton.Name = "convertToBinaryButton";
            this.convertToBinaryButton.Size = new System.Drawing.Size(109, 50);
            this.convertToBinaryButton.TabIndex = 8;
            this.convertToBinaryButton.Text = "Force\r\nconvert to binary";
            this.convertToBinaryButton.UseVisualStyleBackColor = true;
            this.convertToBinaryButton.Click += new System.EventHandler(this.convertToBinaryButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Any file | *.*";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 253);
            this.Controls.Add(this.convertToBinaryButton);
            this.Controls.Add(this.convertToB64Button);
            this.Controls.Add(this.autoConvertButton);
            this.Controls.Add(this.outputFileLabel);
            this.Controls.Add(this.inputFileLabel);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.inputFileTextBox);
            this.Controls.Add(this.openFileButton);
            this.Name = "MainForm";
            this.Text = "Byte64 encoder/decoder by Mariusz Kozłowski";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Label outputFileLabel;
        private System.Windows.Forms.Button autoConvertButton;
        private System.Windows.Forms.Button convertToB64Button;
        private System.Windows.Forms.Button convertToBinaryButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

