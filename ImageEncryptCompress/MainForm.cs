using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageEncryptCompress
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw = Stopwatch.StartNew();
            LFSR lfsr = new LFSR(seed.Text,Int32.Parse(tap.Text));
            ImageOperations.DisplayImage(ImageEncrypterDecrypter.EncryptDecrypt(ImageMatrix,lfsr),pictureBox2);
            sw.Stop();
            Console.WriteLine("time = {0} ms", sw.ElapsedMilliseconds);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}