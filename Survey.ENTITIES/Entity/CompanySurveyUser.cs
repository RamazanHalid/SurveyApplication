using System;

namespace Survey.ENTITIES.Entity
{
    public class CompanySurveyUser
    {
        public int Id { get; set; }
        public int CompanySurveyId { get; set; }
        public int CompanyUserId{ get; set; }
        public bool IsComplete{ get; set; }
    }
}
