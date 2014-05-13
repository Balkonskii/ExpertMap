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
    public partial class ExpertQuoteListForm : Form
    {
        public ExpertQuoteListForm()
        {
            InitializeComponent();
            expertQuoteGridView.AutoGenerateColumns = false;
        }

        public int ExpertId { get; set; }

        private ContextMenu _menu;

        public int SelectedRowId
        {
            get
            {
                if (expertQuoteGridView.SelectedRows.Count > 0)
                {
                    return int.Parse(expertQuoteGridView.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                    return -1;
            }
        }

        private void ExpertQuoteListForm_Load(object sender, EventArgs e)
        {
            Fill(); 
            InitMenu();
        }

        private void Fill()
        {
            expertQuoteGridView.Rows.Clear();
            var expertQuoteTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertQuoteTableAdapter();
            var expertQuoteRows = expertQuoteTableAdapter.GetData().Where(x => x.ExpertId == ExpertId);

            foreach (var item in expertQuoteRows)
            {
                expertQuoteGridView.Rows.Add(item.Id, item.QuoteText);
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
            EditExpertQuoteForm form = new EditExpertQuoteForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                expertQuoteTableAdapter.Insert(ExpertId, form.QuoteText);
                Fill();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            if (SelectedRowId == -1) return;
            EditExpertQuoteForm form = new EditExpertQuoteForm();
            form.QuoteText = expertQuoteGridView.SelectedRows[0].Cells["Quotes"].Value.ToString();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var row = expertQuoteTableAdapter.GetData().Where(x => x.Id == SelectedRowId).FirstOrDefault();
                if (row != null)
                {
                    row.QuoteText = form.QuoteText;
                    expertQuoteTableAdapter.Update(row.ExpertId, row.QuoteText, row.Id);
                    Fill();
                }
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (SelectedRowId == -1) return;
            if (MessageBox.Show(this,"Удалить цитату?","", MessageBoxButtons.YesNo,MessageBoxIcon.Question) 
                == System.Windows.Forms.DialogResult.Yes)
            {
                expertQuoteTableAdapter.Delete(SelectedRowId);
                Fill();
            }
        }

        private void expertQuoteGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _menu.Show(expertQuoteGridView, e.Location);
            }
        }
    }
}
