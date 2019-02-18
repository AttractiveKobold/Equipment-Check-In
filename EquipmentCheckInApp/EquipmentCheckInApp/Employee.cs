using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace EquipmentCheckInApp
{
    class Employee
    {
        private string id, name, contactNumber, address, userName;
        private string[] skills;

        static OdbcConnection con;
        static OdbcCommand cmd;
        static OdbcDataReader reader;

        public Employee() { }
        public Employee(string employeeID)
        {


            string databasePath = AppDomain.CurrentDomain.BaseDirectory + "\\EquipmentDatabase.accdb";

            con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + databasePath + ";Uid=Admin;PWD=;");
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT [First Name], [Last Name], [Phone Number], [Address], [Skills], [Username] FROM Employees WHERE [ID] = " + employeeID;
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                id = employeeID;
                name = reader[0] + " " + reader[1];
                contactNumber = reader[2].ToString();
                address = reader[3].ToString();
                skills = reader[4].ToString().Split(';');
                userName = reader[5].ToString();
            }
            else
            {
                MessageBox.Show("Employee ID Does Not Exist", "Employee Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public string[] getSkills() { return skills; }
        public string getID() { return id; }
    }
}
