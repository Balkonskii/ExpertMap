using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertMap.DataModels;
using System.Data;
using System.Data.OleDb;

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
                _instance = new DbHelper();                
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

        private void Init()
        {
            ExpertMapDataSet = new ExpertMapDataSet();
            FillDataSet(ExpertMapDataSet);
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

                table.Load(reader);
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
    }
}
