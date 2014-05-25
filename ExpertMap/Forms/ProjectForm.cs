using ExpertMap.DataModels;
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
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
        }

        private string[] _deniedChars = { @"\", "/", ":", "?", "*", "\"", "<", ">", "|" };

        public Project Project
        {
            get
            {
                return new Project()
                {
                    DataBasePath = tbDbPath.Text,
                    FullName = tbFullName.Text,
                    MapPath = tbMapPath.Text,
                    ShortDescription = rtbShortDescription.Text,
                    ShortName = tbShortName.Text
                };
            }
        }

        private void btnLoadMapPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Изображения | *.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tga";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbMapPath.Text = dialog.FileName;
            }
        }

        private void tbDbPath_TextChanged(object sender, EventArgs e)
        {
            if (tbDbPath.Text.Any(x => _deniedChars.Contains(x.ToString())))
            {
                tbDbPath.Text.Remove(tbDbPath.Text.Length - 1, 1);
                MessageBox.Show(this, "Название базы не должно содержать следующие символы: " + string.Join(", ", _deniedChars), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
