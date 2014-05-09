namespace ExpertMap.Forms
{
    partial class EditExpertForm
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label surnameLabel;
            System.Windows.Forms.Label middlenameLabel;
            System.Windows.Forms.Label datebirthLabel;
            System.Windows.Forms.Label jobLabel;
            System.Windows.Forms.Label ratingLabel;
            this.expertMapDataSet = new ExpertMap.DataModels.ExpertMapDataSet();
            this.expertBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expertTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();
            this.tableAdapterManager = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager();
            this.countryTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.CountryTableAdapter();
            this.specializationTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.SpecializationTableAdapter();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.middlenameTextBox = new System.Windows.Forms.TextBox();
            this.datebirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.jobTextBox = new System.Windows.Forms.TextBox();
            this.ratingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.specializationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specializationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            nameLabel = new System.Windows.Forms.Label();
            surnameLabel = new System.Windows.Forms.Label();
            middlenameLabel = new System.Windows.Forms.Label();
            datebirthLabel = new System.Windows.Forms.Label();
            jobLabel = new System.Windows.Forms.Label();
            ratingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specializationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(66, 43);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(32, 13);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя:";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new System.Drawing.Point(41, 17);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new System.Drawing.Size(59, 13);
            surnameLabel.TabIndex = 2;
            surnameLabel.Text = "Фамилия:";
            // 
            // middlenameLabel
            // 
            middlenameLabel.AutoSize = true;
            middlenameLabel.Location = new System.Drawing.Point(41, 69);
            middlenameLabel.Name = "middlenameLabel";
            middlenameLabel.Size = new System.Drawing.Size(57, 13);
            middlenameLabel.TabIndex = 4;
            middlenameLabel.Text = "Отчество:";
            // 
            // datebirthLabel
            // 
            datebirthLabel.AutoSize = true;
            datebirthLabel.Location = new System.Drawing.Point(11, 95);
            datebirthLabel.Name = "datebirthLabel";
            datebirthLabel.Size = new System.Drawing.Size(89, 13);
            datebirthLabel.TabIndex = 6;
            datebirthLabel.Text = "Дата рождения:";
            // 
            // jobLabel
            // 
            jobLabel.AutoSize = true;
            jobLabel.Location = new System.Drawing.Point(18, 121);
            jobLabel.Name = "jobLabel";
            jobLabel.Size = new System.Drawing.Size(82, 13);
            jobLabel.TabIndex = 8;
            jobLabel.Text = "Место работы:";
            // 
            // ratingLabel
            // 
            ratingLabel.AutoSize = true;
            ratingLabel.Location = new System.Drawing.Point(47, 287);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new System.Drawing.Size(51, 13);
            ratingLabel.TabIndex = 10;
            ratingLabel.Text = "Рейтинг:";
            // 
            // expertMapDataSet
            // 
            this.expertMapDataSet.DataSetName = "ExpertMapDataSet";
            this.expertMapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // expertBindingSource
            // 
            this.expertBindingSource.DataMember = "Expert";
            this.expertBindingSource.DataSource = this.expertMapDataSet;
            // 
            // expertTableAdapter
            // 
            this.expertTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CountryTableAdapter = this.countryTableAdapter;
            this.tableAdapterManager.ExpertInMarkerTableAdapter = null;
            this.tableAdapterManager.ExpertQuoteTableAdapter = null;
            this.tableAdapterManager.ExpertTableAdapter = this.expertTableAdapter;
            this.tableAdapterManager.MarkerInRegionTableAdapter = null;
            this.tableAdapterManager.MarkerTableAdapter = null;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.SpecializationTableAdapter = this.specializationTableAdapter;
            this.tableAdapterManager.UpdateOrder = ExpertMap.DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // countryTableAdapter
            // 
            this.countryTableAdapter.ClearBeforeFill = true;
            // 
            // specializationTableAdapter
            // 
            this.specializationTableAdapter.ClearBeforeFill = true;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.expertBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(104, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(237, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.expertBindingSource, "Surname", true));
            this.surnameTextBox.Location = new System.Drawing.Point(104, 14);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(237, 20);
            this.surnameTextBox.TabIndex = 0;
            // 
            // middlenameTextBox
            // 
            this.middlenameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.expertBindingSource, "Middlename", true));
            this.middlenameTextBox.Location = new System.Drawing.Point(104, 66);
            this.middlenameTextBox.Name = "middlenameTextBox";
            this.middlenameTextBox.Size = new System.Drawing.Size(237, 20);
            this.middlenameTextBox.TabIndex = 2;
            // 
            // datebirthDateTimePicker
            // 
            this.datebirthDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.expertBindingSource, "Datebirth", true));
            this.datebirthDateTimePicker.Location = new System.Drawing.Point(104, 92);
            this.datebirthDateTimePicker.Name = "datebirthDateTimePicker";
            this.datebirthDateTimePicker.Size = new System.Drawing.Size(237, 20);
            this.datebirthDateTimePicker.TabIndex = 3;
            // 
            // jobTextBox
            // 
            this.jobTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.expertBindingSource, "Job", true));
            this.jobTextBox.Location = new System.Drawing.Point(104, 118);
            this.jobTextBox.Multiline = true;
            this.jobTextBox.Name = "jobTextBox";
            this.jobTextBox.Size = new System.Drawing.Size(237, 105);
            this.jobTextBox.TabIndex = 4;
            // 
            // ratingNumericUpDown
            // 
            this.ratingNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.expertBindingSource, "Rating", true));
            this.ratingNumericUpDown.Location = new System.Drawing.Point(104, 283);
            this.ratingNumericUpDown.Name = "ratingNumericUpDown";
            this.ratingNumericUpDown.Size = new System.Drawing.Size(237, 20);
            this.ratingNumericUpDown.TabIndex = 7;
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataMember = "Country";
            this.countryBindingSource.DataSource = this.expertMapDataSet;
            // 
            // countryComboBox
            // 
            this.countryComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.expertBindingSource, "CountryId", true));
            this.countryComboBox.DataSource = this.countryBindingSource;
            this.countryComboBox.DisplayMember = "Name";
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(104, 229);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(237, 21);
            this.countryComboBox.TabIndex = 5;
            this.countryComboBox.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Страна:";
            // 
            // specializationBindingSource
            // 
            this.specializationBindingSource.DataMember = "Specialization";
            this.specializationBindingSource.DataSource = this.expertMapDataSet;
            // 
            // specializationComboBox
            // 
            this.specializationComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.expertBindingSource, "SpecializationId", true));
            this.specializationComboBox.DataSource = this.specializationBindingSource;
            this.specializationComboBox.DisplayMember = "Name";
            this.specializationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specializationComboBox.FormattingEnabled = true;
            this.specializationComboBox.Location = new System.Drawing.Point(104, 256);
            this.specializationComboBox.Name = "specializationComboBox";
            this.specializationComboBox.Size = new System.Drawing.Size(237, 21);
            this.specializationComboBox.TabIndex = 6;
            this.specializationComboBox.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Специализация:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(209, 326);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(51, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 360);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.specializationComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(ratingLabel);
            this.Controls.Add(this.ratingNumericUpDown);
            this.Controls.Add(jobLabel);
            this.Controls.Add(this.jobTextBox);
            this.Controls.Add(datebirthLabel);
            this.Controls.Add(this.datebirthDateTimePicker);
            this.Controls.Add(middlenameLabel);
            this.Controls.Add(this.middlenameTextBox);
            this.Controls.Add(surnameLabel);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditExpert";
            this.Text = "Редактирование эксперта";
            this.Load += new System.EventHandler(this.EditExpert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expertMapDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specializationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataModels.ExpertMapDataSet expertMapDataSet;
        private System.Windows.Forms.BindingSource expertBindingSource;
        private DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter expertTableAdapter;
        private DataModels.ExpertMapDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DataModels.ExpertMapDataSetTableAdapters.CountryTableAdapter countryTableAdapter;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox middlenameTextBox;
        private System.Windows.Forms.DateTimePicker datebirthDateTimePicker;
        private System.Windows.Forms.TextBox jobTextBox;
        private System.Windows.Forms.NumericUpDown ratingNumericUpDown;
        private System.Windows.Forms.BindingSource countryBindingSource;
        private DataModels.ExpertMapDataSetTableAdapters.SpecializationTableAdapter specializationTableAdapter;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource specializationBindingSource;
        private System.Windows.Forms.ComboBox specializationComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

    }
}