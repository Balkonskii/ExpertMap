using ExpertMap.DbTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpertMap.Forms
{
    public partial class RegionListForm : Form
    {
        public RegionListForm(bool needToSelect = false)
        {
            InitializeComponent();
            btnOk.Visible = btnClose.Visible = needToSelect;
            regionListBox.Dock = needToSelect ? DockStyle.None : DockStyle.Fill;
            _needToSelect = needToSelect;
        }

        private bool _needToSelect = false;
        private ContextMenu _menu;

        private void RegionListForm_Load(object sender, EventArgs e)
        {
            Fill();
            InitMenu();
            DbHelper.GetInstance();
        }

        private void Fill()
        {
            this.regionTableAdapter.Fill(this.expertMapDataSet.Region);
        }

        public ExpertMap.Models.Region SelectedRegion
        {
            get
            {
                var selectedItem = regionListBox.SelectedItem as System.Data.DataRowView;
                var regRow = selectedItem.Row as ExpertMap.DataModels.ExpertMapDataSet.RegionRow;

                return new ExpertMap.Models.Region()
                {
                    RegionId = regRow.Id,
                    RegionName = regRow.Name
                };
            }
        }

        public int SelectedRegionId
        {
            get
            {
                return regionListBox.SelectedItems.Count > 0 ? (int)regionListBox.SelectedValue : -1;
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
            EditRegionForm form = new EditRegionForm();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fill();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            EditRegionForm form = new EditRegionForm();

            int id = SelectedRegionId;

            if (id != -1)
            {
                form.RegionId = id;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (SelectedRegionId == -1) return;

            if (MessageBox.Show(this, "Удалить регион?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {

                var regionPointsAdapter = new DataModels.ExpertMapDataSetTableAdapters.RegionPointsTableAdapter();

                foreach (var row in regionPointsAdapter.GetData().Rows)
                {
                    var rw = row as ExpertMap.DataModels.ExpertMapDataSet.RegionPointsRow;
                    if (rw.RegionId == SelectedRegionId)
                        regionPointsAdapter.Delete(rw.RegionId, rw.X, rw.Y, rw.Number);
                }

                var markerInRegionAdapter = new DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();

                foreach (var row in markerInRegionAdapter.GetData().Rows)
                {
                    var rw = row as ExpertMap.DataModels.ExpertMapDataSet.MarkerInRegionRow;
                    if (rw.RegionId == SelectedRegionId)
                        markerInRegionAdapter.Delete(rw.Id, rw.MarkerId, rw.RegionId);
                }

                var region = DbHelper.GetInstance().ExpertMapDataSet.Region.Where(x => x.Id == SelectedRegionId).FirstOrDefault();
                regionTableAdapter.Delete(region.Id, region.Name);

                Fill();
            }
        }

        private void regionListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (!_needToSelect)
                    _menu.Show(regionListBox, e.Location);
            }
        }
    }
}
