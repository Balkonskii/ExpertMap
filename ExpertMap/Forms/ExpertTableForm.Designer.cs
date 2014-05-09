namespace ExpertMap.Forms
{
    partial class ExpertTableForm
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
            this.expertTable = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpertName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Middlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datebirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecializationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expertTable)).BeginInit();
            this.SuspendLayout();
            // 
            // expertTable
            // 
            this.expertTable.AllowUserToAddRows = false;
            this.expertTable.AllowUserToDeleteRows = false;
            this.expertTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expertTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expertTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ExpertName,
            this.Surname,
            this.Middlename,
            this.Datebirth,
            this.Job,
            this.Rating,
            this.CountryName,
            this.SpecializationName});
            this.expertTable.Location = new System.Drawing.Point(0, 0);
            this.expertTable.MultiSelect = false;
            this.expertTable.Name = "expertTable";
            this.expertTable.ReadOnly = true;
            this.expertTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expertTable.Size = new System.Drawing.Size(793, 325);
            this.expertTable.TabIndex = 0;
            this.expertTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.expertTable_MouseUp);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ExpertName
            // 
            this.ExpertName.HeaderText = "Имя";
            this.ExpertName.Name = "ExpertName";
            this.ExpertName.ReadOnly = true;
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Фамилия";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            // 
            // Middlename
            // 
            this.Middlename.HeaderText = "Отчество";
            this.Middlename.Name = "Middlename";
            this.Middlename.ReadOnly = true;
            // 
            // Datebirth
            // 
            this.Datebirth.HeaderText = "Дата рождения";
            this.Datebirth.Name = "Datebirth";
            this.Datebirth.ReadOnly = true;
            // 
            // Job
            // 
            this.Job.HeaderText = "Место работы";
            this.Job.Name = "Job";
            this.Job.ReadOnly = true;
            // 
            // Rating
            // 
            this.Rating.HeaderText = "Рейтинг";
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            // 
            // CountryName
            // 
            this.CountryName.HeaderText = "Страна";
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            // 
            // SpecializationName
            // 
            this.SpecializationName.HeaderText = "Специализация";
            this.SpecializationName.Name = "SpecializationName";
            this.SpecializationName.ReadOnly = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(624, 332);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(705, 332);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ExpertTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 367);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.expertTable);
            this.Name = "ExpertTableForm";
            this.Text = "Эксперты";
            this.Load += new System.EventHandler(this.ExpertTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expertTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView expertTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpertName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Middlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datebirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecializationName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;

    }
}