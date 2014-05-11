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
    public partial class CountryListForm : Form
    {
        public CountryListForm(bool needToSelect = false)
        {
            InitializeComponent();

            btnOk.Visible = btnClose.Visible = needToSelect;
            countryListBox.Dock = needToSelect ? DockStyle.None : DockStyle.Fill;
        }

        private ContextMenu _menu;

        public int SelectedCountryId
        {
            get
            {
                return countryListBox.SelectedItems.Count > 0 ? (int)countryListBox.SelectedValue : -1;
            }
        }

        private void Fill()
        {
            this.countryTableAdapter.Fill(this.expertMapDataSet.Country);
        }

        private void CountryListForm_Load(object sender, EventArgs e)
        {
            Fill();
            InitMenu();
        }

        private void InitMenu()
        {
            _menu = new System.Windows.Forms.ContextMenu();
            _menu.MenuItems.AddRange(new MenuItem[]{
                new MenuItem("Добавить", AddItem_Click),
                new MenuItem("Изменить", EditItem_Click),
                new MenuItem("Удалить", RemoveItem_Click) });
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            EditCountryForm form = new EditCountryForm();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fill();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            EditCountryForm form = new EditCountryForm();
            int id = SelectedCountryId;

            if (id != -1)
            {
                form.CountryId = id;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (SelectedCountryId == -1) return;

            if (MessageBox.Show(this, "Удалить страну?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                var expertTableAdapter = new DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();
                var experts = DbHelper.GetInstance().ExpertMapDataSet.Expert.Where(x => x.CountryId == SelectedCountryId);

                foreach (ExpertMap.DataModels.ExpertMapDataSet.ExpertRow row in experts)
                {
                    expertTableAdapter.Delete(
                      row.Id,
                      row.Name,
                      row.Surname,
                      row.Middlename,
                      row.Datebirth,
                      row.SpecializationId,
                      row.Job,
                      row.CountryId,
                      row.Rating);
                }

                var country = DbHelper.GetInstance().ExpertMapDataSet.Country.Where(x => x.Id == SelectedCountryId).FirstOrDefault();
                countryTableAdapter.Delete(country.Id, country.Name);

                Fill();
            }
        }

        private void countryListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _menu.Show(countryListBox, e.Location);
            }
        }
    }
}
