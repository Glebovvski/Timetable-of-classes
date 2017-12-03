namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Schedules", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Schedules", new[] { "Group_Id" });
            DropIndex("dbo.Schedules", new[] { "Room_Id" });
            DropIndex("dbo.Schedules", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.Schedules", name: "Group_Id", newName: "GroupId");
            RenameColumn(table: "dbo.Schedules", name: "Room_Id", newName: "RoomId");
            RenameColumn(table: "dbo.Schedules", name: "Teacher_Id", newName: "TeacherId");
            AlterColumn("dbo.Schedules", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "RoomId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "GroupId");
            CreateIndex("dbo.Schedules", "TeacherId");
            CreateIndex("dbo.Schedules", "RoomId");
            AddForeignKey("dbo.Schedules", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Schedules", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "GroupId", "dbo.Groups");
            DropIndex("dbo.Schedules", new[] { "RoomId" });
            DropIndex("dbo.Schedules", new[] { "TeacherId" });
            DropIndex("dbo.Schedules", new[] { "GroupId" });
            AlterColumn("dbo.Schedules", "TeacherId", c => c.Int());
            AlterColumn("dbo.Schedules", "RoomId", c => c.Int());
            AlterColumn("dbo.Schedules", "GroupId", c => c.Int());
            RenameColumn(table: "dbo.Schedules", name: "TeacherId", newName: "Teacher_Id");
            RenameColumn(table: "dbo.Schedules", name: "RoomId", newName: "Room_Id");
            RenameColumn(table: "dbo.Schedules", name: "GroupId", newName: "Group_Id");
            CreateIndex("dbo.Schedules", "Teacher_Id");
            CreateIndex("dbo.Schedules", "Room_Id");
            CreateIndex("dbo.Schedules", "Group_Id");
            AddForeignKey("dbo.Schedules", "Teacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Schedules", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Schedules", "Group_Id", "dbo.Groups", "Id");
        }
    }
}
