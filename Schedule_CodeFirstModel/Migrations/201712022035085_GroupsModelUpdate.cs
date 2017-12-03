namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupsModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Groups", "Speciality_Id", "dbo.Specialities");
            DropIndex("dbo.Groups", new[] { "Course_Id" });
            DropIndex("dbo.Groups", new[] { "Speciality_Id" });
            RenameColumn(table: "dbo.Groups", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.Groups", name: "Speciality_Id", newName: "SpecialityId");
            AlterColumn("dbo.Groups", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "SpecialityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Groups", "CourseId");
            CreateIndex("dbo.Groups", "SpecialityId");
            AddForeignKey("dbo.Groups", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Groups", "SpecialityId", "dbo.Specialities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Groups", "CourseId", "dbo.Courses");
            DropIndex("dbo.Groups", new[] { "SpecialityId" });
            DropIndex("dbo.Groups", new[] { "CourseId" });
            AlterColumn("dbo.Groups", "SpecialityId", c => c.Int());
            AlterColumn("dbo.Groups", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.Groups", name: "SpecialityId", newName: "Speciality_Id");
            RenameColumn(table: "dbo.Groups", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.Groups", "Speciality_Id");
            CreateIndex("dbo.Groups", "Course_Id");
            AddForeignKey("dbo.Groups", "Speciality_Id", "dbo.Specialities", "Id");
            AddForeignKey("dbo.Groups", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
