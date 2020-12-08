using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetReadingData(int buildingId,int objectId,int dataFieldId,DateTime startDate,DateTime endDate)
        {
            return Json(new Repository.Repository(ConfigurationManager.ConnectionStrings["connString"].ConnectionString).GetReadingData(buildingId,objectId,dataFieldId, startDate, endDate),JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetBuildings()
        {
            return Json(new Repository.Repository(ConfigurationManager.ConnectionStrings["connString"].ConnectionString).GetBuildings(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetObjects()
        {
            return Json(new Repository.Repository(ConfigurationManager.ConnectionStrings["connString"].ConnectionString).GetObjects(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetDataFields()
        {
            return Json(new Repository.Repository(ConfigurationManager.ConnectionStrings["connString"].ConnectionString).GetDataFields(), JsonRequestBehavior.AllowGet);
        }
    }
}