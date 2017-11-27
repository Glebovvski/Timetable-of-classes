namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDbScheduleForEachGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "ScheduleId_Id", "dbo.Schedules");
            DropIndex("dbo.Groups", new[] { "ScheduleId_Id" });
            AddColumn("dbo.Schedules", "GroupId_Id", c => c.Int());
            CreateIndex("dbo.Schedules", "GroupId_Id");
            AddForeignKey("dbo.Schedules", "GroupId_Id", "dbo.Groups", "Id");
            DropColumn("dbo.Groups", "ScheduleId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "ScheduleId_Id", c => c.Int());
            DropForeignKey("dbo.Schedules", "GroupId_Id", "dbo.Groups");
            DropIndex("dbo.Schedules", new[] { "GroupId_Id" });
            DropColumn("dbo.Schedules", "GroupId_Id");
            CreateIndex("dbo.Groups", "ScheduleId_Id");
            AddForeignKey("dbo.Groups", "ScheduleId_Id", "dbo.Schedules", "Id");
        }
    }
}
