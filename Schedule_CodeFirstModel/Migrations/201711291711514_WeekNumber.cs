namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeekNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "WeekNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "WeekNumber");
        }
    }
}
