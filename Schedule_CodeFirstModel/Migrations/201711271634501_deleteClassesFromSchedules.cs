namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteClassesFromSchedules : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Schedules", new[] { "Class_Id" });
            DropColumn("dbo.Schedules", "Class_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Class_Id", c => c.Int());
            CreateIndex("dbo.Schedules", "Class_Id");
            AddForeignKey("dbo.Schedules", "Class_Id", "dbo.Classes", "Id");
        }
    }
}
