using Newtonsoft.Json;
using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Admin/Cities
        [HttpGet]
        public ActionResult GetAll()
        {
            List<City> cities = new List<City>() { new City() { Id=1,Name="Antalya"} , new City() { Id = 2, Name = "Izmir" } };
            return this.Json(JsonConvert.SerializeObject(cities), JsonRequestBehavior.AllowGet);
        }
    }
}