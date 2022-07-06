using Newtonsoft.Json;
using Survey.BLL.DesignPatterns;
using Survey.ENTITIES.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.User.Controllers
{
    public class SurveysController : Controller
    {
        private readonly CompanySurveyRepository _companySurveyRepository = new CompanySurveyRepository();
        private readonly TextQuestionRepository _textQuestionRepository = new TextQuestionRepository();
        private readonly MultipleChooseQuestionRepository _multipleChooseQuestionRepository = new MultipleChooseQuestionRepository();
        // GET: User/Surveys
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            var re = _companySurveyRepository.GetAllForUser(id);
            if (re == null)
                return View(new List<SurveyForUserDto>());
            return View(re);
        }
        public ActionResult DoQuestions(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllTextQuestions(int id)
        {
            var jsonRes = JsonConvert.SerializeObject(_textQuestionRepository.GetAll(x => x.CompanySurveyId == id));
            return Json(jsonRes, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllMultiChooseQuestions(int surveyId)
        {
            var jsonRes = JsonConvert.SerializeObject(_multipleChooseQuestionRepository.GetAllWithOptions(x => x.MultipleChooseQuestion.CompanySurveyId == surveyId));
            return Json(jsonRes, JsonRequestBehavior.AllowGet);
        }



    }
}