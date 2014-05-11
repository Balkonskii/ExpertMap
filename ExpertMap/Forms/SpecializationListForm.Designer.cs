namespace ExpertMap.Forms
{
    partial class SpecializationListForm
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
            this.specializationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specializationTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.SpecializationTableAdapter();
            this.tableAdapterManager = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager();
            this.specializationListBox = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specializationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // expertMapDataSet
            // 
            this.expertMapDataSet.DataSetName = "ExpertMapDataSet";
            this.expertMapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // specializationBindingSource
            // 
            this.specializationBindingSource.DataMember = "Specialization";
            this.specializationBindingSource.DataSource = this.expertMapDataSet;
            // 
            // specializationTableAdapter
            // 
            this.specializationTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.SpecializationTableAdapter = this.specializationTableAdapter;
            this.tableAdapterManager.UpdateOrder = ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // specializationListBox
            // 
            this.specializationListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specializationListBox.DataSource = this.specializationBindingSource;
            this.specializationListBox.DisplayMember = "Name";
            this.specializationListBox.FormattingEnabled = true;
            this.specializationListBox.Location = new System.Drawing.Point(0, 0);
            this.specializationListBox.Name = "specializationListBox";
            this.specializationListBox.Size = new System.Drawing.Size(437, 212);
            this.specializationListBox.TabIndex = 1;
            this.specializationListBox.ValueMember = "Id";
            this.specializationListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.specializationListBox_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(350, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(269, 218);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // SpecializationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 251);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.specializationListBox);
            this.Name = "SpecializationListForm";
            this.Text = "Справочник специализаций";
            this.Load += new System.EventHandler(this.SpecializationListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specializationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataModels.ExpertMapDataSet expertMapDataSet;
        private System.Windows.Forms.BindingSource specializationBindingSource;
        private DataModels.ExpertMapDataSetTableAdapters.SpecializationTableAdapter specializationTableAdapter;
        private DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ListBox specializationListBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
    }
}