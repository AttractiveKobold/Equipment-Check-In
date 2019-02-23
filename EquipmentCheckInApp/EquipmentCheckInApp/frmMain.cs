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

        public frmMain(bool manager)
        {
            InitializeComponent();
            eManager = new EquipmentManager();

            if (!manager)
                btnCreateReport.Enabled = false;
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxBarcode.Text))
            {
                MessageBox.Show("Barcode cannot be blank");
                return;
            }

            Equipment equipmenttest = new Equipment("481254");
            Equipment equipment = new Equipment(tbxBarcode.Text);
            eManager.CheckInEquipment(equipment);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxEmployeeID.Text) || string.IsNullOrWhiteSpace(tbxBarcode.Text))
            {
                MessageBox.Show("Barcode and employee ID cannot be blank");
                return;
            }
            Employee employee = new Employee(tbxEmployeeID.Text);
            Equipment equipment = new Equipment(tbxBarcode.Text);
            eManager.CheckOutEquipment(employee, equipment);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            frmReportSelect frmReportSelect = new frmReportSelect();
            frmReportSelect.Owner = this;
            frmReportSelect.Show();
            this.Hide();
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            frmCreateReport frmCreateReport = new frmCreateReport();
            frmCreateReport.Owner = this;
            frmCreateReport.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
