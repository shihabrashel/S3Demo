using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public class Repository
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Reading> GetReadingData(int buildingId, int objectId, int dataFieldId,DateTime startDate,DateTime endDate)
        {
            try
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
                                Value = sqlReader["Value"] == null ? 0 : int.Parse(sqlReader["Value"].ToString()),
                                Timestamp = sqlReader["Timestamp"] == null ?new DateTime() : DateTime.Parse(sqlReader["Timestamp"].ToString())
                            });
                        }
                    }
                }
                return readingData;
            }
            catch (Exception ex)
            {
                return new List<Reading>();
            }
        }
        public List<Building> GetBuildings()
        {
            try
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
            catch (Exception ex)
            {
                return new List<Building>();
            }
        }
        public List<Models.Object> GetObjects()
        {
            
            try
            {
                var objectData = new List<Models.Object>();
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
                            objectData.Add(new Models.Object
                            {
                                Id = sqlReader["Id"] == null ? 0 : int.Parse(sqlReader["Id"].ToString()),
                                Name = sqlReader["Name"] == null ? string.Empty : sqlReader["Name"].ToString()
                            });
                        }
                    }
                }
                return objectData;
            }
            catch (Exception ex)
            {
                return new List<Models.Object>();
            }
        }
        public List<DataField> GetDataFields()
        {
            try
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
            catch (Exception ex)
            {
                return new List<DataField>();
            }
        }
    }
}