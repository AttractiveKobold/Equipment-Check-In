namespace EquipmentCheckInApp
{
    partial class frmCreateReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.equipmentDataset = new EquipmentCheckInApp.EquipmentDatabaseDataSet();
            this.cbSelectedColumns = new System.Windows.Forms.ComboBox();
            this.tvData = new System.Windows.Forms.TreeView();
            this.tbxValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // equipmentDataset
            // 
            this.equipmentDataset.DataSetName = "equipmentDataset";
            this.equipmentDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbSelectedColumns
            // 
            this.cbSelectedColumns.FormattingEnabled = true;
            this.cbSelectedColumns.Location = new System.Drawing.Point(182, 305);
            this.cbSelectedColumns.Name = "cbSelectedColumns";
            this.cbSelectedColumns.Size = new System.Drawing.Size(206, 21);
            this.cbSelectedColumns.TabIndex = 2;
            // 
            // tvData
            // 
            this.tvData.CheckBoxes = true;
            this.tvData.Location = new System.Drawing.Point(244, 52);
            this.tvData.Name = "tvData";
            this.tvData.Size = new System.Drawing.Size(263, 226);
            this.tvData.TabIndex = 3;
            this.tvData.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tvData_DrawNode);
            // 
            // tbxValue
            // 
            this.tbxValue.Location = new System.Drawing.Point(454, 306);
            this.tbxValue.Name = "tbxValue";
            this.tbxValue.Size = new System.Drawing.Size(100, 20);
            this.tbxValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "WHERE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "SELECT";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(585, 303);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmCreateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxValue);
            this.Controls.Add(this.tvData);
            this.Controls.Add(this.cbSelectedColumns);
            this.Name = "frmCreateReport";
            this.Text = "frmCreateReport";
            this.Load += new System.EventHandler(this.frmCreateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EquipmentDatabaseDataSet equipmentDataset;
        private System.Windows.Forms.ComboBox cbSelectedColumns;
        private System.Windows.Forms.TreeView tvData;
        private System.Windows.Forms.TextBox tbxValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApply;
    }
}