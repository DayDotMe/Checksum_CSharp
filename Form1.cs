using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Checksum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private static string GetSHA2(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {

                
                var sha2 = new SHA256Managed();
                byte[] checksum_sha2 = sha2.ComputeHash(stream);
                return BitConverter.ToString(checksum_sha2).Replace("-", String.Empty);

            }
        }
        private static string GetSHA1(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha1 = new SHA1Managed();
                byte[] checksum_sha1 = sha1.ComputeHash(stream);
                return BitConverter.ToString(checksum_sha1).Replace("-", String.Empty);
            }
        }

        private static string GetMD5(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var md5 = new MD5CryptoServiceProvider();
                byte[] checksum_md5 = md5.ComputeHash(stream);
                return BitConverter.ToString(checksum_md5).Replace("-", String.Empty);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label6.Visible = false;
                textBox4.Text = openFileDialog1.FileName;
                textBox1.Text = GetSHA2(openFileDialog1.FileName);
                textBox2.Text = GetSHA1(openFileDialog1.FileName);
                textBox3.Text = GetMD5(openFileDialog1.FileName);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
      
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBox1.Text);
            }catch (ArgumentNullException) { }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBox2.Text);
            }
            catch (ArgumentNullException) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBox3.Text);
            }
            catch (ArgumentNullException) { }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = textBox5.Text;
            if(input != "")
            {
                if (input == textBox1.Text)
                {
                    label6.Text = "SHA256 OK";
                    label6.Visible = true;
                    label6.ForeColor = System.Drawing.Color.Green;
                }
                else if(input == textBox2.Text)
                {
                    label6.Text = "SHA1 OK";
                    label6.Visible = true;
                    label6.ForeColor = System.Drawing.Color.Green;
                }
                else if(input == textBox3.Text)
                {
                    label6.Text = "MD5 OK";
                    label6.Visible = true;
                    label6.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    label6.Text = "Aucun hash ne correspond";
                    label6.Visible = true;
                    label6.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                label6.Text = "Veuillez saisir un hash !";
                label6.Visible = true;
                label6.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
