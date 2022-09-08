using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFixScript
{
    public partial class Form1 : Form
    {
        string CurrentlyPath;
        string i3BaseDx_CliPath;
        string CryptoPath;
        string ScriptFile;
        OpenFileDialog FileOpen = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            CurrentlyPath = Directory.GetCurrentDirectory();
            i3BaseDx_CliPath = Path.Combine(CurrentlyPath, "i3BaseDx_Cli.dll");
            CryptoPath = Path.Combine(CurrentlyPath, "Crypto.dll");
            label3.Text = "";
            label4.Text = "";
            this.ActiveControl = label1;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            FileOpen.Filter = "Script Files|Script.i3Pack";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(i3BaseDx_CliPath) || File.Exists(CryptoPath))
            {
                if (textBox1.Text != string.Empty)
                {
                    label3.Text = DLL.CheckProtectionCode(ScriptFile, "Zepetto Inc.", 12) ? "Success" : "Fail";
                    if (label3.Text == "Fail")
                    {
                        label3.ForeColor = Color.Red;
                        button2.Enabled = true;
                    }
                    else
                    {
                        label3.ForeColor = Color.LightGreen;
                        button2.Enabled = false;
                    }
                    button1.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No i3BaseDx_Cli.dll or Crypto.dll file found");
                button1.Enabled = false;
                textBox1.Text = string.Empty;
                ScriptFile = string.Empty;
            }
            this.ActiveControl = label1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(i3BaseDx_CliPath) || File.Exists(CryptoPath))
            {
                label4.Text = DLL.SetProtectionCode(ScriptFile, "Zepetto Inc.", 12) ? "Finish" : "Fail";
                if (label4.Text == "Fail")
                {
                    label4.ForeColor = Color.Red;
                }
                else
                {
                    label4.ForeColor = Color.LightCyan;
                    textBox1.Text = string.Empty;
                }
                button2.Enabled = false;
            }
            else
            {
                MessageBox.Show("No i3BaseDx_Cli.dll or Crypto.dll file found");
                button2.Enabled = false;
                textBox1.Text = string.Empty;
                ScriptFile = string.Empty;
            }
            this.ActiveControl = label1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FileOpen.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FileOpen.FileName;
                ScriptFile = FileOpen.FileName;
                button1.Enabled = true;
                label3.Text = string.Empty;
                label4.Text = string.Empty;
            }
        }

    }
}
