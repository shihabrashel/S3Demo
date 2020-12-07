using S3Demo.Model;
using S3Demo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace S3Demo.Service.Services
{
    public partial class DataAccessService: IDataAccessService
    {
        private readonly string _connectionString;
        public DataAccessService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Reading> GetReadings(int buildingId, int objectId, int dataFieldId)
        {
            throw new NotImplementedException();
        }
    }
}
