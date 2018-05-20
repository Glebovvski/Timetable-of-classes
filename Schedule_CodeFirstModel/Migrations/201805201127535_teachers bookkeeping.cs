namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachersbookkeeping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeachersBookkeepings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        Hours = c.Int(nullable: false),
                        Experience_months = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        Taxes = c.Double(nullable: false),
                        Bonus = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeachersBookkeepings", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeachersBookkeepings", new[] { "TeacherId" });
            DropTable("dbo.TeachersBookkeepings");
        }
    }
}
