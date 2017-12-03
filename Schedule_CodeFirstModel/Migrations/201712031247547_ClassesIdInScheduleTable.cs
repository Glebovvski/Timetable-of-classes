namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassesIdInScheduleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Schedules", new[] { "Class_Id" });
            RenameColumn(table: "dbo.Schedules", name: "Class_Id", newName: "ClassId");
            AlterColumn("dbo.Schedules", "ClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "ClassId");
            AddForeignKey("dbo.Schedules", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ClassId", "dbo.Classes");
            DropIndex("dbo.Schedules", new[] { "ClassId" });
            AlterColumn("dbo.Schedules", "ClassId", c => c.Int());
            RenameColumn(table: "dbo.Schedules", name: "ClassId", newName: "Class_Id");
            CreateIndex("dbo.Schedules", "Class_Id");
            AddForeignKey("dbo.Schedules", "Class_Id", "dbo.Classes", "Id");
        }
    }
}
