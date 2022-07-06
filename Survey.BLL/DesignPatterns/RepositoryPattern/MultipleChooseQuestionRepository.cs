using Survey.BLL.DesignPatterns.BaseRep;
using Survey.DAL.ContextClasses;
using Survey.ENTITIES.Dto;
using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BLL.DesignPatterns
{
    public class MultipleChooseQuestionRepository : BaseRepository<MultipleChooseQuestion, SurveyContext>
    {
        public MultipleChooseQuestion AddWitnReturn(MultipleChooseQuestion multipleChooseQuestion)
        {
            using (var context = new SurveyContext())
            {
                var addedEntity = context.Entry(multipleChooseQuestion);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return multipleChooseQuestion;
            }
        }
        public List<MultipleChooseDto> GetAllWithOptions(Expression<Func<MultipleChooseDto, bool>> filter = null)
        {
            using (var context = new SurveyContext())
            {
                var result = from m in context.MultipleChooseQuestions
                             join mo in context.MultipleChooseQuestionOptions on m.Id equals mo.MultipleChooseQuestionId
                             select new MultipleChooseDto
                             {
                                 MultipleChooseQuestion = m,
                                 MultipleChooseQuestionOptions = context.MultipleChooseQuestionOptions.Where(x => x.MultipleChooseQuestionId == m.Id).ToList(),
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
