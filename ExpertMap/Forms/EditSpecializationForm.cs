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

        private void specializationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.specializationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.expertMapDataSet);

        }

        private void EditSpecialization_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'expertMapDataSet.Specialization' table. You can move, or remove it, as needed.
            this.specializationTableAdapter.Fill(this.expertMapDataSet.Specialization);

        }
    }
}
