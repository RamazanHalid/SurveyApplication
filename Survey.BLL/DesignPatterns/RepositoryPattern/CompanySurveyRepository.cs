using Survey.BLL.DesignPatterns.BaseRep;
using Survey.DAL.ContextClasses;
using Survey.ENTITIES.Dto;
using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.BLL.DesignPatterns
{
    public class CompanySurveyRepository : BaseRepository<CompanySurvey, SurveyContext>
    {
        public CompanySurvey AddWithReturnEntity(CompanySurvey companySurvey)
        {
            using (var context = new SurveyContext())
            {
                var addedEntity = context.Entry(companySurvey);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return companySurvey;
            }
        }
        public List<SurveyForUserDto> GetAllForUser(int usrId, Expression<Func<SurveyForUserDto, bool>> filter = null)
        {
            using (var context = new SurveyContext())
            {
                var result = from companySurvey in context.CompanySurveys
                             join companySurveyUser in context.CompanySurveyUsers on companySurvey.Id equals companySurveyUser.CompanySurveyId
                             where companySurveyUser.CompanyUserId == usrId
                             select new SurveyForUserDto()
                             {
                                 EndDate = companySurvey.EndDate,
                                 Id = companySurvey.Id,
                                 IsComplete = companySurveyUser.IsComplete,
                                 Name = companySurvey.Name,
                                 QuestionCount =
                                 context.MultipleChooseQuestions.Count(x => x.CompanySurveyId == companySurvey.Id)
                                 + context.TextQuestions.Count(x => x.CompanySurveyId == companySurvey.Id),
                                 StartDate = companySurvey.StartDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
