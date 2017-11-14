namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Day", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Day");
        }
    }
}
