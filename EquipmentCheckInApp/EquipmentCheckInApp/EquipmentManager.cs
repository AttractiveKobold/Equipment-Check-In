using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace EquipmentCheckInApp
{
    class EquipmentManager
    {
        public EquipmentManager() {}

        static OdbcConnection con;
        static OdbcCommand cmd;
        static OdbcDataReader reader;

        public void CheckInEquipment(Employee employee, Equipment equipment)
        {
           
        }

        public void CheckOutEquipment(Employee employee, Equipment equipment)
        {
            if (equipment.getEmployeeID() != "")
            {
                MessageBox.Show("That Equipment is already checked out. Please Check it in before checking it out again");
                return;
            }


            string[] employeeSkills = employee.getSkills();
            string[] requiredSkills = equipment.getSkills();
            int numOfRequiredSkills = requiredSkills.GetLength(0);
            
            if (numOfRequiredSkills != 0)
            {
                for (int i = 0; i < numOfRequiredSkills; i++)
                {
                    if (!employeeSkills.Contains(requiredSkills[i]))
                    { 
                        MessageBox.Show("Emplyee does not have the required skill: " + requiredSkills[i]);
                        return;
                    }
                }
            }

            string databasePath = AppDomain.CurrentDomain.BaseDirectory + "\\EquipmentDatabase.accdb";
            con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + databasePath + ";Uid=Admin;PWD=;");
            cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Equipment SET Equipment.[Checked Out To] = " + employee.getID() + " WHERE (((Equipment.ID)=" + equipment.getID() + "));";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
