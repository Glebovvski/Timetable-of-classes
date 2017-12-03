namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalScheduleMigr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Schedules", new[] { "Group_Id" });
            RenameColumn(table: "dbo.Schedules", name: "Group_Id", newName: "GroupId");
            AlterColumn("dbo.Schedules", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "GroupId");
            AddForeignKey("dbo.Schedules", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "GroupId", "dbo.Groups");
            DropIndex("dbo.Schedules", new[] { "GroupId" });
            AlterColumn("dbo.Schedules", "GroupId", c => c.Int());
            RenameColumn(table: "dbo.Schedules", name: "GroupId", newName: "Group_Id");
            CreateIndex("dbo.Schedules", "Group_Id");
            AddForeignKey("dbo.Schedules", "Group_Id", "dbo.Groups", "Id");
        }
    }
}
