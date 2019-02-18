using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EquipmentCheckInApp
{
    public partial class frmCreateReport : Form
    {
        Dictionary<string, string> selectedColumns;
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

            //this.tvData.DrawMode = TreeViewDrawMode.OwnerDrawText;
            //this.tvData.DrawNode += new DrawTreeNodeEventHandler(arbolDependencias_DrawNode);

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
        }


        private void CheckBoxIsChecked(object sender, TreeViewEventArgs e)
        {
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

        private void tvData_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //if (e.Node.Level == 0) e.Node.HideCheckBox();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            selectedColumns[cbSelectedColumns.Text] = tbxValue.Text;
        }
    }
}
