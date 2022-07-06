using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Dto
{
    public class MultipleChooseDto
    {
        public MultipleChooseQuestion MultipleChooseQuestion { get; set; }
        public List<MultipleChooseQuestionOption> MultipleChooseQuestionOptions { get; set; }
    }
}
