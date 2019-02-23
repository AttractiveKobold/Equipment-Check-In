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
        string queryString;

        public frmReportView(string queryString)
        {
            InitializeComponent();

            this.queryString = queryString;
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
            cmd.CommandText = queryString;
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dgvData.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                do 
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dgvData.Rows.Add(rowData);
                } while((reader.Read()));

            }
            else
            {
                MessageBox.Show("There was no data to retireve");
            }

            con.Close();
        }
    }
}
