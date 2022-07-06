using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Entity
{
    public class TextQuestion
    {
        public int Id { get; set; }
        public int CompanySurveyId { get; set; }
        public string Description { get; set; }
    }
}
