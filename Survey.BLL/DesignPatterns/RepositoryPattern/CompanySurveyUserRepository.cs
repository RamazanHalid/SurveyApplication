using Survey.BLL.DesignPatterns.BaseRep;
using Survey.DAL.ContextClasses;
using Survey.ENTITIES.Entity;
using System.Collections.Generic;

namespace Survey.BLL.DesignPatterns
{
    public class CompanySurveyUserRepository : BaseRepository<CompanySurveyUser, SurveyContext>
    {
        public void AddWithRange(List<CompanySurveyUser> companySurveyUsers)
        {
            using (var context = new SurveyContext())
            {
                context.CompanySurveyUsers.AddRange(companySurveyUsers);
                context.SaveChanges();
            }
        }
    }
}
