namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastScheduleModelMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Schedules", new[] { "Subject_Id" });
            RenameColumn(table: "dbo.Schedules", name: "Subject_Id", newName: "SubjectId");
            AlterColumn("dbo.Schedules", "SubjectId", c => c.Int(nullable: true));
            CreateIndex("dbo.Schedules", "SubjectId");
            AddForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Schedules", new[] { "SubjectId" });
            AlterColumn("dbo.Schedules", "SubjectId", c => c.Int());
            RenameColumn(table: "dbo.Schedules", name: "SubjectId", newName: "Subject_Id");
            CreateIndex("dbo.Schedules", "Subject_Id");
            AddForeignKey("dbo.Schedules", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
