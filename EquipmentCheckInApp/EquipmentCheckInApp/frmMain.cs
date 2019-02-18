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

        private EquipmentManager eManager;

        public frmMain()
        {
            InitializeComponent();
            eManager = new EquipmentManager();
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Equipment equipmenttest = new Equipment("481254");
            if (tbxBarcode.Text != "") { 
                Equipment equipment = new Equipment(tbxBarcode.Text);
                eManager.CheckInEquipment(equipment);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (tbxEmployeeID.Text != "" && tbxBarcode.Text != "")
            {
                Employee employee = new Employee(tbxEmployeeID.Text);
                Equipment equipment = new Equipment(tbxBarcode.Text);
                eManager.CheckOutEquipment(employee, equipment);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            frmReportView frmReportView = new frmReportView();
            frmReportView.Owner = this;
            frmReportView.Show();
            this.Hide();
        }
    }
}
