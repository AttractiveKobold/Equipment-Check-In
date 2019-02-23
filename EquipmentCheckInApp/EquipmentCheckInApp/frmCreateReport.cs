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
    public partial class frmCreateReport : Form
    {
        Dictionary<string, string> selectedColumns;
        Dictionary<string, string> reports;
        DataSet ds;

        public frmCreateReport()
        {
            InitializeComponent();
            ds = equipmentDataset;
            this.tvData.AfterCheck += CheckBoxIsChecked;
            selectedColumns = new Dictionary<string, string>();
        }

        private void frmCreateReport_Load(object sender, EventArgs e)
        {

            int index = 0;
            foreach (DataTable dt in ds.Tables)
            {
                tvData.Nodes.Add(dt.TableName);
                foreach (DataColumn dc in dt.Columns)
                {
                    tvData.Nodes[index].Nodes.Add(dc.ColumnName);
                }
                index++;
            }

            ReportManager mgr = new ReportManager();
            reports = mgr.getReports();
        }


        private void CheckBoxIsChecked(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0) return;

            string fullSelectionText = e.Node.Parent.Text + ".[" + e.Node.Text + "]";

            if (e.Node.Checked == true)
            {
                selectedColumns.Add(fullSelectionText, "");
                cbSelectedColumns.Items.Add(fullSelectionText);
            }
            else
            {
                selectedColumns.Remove(fullSelectionText);
                cbSelectedColumns.Items.Remove(fullSelectionText);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            selectedColumns[cbSelectedColumns.Text] = tbxValue.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxReportName.Text.Contains('$'))
            {
                MessageBox.Show("Report names cannot contain the character $");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxReportName.Text))
            {
                MessageBox.Show("Report name cannot be blank");
                return;
            }

            if (reports.Keys.Contains(tbxReportName.Text))
            {
                MessageBox.Show("A report already exists with that name. Please choose a different name.");
                return;
            }


            string queryString = CreateQueryString();

            using (StreamWriter sw = File.AppendText("Reports.txt"))
            {
                sw.Write("$" + tbxReportName.Text + "$" + queryString);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string queryString = CreateQueryString();

            frmReportView frmReportView = new frmReportView(queryString);
            frmReportView.Owner = this;
            frmReportView.Show();
            this.Hide();
        }

        private string CreateQueryString()
        {
            string SELECT = "SELECT";
            string FROM = " FROM Skills INNER JOIN (EquipmentCategory INNER JOIN (Employees INNER JOIN Equipment ON Employees.ID = Equipment.[Checked Out To]) ON EquipmentCategory.ID = Equipment.Category) ON (Skills.ID = EquipmentCategory.[Skills Required].Value) AND (Skills.ID = Employees.Skills.Value)";
            string WHERE = " WHERE";
            string finalQuery = "";

            foreach (var c in selectedColumns)
            {
                SELECT += " " + c.Key + ",";
                if (c.Value != "")
                    WHERE += " " + c.Key + "=" + c.Value;
            }

            SELECT = SELECT.TrimEnd(',');

            finalQuery += SELECT + FROM;
            if (WHERE != " WHERE")
                finalQuery += WHERE;

            return finalQuery;
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            frmReportSelect frmReportSelect = new frmReportSelect();
            frmReportSelect.Owner = this;
            frmReportSelect.Show();
            this.Hide();
        }

        private void frmCreateReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
