using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ExpertMap.DataModels;
using ExpertMap.Forms;
using System.Drawing;

namespace ExpertMap.Tools
{
    public static class ProjectManager
    {
        public static string TemplateDataBasePath { get; set; }
        public static string CurrentDataBasePath { get; set; }
        private const string _templateFileName = "ClearDataBase.accdb";

        private static string _openedFilePath = string.Empty;
        private static string _tempFileName = "temp.accdb";
        private static bool _wasOpened = false;
        private static string _emptyDataBaseFilePath;

        public static string TempFilePath { get; set; }
        public static bool Saved { get; private set; }

        public static Project CurrentProject { get; set; }

        public static bool TemplateFileExists()
        {
            return File.Exists(TemplateDataBasePath);
        }

        public static void Init()
        {
            TemplateDataBasePath = Path.Combine(Application.StartupPath, _templateFileName);
            _emptyDataBaseFilePath = TemplateDataBasePath;

            RefreshTemplatePath();
            Saved = false;

            TempFilePath = Path.Combine(Application.StartupPath, _tempFileName);

            Application.ApplicationExit += Application_ApplicationExit;
            NewDataBase();
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DeleteTempFile();
        }

        private static void RefreshTemplatePath()
        {
            if (!TemplateFileExists())
            {
                using (var dialog = new OpenFileDialog())
                {
                    MessageBox.Show("Не найден файл чистой базы данных.");

                    dialog.Title = "Путь до чистой базы данных";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        TemplateDataBasePath = dialog.FileName;
                    }
                    else
                        Environment.Exit(0);
                }
            }
        }

        public static void Open(Project project)
        {
            //using (var dialog = new OpenFileDialog())
            //{
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        _wasOpened = true;
            //        _openedFilePath = dialog.FileName;
            //        File.Copy(_openedFilePath, TempFilePath, true);
            //        CurrentDataBasePath = TempFilePath;
            //    }
            //}

            _wasOpened = true;
            _openedFilePath = project.DataBasePath;
            File.Copy(_openedFilePath, TempFilePath, true);
            CurrentDataBasePath = TempFilePath;
        }

        public static void Save()
        {
            Saved = true;

            if (_wasOpened)
            {
                File.Copy(CurrentDataBasePath, _openedFilePath, true);
            }
            else
            {
                //using (var dialog = new SaveFileDialog())
                //{
                //    dialog.Filter = "Access database | *.accdb";
                //    if (dialog.ShowDialog() == DialogResult.OK)
                //    {
                //        File.Copy(CurrentDataBasePath, dialog.FileName, true);
                //    }
                //}

                SaveAs(false);
            }
        }

        public static void SaveAs(bool createNew)
        {
            string projectsDirectory = Path.Combine(Application.StartupPath, "Projects");

            if (!Directory.Exists(projectsDirectory))
                Directory.CreateDirectory(projectsDirectory);

            ProjectForm form = new ProjectForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Project project = form.Project;

                string projectDirectory = Path.Combine(Application.StartupPath, "Projects", project.ShortName);

                if (!Directory.Exists(projectDirectory))
                    Directory.CreateDirectory(projectDirectory);

                string dataBaseFilePath = Path.Combine(projectDirectory, project.DataBasePath + ".accdb");
                string mapFileName = Path.GetFileName(project.MapPath);
                string newMapFileName = Path.Combine(projectDirectory, mapFileName);
                string projectFilePath = Path.Combine(projectDirectory, project.ShortName + ".prj");

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("ShortName:" + project.ShortName);
                builder.AppendLine("ShortDescription:" + project.ShortDescription);
                builder.AppendLine("FullName:" + project.FullName);
                builder.AppendLine("DataBasePath:" + dataBaseFilePath);
                builder.AppendLine("MapPath:" + newMapFileName);
                builder.AppendLine("ProjectPath:" + projectFilePath);

                File.Create(projectFilePath).Close();

                using (StreamWriter writer = new StreamWriter(projectFilePath))
                {
                    writer.Write(builder.ToString());
                }

                if (!string.IsNullOrEmpty(project.MapPath))
                    File.Copy(project.MapPath, newMapFileName, true);

                _openedFilePath = dataBaseFilePath;

                if (createNew)
                {
                    File.Copy(_emptyDataBaseFilePath, _openedFilePath, true);
                }
                else
                {
                    File.Copy(CurrentDataBasePath, _openedFilePath, true);
                }

                project.DataBasePath = dataBaseFilePath;
                    project.ProjectPath = projectFilePath;
                    project.MapPath = newMapFileName;

                var projectTableAdapter = new ExpertMap.DataModels.ProjectDataModelTableAdapters.ProjectTableAdapter();
                projectTableAdapter.Insert(project.ShortName, project.FullName, project.ShortDescription, project.DataBasePath, project.MapPath, project.ProjectPath);
            }
        }

        public static void NewDataBase()
        {
            try
            {
                Saved = false;
                File.Copy(TemplateDataBasePath, TempFilePath, true);
                CurrentDataBasePath = TempFilePath;
                _wasOpened = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(null, exc.Message, "Ошибка при создании базы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteTempFile()
        {
            if (File.Exists(TempFilePath))
            {
                File.Delete(TempFilePath);
            }
        }

        public static void LoadProject(string filename)
        {
            var project = new Project();

            var properties = project.GetType().GetProperties();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    var rowAttributes = row.Split(':');

                    var property = properties.Where(x => x.Name == rowAttributes[0]).First();
                    property.SetValue(project, rowAttributes[1], null);
                }
            }

            var projectTableAdapter = new ExpertMap.DataModels.ProjectDataModelTableAdapters.ProjectTableAdapter();
            projectTableAdapter.Insert(project.ShortName, project.FullName, project.ShortDescription, project.DataBasePath, project.MapPath, project.ProjectPath);
        }

        public static void CloseProject()
        {
            _wasOpened = false;
        }
    }
}
