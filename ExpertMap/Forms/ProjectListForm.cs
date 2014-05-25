using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertMap.DataModels;
using System.IO;
using ExpertMap.Tools;

namespace ExpertMap.Forms
{
    public partial class ProjectListForm : Form
    {
        public ProjectListForm()
        {
            InitializeComponent();
        }

        private Project _SelectedProject;

        private void ProjectListForm_Load(object sender, EventArgs e)
        {
            FillProjects();
        }

        private void FillProjects()
        {
            lbProjectNames.Items.Clear();

            var projectTableAdapter = new ExpertMap.DataModels.ProjectDataModelTableAdapters.ProjectTableAdapter();

            //var collection = (from proj in projectTableAdapter.GetData()
            //                  select new { Id = proj.Id, ShortName = proj.ShortName }).ToList();
            var collection = projectTableAdapter.GetData().ToList();

            lbProjectNames.DisplayMember = "ShortName";
            lbProjectNames.ValueMember = "Id";
            collection.ForEach(x => lbProjectNames.Items.Add(x));
        }

        private void lbProjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var project = (lbProjectNames.SelectedItem as ExpertMap.DataModels.ProjectDataModel.ProjectRow);
            rtbProjectProperties.Clear();
            if (project != null)
            {
                _SelectedProject = new Project()
                {
                    Id = project.Id,
                    DataBasePath = project.DataBasePath,
                    FullName = project.FullName,
                    MapPath = project.MapPath,
                    ProjectPath = project.ProjectPath,
                    ShortDescription = project.ShortDescription,
                    ShortName = project.ShortName
                };
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(project.FullName);
                builder.AppendLine();
                builder.Append(project.ShortDescription);
                rtbProjectProperties.Text = builder.ToString();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(_SelectedProject.ProjectPath))
                {
                    using (var projectTableAdapter = new ExpertMap.DataModels.ProjectDataModelTableAdapters.ProjectTableAdapter())
                    {
                        projectTableAdapter.Delete(_SelectedProject.Id);
                    }

                    MessageBox.Show(this, "Файл проекта не найден", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FillProjects();
                }
                else
                {
                    if (_SelectedProject != null)
                    {
                        MapForm form = new MapForm();
                        form.FormClosed += MapForm_FormClosed;
                        form.Project = _SelectedProject;
                        this.Hide();
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.ToString(), "Ошибка при открытии проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            FillProjects();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "*.prj | *.prj";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var projectTableAdapter = new ExpertMap.DataModels.ProjectDataModelTableAdapters.ProjectTableAdapter();
                    bool existing = projectTableAdapter.GetData().Any(x => x.ProjectPath == dialog.FileName);
                    if (existing)
                        MessageBox.Show(this, "Этот проект уже загружен.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        ProjectManager.LoadProject(dialog.FileName);
                        FillProjects();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.ToString(), "Ошибка при загрузке проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveAs(true);
            FillProjects();
        }
    }
}
