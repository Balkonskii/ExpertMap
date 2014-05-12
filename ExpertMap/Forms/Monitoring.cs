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
    public partial class Monitoring : Form
    {
        public Monitoring()
        {
            InitializeComponent();
        }

        public void Update(List<KeyValuePair<string,object>> values)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in values)
            {
                dataGridView1.Rows.Add(item.Key, item.Value);
            }
        }
    }
}
