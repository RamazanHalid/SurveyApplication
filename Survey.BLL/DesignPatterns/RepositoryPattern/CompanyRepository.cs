using Survey.BLL.DesignPatterns.BaseRep;
using Survey.DAL.ContextClasses;
using Survey.ENTITIES.Dto;
using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.BLL.DesignPatterns
{
    public class CompanyRepository : BaseRepository<Company, SurveyContext>
    {
        public List<CompanyDto> GetAllWithInclude(Expression<Func<CompanyDto, bool>> filter = null)
        {

            using (var context = new SurveyContext())
            {
                var result = from company in context.Companies
                             select new CompanyDto()
                             {
                                 Id = company.Id,
                                 CreatedDate = company.CreatedDate,
                                 Email = company.Email,
                                 Name = company.Name,
                                 PersonCount = context.CompanyUsers.Count(x => x.CompanyId == company.Id),
                                 SurveyCount = context.CompanySurveys.Count(x => x.CompanyId == company.Id)
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
