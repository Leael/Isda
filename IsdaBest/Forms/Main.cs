using IsdaBest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsdaBest.Forms
{
    public partial class Main : Form
    {
        private readonly int mainThreadId;
        private string path;
        protected bool validData;

        public bool IsMainThread
        {
            get { return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThreadId; }
        }

        public Main()
        {
            InitializeComponent();
            mainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            AllowDrop = true;
            ML.Logger += Log;
            ML.Init();
        }

        private void Log(string line)
        {
            line = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " " + line;
            try
            {
                if (IsMainThread)
                {
                    if (!string.IsNullOrEmpty(textBoxlog.Text)) textBoxlog.AppendText(Environment.NewLine);
                    textBoxlog.AppendText(line);
                }
                else
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        if (!string.IsNullOrEmpty(textBoxlog.Text)) textBoxlog.AppendText(Environment.NewLine);
                        textBoxlog.AppendText(line);
                    }));
                }
            }
            catch
            {
            }
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            filename = string.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                if (e.Data.GetData("FileDrop") is Array data)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is string))
                    {
                        filename = ((string[])data)[0];
                    }
                }
            }
            return true;
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            validData = GetFilename(out string filename, e);
            if (validData)
            {
                path = filename;
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                textBoxFile.Text = path;
            }
        }

        private void ButtonClearLog_Click(object sender, EventArgs e)
        {
            textBoxlog.Text = "";
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxFile.Text = openFileDialog1.FileName;
        }

        private void ButtonClassify_Click(object sender, EventArgs e)
        {
            if (File.Exists(openFileDialog1.FileName))
            {
                Log("ML: Classifying");
                new Processor(openFileDialog1.FileName).ShowDialog();
            }
            else
            {
                MessageBox.Show("File does not exist", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ButtonGenModel_Click(object sender, EventArgs e)
        {
            ML.GenerateModel();
        }
    }
}
