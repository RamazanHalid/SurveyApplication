using Survey.ENTITIES.Entity;
using System.Data.Entity;

namespace Survey.DAL.ContextClasses
{
    public class SurveyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<CompanySurvey> CompanySurveys { get; set; }
        public DbSet<MultipleChooseQuestion> MultipleChooseQuestions { get; set; }
        public DbSet<MultipleChooseQuestionAnswer> MultipleChooseQuestionAnswers { get; set; }
        public DbSet<MultipleChooseQuestionOption> MultipleChooseQuestionOptions { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }
        public DbSet<TextQuestionAnswer> TextQuestionAnswers { get; set; }
        public DbSet<CompanySurveyUser> CompanySurveyUsers { get; set; }

        
    }


}
