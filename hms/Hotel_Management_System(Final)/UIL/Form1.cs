using Hotel_Management_System_Final_.BLL;
using Hotel_Management_System_Final_.DAL.DAO;
using Hotel_Management_System_Final_.UIL;
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

namespace Hotel_Management_System_Final_
{
    public partial class SignUp_Form1 : Form
    {
        public SignUp_Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUp_Form1_Load(object sender, EventArgs e)
        {
            string userName = System.Environment.UserName;
            try
            {
                if (File.ReadAllText(@"C:\Users\"+userName+ @"\Documents\DataSource.txt") != "")
                {
                    srvrs_addresspanel20.Visible = false;
                    groupBox2.Visible = true;
                    label2.Visible = true;
                }
            }
            catch
            {
                groupBox2.Visible = false ;
                label2.Visible = false;
                srvrs_addresspanel20.Visible = true;
                
            }




            Username_label4.Visible = false;
            Password_label5.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            Username_label4.Visible = true;

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Username_textBox2.Text = "";
            Username_label4.Visible = true;
            Password_Warning_label4.Text = "";

        }

        private void Password_textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Password_textBox1.Text = "";
            Password_label5.Visible = true;
            Password_textBox1.PasswordChar = '\u25CF';
            Password_Warning_label4.Text = "";
        }


        private void Password_textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserNamePasswordCheck();
        }
        private void UserNamePasswordCheck()
        {
            string EncryptedPassword = EncryptPassword(Password_textBox1.Text);
            SystemAccess aSystenAccess = new SystemAccess();
            aSystenAccess.Username = Username_textBox2.Text;
            aSystenAccess.Password = EncryptedPassword;
            SignInBLL aSignInBLL = new SignInBLL();
            bool result = aSignInBLL.Check_UserID_and_PasswordBLL(aSystenAccess);
            if (result)
            {
                Frontend aFrontend = new Frontend();
                aFrontend.Show();
                this.Hide();
            }
            else
            {
                Password_Warning_label4.Text = "!!!  Wrong UserID or Password  !!!";
            }
        }
        private void Username_textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserNamePasswordCheck();
            }
            if (e.KeyCode == Keys.Down)
            {
                this.ActiveControl = Password_textBox1;
                Password_textBox1.Text = "";
                Password_textBox1.PasswordChar = '\u25CF';
                Password_label5.Visible = true;
                Password_Warning_label4.Text = "";

            }

        }

        private void Password_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserNamePasswordCheck();
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ActiveControl = Username_textBox2;
                Username_textBox2.Text = "";
                Username_label4.Visible = true;
                Password_Warning_label4.Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)//Attach Database Server address
        {
            string userName = System.Environment.UserName;
            File.WriteAllText(@"C:\Users\" + userName + @"\Documents\DataSource.txt", SQLServer_adreress_textBox1.Text);
            MessageBox.Show("Database Server Address successfully saved");
            label2.Visible =true;
            groupBox2.Visible = true;
            srvrs_addresspanel20.Visible = false;
            
        }


        string hash = "f0xle@rn";
        public string EncryptPassword(string Password)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(Password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string EncryptedPassword = Convert.ToBase64String(results, 0, results.Length);
                    return EncryptedPassword;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Down)
            {
                Username_textBox2.Text = "";
                this.ActiveControl = Username_textBox2;
                Username_label4.Visible = true;
            }
        }

        private void SelectPathButton_button2_Click(object sender, EventArgs e)
        {

        }
    }
}
