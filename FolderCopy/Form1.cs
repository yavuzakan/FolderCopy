﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FolderCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Kaynak";
            label2.Text = "Hedef";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "";
            
            try
            {
                String komut = "robocopy "+textBox2.Text+" " +textBox3.Text+ " /e /xc /xn /xo";
                //textBox1.Text = komut;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + komut;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                while (!process.HasExited)
                {
                    q += process.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                q += "error";
            }
            textBox1.Text = q;
            string fileName = @"1.txt";

            using (FileStream fs = File.Create(fileName))
            {
               
            }
            File.WriteAllText(fileName, textBox1.Text);
       
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
                string a1 = textBox2.Text;
                textBox4.Text = (Path.GetDirectoryName(fbd.SelectedPath));
                string a2 = textBox4.Text;
                textBox5.Text = a1.Replace(a2, "");
            }
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              
                textBox3.Text = fbd.SelectedPath+textBox5.Text;
            }
        }
    }
}
