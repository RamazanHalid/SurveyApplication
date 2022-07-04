using Survey.BLL.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CompanySurveysController : Controller
    {
        // GET: Admin/CompanySurveys
        CompanySurveyRepository _companySurveyRepository = new CompanySurveyRepository();
        public ActionResult GetAll(int id)
        {
            var companySurvey = _companySurveyRepository.GetAll(s => s.CompanyId == id);
            return View(companySurvey);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            return View();
        }
    }
}