namespace ExpertMap.Forms
{
    partial class RegionListForm
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
            this.components = new System.ComponentModel.Container();
            this.expertMapDataSet = new ExpertMap.DataModels.ExpertMapDataSet();
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regionTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.RegionTableAdapter();
            this.tableAdapterManager = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager();
            this.regionListBox = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // expertMapDataSet
            // 
            this.expertMapDataSet.DataSetName = "ExpertMapDataSet";
            this.expertMapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember = "Region";
            this.regionBindingSource.DataSource = this.expertMapDataSet;
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CountryTableAdapter = null;
            this.tableAdapterManager.ExpertInMarkerTableAdapter = null;
            this.tableAdapterManager.ExpertQuoteTableAdapter = null;
            this.tableAdapterManager.ExpertTableAdapter = null;
            this.tableAdapterManager.MarkerInRegionTableAdapter = null;
            this.tableAdapterManager.MarkerTableAdapter = null;
            this.tableAdapterManager.RegionPointsTableAdapter = null;
            this.tableAdapterManager.RegionTableAdapter = this.regionTableAdapter;
            this.tableAdapterManager.SpecializationTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // regionListBox
            // 
            this.regionListBox.DataSource = this.regionBindingSource;
            this.regionListBox.DisplayMember = "Name";
            this.regionListBox.FormattingEnabled = true;
            this.regionListBox.Location = new System.Drawing.Point(-1, -1);
            this.regionListBox.Name = "regionListBox";
            this.regionListBox.Size = new System.Drawing.Size(527, 316);
            this.regionListBox.TabIndex = 1;
            this.regionListBox.ValueMember = "Id";
            this.regionListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.regionListBox_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(439, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(358, 318);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // RegionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 353);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.regionListBox);
            this.Name = "RegionListForm";
            this.Text = "Справочник регионов";
            this.Load += new System.EventHandler(this.RegionListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataModels.ExpertMapDataSet expertMapDataSet;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private DataModels.ExpertMapDataSetTableAdapters.RegionTableAdapter regionTableAdapter;
        private DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ListBox regionListBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;

    }
}