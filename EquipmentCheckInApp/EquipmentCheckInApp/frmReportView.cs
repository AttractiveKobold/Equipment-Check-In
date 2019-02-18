using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace EquipmentCheckInApp
{
    public partial class frmReportView : Form
    {
        static OdbcConnection con;
        static OdbcCommand cmd;
        static OdbcDataReader reader;

        public frmReportView()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void frmReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmReportView_Load(object sender, EventArgs e)
        {
            string databasePath = AppDomain.CurrentDomain.BaseDirectory + "\\EquipmentDatabase.accdb";

            con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + databasePath + ";Uid=Admin;PWD=;");
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees";
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                //WRITE YOUR CODE HERE
            }
            else
            {
                MessageBox.Show("Nope");
            }

            con.Close();
        }
    }
}
