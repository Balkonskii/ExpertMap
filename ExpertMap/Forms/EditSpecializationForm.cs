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
    public partial class EditSpecializationForm : Form
    {
        public EditSpecializationForm()
        {
            InitializeComponent();
        }

        public int SpecializationId = -1;

        private void EditSpecialization_Load(object sender, EventArgs e)
        {
            try
            {
                var specialization = DbHelper.GetInstance().ExpertMapDataSet.Specialization.Where(x => x.Id == SpecializationId).FirstOrDefault();

                if (specialization != null)
                    specializationBindingSource.DataSource = specialization;
                else
                {
                    var tbl = DbHelper.GetInstance().ExpertMapDataSet.Country;
                    var row = DbHelper.GetInstance().GetEmptyRow(tbl);
                    specializationBindingSource.DataSource = row;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SpecializationId > 0)
            {
                var specialization = DbHelper.GetInstance().ExpertMapDataSet.Specialization.Where(x => x.Id == SpecializationId).FirstOrDefault();
                specializationTableAdapter.Update(specialization);
            }
            else
                specializationTableAdapter.Insert(nameTextBox.Text);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
