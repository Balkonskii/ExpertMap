using ExpertMap.DbTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpertMap.Forms
{
    public partial class EditExpertForm : Form
    {
        public EditExpertForm()
        {
            InitializeComponent();
        }

        public int ExpertId = -1;

        private void expertBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.expertBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.expertMapDataSet);

        }

        private void EditExpert_Load(object sender, EventArgs e)
        {
            this.specializationTableAdapter.Fill(this.expertMapDataSet.Specialization);
            this.countryTableAdapter.Fill(this.expertMapDataSet.Country);
            var expert = DbHelper.GetInstance().ExpertMapDataSet.Expert.Where(x => x.Id == ExpertId).FirstOrDefault();
            if (expert != null)
            {
                expertBindingSource.DataSource = expert;
            }
            else
            {
                var tbl = DbHelper.GetInstance().ExpertMapDataSet.Expert;
                var row = DbHelper.GetInstance().GetEmptyRow(tbl);
                expertBindingSource.DataSource = row;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ExpertId > 0)
            {
                var expert = DbHelper.GetInstance().ExpertMapDataSet.Expert.Where(x => x.Id == ExpertId).FirstOrDefault();

                var editedExpert = expertBindingSource.DataSource as ExpertMap.DataModels.ExpertMapDataSet.ExpertRow;
                expert.Name = editedExpert.Name;
                expert.Surname = editedExpert.Surname;
                expert.Datebirth = editedExpert.Datebirth;
                expert.SpecializationId = editedExpert.SpecializationId;
                expert.Job = editedExpert.Job;
                expert.CountryId = editedExpert.CountryId;
                expert.Rating = editedExpert.Rating;

                expertTableAdapter.Update(expert);
            }
            else
            {
                var expert = expertBindingSource.DataSource as ExpertMap.DataModels.ExpertMapDataSet.ExpertRow;
                expertTableAdapter.Insert(expert.Name, expert.Surname, expert.Middlename, 
                    expert.Datebirth, expert.SpecializationId, expert.Job, 
                    expert.CountryId, expert.Rating);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
