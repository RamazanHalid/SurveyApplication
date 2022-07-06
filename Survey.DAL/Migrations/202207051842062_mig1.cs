namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanySurveyUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanySurveyId = c.Int(nullable: false),
                        CompanyUserId = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanySurveyUsers");
        }
    }
}
