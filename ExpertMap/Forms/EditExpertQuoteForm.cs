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
    public partial class EditExpertQuoteForm : Form
    {
        public EditExpertQuoteForm()
        {
            InitializeComponent();
        }

        public string QuoteText { get { return richTextBox1.Text; } set { richTextBox1.Text = value; } }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void EditExpertQuoteForm_Load(object sender, EventArgs e)
        {
        }
    }
}
