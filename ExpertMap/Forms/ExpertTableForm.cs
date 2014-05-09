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
    public partial class ExpertTableForm : Form
    {
        public ExpertTableForm(bool needToSelect = false)
        {
            InitializeComponent();

            btnOk.Visible = btnClose.Visible = needToSelect;
            expertTable.Dock = needToSelect ? DockStyle.None : DockStyle.Fill;
        }

        private ContextMenu _menu;

        public int SelectedExpertId
        {
            get
            {
                return
                    expertTable.SelectedRows.Count > 0 ?
                    int.Parse(expertTable.SelectedRows[0].Cells["Id"].Value.ToString()) : -1;
            }
        }

        private void ExpertTableForm_Load(object sender, EventArgs e)
        {
            FillTable();
            InitMenu();
        }   

        private void FillTable()
        {
            expertTable.AutoGenerateColumns = false;
            try
            {
                var instance = DbHelper.GetInstance();
                instance.ExpertMapDataSet.Reset();
                instance.Init();
                var dataSet = instance.ExpertMapDataSet;

                var collection =
                    (from exp in dataSet.Expert
                     join cnt in dataSet.Country on exp.CountryId equals cnt.Id
                     join spec in dataSet.Specialization on exp.SpecializationId equals spec.Id
                     select new
                     {
                         exp.Id,
                         ExpertName = exp.Name,
                         exp.Surname,
                         exp.Middlename,
                         exp.Datebirth,
                         exp.Job,
                         exp.Rating,
                         CountryName = cnt.Name,
                         SpecializationName = spec.Name
                     }).ToList();

                expertTable.Rows.Clear();

                foreach (var row in collection)
                {
                    expertTable.Rows.Add(row.Id, row.ExpertName, row.Surname,
                        row.Middlename, row.Datebirth.Date.ToShortDateString(),
                        row.Job, row.Rating, row.CountryName, row.SpecializationName);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
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
            EditExpertForm form = new EditExpertForm();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FillTable();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            EditExpertForm form = new EditExpertForm();
            form.ExpertId = SelectedExpertId;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FillTable();
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Удалить эксперта?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                var expertRow = DbHelper.GetInstance().ExpertMapDataSet.Expert.Where(x => x.Id == SelectedExpertId).FirstOrDefault();

                new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertTableAdapter().Delete(
                    expertRow.Id,
                    expertRow.Name,
                    expertRow.Surname,
                    expertRow.Middlename,
                    expertRow.Datebirth,
                    expertRow.SpecializationId,
                    expertRow.Job,
                    expertRow.CountryId,
                    expertRow.Rating);

                FillTable();
            }
        }

        private void expertTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _menu.Show(expertTable, e.Location);
            }
        }
    }
}
