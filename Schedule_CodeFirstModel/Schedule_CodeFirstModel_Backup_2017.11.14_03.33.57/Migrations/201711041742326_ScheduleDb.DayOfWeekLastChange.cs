namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDbDayOfWeekLastChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "Day", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Day", c => c.String(maxLength: 2));
        }
    }
}
