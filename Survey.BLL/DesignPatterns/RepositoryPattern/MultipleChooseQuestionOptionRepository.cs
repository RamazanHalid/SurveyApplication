using Survey.BLL.DesignPatterns.BaseRep;
using Survey.DAL.ContextClasses;
using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BLL.DesignPatterns
{
    public class MultipleChooseQuestionOptionRepository : BaseRepository<MultipleChooseQuestionOption, SurveyContext>
    {
        public void AddWithRange(List<MultipleChooseQuestionOption> multipleChooseQuestionOptions)
        {
            using (var context = new SurveyContext())
            {
                context.MultipleChooseQuestionOptions.AddRange(multipleChooseQuestionOptions);
                context.SaveChanges();
            }
        }
    }
}
