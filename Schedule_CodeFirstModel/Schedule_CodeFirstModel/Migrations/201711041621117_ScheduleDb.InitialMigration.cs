namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDbInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemestreId_Id = c.Int(nullable: false),
                        SpecialityId_Id = c.Int(nullable: false),
                        SubjectId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semestres", t => t.SemestreId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId_Id)
                .Index(t => t.SemestreId_Id)
                .Index(t => t.SpecialityId_Id)
                .Index(t => t.SubjectId_Id);
            
            CreateTable(
                "dbo.Semestres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 10),
                        Students = c.Int(nullable: false),
                        CourseId_Id = c.Int(),
                        ScheduleId_Id = c.Int(),
                        SpecialityId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId_Id)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId_Id)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId_Id)
                .Index(t => t.CourseId_Id)
                .Index(t => t.ScheduleId_Id)
                .Index(t => t.SpecialityId_Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        ClassNumber = c.Int(nullable: false),
                        Room_Id = c.Int(),
                        SubjectId_Id = c.Int(),
                        TeacherId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId_Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.SubjectId_Id)
                .Index(t => t.TeacherId_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        PlacesAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        SubjectId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId_Id, cascadeDelete: true)
                .Index(t => t.SubjectId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "SpecialityId_Id", "dbo.Specialities");
            DropForeignKey("dbo.Groups", "ScheduleId_Id", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "TeacherId_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "SubjectId_Id", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "SubjectId_Id", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Groups", "CourseId_Id", "dbo.Courses");
            DropForeignKey("dbo.AcademicPlans", "SubjectId_Id", "dbo.Subjects");
            DropForeignKey("dbo.AcademicPlans", "SpecialityId_Id", "dbo.Specialities");
            DropForeignKey("dbo.AcademicPlans", "SemestreId_Id", "dbo.Semestres");
            DropIndex("dbo.Teachers", new[] { "SubjectId_Id" });
            DropIndex("dbo.Schedules", new[] { "TeacherId_Id" });
            DropIndex("dbo.Schedules", new[] { "SubjectId_Id" });
            DropIndex("dbo.Schedules", new[] { "Room_Id" });
            DropIndex("dbo.Groups", new[] { "SpecialityId_Id" });
            DropIndex("dbo.Groups", new[] { "ScheduleId_Id" });
            DropIndex("dbo.Groups", new[] { "CourseId_Id" });
            DropIndex("dbo.AcademicPlans", new[] { "SubjectId_Id" });
            DropIndex("dbo.AcademicPlans", new[] { "SpecialityId_Id" });
            DropIndex("dbo.AcademicPlans", new[] { "SemestreId_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Rooms");
            DropTable("dbo.Schedules");
            DropTable("dbo.Groups");
            DropTable("dbo.Courses");
            DropTable("dbo.Subjects");
            DropTable("dbo.Specialities");
            DropTable("dbo.Semestres");
            DropTable("dbo.AcademicPlans");
        }
    }
}
