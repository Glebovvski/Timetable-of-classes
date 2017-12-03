namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalScheduleMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "GroupId", "dbo.Groups");
            DropIndex("dbo.Schedules", new[] { "GroupId" });
            RenameColumn(table: "dbo.Schedules", name: "GroupId", newName: "Group_Id");
            AlterColumn("dbo.Schedules", "Group_Id", c => c.Int());
            CreateIndex("dbo.Schedules", "Group_Id");
            AddForeignKey("dbo.Schedules", "Group_Id", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Schedules", new[] { "Group_Id" });
            AlterColumn("dbo.Schedules", "Group_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Schedules", name: "Group_Id", newName: "GroupId");
            CreateIndex("dbo.Schedules", "GroupId");
            AddForeignKey("dbo.Schedules", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
    }
}
