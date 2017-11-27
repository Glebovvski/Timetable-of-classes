namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryingFixIT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "Subject_Id" });
            AlterColumn("dbo.Subjects", "SubjectName", c => c.String());
            AlterColumn("dbo.Teachers", "Subject_Id", c => c.Int());
            CreateIndex("dbo.Teachers", "Subject_Id");
            AddForeignKey("dbo.Teachers", "Subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "Subject_Id" });
            AlterColumn("dbo.Teachers", "Subject_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "SubjectName", c => c.String(nullable: false));
            CreateIndex("dbo.Teachers", "Subject_Id");
            AddForeignKey("dbo.Teachers", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
