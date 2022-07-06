using Core.Utilities.Results;
using Newtonsoft.Json;
using Survey.BLL.DesignPatterns;
using Survey.ENTITIES.Entity;
using Survey.MMVCUI.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CompanySurveysController : Controller
    {
        // GET: Admin/CompanySurveys
        CompanySurveyRepository _companySurveyRepository = new CompanySurveyRepository();
        TextQuestionRepository _textQuestionRepository = new TextQuestionRepository();
        CompanyUserRepository _companyUserRepository = new CompanyUserRepository();
        CompanySurveyUserRepository _companySurveyUserRepository = new CompanySurveyUserRepository();
        MultipleChooseQuestionRepository _multipleChooseQuestionRepository = new MultipleChooseQuestionRepository();
        MultipleChooseQuestionOptionRepository _multipleChooseQuestionOptionRepository = new MultipleChooseQuestionOptionRepository();
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

        [HttpPost]
        public ActionResult Add(CompanySurveyModel companySurveyModel)
        {
            companySurveyModel.SurveyInfo.CreatedDate = DateTime.Now;
            var companySurvey = _companySurveyRepository.AddWithReturnEntity(companySurveyModel.SurveyInfo);
            List<TextQuestion> textQuestions = new List<TextQuestion>();
            companySurveyModel.TextQuestions.ForEach(x => textQuestions.Add(new TextQuestion { Description = x, CompanySurveyId = companySurvey.Id }));
            _textQuestionRepository.AddWithRange(textQuestions);

            List<MultipleChooseQuestionOption> multipleChooseQuestionOptions = new List<MultipleChooseQuestionOption>();
            foreach (var item in companySurveyModel.MultipleChooseQuestions)
            {
                var addedQuestion = _multipleChooseQuestionRepository.AddWitnReturn(
                    new MultipleChooseQuestion { Description = item.Question, CompanySurveyId = companySurvey.Id });
                item.Options.ForEach(w => multipleChooseQuestionOptions.Add(new MultipleChooseQuestionOption { Description = w, MultipleChooseQuestionId = addedQuestion.Id }));
            }

            var allUserBelongsTheCompany = _companyUserRepository.GetAll(x => x.CompanyId == companySurveyModel.SurveyInfo.CompanyId);
            _multipleChooseQuestionOptionRepository.AddWithRange(multipleChooseQuestionOptions);

            //
            List<CompanySurveyUser> companySurveyUsers = new List<CompanySurveyUser>();
            allUserBelongsTheCompany.ForEach(x => companySurveyUsers.Add(new CompanySurveyUser { CompanySurveyId = companySurvey.Id, CompanyUserId = x.Id, IsComplete = false }));
            _companySurveyUserRepository.AddWithRange(companySurveyUsers);

            return Json(JsonConvert.SerializeObject(new SuccessResult("İşlem Başarı ile tamamlandı!")), JsonRequestBehavior.AllowGet);
        }
    }
}