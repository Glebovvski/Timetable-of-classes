namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Days : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Day", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Day");
        }
    }
}
