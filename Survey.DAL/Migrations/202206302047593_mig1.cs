namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Companies", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "CityId");
            AddForeignKey("dbo.Companies", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            DropColumn("dbo.Companies", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "City", c => c.Int(nullable: false));
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropColumn("dbo.Companies", "CityId");
            DropTable("dbo.Cities");
        }
    }
}
