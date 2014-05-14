using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertMap.DataModels;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using ExpertMap.Models;
using System.Windows.Forms;
using System.IO;
using ExpertMap.Tools;

namespace ExpertMap.DbTools
{
    public class DbHelper
    {
        private static DbHelper _instance;
        private string _connectionString = string.Empty;

        public ExpertMapDataSet ExpertMapDataSet { get; set; }

        private DbHelper()
        {
            InitConnectionString();
            Init();
        }

        //private DbHelper(string connectionString)
        //{
        //    _connectionString = connectionString;
        //    Init();
        //}

        public static DbHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbHelper();       //Properties.Settings.Default.ExpertMapDbConnectionString         
            }

            return _instance;
        }

        //public static DbHelper GetInstance(string connectionString)
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new DbHelper(connectionString);
        //    }

        //    return _instance;
        //}

        public void FillDataSet(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                FillDataTable(table);
            }
        }

        public DbHelper Init()
        {
            ExpertMapDataSet = new ExpertMapDataSet();
            FillDataSet(ExpertMapDataSet);
            return this;
        }

        public void FillDataTable(DataTable table)
        {
            OleDbConnection conn = new OleDbConnection(_connectionString);

            try
            {
                var command = conn.CreateCommand();
                command.CommandType = CommandType.TableDirect;
                command.CommandText = table.TableName;
                conn.Open();
                var reader = command.ExecuteReader();

                table.Load(reader, LoadOption.OverwriteChanges);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public DataRow GetEmptyRow(DataTable table)
        {
            var row = table.NewRow();

            foreach (DataColumn column in table.Columns)
            {
                if (DBNull.Value.Equals(row[column]))
                {
                    row[column] = GetDefault(column.DataType);
                }
            }
            
            return row;
        }

        public object GetDefault(Type t)
        {
            if (t.Name == "String") return string.Empty;
            return this.GetType().GetMethod("GetDefaultGeneric").MakeGenericMethod(t).Invoke(this, null);
        }

        public T GetDefaultGeneric<T>()
        {
            return default(T);
        }

        public void SaveRegionPoints(ExpertMap.Models.Region region)
        {
            var adapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.RegionPointsTableAdapter();

            for (int i = 0; i < region.Points.Count; i++)
            {
                adapter.Insert(region.RegionId, region.Points[i].X, region.Points[i].Y, (i + 1));
            }
        }

        public void SaveMarker(Marker marker)
        {
            var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();
            markerTableAdapter.Insert(marker.DefaultLocation.X, marker.DefaultLocation.Y, marker.ImageName);

            if (marker.Parent != null)
            {
                var row = markerTableAdapter.GetData().Where(x =>
                     x.X == marker.DefaultLocation.X &&
                     x.Y == marker.DefaultLocation.Y &&
                     x.ImageName == marker.ImageName).FirstOrDefault();

                var markerInRegionTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();
                markerInRegionTableAdapter.Insert(row.Id, marker.Parent.RegionId);
            }
        }

        public void DeleteMarker(int markerId)
        {
            var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();
            var markerRow = markerTableAdapter.GetData().Where(x => x.Id == markerId).FirstOrDefault();
            if (markerRow != null)
            {
                DeleteMarker(markerRow.ImageName, markerRow.X, markerRow.Y);
            }
        }
        
        public void DeleteMarker(string imageName, int x, int y)
        {
            var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();
            var markerRow = GetMarkerRow(imageName, x, y);
            DeleteExpertInMarker(markerRow.Id, null);
            markerTableAdapter.Delete(markerRow.Id, markerRow.X, markerRow.Y);
        }

        public void DeleteExpertInMarker(int? markerId,int? expertId)
        {
            if (!markerId.HasValue && !expertId.HasValue) return;

            List<int> markerIds = new List<int>();
            List<int> expertIds = new List<int>();

            var expertInMarkerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertInMarkerTableAdapter();

            if (!markerId.HasValue)
            {
                markerIds = expertInMarkerTableAdapter.GetData()
                    .Where(x => x.ExpertId == expertId.Value).Select(x => x.MarkerId).ToList();
            }
            else
                markerIds.Add(markerId.Value);

            if (!expertId.HasValue)
            {
                expertIds = expertInMarkerTableAdapter.GetData()
                    .Where(x => x.MarkerId == markerId).Select(x => x.ExpertId).ToList();
            }
            else
                expertIds.Add(expertId.Value);

            var expertInMarkerRows = expertInMarkerTableAdapter.GetData()
                .Where(x => expertIds.Contains(x.ExpertId) && markerIds.Contains(x.MarkerId));

            foreach (var item in expertInMarkerRows)
            {
                expertInMarkerTableAdapter.Delete(item.Id, item.ExpertId, item.MarkerId);
            }
        }

        public void DeleteMarkerInRegion(int? markerId, int? regionId)
        {
            if (!markerId.HasValue && !regionId.HasValue) return;

            List<int> markerIds = new List<int>();
            List<int> regionIds = new List<int>();

            var markerInRegionTableAdapter = 
                new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();

            if (!markerId.HasValue)
            {
                markerIds = markerInRegionTableAdapter.GetData()
                    .Where(m => m.RegionId == regionId.Value).Select(x => x.MarkerId).ToList();
            }
            else
                markerIds.Add(markerId.Value);

            if (!regionId.HasValue)
            {
                regionIds = markerInRegionTableAdapter.GetData()
                    .Where(x => x.MarkerId == markerId.Value).Select(x => x.RegionId).ToList();
            }
            else
                regionIds.Add(regionId.Value);

            var markerInRegionRows = markerInRegionTableAdapter.GetData()
                .Where(x => markerIds.Contains(x.MarkerId) && regionIds.Contains(x.RegionId));

            foreach (var item in markerInRegionRows)
            {
                markerInRegionTableAdapter.Delete(item.Id, item.MarkerId, item.RegionId);
            }
        }

        public void DeleteRegion(ExpertMap.Models.Region region)
        {
            var regionTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.RegionTableAdapter();
            var regionRow = regionTableAdapter.GetData().Where(x => x.Id == region.RegionId).FirstOrDefault();

            var regionPointsTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.RegionPointsTableAdapter();
            var regionPointsRows = regionPointsTableAdapter.GetData().Where(x => x.RegionId == regionRow.Id);

            foreach (var item in regionPointsRows)
            {
                regionPointsTableAdapter.Delete(item.RegionId, item.X, item.Y, item.Number);
            }

            var markerInRegionTableAdapter =
                     new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();

            var markerIds = markerInRegionTableAdapter.GetData()
                .Where(x => x.RegionId == regionRow.Id).Select(x => x.MarkerId).ToList();

            DeleteMarkerInRegion(null, regionRow.Id);

            if (ExpertMap.Tools.ExpertMapOptions.CurrentOptions.DeleteMarkerByRegion)
            {
                markerIds.ForEach(DeleteMarker);
            }

            regionTableAdapter.Delete(regionRow.Id, regionRow.Name);
        }

        public void InsertMarkerInRegion(int markerId, int regionId)
        {
            var markerInRegionTableAdapter =
                new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();

            markerInRegionTableAdapter.Insert(markerId, regionId);
        }

        public ExpertMap.DataModels.ExpertMapDataSet.MarkerRow GetMarkerRow(string imageName, int x, int y)
        {
            var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();

            var markerRow = markerTableAdapter.GetData().Where(m =>
                m.X == x &&
                m.Y == y &&
                m.ImageName == imageName).FirstOrDefault();

            return markerRow;
        }

        public ExpertMap.DataModels.ExpertMapDataSet.MarkerRow GetMarkerRow(Marker marker)
        {
            return GetMarkerRow(marker.ImageName, marker.DefaultLocation.X, marker.DefaultLocation.Y);
        }

        public void UpdateMarker(ExpertMap.DataModels.ExpertMapDataSet.MarkerRow markerRow)
        {
            var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();
            markerTableAdapter.Update(markerRow);
        }

        public void InsertExpertInMarker(int expertId,int markerId)
        {
            var expertInMarkerTableAdapter = 
                new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertInMarkerTableAdapter();

            expertInMarkerTableAdapter.Insert(expertId, markerId);
        }

        private void InitConnectionString()
        {
            _connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", DataBaseManager.CurrentDataBasePath);
            ExpertMap.Properties.Settings.Default["ExpertMapDbConnectionString"] = _connectionString;       
        }

        public static void Reset()
        {
            _instance = null;
        }
    }
}
