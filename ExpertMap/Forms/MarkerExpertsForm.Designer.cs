namespace ExpertMap.Forms
{
    partial class MarkerExpertsForm
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
            this.expertMapDataSet = new ExpertMap.DataModels.ExpertMapDataSet();
            this.expertTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();
            this.tableAdapterManager = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager();
            this.expertListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // expertMapDataSet
            // 
            this.expertMapDataSet.DataSetName = "ExpertMapDataSet";
            this.expertMapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // expertTableAdapter
            // 
            this.expertTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CountryTableAdapter = null;
            this.tableAdapterManager.ExpertInMarkerTableAdapter = null;
            this.tableAdapterManager.ExpertQuoteTableAdapter = null;
            this.tableAdapterManager.ExpertTableAdapter = this.expertTableAdapter;
            this.tableAdapterManager.MarkerInRegionTableAdapter = null;
            this.tableAdapterManager.MarkerTableAdapter = null;
            this.tableAdapterManager.RegionPointsTableAdapter = null;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.SpecializationTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // expertListBox
            // 
            this.expertListBox.DisplayMember = "Id";
            this.expertListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expertListBox.FormattingEnabled = true;
            this.expertListBox.Location = new System.Drawing.Point(0, 0);
            this.expertListBox.Name = "expertListBox";
            this.expertListBox.Size = new System.Drawing.Size(310, 305);
            this.expertListBox.TabIndex = 1;
            this.expertListBox.ValueMember = "Id";
            this.expertListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.expertListBox_MouseUp);
            // 
            // MarkerExpertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 305);
            this.Controls.Add(this.expertListBox);
            this.Name = "MarkerExpertsForm";
            this.Text = "Эксперты";
            this.Load += new System.EventHandler(this.MarkerExpertsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataModels.ExpertMapDataSet expertMapDataSet;
        private DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter expertTableAdapter;
        private DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ListBox expertListBox;
    }
}