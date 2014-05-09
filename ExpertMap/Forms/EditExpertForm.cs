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
            // TODO: This line of code loads data into the 'expertMapDataSet.Specialization' table. You can move, or remove it, as needed.
            this.specializationTableAdapter.Fill(this.expertMapDataSet.Specialization);
            // TODO: This line of code loads data into the 'expertMapDataSet.Country' table. You can move, or remove it, as needed.
            this.countryTableAdapter.Fill(this.expertMapDataSet.Country);
            // TODO: This line of code loads data into the 'expertMapDataSet.Expert' table. You can move, or remove it, as needed.
            //this.expertTableAdapter.Fill(this.expertMapDataSet.Expert.Where(x => x.Id == ExpertId).FirstOrDefault());
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
