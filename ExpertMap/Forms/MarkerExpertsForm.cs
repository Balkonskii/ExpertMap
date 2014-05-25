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
    public partial class MarkerExpertsForm : Form
    {
        public MarkerExpertsForm()
        {
            InitializeComponent();
        }

        public int SelectedMarkerId { get; set; }

        private ContextMenu _menu;

        private void MarkerExpertsForm_Load(object sender, EventArgs e)
        {
            Fill();
            InitMenu();
        }

        private void InitMenu()
        {
            _menu = new System.Windows.Forms.ContextMenu();
            _menu.MenuItems.AddRange(new MenuItem[]{
                new MenuItem("Добавить", AddItem_Click),
                new MenuItem("Удалить", RemoveItem_Click) });
        }

        private void Fill()
        {
            var expertIds = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertInMarkerTableAdapter()
                .GetData().Where(x => x.MarkerId == SelectedMarkerId).Select(x => x.ExpertId).ToList();

            var experts = this.expertTableAdapter.GetData().Where(x => expertIds.Contains(x.Id));

            var expertView = (from exp in experts
                              select new { Id = exp.Id, 
                                  FullName = (exp.Surname + " " + exp.Name + " " + exp.Middlename) 
                              }).ToList();


            expertListBox.DisplayMember = "FullName";
            expertListBox.ValueMember = "Id";
            expertListBox.DataSource = expertView;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            ExpertTableForm form = new ExpertTableForm(true);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DbHelper.GetInstance().InsertExpertInMarker(form.SelectedExpertId,SelectedMarkerId);
                Fill();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
           
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"Удалить привязку эксперта к маркеру?","",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) 
                == System.Windows.Forms.DialogResult.Yes)
            {
                int id = int.Parse(expertListBox.SelectedValue.ToString());
                DbHelper.GetInstance().DeleteExpertInMarker(SelectedMarkerId, id);

                Fill();
            }
        }

        private void expertListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //_menu.Show(expertListBox, e.Location);
            }
        }
    }
}
