using System;
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
    public partial class Passenger_Form : Form
    {
        OracleConnection connect;
        string userID;
        SignIn signIn;
        public Passenger_Form(OracleConnection con, string id, SignIn signIn)
        {
            connect = con;
            userID = id;
            InitializeComponent();
            this.signIn = signIn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                hideAll();
                this.radioButton1.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT * FROM PASSENGER WHERE USERID=" + userID;
                OracleDataReader reader = search.ExecuteReader();
                if(reader.Read()) this.label3.Text = "Name: "+ reader.GetString(reader.GetOrdinal("NAME")) + "\n\nCNIC: " + reader.GetString(reader.GetOrdinal("CNIC")) + "\n\nE-Mail: " + reader.GetString(reader.GetOrdinal("EMAIL")) + "\n\nPhone Number: " + reader.GetString(reader.GetOrdinal("PHONE_NO"));
                this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
                this.label3.Location = new System.Drawing.Point(180, 165);
                this.label3.Show();
            }
            else
            {
                this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
                this.label3.Location = new System.Drawing.Point(182, 122);
                this.radioButton1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.label5.Show();
                this.label3.Show();
                this.label4.Show();
                this.radioButton2.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
                this.label3.Text = "Departure Location";
                this.label4.Text = "Arrival Location";
                this.label5.Text = "Enter Flight ID:";
                this.button1.Text = "Book Seat";
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.Show();
                this.textBox2.Show();
                this.textBox3.Show();
                this.dataGridView1.Show();
                this.button1.Show();
                this.button2.Show();
                this.button3.Show();
                this.button4.Show();
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT";
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
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
                search.CommandText = "SELECT B.FLIGHT_ID AS \"Flight ID\", F.DEPARTURE_LOCATION AS \"Departure Location\", F.DESTINATION AS \"Arrival Location\", F.DEPARTURE_TIME AS \"Departure Time\", F.ARRIVAL_TIME AS \"Arrival Time\", B.COST AS \"Ticket Price\", B.SEAT_NO AS \"Seat#\" FROM FLIGHT F, BOOKING B WHERE B.FLIGHT_ID = F.FLIGHT_ID AND B.PASSENGER_ID=" + this.userID + " AND B.STATUS='Valid' AND B.TICKET='Not Sold'";
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                this.dataGridView1.Show();
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
                this.textBox2.MaxLength = 50;
                this.label4.Location = new System.Drawing.Point(182, 195);
                this.label4.Size = new System.Drawing.Size(56, 18);
                this.textBox2.Location = new System.Drawing.Point(182, 216);
                this.textBox2.Size = new System.Drawing.Size(400, 23);
                this.button2.Location = new System.Drawing.Point(185, 239);
                this.button2.Size = new System.Drawing.Size(400, 2);
                hideAll();
                this.textBox1.Show();
                this.textBox2.Show();
                this.button1.Show();
                this.button2.Show();
                this.button3.Show();
                this.label3.Text = "Flight ID: ";
                this.label4.Text = "Feedback: ";
                this.label3.Show();
                this.label4.Show();
                this.radioButton4.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
            }
            else
            {
                this.label4.Location = new System.Drawing.Point(499, 122);
                this.label4.Size = new System.Drawing.Size(56, 18);
                this.textBox2.Location = new System.Drawing.Point(502, 143);
                this.textBox2.Size = new System.Drawing.Size(295, 23);
                this.button3.Location = new System.Drawing.Point(185, 166);
                this.button3.Size = new System.Drawing.Size(297, 2);
                this.radioButton4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton5.Checked)
            {
                hideAll();
                OracleCommand search = connect.CreateCommand();
                search.CommandText = "SELECT B.FLIGHT_ID AS \"Flight ID\", F.DEPARTURE_LOCATION AS \"Departure Location\", F.DESTINATION AS \"Arrival Location\", F.DEPARTURE_TIME AS \"Departure Time\", F.ARRIVAL_TIME AS \"Arrival Time\", B.COST AS \"Ticket Price\", B.SEAT_NO AS \"Seat#\" FROM FLIGHT F, BOOKING B WHERE B.FLIGHT_ID = F.FLIGHT_ID AND B.PASSENGER_ID=" + this.userID + " AND B.STATUS='Valid' AND B.TICKET='Sold'";
                OracleDataReader reader = search.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                dataGridView1.DataSource = DT;
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                this.dataGridView1.Show();
                this.radioButton5.BackColor = System.Drawing.ColorTranslator.FromHtml("#332084");
                this.radioButton5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0A3359");
            }
            else
            {
                this.radioButton5.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B1D5A");
                this.radioButton5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6F6FBC");
            }
        }

        private void Passenger_Form_Load(object sender, EventArgs e)
        {
            label2.Text = "User ID: " + userID;
            this.radioButton1.Checked = true;
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

        private void Passenger_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OracleCommand search = connect.CreateCommand();
            string arrv, dept;
            dept = textBox1.Text;
            arrv = textBox2.Text;
            arrv = arrv.ToUpper();
            dept = dept.ToUpper();
            if (this.textBox1.Text == "" && this.textBox2.Text == "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            if (this.textBox1.Text != "" && this.textBox2.Text == "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE DEPARTURE_LOCATION LIKE '%" + dept + "%' AND STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            if (this.textBox1.Text == "" && this.textBox2.Text != "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE DESTINATION LIKE '%" + arrv + "%' AND STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE DEPARTURE_LOCATION LIKE '%" + dept + "%' AND DESTINATION LIKE '%" + arrv + "%' AND STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            OracleDataReader reader = search.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(reader);
            dataGridView1.DataSource = DT;
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OracleCommand search = connect.CreateCommand();
            string arrv, dept;
            dept = textBox1.Text;
            arrv = textBox2.Text;
            arrv = arrv.ToUpper();
            dept = dept.ToUpper();
            if (this.textBox1.Text == "" && this.textBox2.Text == "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            if (this.textBox1.Text != "" && this.textBox2.Text == "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE DEPARTURE_LOCATION LIKE '%" + dept + "%' AND STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            if (this.textBox1.Text == "" && this.textBox2.Text != "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE DESTINATION LIKE '%" + arrv + "%' AND STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                search.CommandText = "SELECT FLIGHT_ID AS ID, DEPARTURE_LOCATION AS \"Departure Location\", DESTINATION AS \"Arrival Location\", DEPARTURE_TIME AS \"Departure Time\", ARRIVAL_TIME AS \"Arrival Time\", AV_SEATS AS \"Vacant Seats\" FROM FLIGHT WHERE DEPARTURE_LOCATION LIKE '%" + dept + "%' AND DESTINATION LIKE '%" + arrv + "%' AND STATUS = 'Scheduled' AND AV_SEATS>0";
            }
            OracleDataReader reader = search.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(reader);
            dataGridView1.DataSource = DT;
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
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

                int seat = 0;
                search.CommandText = "SELECT * FROM AIRCRAFT WHERE AIRCRAFT_ID = (SELECT AIRCRAFT_ID FROM FLIGHT WHERE FLIGHT_ID=" + textBox3.Text + ")";
                reader = search.ExecuteReader();
                if (reader.Read())
                {
                    seat = int.Parse(reader.GetString(reader.GetOrdinal("SEATS")));
                }
                if (MessageBox.Show("Booking this seat will cost $" + seat.ToString() + "\nDo you want to book this seat?", "Booking Conformation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
                search.CommandText = "SELECT * FROM FLIGHT WHERE FLIGHT_ID=" + textBox3.Text;
                reader = search.ExecuteReader();
                int new_seats = 0;
                if (reader.Read())
                {
                    new_seats = int.Parse(reader.GetString(reader.GetOrdinal("AV_SEATS")));
                    if (new_seats == 0)
                    {
                        MessageBox.Show("Unexpected Error: No seats available in that flight", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    new_seats--;
                }
                search.CommandText = "UPDATE FLIGHT SET AV_SEATS=" + new_seats.ToString() + "WHERE FLIGHT_ID=" + textBox3.Text;
                search.ExecuteNonQuery();
                Random rand = new Random();
                int bookingID = rand.Next(10000, 99999);
                search.CommandText = "SELECT * FROM BOOKING WHERE BOOKING_ID=" + bookingID.ToString();
                reader = search.ExecuteReader();
                while (reader.Read())
                {
                    bookingID = rand.Next(10000, 99999);
                    search.CommandText = "SELECT * FROM BOOKING WHERE BOOKING_ID=" + bookingID.ToString();
                    reader = search.ExecuteReader();
                }
                search.CommandText = "INSERT INTO BOOKING VALUES(" + bookingID.ToString() + "," + this.userID + "," + this.textBox3.Text + "," + seat.ToString() + "," + (seat - new_seats).ToString() + ", 'Valid', 'Not Sold'" + ")";
                search.ExecuteNonQuery();
                MessageBox.Show("Seat Booked Sucessfully\n", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.radioButton3.Checked = true;
            }
            if (this.radioButton4.Checked)
            {
                if(this.textBox1.Text == "")
                {
                    MessageBox.Show("Please enter select a flight by entering Flight ID", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if(this.textBox2.Text == "")
                {
                    MessageBox.Show("Please enter your feedback in the form of comments", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                for (int i = 0; i < textBox1.Text.Length; i++) if (textBox1.Text[i] < '0' || textBox1.Text[i] > '9')
                    {
                        MessageBox.Show("Flight ID is a number\nIt must not contain any non numeric characters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                OracleCommand search = connect.CreateCommand();
                OracleDataReader reader;
                search.CommandText = "SELECT * FROM BOOKING WHERE PASSENGER_ID=" + userID + " AND FLIGHT_ID=" + textBox1.Text;
                reader = search.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("You cannot provide feedback for a flight you did not take", "Errur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                search.CommandText = "INSERT INTO FEEDBACK VALUES(" + this.userID + ", " + textBox1.Text + ", '" + textBox2.Text + "')";
                search.ExecuteNonQuery();
                MessageBox.Show("Thank you for providing your valuable feedback\nOur staff will view this feedback and make sure appropriate changes are made", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.signIn.Show();
            this.Hide();
        }
    }
}
