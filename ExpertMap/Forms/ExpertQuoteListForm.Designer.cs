namespace ExpertMap.Forms
{
    partial class ExpertQuoteListForm
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
            this.expertQuoteGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertQuoteTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertQuoteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.expertQuoteGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // expertQuoteGridView
            // 
            this.expertQuoteGridView.AllowUserToAddRows = false;
            this.expertQuoteGridView.AllowUserToDeleteRows = false;
            this.expertQuoteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expertQuoteGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Quotes});
            this.expertQuoteGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expertQuoteGridView.Location = new System.Drawing.Point(0, 0);
            this.expertQuoteGridView.MultiSelect = false;
            this.expertQuoteGridView.Name = "expertQuoteGridView";
            this.expertQuoteGridView.ReadOnly = true;
            this.expertQuoteGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expertQuoteGridView.Size = new System.Drawing.Size(596, 353);
            this.expertQuoteGridView.TabIndex = 0;
            this.expertQuoteGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.expertQuoteGridView_MouseUp);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Quotes
            // 
            this.Quotes.HeaderText = "Тексты цитат";
            this.Quotes.Name = "Quotes";
            this.Quotes.ReadOnly = true;
            this.Quotes.Width = 500;
            // 
            // expertQuoteTableAdapter
            // 
            this.expertQuoteTableAdapter.ClearBeforeFill = true;
            // 
            // ExpertQuoteListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 353);
            this.Controls.Add(this.expertQuoteGridView);
            this.Name = "ExpertQuoteListForm";
            this.Text = "Цитаты";
            this.Load += new System.EventHandler(this.ExpertQuoteListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expertQuoteGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView expertQuoteGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quotes;
        private DataModels.ExpertMapDataSetTableAdapters.ExpertQuoteTableAdapter expertQuoteTableAdapter;
    }
}