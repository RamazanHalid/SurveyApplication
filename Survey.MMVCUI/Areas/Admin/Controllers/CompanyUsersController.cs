using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using FluentValidation.Results;
using Newtonsoft.Json;
using Survey.BLL.DesignPatterns;
using Survey.COMMON.Validation;
using Survey.ENTITIES.Entity;
using System;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CompanyUsersController : Controller
    {
        // GET: Admin/CompanyUsers 
        CompanyUserRepository _companyUserRepository = new CompanyUserRepository();

        //Users operations page
        public ActionResult Operations(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllByCompanyId(int id)
        {
            var companyUsers = _companyUserRepository.GetAllWithInclude(c => c.CompanyId == id);
            var jsonCompanyUsers = JsonConvert.SerializeObject(companyUsers);
            return Json(jsonCompanyUsers, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(CompanyUser companyUser)
        {
            CompanyUserValidator companyUserValidator = new CompanyUserValidator();
            ValidationResult validationResult = companyUserValidator.Validate(companyUser);
            if (!validationResult.IsValid)
            {
                //First error validation message
                var jsonValidationResult = JsonConvert.SerializeObject(new ErrorResult(validationResult.Errors[0].ErrorMessage));
                return Json(jsonValidationResult, JsonRequestBehavior.AllowGet);
            }
            companyUser.CreatedDate = DateTime.Now;
            //User password is his/her birthday such 10121997 for 10.12.1997
            string password = companyUser.DateOfBirth.ToString().Split(' ')[0].Replace(".", "");
            //Hashing user password for security
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            companyUser.PasswordHash = passwordHash;
            companyUser.PasswordSalt = passwordSalt;
            //Add operation
            _companyUserRepository.Add(companyUser);
            //return result
            var jsonResult = JsonConvert.SerializeObject(new SuccessResult("Kullanıcı başarılı bir şekilde eklendi!"));
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            _companyUserRepository.Delete(_companyUserRepository.Get(u => u.Id == id));
            var jsonResult = JsonConvert.SerializeObject(new SuccessResult("Kullanıcı başarı ile silindi"));
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}