using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CustomBase64
{
    public partial class MainForm : Form
    {

        string inputPath;
        string outputPath;
        string outputFileExtension;

        bool isB64 = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            inputPath = openFileDialog.FileName;
            inputFileTextBox.Text = inputPath;
            inputFileTextBox.SelectionLength = 0;
            inputFileTextBox.SelectionStart = inputPath.Length;
            string tempInputFileExtension;
            tempInputFileExtension = Path.GetExtension(inputPath);
            isB64 = (tempInputFileExtension == ".b64") || (tempInputFileExtension == ".B64");
            if (isB64)
            {
                outputPath = Path.ChangeExtension(inputPath, "");
                outputPath = outputPath.Remove(outputPath.Length -1,1);
                outputFileExtension = Path.GetExtension(outputPath);
            }
            else
            {
                outputPath = inputPath + ".b64";
            }
            outputFileTextBox.Text = outputPath;
            outputFileTextBox.SelectionLength = 0;
            outputFileTextBox.SelectionStart = outputPath.Length;
        }

        //z neta dla wygody
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void convertToB64Button_Click(object sender, EventArgs e)
        {
            B64Converter.ToBase64(inputPath, outputPath);
        }

        private void convertToBinaryButton_Click(object sender, EventArgs e)
        {
            B64Converter.FromBase64(inputPath, outputPath);
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            outputPath = saveFileDialog.FileName;
            outputFileTextBox.Text = outputPath;
            outputFileTextBox.SelectionLength = 0;
            outputFileTextBox.SelectionStart = outputPath.Length;
        }

        private void autoConvertButton_Click(object sender, EventArgs e)
        {
            if (isB64)
            {
                B64Converter.FromBase64(inputPath, outputPath);
            }
            else
            {
                B64Converter.ToBase64(inputPath, outputPath);

            }
        }
    }
}
