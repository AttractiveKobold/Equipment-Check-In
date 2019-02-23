using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EquipmentCheckInApp
{
    public partial class frmReportSelect : Form
    {

        Dictionary<string, string> reports;
        ReportManager mgr = new ReportManager();

        public frmReportSelect()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxReports.Text))
            {
                MessageBox.Show("Please select a report");
                return;
            }

            frmReportView frmReportView = new frmReportView(reports[cbxReports.Text]);
            frmReportView.Owner = this;
            frmReportView.Show();
            this.Hide();
        }

        private void frmReportSelect_Load(object sender, EventArgs e)
        {
            
            reports = mgr.getReports();

            foreach (var r in reports)
                cbxReports.Items.Add(r.Key);

            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxReports.Text))
            {
                MessageBox.Show("Please select a report");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete " + cbxReports.Text, "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                reports.Remove(cbxReports.Text);

                mgr.removeReport(reports);

                cbxReports.Items.Remove(cbxReports.SelectedItem);
                cbxReports.Text = "";
            }
        }

        private void frmReportSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
