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
    public partial class EditRegionForm : Form
    {
        public EditRegionForm()
        {
            InitializeComponent();
        }

        public int RegionId = -1;

        private void EditRegionForm_Load(object sender, EventArgs e)
        {
            try
            {
                var region = DbHelper.GetInstance().ExpertMapDataSet.Region.Where(x => x.Id == RegionId).FirstOrDefault();
                if (region != null)
                    regionBindingSource.DataSource = region;
                else
                {
                    var tbl = DbHelper.GetInstance().ExpertMapDataSet.Region;
                    var row = DbHelper.GetInstance().GetEmptyRow(tbl);
                    regionBindingSource.DataSource = row;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (RegionId > 0)
            {
                var region = DbHelper.GetInstance().ExpertMapDataSet.Region.Where(x => x.Id == RegionId).FirstOrDefault();
                region.Name = nameTextBox.Text;
                regionTableAdapter.Update(region);
            }
            else
                regionTableAdapter.Insert(nameTextBox.Text);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
