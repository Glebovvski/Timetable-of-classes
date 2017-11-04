namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDbMakingColumnNamesMoreReadable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AcademicPlans", name: "SemestreId_Id", newName: "Semestre_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "SpecialityId_Id", newName: "Speciality_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "SubjectId_Id", newName: "Subject_Id");
            RenameColumn(table: "dbo.Groups", name: "CourseId_Id", newName: "Course_Id");
            RenameColumn(table: "dbo.Groups", name: "SpecialityId_Id", newName: "Speciality_Id");
            RenameColumn(table: "dbo.Schedules", name: "GroupId_Id", newName: "Group_Id");
            RenameColumn(table: "dbo.Schedules", name: "SubjectId_Id", newName: "Subject_Id");
            RenameColumn(table: "dbo.Teachers", name: "SubjectId_Id", newName: "Subject_Id");
            RenameColumn(table: "dbo.Schedules", name: "TeacherId_Id", newName: "Teacher_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_SemestreId_Id", newName: "IX_Semestre_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_SpecialityId_Id", newName: "IX_Speciality_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_SubjectId_Id", newName: "IX_Subject_Id");
            RenameIndex(table: "dbo.Groups", name: "IX_CourseId_Id", newName: "IX_Course_Id");
            RenameIndex(table: "dbo.Groups", name: "IX_SpecialityId_Id", newName: "IX_Speciality_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_GroupId_Id", newName: "IX_Group_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_SubjectId_Id", newName: "IX_Subject_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_TeacherId_Id", newName: "IX_Teacher_Id");
            RenameIndex(table: "dbo.Teachers", name: "IX_SubjectId_Id", newName: "IX_Subject_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teachers", name: "IX_Subject_Id", newName: "IX_SubjectId_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_Teacher_Id", newName: "IX_TeacherId_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_Subject_Id", newName: "IX_SubjectId_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_Group_Id", newName: "IX_GroupId_Id");
            RenameIndex(table: "dbo.Groups", name: "IX_Speciality_Id", newName: "IX_SpecialityId_Id");
            RenameIndex(table: "dbo.Groups", name: "IX_Course_Id", newName: "IX_CourseId_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_Subject_Id", newName: "IX_SubjectId_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_Speciality_Id", newName: "IX_SpecialityId_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_Semestre_Id", newName: "IX_SemestreId_Id");
            RenameColumn(table: "dbo.Schedules", name: "Teacher_Id", newName: "TeacherId_Id");
            RenameColumn(table: "dbo.Teachers", name: "Subject_Id", newName: "SubjectId_Id");
            RenameColumn(table: "dbo.Schedules", name: "Subject_Id", newName: "SubjectId_Id");
            RenameColumn(table: "dbo.Schedules", name: "Group_Id", newName: "GroupId_Id");
            RenameColumn(table: "dbo.Groups", name: "Speciality_Id", newName: "SpecialityId_Id");
            RenameColumn(table: "dbo.Groups", name: "Course_Id", newName: "CourseId_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "Subject_Id", newName: "SubjectId_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "Speciality_Id", newName: "SpecialityId_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "Semestre_Id", newName: "SemestreId_Id");
        }
    }
}
