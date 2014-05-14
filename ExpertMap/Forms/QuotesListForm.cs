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
    public partial class QuotesListForm : Form
    {
        public QuotesListForm()
        {
            InitializeComponent();
        }

        private void Fill()
        {
            var expertQuotesRows = expertQuoteTableAdapter.GetData();
            var expertRows = expertTableAdapter.GetData();

            var resultView =
                (from quot in expertQuotesRows
                 join exp in expertRows on quot.ExpertId equals exp.Id
                 select new { FullName = exp.Surname + " " + exp.Name + " " + exp.Middlename, quot.QuoteText }).ToList();

            resultView.ForEach(x => dataGridView1.Rows.Add(x.FullName, x.QuoteText));
        }

        private void QuotesListForm_Load(object sender, EventArgs e)
        {
            Fill();
        }
    }
}
