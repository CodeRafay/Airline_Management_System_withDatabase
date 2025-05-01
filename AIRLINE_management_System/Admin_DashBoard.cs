using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Org.BouncyCastle.Asn1.Ess;

namespace DB_Project
{
    public partial class Admin_Dashboard : Form
    {
        string t1;
        int t2;
        OracleConnection connect;
        SignIn signIn;
        string userID;
        public Admin_Dashboard(OracleConnection con, SignIn parent, string id)
        {
            signIn = parent;
            t1 = "";
            this.userID = id;
            t2 = 0;
            this.connect = con;
            InitializeComponent();
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            this.CheckProfile.Checked = true;
        }

        private void CheckProfile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckProfile.Checked)
            {
                this.CheckProfile.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.CheckProfile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                //.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                //.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.addEmp.Checked = false;
                this.manageEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.revenue.Checked = false;
                this.viewFlight.Checked = false;
                this.assignTask.Checked = false;
                this.feedback.Checked = false;
                //first hide everything(hiding all labels at start)
                hideAll();

                //show relevant buttons and text boxes
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                if (userID == "Admin")
                {
                    label2.Text = "UserId: 0000";
                    //take user id from DB and concat with label2
                    label3.Text = "Name: Admin";
                    //take Name from DB and concat with label3
                    label4.Text = "CNIC:NULL-NULL-NULL";
                    //take CNIC from DB and concat with label4
                    label5.Text = "Email: NULL@NULL.NULL";
                    //take Email from DB and concat with label5
                    label6.Text = "Phone Number: NULL NULLNULL";
                    //take phoneNo from DB and concat with label6
                    this.textBox6.UseSystemPasswordChar = true;
                    this.textBox7.UseSystemPasswordChar = true;
                }

            }
            else
            {
                this.CheckProfile.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.CheckProfile.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
                this.textBox6.UseSystemPasswordChar = false;
                this.textBox7.UseSystemPasswordChar = false;

            }
        }

        private void addEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.addEmp.Checked)
            {
                this.addEmp.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.addEmp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.manageEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.revenue.Checked = false;
                this.viewFlight.Checked = false;
                this.assignTask.Checked = false;
                this.feedback.Checked = false;
                //first hide everything(hiding all labels at start)
                hideAll();

                //show relevant buttons and text boxes

                this.textBox2.MaxLength = 30; //name
                this.textBox3.MaxLength = 16; //cnic
                this.textBox4.MaxLength = 29; //email
                this.textBox5.MaxLength = 13; //phone number
                this.textBox6.MaxLength = 29; //password
                this.textBox7.MaxLength = 29; //password

                this.label3.Show();
                this.label4.Show();
                this.label5.Show();
                this.label6.Show();
                this.label7.Show();
                this.label8.Show();

                this.textBox2.Show();
                this.textBox3.Show();
                this.textBox4.Show();
                this.textBox5.Show();
                this.textBox6.Show();
                this.textBox7.Show();

                this.button4.Show();
                this.button5.Show();
                this.button6.Show();
                this.button7.Show();
                this.button8.Show();
                this.button9.Show();

                button1.Show();
                label2.Text = "UserId:";
                //take user id from DB and concat with label2
                label3.Text = "Name:";
                //take Name from DB and concat with label3
                label4.Text = "CNIC:";
                //take CNIC from DB and concat with label4
                label5.Text = "Email:";
                //take Email from DB and concat with label5
                label6.Text = "Phone Number:";
                //take phoneNo from DB and concat with label6
                label7.Text = "Password:";
                label8.Text = "Confirm Password:";

                button1.Text = "Insert";
                


            }
            else
            {
                this.addEmp.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.addEmp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void manageEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manageEmp.Checked)
            {
                this.textBox2.MaxLength = 30; //name
                this.textBox3.MaxLength = 16; //cnic
                this.textBox4.MaxLength = 29; //email
                this.textBox5.MaxLength = 13; //phone number
                this.textBox6.MaxLength = 29; //password
                this.textBox7.MaxLength = 29; //password
                this.manageEmp.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.manageEmp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.addEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.revenue.Checked = false;
                this.viewFlight.Checked = false;
                this.assignTask.Checked = false;
                this.feedback.Checked = false;
                //first hide everything(hiding all labels at start)
                hideAll();

                //show relevant buttons and text boxes 

                this.label3.Show();
                this.label4.Show();
                this.label5.Show();
                this.label6.Show();
                this.label7.Show();
                this.label8.Show();
                this.label9.Show();

                this.textBox2.Show();
                this.textBox3.Show();
                this.textBox4.Show();
                this.textBox5.Show();
                this.textBox6.Show();
                this.textBox7.Show();
                this.textBox8.Show();

                this.button4.Show();
                this.button5.Show();
                this.button6.Show();
                this.button7.Show();
                this.button8.Show();
                this.button9.Show();
                this.button10.Show();

                button1.Show();
                button2.Show();

             
                dataGridView1.Show();

                label9.Text = "Enter Employee ID:";

                label2.Text = "UserId:";
                //take user id from DB and concat with label2
                label3.Text = "Name:";
                //take Name from DB and concat with label3
                label4.Text = "CNIC:";
                //take CNIC from DB and concat with label4
                label5.Text = "Email:";
                //take Email from DB and concat with label5
                label6.Text = "Phone Number:";
                //take phoneNo from DB and concat with label6
                label7.Text = "Password:";
                label8.Text = "Confirm Password:";

                button1.Text = "Update";
                this.button2.Text = "Search";
                
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM EMPLOYEE";
                search.CommandType = CommandType.Text;
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            else
            {
                this.manageEmp.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.manageEmp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void manageFlight_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manageFlight.Checked)
            {
                this.textBox2.MaxLength = 5;
                this.textBox3.MaxLength = 29;
                this.textBox4.MaxLength = 29;
                this.textBox5.MaxLength = 19;
                this.textBox6.MaxLength = 19;
                this.textBox7.MaxLength = 14;

                this.manageFlight.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.manageFlight.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.addEmp.Checked = false;
                this.manageEmp.Checked = false;
                this.revenue.Checked = false;
                this.viewFlight.Checked = false;
                this.assignTask.Checked = false;
                this.feedback.Checked = false;
                //first hide everything(hiding all labels at start)
                hideAll();

                //show relevant buttons and text boxes
                this.label3.Show();
                this.label4.Show();
                this.label5.Show();
                this.label6.Show();
                this.label7.Show();
                this.label8.Show();
                this.label9.Show();

                this.textBox2.Show();
                this.textBox3.Show();
                this.textBox4.Show();
                this.textBox5.Show();
                this.textBox6.Show();
                this.textBox7.Show();
                this.textBox8.Show();

                this.button1.Show();
                this.button2.Show();

                this.checkBox1.Show();
                this.checkBox2.Show();

                this.button4.Show();
                this.button5.Show();
                this.button6.Show();
                this.button7.Show();
                this.button8.Show();
                this.button9.Show();
                this.button10.Show();

                this.label8.Hide();
                this.label9.Hide();
                this.textBox7.Hide();
                this.textBox8.Hide();
                this.button2.Hide();
                this.button9.Hide();
                this.button10.Hide();
                this.dataGridView1.Show();

                label9.Text = "Enter Flight ID:";

                label3.Text = "Aircraft ID:";
                //take user id from DB and concat with label2
                label4.Text = "Departure Location:";
                //take Name from DB and concat with label3
                label5.Text = "Arrival Location:";
                //take CNIC from DB and concat with label4
                label6.Text = "Departure Time:";
                //take Email from DB and concat with label5
                label7.Text = "Arrival Time:";
                //take phoneNo from DB and concat with label6
                label8.Text = "Status:";

                checkBox1.Text = "Add";
                checkBox2.Text = "Update";

                button1.Text = "Submit";
                this.button2.Text = "Search";
                this.checkBox1.Checked = true;
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM AIRCRAFT";
                search.CommandType = CommandType.Text;
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            else
            {
                this.manageFlight.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.manageFlight.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void revenue_CheckedChanged(object sender, EventArgs e)
        {
            if (this.revenue.Checked)
            {
                this.revenue.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.revenue.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.addEmp.Checked = false;
                this.manageEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.viewFlight.Checked = false;
                this.assignTask.Checked = false;
                this.feedback.Checked = false;
                //first hide everything(hiding all labels at start)
                hideAll();
                //show rerleveant stuff
                this.dataGridView1.Location = new System.Drawing.Point(175, 82);
                this.dataGridView1.Size = new System.Drawing.Size(670, 674);
                this.button1.Show();
                this.dataGridView1.Show();
                this.button1.Text = "Print";
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM REVENUE";
                search.CommandType = CommandType.Text;
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            }
            else
            {
                this.revenue.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.revenue.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
                this.dataGridView1.Location = new System.Drawing.Point(175, 395);
                this.dataGridView1.Size = new System.Drawing.Size(323, 256);
            }
        }

        private void viewFlight_CheckedChanged(object sender, EventArgs e)
        {
            if (this.viewFlight.Checked)
            {
                this.viewFlight.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.viewFlight.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.addEmp.Checked = false;
                this.manageEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.revenue.Checked = false;
                this.assignTask.Checked = false;
                this.feedback.Checked = false;
                //hide all
                hideAll();
                //show relevant stuff
                this.dataGridView1.Location = new System.Drawing.Point(175, 82);
                this.dataGridView1.Size = new System.Drawing.Size(670, 674);
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM FLIGHT";
                search.CommandType = CommandType.Text;
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                this.dataGridView1.Show();
            }
            else
            {
                this.viewFlight.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.viewFlight.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
                this.dataGridView1.Location = new System.Drawing.Point(175, 395);
                this.dataGridView1.Size = new System.Drawing.Size(323, 256);
            }
        }

        private void assignTask_CheckedChanged(object sender, EventArgs e)
        {
            if (this.assignTask.Checked)
            {
                this.textBox4.MaxLength = 49;
                this.assignTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.assignTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.addEmp.Checked = false;
                this.manageEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.revenue.Checked = false;
                this.viewFlight.Checked = false;
                this.feedback.Checked = false;
                this.checkBox1.Checked = true;
                // first hide everything (hiding all labels at start)
                hideAll();
                //SHOW RELEVANT STUFF

                label3.Show();
                label4.Show();
                label5.Show();

                button1.Show();
                button4.Show();
                button5.Show();
                button6.Show();

                textBox2.Show();
                textBox3.Show();
                textBox4.Show();

                dataGridView1.Show();

                checkBox1.Show();
                checkBox2.Show();

                label9.Text = "Enter Employee ID:";
                label3.Text = "Employee ID:";
                //take Name from DB and concat with label3
                label4.Text = "Flight ID:";
                label5.Text = "Task:";
                //take CNIC from DB and concat with label4

                checkBox1.Text = "Employees";
                checkBox2.Text = "Flights";

                button1.Text = "Assign";
            }
            else
            {
                this.assignTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.assignTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void feedback_CheckedChanged(object sender, EventArgs e)
        {
            if (this.feedback.Checked)
            {
                this.feedback.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.feedback.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.CheckProfile.Checked = false;
                this.addEmp.Checked = false;
                this.manageEmp.Checked = false;
                this.manageFlight.Checked = false;
                this.revenue.Checked = false;
                this.viewFlight.Checked = false;
                this.assignTask.Checked = false;
                // first hide everything (hiding all labels at start)
                hideAll();
                hideAll();
                //show relevant stuff
                this.dataGridView1.Location = new System.Drawing.Point(175, 82);
                this.dataGridView1.Size = new System.Drawing.Size(670, 674);
                this.dataGridView1.Show();
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM FEEDBACK";
                search.CommandType = CommandType.Text;
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            else
            {
                this.feedback.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.feedback.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
                this.dataGridView1.Location = new System.Drawing.Point(175, 395);
                this.dataGridView1.Size = new System.Drawing.Size(323, 256);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.addEmp.Checked)
            {
                if (this.textBox2.Text == "")
                {
                    MessageBox.Show("Employee Name not provided\nPlease enter a name in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox3.Text == "")
                {
                    MessageBox.Show("Employee CNIC not provided\nPlease enter a CNIC in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox4.Text == "")
                {
                    MessageBox.Show("Employee E-Mail not provided\nPlease enter an email address in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox5.Text == "")
                {
                    MessageBox.Show("Employee Phone Number not provided\nPlease enter a phone number in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox6.Text == "")
                {
                    MessageBox.Show("Password not provided\nPlease enter a password in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox7.Text != textBox6.Text)
                {
                    MessageBox.Show("Password not confirmed\nPasswords entered in Password and Confirm password field do not match", "Error: Unmatching Passkeys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string str = textBox3.Text;
                if (str.Length != 15)
                {
                    MessageBox.Show("Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8", "Invalid CNIC Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    this.label4.Text = "";
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
                str = textBox5.Text;
                if (str.Length != 12 || str[4] != '-')
                {
                    MessageBox.Show("Invalid Phone Number Format\nPlease use the Format 1234-1234567", "Invalid Phone# Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                for(int i = 0; i < str.Length; i++) if (str[i]!= '-' && (str[i] < '0' || str[i] > '9'))
                    {
                        MessageBox.Show("Invalid Phone Number Format\nPlease use the Format 1234-1234567", "Invalid Phone# Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE CNIC ='" + textBox3.Text + "'";
                OracleDataReader reader = search.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Entered CNIC is already registered against another employee", "Invalid CNIC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE PHONE_NO = '"+textBox5.Text + "'";
                reader = search.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Entered Phone number is already registered against another employee", "Invalid Phone#", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE EMAIL='" + textBox4.Text+"'";
                reader = search.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Entered E-Mail address is already registered against another employee", "Invalid E-mail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Random rand = new Random();
                int userID = rand.Next(10000,99999);
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + userID.ToString();
                reader = search.ExecuteReader();
                while (reader.Read())
                {
                    userID = rand.Next(10000, 99999);
                    search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + userID.ToString();
                    reader = search.ExecuteReader();
                }
                search.CommandText = "INSERT INTO EMPLOYEE VALUES(" + userID.ToString() + ",'" + textBox3.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox4.Text + "')";
                int insertionSuccess = search.ExecuteNonQuery();
                MessageBox.Show("Employee Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
            }
            if (this.manageEmp.Checked)
            {
                if (this.textBox2.Text == "")
                {
                    MessageBox.Show("Employee Name not provided\nPlease enter a name in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox3.Text == "")
                {
                    MessageBox.Show("Employee CNIC not provided\nPlease enter a CNIC in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox4.Text == "")
                {
                    MessageBox.Show("Employee E-Mail not provided\nPlease enter an email address in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox5.Text == "")
                {
                    MessageBox.Show("Employee Phone Number not provided\nPlease enter a phone number in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox6.Text == "")
                {
                    MessageBox.Show("Password not provided\nPlease enter a password in the appropriate field and try again", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.textBox7.Text != textBox6.Text)
                {
                    MessageBox.Show("Password not confirmed\nPasswords entered in Password and Confirm password field do not match", "Error: Unmatching Passkeys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string str = textBox3.Text;
                if (str.Length != 15)
                {
                    MessageBox.Show("Invalid CNIC Format\nPlease use the CNIC Format 12345-1234567-8", "Invalid CNIC Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    this.label4.Text = "";
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
                str = textBox5.Text;
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
                
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE CNIC ='" + textBox3.Text + "'";
                OracleDataReader reader = search.ExecuteReader();
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + t1;
                OracleDataReader reader2 = search.ExecuteReader();
                if (reader.Read() && reader.GetString(reader.GetOrdinal("CNIC")) != textBox3.Text)
                {
                    MessageBox.Show("Entered CNIC is already registered against another employee", "Invalid CNIC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE PHONE_NO = '" + textBox5.Text + "'";
                reader = search.ExecuteReader();
                if (reader.Read() && reader.GetString(reader.GetOrdinal("PHONE_NO")) != textBox5.Text)
                {
                    MessageBox.Show("Entered Phone number is already registered against another employee", "Invalid Phone#", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE EMAIL='" + textBox4.Text + "'";
                reader = search.ExecuteReader();
                if (reader.Read() && reader.GetString(reader.GetOrdinal("EMAIL")) != textBox4.Text)
                {
                    MessageBox.Show("Entered E-Mail address is already registered against another employee", "Invalid E-mail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "UPDATE EMPLOYEE SET USERID=" + t1 + ",CNIC='" + textBox3.Text + "',NAME='" + textBox2.Text + "',PHONE_NO='" + textBox5.Text + "',PASSWORD='" + textBox6.Text + "',EMAIL='" + textBox4.Text + "' WHERE USERID = " + t1;
                int upd = search.ExecuteNonQuery();
                search.CommandText = "SELECT * FROM EMPLOYEE";
                search.CommandType = CommandType.Text;
                reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                MessageBox.Show("Employee Modified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
            }
            if (this.manageFlight.Checked)
            {
                if (this.checkBox1.Checked)
                {
                    if(this.textBox2.Text == "")
                    {
                        MessageBox.Show("No Aircraft ID Provided\nPlease enter an aircraft ID", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox3.Text == "")
                    {
                        MessageBox.Show("No Departure Location Provided\nPlease enter a location", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox4.Text == "")
                    {
                        MessageBox.Show("No Arrival Location Provided\nPlease enter a location", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox5.Text == "")
                    {
                        MessageBox.Show("No Departure Time Provided\nPlease enter a time", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox6.Text == "")
                    {
                        MessageBox.Show("No Arrival Time Provided\nPlease enter a time", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int i = 0; i < textBox2.Text.Length; i++) if (textBox2.Text[i] < '0' || textBox2.Text[i] > '9')
                    {
                        MessageBox.Show("Flight ID must be a number\nNon Numeric characters are not allowed", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    DateTime Departure;
                    if (!DateTime.TryParseExact(this.textBox5.Text, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Departure))
                    {
                        MessageBox.Show("Please use the format MM-DD-YY HH:MM:SS for the date and time", "Error: Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    DateTime Arrival;
                    if (!DateTime.TryParseExact(this.textBox6.Text, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Arrival))
                    {
                        MessageBox.Show("Please use the format MM-DD-YYYY HH:MM:SS for the date and time","Error: Invalid Format",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    OracleCommand search = connect.CreateCommand();
                    OracleDataReader reader;
                    Random rand = new Random();
                    int flightID = rand.Next(10000, 99999);
                    search.CommandText = "SELECT * FROM FLIGHT WHERE FLIGHT_ID=" + flightID.ToString();
                    reader = search.ExecuteReader();
                    while (reader.Read())
                    {
                        flightID = rand.Next(10000, 99999);
                        search.CommandText = "SELECT * FROM FLIGHT WHERE FLIGHT_ID=" + flightID.ToString();
                        reader = search.ExecuteReader();
                    }
                    search.CommandText = "SELECT * FROM AIRCRAFT WHERE AIRCRAFT_ID=" + textBox2.Text;
                    reader = search.ExecuteReader();
                    if (!reader.Read())
                    {
                        MessageBox.Show("No aircraft found with that ID", "Error: Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    string str = textBox3.Text.ToUpper();
                    string str2 = textBox4.Text.ToUpper();
                    string seats = reader.GetString(reader.GetOrdinal("SEATS"));
                    search.CommandText = "INSERT INTO FLIGHT VALUES(" + flightID.ToString() + ", '" + str2 + "', '" + str + "', TO_TIMESTAMP('" + textBox6.Text + "', 'MM-DD-YYYY HH24:MI:SS'), TO_TIMESTAMP('" + textBox5.Text + "', 'MM-DD-YYYY HH24:MI:SS'), 'Pending', " + textBox2.Text + ", " + seats + ")";
                    search.ExecuteNonQuery();
                    MessageBox.Show("Flight Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                    this.textBox6.Text = "";
                    this.textBox7.Text = "";
                    this.textBox8.Text = "";
                }
                if (this.checkBox2.Checked)
                {
                    if (this.textBox2.Text == "")
                    {
                        MessageBox.Show("No Aircraft ID Provided\nPlease enter an aircraft ID", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox3.Text == "")
                    {
                        MessageBox.Show("No Departure Location Provided\nPlease enter a location", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox4.Text == "")
                    {
                        MessageBox.Show("No Arrival Location Provided\nPlease enter a location", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox5.Text == "")
                    {
                        MessageBox.Show("No Departure Time Provided\nPlease enter a time", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox6.Text == "")
                    {
                        MessageBox.Show("No Arrival Time Provided\nPlease enter a time", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.textBox7.Text == "")
                    {
                        MessageBox.Show("No Flight Status\nPlease enter the flight status", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int i = 0; i < textBox2.Text.Length; i++) if (textBox2.Text[i] < '0' || textBox2.Text[i] > '9')
                        {
                            MessageBox.Show("Flight ID must be a number\nNon Numeric characters are not allowed", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    DateTime Departure;
                    if (!DateTime.TryParseExact(this.textBox5.Text, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Departure))
                    {
                        MessageBox.Show("Please use the format MM-DD-YY HH:MM:SS for the date and time", "Error: Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    DateTime Arrival;
                    if (!DateTime.TryParseExact(this.textBox6.Text, "MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Arrival))
                    {
                        MessageBox.Show("Please use the format MM-DD-YYYY HH:MM:SS for the date and time", "Error: Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    OracleCommand search = connect.CreateCommand();
                    search.CommandText = "SELECT * FROM AIRCRAFT WHERE AIRCRAFT_ID=" + textBox2.Text;
                    OracleDataReader reader2 = search.ExecuteReader();
                    string seats = "";
                    string str = textBox3.Text.ToUpper();
                    string str2 = textBox4.Text.ToUpper();
                    if (reader2.Read()) seats = reader2.GetString(reader2.GetOrdinal("SEATS"));
                    search.CommandText = "UPDATE FLIGHT SET FLIGHT_ID=" + t1 + ", DESTINATION='" + str2 + "', DEPARTURE_LOCATION='" + str + "', ARRIVAL_TIME=TO_TIMESTAMP('" + textBox6.Text + "', 'MM-DD-YYYY HH24:MI:SS'), DEPARTURE_TIME=TO_TIMESTAMP('" + textBox5.Text + "', 'MM-DD-YYYY HH24:MI:SS'), STATUS='" + textBox7.Text + "', AIRCRAFT_ID=" + textBox2.Text + ", AV_SEATS=" + seats + " WHERE FLIGHT_ID=" + t1;
                    search.ExecuteNonQuery();
                    search.CommandText = "SELECT * FROM FLIGHT";
                    search.CommandType = CommandType.Text;
                    OracleDataReader reader = search.ExecuteReader();
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    dataGridView1.DataSource = DT;
                    this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    MessageBox.Show("Flight Modified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                    this.textBox6.Text = "";
                    this.textBox7.Text = "";
                    this.textBox8.Text = "";
                }
            }
            if (this.revenue.Checked)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "Reports");
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                filePath += "/Revenue_Report.pdf";
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();
                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                foreach (DataGridViewColumn column in dataGridView1.Columns) table.AddCell(column.HeaderText);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null) table.AddCell(cell.Value.ToString()); 
                        else table.AddCell("");
                    }
                }
                document.Add(table);
                document.Close();
                MessageBox.Show("Revenue report generated, Check Reports folder on your Desktop", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.assignTask.Checked)
            {
                if(textBox2.Text == "")
                {
                    MessageBox.Show("No Employee ID provided\nEnter an Employee ID to assign a task", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("No Flight ID provided\nEnter an Flight ID to assign a task", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("No Task provided\nPlease assign a task", "Error: Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string str = textBox2.Text;
                for (int i = 0; i < str.Length; i++) if (str[i] < '0' || str[i] > '9')
                {
                    MessageBox.Show("Employee ID must be a number\nNon Numeric characters are not allowed", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                str = textBox3.Text;
                for (int i = 0; i < str.Length; i++) if (str[i] < '0' || str[i] > '9')
                {
                    MessageBox.Show("Flight ID must be a number\nNon Numeric characters are not allowed", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                OracleCommand search = connect.CreateCommand();
                OracleDataReader reader;
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID="+textBox2.Text;
                reader = search.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("No employee found against the entered ID", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "SELECT * FROM FLIGHT WHERE FLIGHT_ID="+textBox3.Text;
                reader = search.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("No flight found against the entered ID", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Random rand = new Random();
                int taskID = rand.Next(10000, 99999);
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + taskID.ToString();
                reader = search.ExecuteReader();
                while (reader.Read())
                {
                    taskID = rand.Next(10000, 99999);
                    search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + taskID.ToString();
                    reader = search.ExecuteReader();
                }
                search.CommandText = "INSERT INTO TASK VALUES(" + taskID + ", " + textBox2.Text + ", " + textBox3.Text + ", '" + textBox4.Text + "')";
                search.ExecuteNonQuery();
                MessageBox.Show("Task Assigned", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manageFlight.Checked)
            {
                if (checkBox1.Checked)
                {
                    checkBox2.Checked = false;
                    this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(82)))), ((int)(((byte)(139)))));
                    this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                    this.label8.Hide();
                    this.label9.Hide();
                    this.textBox7.Hide();
                    this.textBox8.Hide();
                    this.button2.Hide();
                    this.button9.Hide();
                    this.button10.Hide();
                    this.dataGridView1.Show();


                    this.button2.Text = "Search";
                    OracleCommand search = connect.CreateCommand();
                    search.CommandText = "SELECT * FROM AIRCRAFT";
                    search.CommandType = CommandType.Text;
                    OracleDataReader reader = search.ExecuteReader();
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    dataGridView1.DataSource = DT;
                    this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                else
                {
                    if (!this.checkBox2.Checked) this.checkBox2.Checked = true;
                    this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(213)))), ((int)(((byte)(252)))));
                    this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                }
            }
            if (this.assignTask.Checked)
            {
                if (this.checkBox1.Checked)
                {
                    this.checkBox2.Checked = false;
                    this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(82)))), ((int)(((byte)(139)))));
                    this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                    OracleCommand search = connect.CreateCommand();
                    search.CommandText = "SELECT * FROM EMPLOYEE";
                    search.CommandType = CommandType.Text;
                    OracleDataReader reader = search.ExecuteReader();
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    dataGridView1.DataSource = DT;
                    this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                else
                {
                    if (!this.checkBox2.Checked) this.checkBox2.Checked = true;
                    this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(213)))), ((int)(((byte)(252)))));
                    this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manageFlight.Checked)
            {
                if (checkBox2.Checked)
                {
                    this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(82)))), ((int)(((byte)(139)))));
                    this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                    checkBox1.Checked = false;
                    this.label8.Show();
                    this.label9.Show();
                    this.textBox7.Show();
                    this.textBox8.Show();
                    this.button2.Show();
                    this.button9.Show();
                    this.button10.Show();
                    this.dataGridView1.Show();

                    this.button2.Text = "Search";
                    OracleCommand search = connect.CreateCommand();
                    search.CommandText = "SELECT * FROM FLIGHT";
                    search.CommandType = CommandType.Text;
                    OracleDataReader reader = search.ExecuteReader();
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    dataGridView1.DataSource = DT;
                    this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                else
                {
                    if (!this.checkBox1.Checked) this.checkBox1.Checked = true;
                    this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(213)))), ((int)(((byte)(252)))));
                    this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));

                }
            }
            if (this.assignTask.Checked)
            {
                if (this.checkBox2.Checked)
                {
                    OracleCommand search = connect.CreateCommand();
                    search.CommandText = "SELECT * FROM FLIGHT";
                    search.CommandType = CommandType.Text;
                    OracleDataReader reader = search.ExecuteReader();
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    dataGridView1.DataSource = DT;
                    this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    this.checkBox1.Checked = false;
                    this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(82)))), ((int)(((byte)(139)))));
                    this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                }
                else
                {
                    if (!this.checkBox1.Checked) this.checkBox1.Checked = true;
                    this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(213)))), ((int)(((byte)(252)))));
                    this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(12)))), ((int)(((byte)(83)))));
                }
            }
        }
        private void hideAll()
        {
            this.label2.Hide();
            this.label3.Hide();
            this.label4.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.label7.Hide();
            this.label8.Hide();
            this.label9.Hide();

            this.textBox1.Hide();
            this.textBox2.Hide();
            this.textBox3.Hide();
            this.textBox4.Hide();
            this.textBox5.Hide();
            this.textBox6.Hide();
            this.textBox7.Hide();
            this.textBox8.Hide();

            this.button3.Hide();
            this.button4.Hide();
            this.button5.Hide();
            this.button6.Hide();
            this.button7.Hide();
            this.button8.Hide();
            this.button9.Hide();
            this.button10.Hide();

            this.button1.Hide();
            this.button2.Hide();

            this.checkBox1.Hide();
            this.checkBox2.Hide();
            this.dataGridView1.Hide();
            this.dataGridView1.Location = new System.Drawing.Point(178, 214);
            this.dataGridView1.Size = new System.Drawing.Size(323, 256);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.manageEmp.Checked)
            {
                string str = textBox8.Text;
                if (str == "")
                {
                    MessageBox.Show("Please provide a User ID of an employee to edit details", "No ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                for (int i = 0; i < str.Length; i++) if (str[i] < '0' || str[i] > '9')
                {
                    MessageBox.Show("User ID must be a number\nNon Numeric characters are not allowed", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                OracleCommand search = connect.CreateCommand();
                t1 = textBox8.Text;
                t2 = int.Parse(t1);
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + t1;
                OracleDataReader reader = search.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox2.Text = reader.GetString(reader.GetOrdinal("NAME"));
                    this.textBox3.Text = reader.GetString(reader.GetOrdinal("CNIC"));
                    this.textBox4.Text = reader.GetString(reader.GetOrdinal("EMAIL"));
                    this.textBox5.Text = reader.GetString(reader.GetOrdinal("PHONE_NO"));
                    this.textBox6.Text = reader.GetString(reader.GetOrdinal("PASSWORD"));
                    this.textBox7.Text = reader.GetString(reader.GetOrdinal("PASSWORD"));
                }
                else
                {
                    MessageBox.Show("No Employee found against entered ID", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }
            }
            if(this.manageFlight.Checked && this.checkBox2.Checked)
            {
                string str = textBox8.Text;
                if (str == "")
                {
                    MessageBox.Show("Please provide a Flight ID to edit details", "No ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                for (int i = 0; i < str.Length; i++) if (str[i] < '0' || str[i] > '9')
                {
                    MessageBox.Show("Flight ID must be a number\nNon Numeric characters are not allowed", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                OracleCommand search = connect.CreateCommand();
                t1 = textBox8.Text;
                t2 = int.Parse(t1);
                search.CommandText = "SELECT * FROM FLIGHT WHERE FLIGHT_ID=" + t1;
                OracleDataReader reader = search.ExecuteReader();
                if (reader.Read())
                {
                    this.textBox2.Text = reader.GetString(reader.GetOrdinal("AIRCRAFT_ID"));
                    this.textBox3.Text = reader.GetString(reader.GetOrdinal("DEPARTURE_LOCATION"));
                    this.textBox4.Text = reader.GetString(reader.GetOrdinal("DESTINATION"));
                    DateTime departureTime = reader.GetDateTime(reader.GetOrdinal("DEPARTURE_TIME"));
                    DateTime arrivalTime = reader.GetDateTime(reader.GetOrdinal("ARRIVAL_TIME"));
                    this.textBox5.Text = departureTime.ToString("MM-dd-yyyy HH:mm:ss");
                    this.textBox6.Text = arrivalTime.ToString("MM-dd-yyyy HH:mm:ss");
                    this.textBox7.Text = reader.GetString(reader.GetOrdinal("STATUS"));
                }
                else
                {
                    MessageBox.Show("No Flight found against entered ID", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            signIn.Show();
            this.Hide();
        }
    }
}
