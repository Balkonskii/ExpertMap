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

namespace ExpertMap.DbTools
{
    public class DbHelper
    {
        private static DbHelper _instance;
        private string _connectionString = string.Empty;

        public ExpertMapDataSet ExpertMapDataSet { get; set; }

        private DbHelper()
        {
            _connectionString = Path.Combine(Application.StartupPath, "ExpertMapDb.accdb");
            Init();
        }

        private DbHelper(string connectionString)
        {
            _connectionString = connectionString;
            Init();
        }

        public static DbHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbHelper(Properties.Settings.Default.ExpertMapDbConnectionString);                
            }

            return _instance;
        }

        public static DbHelper GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DbHelper(connectionString);
            }

            return _instance;
        }

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
                throw exc;
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

        public void DeleteMarker(string imageName, int x, int y)
        {
            var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();

            var markerRow = markerTableAdapter.GetData().Where(m =>
                m.X == x &&
                m.Y == y &&
                m.ImageName == imageName).FirstOrDefault();

            var expertInMarkerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.ExpertInMarkerTableAdapter();
            var expertInMarkerRows = expertInMarkerTableAdapter.GetData().Where(m => m.MarkerId == markerRow.Id);

            foreach (ExpertMap.DataModels.ExpertMapDataSet.ExpertInMarkerRow item in expertInMarkerRows)
            {
                expertInMarkerTableAdapter.Delete(item.Id, item.ExpertId, item.MarkerId);
            }

            var markerInRegionTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();
            var markerInRegionRows = markerInRegionTableAdapter.GetData().Where(m => m.MarkerId == markerRow.Id);

            foreach (ExpertMap.DataModels.ExpertMapDataSet.MarkerInRegionRow item in markerInRegionRows)
            {
                markerInRegionTableAdapter.Delete(item.Id, item.MarkerId, item.RegionId);
            }
            
            markerTableAdapter.Delete(markerRow.Id, markerRow.X, markerRow.Y);
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

            if (ExpertMap.Tools.ExpertMapOptions.CurrentOptions.DeleteMarkerByRegion)
            {
                var markerInRegionTableAdapter = 
                    new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerInRegionTableAdapter();

                var markerIds = markerInRegionTableAdapter.GetData().Where(x => x.RegionId == regionRow.Id).Select(x => x.MarkerId);
                var markerTableAdapter = new ExpertMap.DataModels.ExpertMapDataSetTableAdapters.MarkerTableAdapter();

                var markerRows = markerTableAdapter.GetData().Where(x => markerIds.Contains(x.Id));

                foreach (var item in markerRows)
                {
                    this.DeleteMarker(item.ImageName, item.X, item.Y);
                }
            }

            regionTableAdapter.Delete(regionRow.Id, regionRow.Name);
        }
    }
}
