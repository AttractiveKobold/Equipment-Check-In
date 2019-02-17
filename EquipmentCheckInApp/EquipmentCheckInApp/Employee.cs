using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace EquipmentCheckInApp
{
    class Employee
    {
        private string id, name, contactNumber, address, userName;
        private string[] skills;

        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        public Employee() { }
        public Employee(string employeeID)
        {
            

            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EquipmentDatabase.accdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT [First Name], [Last Name], [Phone Number], [Address], [Skills], [Username] FROM Employees WHERE [ID] = " + employeeID;
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                id = employeeID;
                name = reader[0] + " " + reader[1];
                contactNumber = reader[2].ToString();
                address = reader[4].ToString();
                userName = reader[6].ToString();

                string tempSkills = reader[5].ToString();
                skills = tempSkills.Split(',');
            }
            else
            {
                MessageBox.Show("Employee ID Does Not Exist", "Employee Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }
    }
}
