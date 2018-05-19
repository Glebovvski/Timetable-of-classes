namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookkeepings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SumToPay = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        StudentStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.StudentStatus", t => t.StudentStatusId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.StudentStatusId);
            
            CreateTable(
                "dbo.StudentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scholarship = c.Boolean(nullable: false),
                        SingleChild = c.Boolean(nullable: false),
                        AverageScoreEqualsOrLessThanNeeded = c.Boolean(nullable: false),
                        Orphan = c.Boolean(nullable: false),
                        DisabledPerson = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookkeepings", "StudentStatusId", "dbo.StudentStatus");
            DropForeignKey("dbo.Bookkeepings", "StudentId", "dbo.Students");
            DropIndex("dbo.Bookkeepings", new[] { "StudentStatusId" });
            DropIndex("dbo.Bookkeepings", new[] { "StudentId" });
            DropTable("dbo.StudentStatus");
            DropTable("dbo.Bookkeepings");
        }
    }
}
