using S3Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace S3Demo.Service.Interfaces
{
    public partial interface IDataAccessService
    {
        List<Reading> GetReadingData(int buildingId, int objectId, int dataFieldId, DateTime startDate, DateTime endDate);
        List<Building> GetBuildings();
        List<Model.Object> GetObjects();
        List<DataField> GetDataFields();
    }
}
