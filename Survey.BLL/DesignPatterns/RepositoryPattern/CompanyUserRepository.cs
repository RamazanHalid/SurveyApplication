
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
    public class CompanyUserRepository : BaseRepository<CompanyUser, SurveyContext>
    {
        public List<UserSurveyDto> GetAllWithInclude(Expression<Func<UserSurveyDto, bool>> filter = null)
        {

            using (var context = new SurveyContext())
            {
                var result = from companyUser in context.CompanyUsers
                             join city in context.Cities on companyUser.CityId equals city.Id
                             select new UserSurveyDto()
                             {
                                 CellPhone = companyUser.CellPhone,
                                 Id = companyUser.Id,
                                 CreatedDate = companyUser.CreatedDate,
                                 DateOfBirth = companyUser.DateOfBirth,
                                 Email = companyUser.Email,
                                 Title = companyUser.Title,
                                 FirstName = companyUser.FirstName,
                                 LastName = companyUser.LastName,
                                 CompletedSurveyCount = context.CompanySurveyUsers.Count(x => x.CompanyUserId == companyUser.Id && x.IsComplete == true),
                                 UncompletedSurveyCount = context.CompanySurveyUsers.Count(x => x.CompanyUserId == companyUser.Id && x.IsComplete == false),
                                 TotalSurveyCount = context.CompanySurveyUsers.Count(x => x.CompanyUserId == companyUser.Id),
                                 CompanyId = companyUser.CompanyId,
                                 City = city.Name
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
