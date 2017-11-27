namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDbDayOfWeek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "Day", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Day", c => c.DateTime(nullable: false));
        }
    }
}
