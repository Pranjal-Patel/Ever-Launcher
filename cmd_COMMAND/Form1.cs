using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace cmd_COMMAND
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const string path = @"C:\Prob";
        const string Add_Path = @"C:\Prob\";

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Enabled = false;
            panel1.Enabled = false;

            label1.Hide();
            panel1.Hide();

            string[] directFiles = Directory.GetFiles(path);
            string[] subFolders = Directory.GetDirectories(path);

            foreach (string item in subFolders)
            {
                comboBox1.Items.Add(item.Remove(0,8));
            }

            foreach (string item in directFiles)
            {
                string nameOnly = Path.GetFileName(item);
                comboBox1.Items.Add(nameOnly);
            }
        }
        
        private new void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.Text == "Shutdown")
                {
                    panel1.Show();
                    panel1.Enabled = true;

                    label1.Show();
                    label1.Enabled = true;
                }
                else if (comboBox1.Text == "Close")
                {
                    this.Close();
                }
                else
                {
                    //////////////////////////////////////////////
                    ///The main method for opening applications///
                    //////////////////////////////////////////////
                    try
                    {
                        string run = Add_Path + comboBox1.Text;
                        ProcessStartInfo psi = new ProcessStartInfo(run);
                        psi.UseShellExecute = true;
                        psi.CreateNoWindow = true;
                        Process whatever = Process.Start(psi);

                        comboBox1.Text = null;
                        label1.Enabled = false;
                        panel1.Enabled = false;
                        panel1.Hide();
                        label1.Hide();

                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Error", "EVA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HotKey(object sender, KeyEventArgs e)
        {
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Process.Start("Shutdown", @"/Hybrid /S");

            label1.Enabled = false;
            panel1.Enabled = false;

            label1.Hide();
            panel1.Hide();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Process.Start("Shutdown", @"/Hybrid /S");

            label1.Enabled = false;
            panel1.Enabled = false;

            label1.Hide();
            panel1.Hide();
            this.Close();
        }

        private void background_Process(object sender, DoWorkEventArgs e)
        {
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Enabled = false;
            panel1.Enabled = false;

            label1.Hide();
            panel1.Hide();
        }
    }
}