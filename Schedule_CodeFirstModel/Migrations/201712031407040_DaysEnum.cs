namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DaysEnum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "Day");
            AddColumn("dbo.Schedules", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Day", c => c.String());
        }
    }
}
