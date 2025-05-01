using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DB_Project
{
    public partial class Employee_Form : Form
    {
        OracleConnection connect;
        string userID;
        SignIn signIn;
        public Employee_Form(OracleConnection con, string id, SignIn signIn)
        {
            this.connect = con;
            this.userID = id;
            InitializeComponent();
            this.signIn = signIn;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                hideAll();
                this.radioButton1.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM EMPLOYEE WHERE USERID=" + userID;
                OracleDataReader reader = search.ExecuteReader();
                if (reader.Read()) this.label3.Text = "Name: " + reader.GetString(reader.GetOrdinal("NAME")) + "\n\nCNIC: " + reader.GetString(reader.GetOrdinal("CNIC")) + "\n\nE-Mail: " + reader.GetString(reader.GetOrdinal("EMAIL")) + "\n\nPhone Number: " + reader.GetString(reader.GetOrdinal("PHONE_NO"));
                this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
                this.label3.Location = new System.Drawing.Point(180, 165);
                this.label3.Show();
            }
            else
            {
                this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
                this.label3.Location = new System.Drawing.Point(184, 115);
                this.radioButton1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                hideAll();
                this.textBox1.Show();
                this.button1.Show();
                this.button3.Show();
                this.button4.Show();
                this.textBox3.Show();
                this.label3.Text = "Search By Name";
                this.label5.Text = "Enter Booking ID: ";
                this.button1.Text = "Sell";
                this.textBox1.Text = "";
                this.label3.Show();
                this.label5.Show();
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT B.BOOKING_ID AS \"Booking ID\", P.NAME AS \"Booked By\", P.CNIC, P.PHONE_NO AS \"Phone no.\", B.SEAT_NO AS \"Seat#\", F.\"DEPARTURE_LOCATION\" AS \"Departure Location\", F.DESTINATION AS \"Destination\", F.DEPARTURE_TIME AS \"Departure Time\" FROM BOOKING B, PASSENGER P, FLIGHT F WHERE B.PASSENGER_ID = P.USERID AND B.FLIGHT_ID = F.FLIGHT_ID AND B.TICKET = 'Not Sold'";
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                this.dataGridView1.Show();
                this.radioButton2.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
            }
            else
            {
                this.radioButton2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked)
            {
                hideAll();
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT T.TASK_ID AS \"Task No.\",T.TASK AS \"Task\" ,A.MODEL \"Airplane\", F.DEPARTURE_TIME AS \"Time\" FROM TASK T, FLIGHT F, AIRCRAFT A WHERE T.FLIGHT_ID = F.FLIGHT_ID AND F.AIRCRAFT_ID = A.AIRCRAFT_ID AND T.DATE_COMPLETED IS NULL";
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                this.label5.Text = "Enter Task ID:";
                this.button1.Text = "Complete";
                this.dataGridView1.Show();
                this.textBox3.Show();
                this.button4.Show();
                this.button1.Show();
                this.label5.Show();
                this.radioButton3.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
            }
            else
            {
                this.radioButton3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked)
            {
                hideAll();
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM FEEDBACK";
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                this.dataGridView1.Show();
                this.radioButton4.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
            }
            else
            {
                this.radioButton4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }
        private void hideAll()
        {
            this.button1.Hide();
            this.button2.Hide();
            this.button3.Hide();
            this.button4.Hide();
            this.textBox1.Hide();
            this.textBox2.Hide();
            this.textBox3.Hide();
            this.label3.Hide();
            this.label4.Hide();
            this.label5.Hide();
            this.dataGridView1.Hide();
        }

        private void Employee_Form_Load(object sender, EventArgs e)
        {
            label2.Text = "User ID: " + userID;
            this.radioButton1.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                string str = this.textBox1.Text.ToLower();
                OracleCommand search = connect.CreateCommand();
                if (str == "")
                {
                    search.CommandText = "SELECT B.BOOKING_ID AS \"Booking ID\", P.NAME AS \"Booked By\", P.CNIC, P.PHONE_NO AS \"Phone no.\", B.SEAT_NO AS \"Seat#\", F.\"DEPARTURE_LOCATION\" AS \"Departure Location\", F.DESTINATION AS \"Destination\", F.DEPARTURE_TIME AS \"Departure Time\" FROM BOOKING B, PASSENGER P, FLIGHT F WHERE B.PASSENGER_ID = P.USERID AND B.FLIGHT_ID = F.FLIGHT_ID AND B.TICKET = 'Not Sold'";
                }
                else
                {
                    search.CommandText = "SELECT B.BOOKING_ID AS \"Booking ID\", P.NAME AS \"Booked By\", P.CNIC, P.PHONE_NO AS \"Phone no.\", B.SEAT_NO AS \"Seat#\", F.\"DEPARTURE_LOCATION\" AS \"Departure Location\", F.DESTINATION AS \"Destination\", F.DEPARTURE_TIME AS \"Departure Time\" FROM BOOKING B, PASSENGER P, FLIGHT F WHERE B.PASSENGER_ID = P.USERID AND B.FLIGHT_ID = F.FLIGHT_ID AND LOWER(NAME) LIKE '%" + str + "%' AND B.TICKET = 'Not Sold'";
                }
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
        }

        private void Employee_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                if (this.textBox3.Text == "")
                {
                    MessageBox.Show("Please enter select a flight by entering Flight ID", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                for (int i = 0; i < textBox3.Text.Length; i++) if (textBox3.Text[i] < '0' || textBox3.Text[i] > '9')
                    {
                        MessageBox.Show("Flight ID is a number\nIt must not contain any non numeric characters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                OracleCommand search = connect.CreateCommand();
                OracleDataReader reader;
                search.CommandText = "UPDATE BOOKING SET TICKET='Sold' WHERE BOOKING_ID=" + textBox3.Text;
                search.ExecuteNonQuery();
                MessageBox.Show("Ticket sold succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Random rand = new Random();
                int revID = rand.Next(10000, 99999);
                search.CommandText = "SELECT * FROM REVENUE WHERE REVENUE_ID=" + revID.ToString();
                reader = search.ExecuteReader();
                while (reader.Read())
                {
                    revID = rand.Next(10000, 99999);
                    search.CommandText = "SELECT * FROM REVENUE WHERE REVENUE_ID=" + revID.ToString();
                    reader = search.ExecuteReader();
                }
                search.CommandText = "SELECT * FROM BOOKING WHERE BOOKING_ID=" + textBox3.Text;
                reader=search.ExecuteReader();
                reader.Read();

                search.CommandText = "INSERT INTO REVENUE VALUES(" + revID.ToString() + ", " + textBox3.Text + ", " + reader.GetString(reader.GetOrdinal("COST")) + ", TO_TIMESTAMP('" + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") + "', 'MM-DD-YYYY HH24:MI:SS'), 'Generated by seeling of tickets')";
                search.ExecuteNonQuery();
                string str = this.textBox1.Text.ToLower();
                if (str == "")
                {
                    search.CommandText = "SELECT B.BOOKING_ID AS \"Booking ID\", P.NAME AS \"Booked By\", P.CNIC, P.PHONE_NO AS \"Phone no.\", B.SEAT_NO AS \"Seat#\", F.\"DEPARTURE_LOCATION\" AS \"Departure Location\", F.DESTINATION AS \"Destination\", F.DEPARTURE_TIME AS \"Departure Time\" FROM BOOKING B, PASSENGER P, FLIGHT F WHERE B.PASSENGER_ID = P.USERID AND B.FLIGHT_ID = F.FLIGHT_ID AND B.TICKET = 'Not Sold'";
                }
                else
                {
                    search.CommandText = "SELECT B.BOOKING_ID AS \"Booking ID\", P.NAME AS \"Booked By\", P.CNIC, P.PHONE_NO AS \"Phone no.\", B.SEAT_NO AS \"Seat#\", F.\"DEPARTURE_LOCATION\" AS \"Departure Location\", F.DESTINATION AS \"Destination\", F.DEPARTURE_TIME AS \"Departure Time\" FROM BOOKING B, PASSENGER P, FLIGHT F WHERE B.PASSENGER_ID = P.USERID AND B.FLIGHT_ID = F.FLIGHT_ID AND LOWER(NAME) LIKE '%" + str + "%' AND B.TICKET = 'Not Sold'";
                }
                reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            if (this.radioButton3.Checked)
            {
                if (this.textBox3.Text == "")
                {
                    MessageBox.Show("Please enter select a task to complete by entering Task ID", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                for (int i = 0; i < textBox3.Text.Length; i++) if (textBox3.Text[i] < '0' || textBox3.Text[i] > '9')
                    {
                        MessageBox.Show("Task ID is a number\nIt must not contain any non numeric characters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "UPDATE TASK SET DATE_COMPLETED= TO_TIMESTAMP('" + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") + "', 'MM-DD-YYYY HH24:MI:SS') WHERE TASK_ID=" + textBox3.Text;
                search.ExecuteNonQuery();
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.signIn.Show();
            this.Hide();
        }
    }
}
