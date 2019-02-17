using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EquipmentCheckInApp
{
    public partial class frmMain : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        private EquipmentManager eManager;

        public frmMain()
        {
            InitializeComponent();
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee("3");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }


        private void getAllEquipment()
        {
            //This is just an example of how to connect C# to the database and will not be in the final product
            int counter = 0;
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EquipmentDatabase.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Equipment";
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                counter++;
                Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            con.Close();
            MessageBox.Show(counter.ToString());
        }

        private void updateHammer()
        {
            //This is just an example of how to connect C# to the database and will not be in the final product
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EquipmentDatabase.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Equipment SET Equipment.[Checked Out To] = \"1\" WHERE(((Equipment.[ID]) = \"154845\"))";
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }
        }
    }
}
