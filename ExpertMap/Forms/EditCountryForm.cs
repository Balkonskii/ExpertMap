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
    public partial class EditCountryForm : Form
    {
        public EditCountryForm()
        {
            InitializeComponent();
        }

        private void countryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.countryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.expertMapDataSet);

        }

        private void EditCountry_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'expertMapDataSet.Country' table. You can move, or remove it, as needed.
            this.countryTableAdapter.Fill(this.expertMapDataSet.Country);

        }
    }
}
