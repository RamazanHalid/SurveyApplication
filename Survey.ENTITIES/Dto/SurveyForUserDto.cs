using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Dto
{
    public class SurveyForUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int QuestionCount { get; set; }
        public bool IsComplete { get; set; }
    }
}
