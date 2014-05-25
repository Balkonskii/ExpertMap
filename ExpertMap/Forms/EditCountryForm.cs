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
    public partial class EditCountryForm : Form
    {
        public EditCountryForm()
        {
            InitializeComponent();
        }

        public int CountryId = -1;

        private void EditCountry_Load(object sender, EventArgs e)
        {
            try
            {
                var country = DbHelper.GetInstance().ExpertMapDataSet.Country.Where(x => x.Id == CountryId).FirstOrDefault();
                if (country != null)
                    countryBindingSource.DataSource = country;
                else
                {
                    var tbl = DbHelper.GetInstance().ExpertMapDataSet.Country;
                    var row = DbHelper.GetInstance().GetEmptyRow(tbl);
                    countryBindingSource.DataSource = row;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CountryId > 0)
            {
                var country = DbHelper.GetInstance().ExpertMapDataSet.Country.Where(x => x.Id == CountryId).FirstOrDefault();
                country.Name = nameTextBox.Text;
                countryTableAdapter.Update(country);
            }
            else
                countryTableAdapter.Insert(nameTextBox.Text);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
