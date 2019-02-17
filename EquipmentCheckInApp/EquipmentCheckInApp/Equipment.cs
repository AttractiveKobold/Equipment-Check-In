using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace EquipmentCheckInApp
{
    class Equipment
    {
        private string id, employeeID;
        private string[] skills;

        static OdbcConnection con;
        static OdbcCommand cmd;
        static OdbcDataReader reader;

        public Equipment() { }
        public Equipment(string id)
        {
            string databasePath = AppDomain.CurrentDomain.BaseDirectory + "\\EquipmentDatabase.accdb";
            con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + databasePath + ";Uid=Admin;PWD=;");
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT EquipmentCategory.[Skills Required] FROM EquipmentCategory WHERE EquipmentCategory.ID = " +
                "(SELECT Equipment.Category FROM Equipment WHERE (((Equipment.ID)=" + id + ")));";
            con.Open();
            reader = cmd.ExecuteReader();
       
            if (reader.Read())
            {
                this.id = id;
                skills = reader[0].ToString().Split(';');
            }
            else
            {
                MessageBox.Show("Equipment ID Does Not Exist", "Equipment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Close();

            cmd.CommandText = "SELECT [Checked Out To] FROM Equipment WHERE Equipment.ID = " + id;
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                employeeID = reader[0].ToString();
            }
        }

        public string[] getSkills() { return skills; }
        public string getEmployeeID() { return employeeID; }
        public string getID() { return id; }
    }
}
