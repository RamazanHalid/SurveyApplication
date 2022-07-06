using Survey.BLL.DesignPatterns.BaseRep;
using Survey.DAL.ContextClasses;
using Survey.ENTITIES.Entity;
using System.Collections.Generic;

namespace Survey.BLL.DesignPatterns
{
    public class TextQuestionRepository : BaseRepository<TextQuestion, SurveyContext>
    {
        public void AddWithRange(List<TextQuestion> textQuestions)
        {
            using(var context = new SurveyContext())
            {
                context.TextQuestions.AddRange(textQuestions);
                context.SaveChanges();
            }
        }
    }
}
