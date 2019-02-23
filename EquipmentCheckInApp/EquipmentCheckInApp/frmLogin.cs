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
    public partial class frmLogin : Form
    {
        static OdbcConnection con;
        static OdbcCommand cmd;
        static OdbcDataReader reader;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login(tbxUsername.Text, tbxPassword.Text);
        }

        private void login(string username, string password)
        {
            string databasePath = AppDomain.CurrentDomain.BaseDirectory + "\\EquipmentDatabase.accdb";

            con = new OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + databasePath + ";Uid=Admin;PWD=;");
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Employees.[Password], Employees.[Manager] FROM Employees WHERE (((Employees.[Username])='" + username + "'));";
            con.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                if (password == reader[0].ToString())
                {
                    if (reader[1].ToString() == "True")
                    {
                        //TODO: make a manager version of the main form and replace the code below to open that form instead of the general main form
                        con.Close();
                        frmMain frmMain = new frmMain(true);
                        frmMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        con.Close();
                        frmMain frmMain = new frmMain(false);
                        frmMain.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }

            con.Close();
        }
    }
}
