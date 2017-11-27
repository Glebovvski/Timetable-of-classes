namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DaysAreBackToMAinTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Day_Id", "dbo.Days");
            DropIndex("dbo.Schedules", new[] { "Day_Id" });
            AddColumn("dbo.Schedules", "Day", c => c.String());
            DropColumn("dbo.Schedules", "Day_Id");
            DropTable("dbo.Days");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Schedules", "Day_Id", c => c.Int());
            DropColumn("dbo.Schedules", "Day");
            CreateIndex("dbo.Schedules", "Day_Id");
            AddForeignKey("dbo.Schedules", "Day_Id", "dbo.Days", "Id");
        }
    }
}
