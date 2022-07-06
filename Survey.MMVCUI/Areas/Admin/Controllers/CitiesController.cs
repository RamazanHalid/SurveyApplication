using Newtonsoft.Json;
using Survey.BLL.DesignPatterns;
using Survey.ENTITIES.Entity;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Admin/Cities

        CityRepository _cityRepository = new CityRepository();
        public ActionResult Index()
        {
            return View(_cityRepository.GetAll());
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var jsonCities = JsonConvert.SerializeObject(_cityRepository.GetAll());
            return Json(jsonCities, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
                return View(new City());
            return View(_cityRepository.Get(c => c.Id == id));
        }
        [HttpPost]
        public ActionResult Add(City city)
        {
            if (city.Id > 0)
                _cityRepository.Update(city);
            else
                _cityRepository.Add(city);
            return RedirectToAction("Index");
        }
    }
}