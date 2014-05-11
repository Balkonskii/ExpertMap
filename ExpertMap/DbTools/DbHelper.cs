using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertMap.DataModels;
using System.Data;
using System.Data.OleDb;
using System.Drawing;

namespace ExpertMap.DbTools
{
    public class DbHelper
    {
        private static DbHelper _instance;
        private string _connectionString = string.Empty;

        public ExpertMapDataSet ExpertMapDataSet { get; set; }

        private DbHelper()
        {
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

        public void SaveMarker()
        {
 
        }
    }
}
