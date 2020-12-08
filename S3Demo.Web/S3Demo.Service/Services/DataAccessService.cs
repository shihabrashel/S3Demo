using S3Demo.Model;
using S3Demo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace S3Demo.Service.Services
{
    public partial class DataAccessService : IDataAccessService
    {
        private readonly string _connectionString;
        public DataAccessService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual List<Reading> GetReadingData(int buildingId, int objectId, int dataFieldId, DateTime startDate, DateTime endDate)
        {
            var readingData = new List<Reading>();
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var sqlCommand = new SqlCommand("dbo.GetReadingData", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@buildingId", buildingId);
                sqlCommand.Parameters.AddWithValue("@objectId", objectId);
                sqlCommand.Parameters.AddWithValue("@dataFieldId", dataFieldId);
                sqlCommand.Parameters.AddWithValue("@startDate", startDate);
                sqlCommand.Parameters.AddWithValue("@endDate", endDate);
                sqlCommand.CommandTimeout = 1000;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        readingData.Add(new Reading
                        {
                            Value = sqlReader["Value"] == null ? 0 : double.Parse(sqlReader["Value"].ToString()),
                            Timestamp = sqlReader["Timestamp"] == null ? "00:00" : sqlReader["Timestamp"].ToString()
                        });
                    }
                }
            }
            return readingData;
        }
        public virtual List<Building> GetBuildings()
        {
            var buildingData = new List<Building>();
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var sqlCommand = new SqlCommand("dbo.GetBuildingData", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 1000;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        buildingData.Add(new Building
                        {
                            Id = sqlReader["Id"] == null ? 0 : int.Parse(sqlReader["Id"].ToString()),
                            Name = sqlReader["Name"] == null ? string.Empty : sqlReader["Name"].ToString()
                        });
                    }
                }
            }
            return buildingData;
        }
        public virtual List<Model.Object> GetObjects()
        {
            var objectData = new List<Model.Object>();
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var sqlCommand = new SqlCommand("dbo.GetObjectData", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 1000;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        objectData.Add(new Model.Object
                        {
                            Id = sqlReader["Id"] == null ? 0 : int.Parse(sqlReader["Id"].ToString()),
                            Name = sqlReader["Name"] == null ? string.Empty : sqlReader["Name"].ToString()
                        });
                    }
                }
            }
            return objectData;
        }
        public virtual List<DataField> GetDataFields()
        {
            var dataFields = new List<DataField>();
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var sqlCommand = new SqlCommand("dbo.GetDataFields", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 1000;
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        dataFields.Add(new DataField
                        {
                            Id = sqlReader["Id"] == null ? 0 : int.Parse(sqlReader["Id"].ToString()),
                            Name = sqlReader["Name"] == null ? string.Empty : sqlReader["Name"].ToString()
                        });
                    }
                }
            }
            return dataFields;
        }
    }
}
