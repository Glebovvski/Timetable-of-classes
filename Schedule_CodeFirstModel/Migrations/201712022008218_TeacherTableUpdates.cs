namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherTableUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "Subject_Id" });
            RenameColumn(table: "dbo.Teachers", name: "Subject_Id", newName: "SubjectId");
            AlterColumn("dbo.Teachers", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "SubjectId");
            AddForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "SubjectId" });
            AlterColumn("dbo.Teachers", "SubjectId", c => c.Int());
            RenameColumn(table: "dbo.Teachers", name: "SubjectId", newName: "Subject_Id");
            CreateIndex("dbo.Teachers", "Subject_Id");
            AddForeignKey("dbo.Teachers", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
