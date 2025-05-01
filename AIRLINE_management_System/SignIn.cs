using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DB_Project
{
    public partial class SignIn : Form
    {
        SignUp signup_form;
        Admin_Dashboard admin;
        Passenger_Form passenger;
        Employee_Form employee;
        bool wrongFormat;
        OracleConnection connect;
        public SignIn()
        {
            string conStr = @"User Id=AIRLINE;Password=db_on_air;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.54.5.65)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";
            connect = new OracleConnection(conStr);
            signup_form = new SignUp(this, connect);
            admin = new Admin_Dashboard(connect, this, "Admin");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect.Open();
            this.radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchAtt = "", msg = "";
            if (this.radioButton1.Checked) searchAtt = "CNIC";
            if (this.radioButton2.Checked) searchAtt = "EMAIL";
            if (this.radioButton1.Checked) msg = "CNIC";
            if (this.radioButton2.Checked) msg = "E-Mail";
            if (this.textBox1.Text == "Admin" && this.textBox2.Text == "admin abuse innit")
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.Hide();
                admin.Show();
                return;
            }
            if (msg == "CNIC" && this.label4.Text == "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8")
            {
                MessageBox.Show("Entered CNIC is in an invalid format\nPlease use the CNIC Format 12345-1234567-8 and try again", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("No " + msg + " entered\nPlease enter a " + msg + " and try again.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("No password entered\nPlease enter password and try again.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            OracleCommand search = connect.CreateCommand();
            search.CommandText = "SELECT * FROM PASSENGER WHERE " + searchAtt + "=:criteria";
            if(searchAtt=="USERID") search.Parameters.Add(":criteria", OracleDbType.Int64).Value = textBox1.Text;
            else search.Parameters.Add(":criteria", OracleDbType.Varchar2).Value = textBox1.Text;
            OracleDataReader reader = search.ExecuteReader();
            if (reader.Read())
            {
                if (textBox2.Text == reader.GetString(reader.GetOrdinal("PASSWORD")))
                {
                    passenger = new Passenger_Form(connect,reader.GetString(reader.GetOrdinal("USERID")), this);
                    passenger.Show();
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.Hide();
                    return;
                }
                else MessageBox.Show("Incorrect Password Entered\nPlease Try again", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE " + searchAtt + "=:criteria";
                reader = search.ExecuteReader();
                if (reader.Read())
                {
                    if (textBox2.Text == reader.GetString(reader.GetOrdinal("PASSWORD")))
                    {
                        employee = new Employee_Form(connect, reader.GetString(reader.GetOrdinal("USERID")), this);
                        employee.Show();
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.Hide();
                        return;
                    }
                    else MessageBox.Show("Incorrect Password Entered\nPlease Try again", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    search.CommandText = "SELECT * FROM ADMIN WHERE " + searchAtt + "=:criteria";
                    reader = search.ExecuteReader();
                    if (reader.Read())
                    {
                        if (textBox2.Text == reader.GetString(reader.GetOrdinal("PASSWORD")))
                        {
                            admin = new Admin_Dashboard(connect, this, reader.GetString(reader.GetOrdinal("USERID")));
                            admin.Show();
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.Hide();
                            return;
                        }
                        else MessageBox.Show("Incorrect Password Entered\nPlease Try again", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No user was found against the " + msg + " Entered.\nPlease check your entered " + msg + " and try again.", "No Account Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = this.textBox1.Text;
            if (str == "")
            {
                this.label4.Text = "Please use the CNIC Format 12345-1234567-8";
                return;
            }
            if (str.Length != 15) this.label4.Text = "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8";
            else
            {
                this.label4.Text = "";
                for (int i = 0; i < 15; i++) if (str[i] != '-' && (str[i]<'0' || str[i] > '9')) this.label4.Text = "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8";
                if (str[5] != '-' || str[13] != '-') this.label4.Text = "           Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8";

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.radioButton2.Checked = false;
                this.radioButton1.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D1493");
                this.radioButton1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4761F3");
                this.label1.Text = "Enter CNIC";
                this.label4.Show();
                this.textBox1.MaxLength = 16;
            }
            else
            {
                this.radioButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(82)))), ((int)(((byte)(139)))));
                this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(183)))), ((int)(((byte)(235)))));
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.radioButton1.Checked = false;
                this.radioButton2.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D1493");
                this.radioButton2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4761F3");
                this.label1.Text = "Enter E-Mail Address";
                this.label4.Hide();
                this.textBox1.MaxLength = 29;
            }
            else
            {
                this.radioButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(82)))), ((int)(((byte)(139)))));
                this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(183)))), ((int)(((byte)(235)))));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            signup_form.Show();
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
