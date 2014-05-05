using ExpertMap.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertMap.DbTools;

namespace ExpertMap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.ExpertMapDbConnectionString;
            dataGridView1.DataSource = DbHelper.GetInstance(cs).ExpertMapDataSet.Country;

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = DbHelper.GetInstance().ExpertMapDataSet.Country;
        }
    }
}
