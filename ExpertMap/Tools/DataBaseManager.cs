using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ExpertMap.Tools
{
   public static class DataBaseManager
    {
        public static string TemplateDataBasePath { get; set; }
        public static string CurrentDataBasePath { get; set; }
        private const string _templateFileName = "ClearDataBase.accdb";

        private static string _openedFilePath = string.Empty;
        private static string _tempFileName = "temp.accdb";
        private static bool _wasOpened = false;

       public static string TempFilePath { get; set; }
       public static bool Saved { get; private set; }


       public static bool TemplateFileExists()
       {
           return File.Exists(TemplateDataBasePath);
       }       

       public static void Init()
       {
           TemplateDataBasePath = Path.Combine(Application.StartupPath, _templateFileName);

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

       public static void Open()
       {
           using (var dialog = new OpenFileDialog())
           {
               if (dialog.ShowDialog() == DialogResult.OK)
               {
                   _wasOpened = true;
                   _openedFilePath = dialog.FileName;
                   File.Copy(_openedFilePath, TempFilePath, true);
                   CurrentDataBasePath = TempFilePath;
               }
           }
       }

       public static void Save()
       {
           Saved = true;

           if (_wasOpened)
           {
               File.Copy(CurrentDataBasePath, _openedFilePath, true);
               _wasOpened = false;
           }
           else
           {
               using (var dialog = new SaveFileDialog())
               {
                   dialog.Filter = "Access database | *.accdb";
                   if (dialog.ShowDialog() == DialogResult.OK)
                   {
                       File.Copy(CurrentDataBasePath, dialog.FileName, true);
                   }
               }
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
    }
}
