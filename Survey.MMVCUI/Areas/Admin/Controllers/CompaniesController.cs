using Core.Utilities.Results;
using Newtonsoft.Json;
using Survey.BLL.DesignPatterns;
using Survey.ENTITIES.Entity;
using Survey.MMVCUI.Models;
using System;
using System.Web.Mvc;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Admin/Companies
        CompanyRepository _companyRepository = new CompanyRepository();
        CityRepository _cityRepository = new CityRepository();
        CompanyUserRepository _companyUserRepository = new CompanyUserRepository();
        public ActionResult Index()
        {
            var companies = _companyRepository.GetAll();
            return View(companies);
        }

        [HttpGet]
        public ActionResult AddAndEdit(int id = 0)
        {
            var cities = _cityRepository.GetAll();
            if (id > 0)
            {
                var company = _companyRepository.Get(c => c.Id == id);
                return View(new CompanyPageModel() { Cities = cities, Company = company });
            }
            return View(new CompanyPageModel() { Cities = cities, Company = new Company() });
        }
        [HttpPost]
        public ActionResult AddAndEdit(Company company)
        {
            if (company.Id > 0)
            {
                var currentCompany = _companyRepository.Get(c => c.Id == company.Id);
                company.CreatedDate = currentCompany.CreatedDate;
                _companyRepository.Update(company);
            }
            else
            {
                company.CreatedDate = DateTime.Now;
                _companyRepository.Add(company);
            }
            return RedirectToAction("Index");
        }
        //Delete selected company by id
        public ActionResult Delete(int id)
        {
            var deletedCompany = _companyRepository.Get(c => c.Id == id);
            _companyRepository.Delete(deletedCompany);
            return RedirectToAction("Index");
        }
        //Get details about selected company by id
        public ActionResult Details(int id)
        {
            var currentCompany = _companyRepository.Get(c => c.Id == id);
            return View(currentCompany);
        } 
      
    }
}