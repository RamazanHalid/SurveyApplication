using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Entity
{
    public class TextQuestionAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int CompanyUserId { get; set; }
        public int CompanySurveyId { get; set; }
        public DateTime AnsweredDate{ get; set; }


    }
}
