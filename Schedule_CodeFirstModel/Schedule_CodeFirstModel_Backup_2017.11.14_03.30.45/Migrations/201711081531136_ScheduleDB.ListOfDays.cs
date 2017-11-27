namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDBListOfDays : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Day", c => c.String(maxLength: 3));
        }
    }
}
