using ExpertMap.DbTools;
using ExpertMap.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpertMap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ExpertMap.Forms.MainForm());
            ProjectManager.Init();
            Application.Run(new ExpertMap.Forms.ProjectListForm());
        }
    }
}
