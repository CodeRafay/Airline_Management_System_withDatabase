using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Project
{
    public partial class SignUp : Form
    {
        SignIn parent;
        OracleConnection connect;
        public SignUp(SignIn par, OracleConnection con)
        {
            this.connect = con;
            this.parent = par;
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.textBox1.Hide();
            this.textBox3.Hide();
            this.textBox5.Hide();
            this.button1.Hide();
            this.button3.Hide();
            this.button5.Hide();
            this.button7.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.textBox6.Text == "")
            {
                MessageBox.Show("Name not provided\nPlease provide your name", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (this.textBox4.Text == "")
            {
                MessageBox.Show("CNIC not provided\nPlease provide your CNIC number", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("Phone number not provided\nPlease provide a phone number", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (this.textBox5.Text == "")
            {
                MessageBox.Show("E-Mail not provided\nPlease provide an email address", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Password not provided\nPlease provide a password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (this.textBox3.Text == "")
            {
                MessageBox.Show("Password not confirmed\nPlease confirm your password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(textBox1.Text != textBox3.Text)
            {
                MessageBox.Show("Confirmed password does not match with the password\nPlease confirm your password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string str = textBox4.Text;
            if (str.Length != 15)
            {
                MessageBox.Show("Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8", "Invalid CNIC Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                for (int i = 0; i < 15; i++) if (str[i] != '-' && (str[i] < '0' || str[i] > '9'))
                    {
                        MessageBox.Show("Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8", "Invalid CNIC Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                if (str[5] != '-' || str[13] != '-')
                {
                    MessageBox.Show("Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8", "Invalid CNIC Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

            }
            str = textBox2.Text;
            if (str.Length != 12 || str[4] != '-')
            {
                MessageBox.Show("Invalid Phone Number Format\nPlease use the Format 1234-1234567", "Invalid Phone# Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            for (int i = 0; i < str.Length; i++) if (str[i] != '-' && (str[i] < '0' || str[i] > '9'))
                {
                    MessageBox.Show("Invalid Phone Number Format\nPlease use the Format 1234-1234567", "Invalid Phone# Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            ///////////////////////////////////////////////////////////////////////////////
            OracleCommand search = connect.CreateCommand();
            search.CommandText = "SELECT * FROM PASSENGER WHERE CNIC ='" + textBox4.Text + "'";
            OracleDataReader reader = search.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Entered CNIC is already registered by another user", "Invalid CNIC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            search.CommandText = "SELECT * FROM PASSENGER WHERE PHONE_NO = '" + textBox2.Text + "'";
            reader = search.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Entered Phone number is already registered by another user", "Invalid Phone#", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            search.CommandText = "SELECT * FROM PASSENGER WHERE EMAIL='" + textBox5.Text + "'";
            reader = search.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Entered E-Mail address is already registered by another user", "Invalid E-mail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Random rand = new Random();
            int userID = rand.Next(10000, 99999);
            search.CommandText = "SELECT * FROM PASSENGER WHERE USERID=" + userID.ToString();
            reader = search.ExecuteReader();
            while (reader.Read())
            {
                userID = rand.Next(10000, 99999);
                search.CommandText = "SELECT * FROM PASSENGER WHERE USERID=" + userID.ToString();
                reader = search.ExecuteReader();
            }
            search.CommandText = "INSERT INTO PASSENGER VALUES(" + userID.ToString() + ",'" + textBox4.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox5.Text + "')";
            int insertionSuccess = search.ExecuteNonQuery();
            MessageBox.Show("Account Creation Succesful\nYou will now be moved to the Signin page where you may signin with your new account", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            parent.Show();
            this.Hide();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.button1.Show();
                this.button3.Show();
                this.button5.Show();
                this.button7.Show();
                this.button6.Hide();
                this.button4.Hide();
                this.button8.Hide();
                this.textBox6.Hide();
                this.textBox4.Hide();
                this.textBox2.Hide();
                this.textBox1.Show();
                this.textBox3.Show();
                this.textBox5.Show();
                this.label5.Hide();
                this.label1.Text = "E-Mail";
                this.label2.Text = "Password";
                this.label4.Text = "Confirm Password";
                this.checkBox1.Text = "Previous";
            }
            else
            {
                this.button1.Hide();
                this.button3.Hide();
                this.button5.Hide();
                this.button7.Hide();
                this.button6.Show();
                this.button4.Show();
                this.button8.Show();
                this.textBox6.Show();
                this.textBox4.Show();
                this.textBox2.Show();
                this.textBox1.Hide();
                this.textBox3.Hide();
                this.textBox5.Hide();
                this.label5.Show();
                this.label1.Text = "Name";
                this.label2.Text = "CNIC";
                this.label4.Text = "Phone No.";
                this.checkBox1.Text = "Next";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string str = this.textBox4.Text;
            if (str == "")
            {
                this.label5.Text = "Please use the CNIC Format 12345-1234567-8";
                return;
            }
            if (str.Length != 15) this.label5.Text = "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8";
            else
            {
                this.label5.Text = "";
                for (int i = 0; i < 15; i++) if (str[i] != '-' && (str[i] < '0' || str[i] > '9')) this.label5.Text = "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8";
                if (str[5] != '-' || str[13] != '-') this.label5.Text = "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8";

            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}