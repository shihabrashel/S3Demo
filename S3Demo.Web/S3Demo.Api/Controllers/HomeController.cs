using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using S3Demo.Model;
using S3Demo.Service.Interfaces;

namespace S3Demo.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/home")]
    public partial class HomeController : ControllerBase
    {

        private readonly IDataAccessService _dataAccessService;

        public HomeController(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        [HttpGet("{buildingId}/{objectId}/{dataFieldId}/{startDate}/{endDate}")]
        public virtual ActionResult< IEnumerable<Reading>> Get(int buildingId,int objectId,int dataFieldId,DateTime startDate,DateTime endDate)
        {
            var data = _dataAccessService.GetReadingData(buildingId, objectId, dataFieldId, startDate, endDate);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpGet("buildings")]
        public virtual ActionResult<IEnumerable<Building>> GetBuildings()
        {
            var data = _dataAccessService.GetBuildings();
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpGet("objects")]
        public virtual ActionResult<IEnumerable<Building>> GetObjects()
        {
            var data = _dataAccessService.GetObjects();
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpGet("datafields")]
        public virtual ActionResult<IEnumerable<Building>> GetDataFields()
        {
            var data = _dataAccessService.GetDataFields();
            if (data != null)
                return Ok(data);
            return NotFound();
        }
    }
}
