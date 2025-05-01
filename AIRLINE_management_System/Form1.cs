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
    public partial class Form1 : Form
    {
        OracleConnection connect;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE=localhost:1521/xe;USER ID=AIRLINE;PASSWORD=db_on_air";
            connect = new OracleConnection(conStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            OracleCommand getEmps = connect.CreateCommand();
            getEmps.CommandText = "SELECT * FROM DEPT";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
          //  dataGridView1.DataSource = empDT;
            connect.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(900, 900);

        }
    }
}
