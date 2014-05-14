namespace ExpertMap.Forms
{
    partial class QuotesListForm
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
            this.expertTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();
            this.expertQuoteTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertQuoteTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ExpertFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpertQuote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // expertTableAdapter
            // 
            this.expertTableAdapter.ClearBeforeFill = true;
            // 
            // expertQuoteTableAdapter
            // 
            this.expertQuoteTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpertFullName,
            this.ExpertQuote});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(491, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // ExpertFullName
            // 
            this.ExpertFullName.HeaderText = "Эксперт";
            this.ExpertFullName.Name = "ExpertFullName";
            this.ExpertFullName.ReadOnly = true;
            // 
            // ExpertQuote
            // 
            this.ExpertQuote.HeaderText = "Цитата";
            this.ExpertQuote.Name = "ExpertQuote";
            this.ExpertQuote.ReadOnly = true;
            // 
            // QuotesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 346);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QuotesListForm";
            this.Text = "Цитаты";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter expertTableAdapter;
        private DataModels.ExpertMapDataSetTableAdapters.ExpertQuoteTableAdapter expertQuoteTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpertFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpertQuote;
    }
}