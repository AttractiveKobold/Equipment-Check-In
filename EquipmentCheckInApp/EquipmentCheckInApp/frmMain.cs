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
            Employee emp = new Employee("1");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}
