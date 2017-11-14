namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableDay : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Schedules", "Day_Id");
            AddForeignKey("dbo.Schedules", "Day_Id", "dbo.Days", "Id");
            DropColumn("dbo.Schedules", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Day", c => c.String());
            DropForeignKey("dbo.Schedules", "Day_Id", "dbo.Days");
            DropIndex("dbo.Schedules", new[] { "Day_Id" });
            DropColumn("dbo.Schedules", "Day_Id");
            DropTable("dbo.Days");
        }
    }
}
