using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.ENTITIES.Dto
{
    public class UserSurveyDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int CompletedSurveyCount { get; set; }
        public int UncompletedSurveyCount { get; set; }
        public int TotalSurveyCount { get; set; }
        public string City { get; set; }
    }
}
