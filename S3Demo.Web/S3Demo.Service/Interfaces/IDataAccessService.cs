using S3Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace S3Demo.Service.Interfaces
{
    public partial interface IDataAccessService
    {
        List<Reading> GetReadings(int buildingId, int objectId, int dataFieldId);
    }
}
