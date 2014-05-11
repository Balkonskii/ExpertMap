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
    public partial class SpecializationListForm : Form
    {
        public SpecializationListForm(bool needToSelect = false)
        {
            InitializeComponent();

            btnOk.Visible = btnClose.Visible = needToSelect;
            specializationListBox.Dock = needToSelect ? DockStyle.None : DockStyle.Fill;
        }

        private ContextMenu _menu;

        public int SelectedSpecializationId
        {
            get
            {
                return specializationListBox.SelectedItems.Count > 0 ? (int)specializationListBox.SelectedValue : -1;
            }
        }

        private void SpecializationListForm_Load(object sender, EventArgs e)
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

        private void Fill()
        {
            this.specializationTableAdapter.Fill(this.expertMapDataSet.Specialization);
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            EditSpecializationForm form = new EditSpecializationForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fill();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            EditSpecializationForm form = new EditSpecializationForm();

            int id = SelectedSpecializationId;

            if (id != -1)
            {
                form.SpecializationId = id;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (SelectedSpecializationId == -1) return;

            if (MessageBox.Show(this, "Удалить специализацию?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                var expertTableAdapter = new DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter();
                var experts = DbHelper.GetInstance().ExpertMapDataSet.Expert.Where(x => x.SpecializationId == SelectedSpecializationId);

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

                var specialization = DbHelper.GetInstance().ExpertMapDataSet.Specialization.Where(x => x.Id == SelectedSpecializationId).FirstOrDefault();
                specializationTableAdapter.Delete(specialization.Id, specialization.Name);

                Fill();
            }
        }

        private void specializationListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _menu.Show(specializationListBox, e.Location);
            }
        }
    }
}
