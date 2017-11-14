namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Schedules", "Class_Id", c => c.Int());
            CreateIndex("dbo.Schedules", "Class_Id");
            AddForeignKey("dbo.Schedules", "Class_Id", "dbo.Classes", "Id");
            DropColumn("dbo.Schedules", "ClassNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "ClassNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.Schedules", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Schedules", new[] { "Class_Id" });
            DropColumn("dbo.Schedules", "Class_Id");
            DropTable("dbo.Classes");
        }
    }
}
