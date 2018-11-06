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

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            bool isB64;
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
    }
}
