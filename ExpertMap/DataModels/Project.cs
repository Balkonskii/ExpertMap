using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertMap.DataModels
{
    public partial class Project
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string ShortDescription { get; set; }
        public string DataBasePath { get; set; }
        public string MapPath { get; set; }
        public string ProjectPath { get; set; }
    }
}
