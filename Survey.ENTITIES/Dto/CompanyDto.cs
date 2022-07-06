using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public int SurveyCount { get; set; }
    }
}
