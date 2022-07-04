using Newtonsoft.Json;
using Survey.BLL.DesignPatterns;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Admin/Cities

        CityRepository _cityRepository = new CityRepository();
        [HttpGet]
        public ActionResult GetAll()
        {
            var jsonCities = JsonConvert.SerializeObject(_cityRepository.GetAll());
            return Json(jsonCities, JsonRequestBehavior.AllowGet);
        }
    }
}