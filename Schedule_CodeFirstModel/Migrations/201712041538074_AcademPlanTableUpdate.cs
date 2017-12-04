namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcademPlanTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AcademicPlans", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.AcademicPlans", new[] { "Subject_Id" });
            RenameColumn(table: "dbo.AcademicPlans", name: "Semestre_Id", newName: "SemestreId");
            RenameColumn(table: "dbo.AcademicPlans", name: "Speciality_Id", newName: "SpecialityId");
            RenameColumn(table: "dbo.AcademicPlans", name: "Subject_Id", newName: "SubjectId");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_Speciality_Id", newName: "IX_SpecialityId");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_Semestre_Id", newName: "IX_SemestreId");
            AlterColumn("dbo.AcademicPlans", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.AcademicPlans", "SubjectId");
            AddForeignKey("dbo.AcademicPlans", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademicPlans", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.AcademicPlans", new[] { "SubjectId" });
            AlterColumn("dbo.AcademicPlans", "SubjectId", c => c.Int());
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_SemestreId", newName: "IX_Semestre_Id");
            RenameIndex(table: "dbo.AcademicPlans", name: "IX_SpecialityId", newName: "IX_Speciality_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "SubjectId", newName: "Subject_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "SpecialityId", newName: "Speciality_Id");
            RenameColumn(table: "dbo.AcademicPlans", name: "SemestreId", newName: "Semestre_Id");
            CreateIndex("dbo.AcademicPlans", "Subject_Id");
            AddForeignKey("dbo.AcademicPlans", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
