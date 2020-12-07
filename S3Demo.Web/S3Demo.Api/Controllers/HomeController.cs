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
    public class HomeController : ControllerBase
    {

        private readonly IDataAccessService _dataAccessService;

        public HomeController(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        [HttpGet("{buildingId}/{objectId}/{dataFieldId}")]
        public ActionResult< IEnumerable<Reading>> Get(int buildingId,int objectId,int dataFieldId)
        {
            var data = _dataAccessService.GetReadings(buildingId, objectId, dataFieldId);
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
