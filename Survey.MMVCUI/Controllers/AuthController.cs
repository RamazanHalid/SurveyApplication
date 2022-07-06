using Core.Utilities.Security.Hashing;
using FluentValidation.Results;
using Survey.BLL.DesignPatterns;
using Survey.COMMON.Validation;
using Survey.ENTITIES.Dto;
using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Survey.MMVCUI.Controllers
{
    public class AuthController : Controller
    {

        // GET: Auth
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly CompanyUserRepository _companyUserRepository = new CompanyUserRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LoginAsAdmin()
        {
            return View(new LoginDto());
        }
        [HttpPost]
        public ActionResult LoginAsAdmin(LoginDto loginDto)
        {
            var user = _userRepository.Get(u => (u.Name + u.SurName).ToLower() == loginDto.UserName.ToLower());
            if (user == null)
            {
                ViewData["Message"] = "Kullanıcı Adı veya Şifre Yanlış!";
                return View(loginDto);
            }
            var res = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!res)
            {
                ViewData["Message"] = "Kullanıcı Adı veya Şifre Yanlış!";
                return View(loginDto);
            }
            FormsAuthentication.SetAuthCookie(loginDto.UserName, false);
            Session["AdminUserName"] = loginDto.UserName;
            return Redirect("/Admin/Companies/Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationAsAdmin registrationAsAdmin)
        {
            RegisterValidator validationRules = new RegisterValidator();
            ValidationResult validationResult = validationRules.Validate(registrationAsAdmin);
            if (!validationResult.IsValid)
            {
                ViewData["Message"] = validationResult.Errors[0].ErrorMessage;
                return View();
            }
            if (registrationAsAdmin.Password != registrationAsAdmin.PasswordAgain)
            {
                ViewData["Message"] = "Şifreleriniz eşleşmiyor!";
                return View();
            }
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(registrationAsAdmin.Password, out passwordHash, out passwordSalt);
            _userRepository.Add(new User
            {
                Name = registrationAsAdmin.Name,
                Email = registrationAsAdmin.Email,
                IsAdmin = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                SurName = registrationAsAdmin.Surname
            });

            return RedirectToAction("LoginAsAdmin");
        }
        [HttpGet]
        public ActionResult LoginAsUser()
        {
            return View(new LoginDto());
        }
        [HttpPost]
        public ActionResult LoginAsUser(LoginDto loginDto)
        {
            var user = _companyUserRepository.Get(u => (u.FirstName + u.LastName).ToLower() == loginDto.UserName.ToLower());
            if (user == null)
            {
                ViewData["Message"] = "Kullanıcı Adı veya Şifre Yanlış!";
                return View(loginDto);
            }
            var res = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!res)
            {
                ViewData["Message"] = "Kullanıcı Adı veya Şifre Yanlış!";
                return View(loginDto);
            }
            FormsAuthentication.SetAuthCookie(loginDto.UserName, false);
            Session["UserName"] = loginDto.UserName;
            Session["UserId"] = user.Id;
            return Redirect("/User/Surveys/Index");
        }
    }
}