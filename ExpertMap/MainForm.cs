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
            ExpertMapDataSet ds = new ExpertMapDataSet();
            DataTableReader reader = ds.CreateDataReader(ds.Country);

            string cs = Properties.Settings.Default.ExpertMapDbConnectionString;

            OleDbConnection connection = new OleDbConnection(cs);

            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.TableDirect;
            command.CommandText = "Country";

            connection.Open();

            ds.Country.Load(command.ExecuteReader());
        }
    }
}
