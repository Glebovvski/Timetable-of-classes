namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherSubjectRelationAltered : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Subjects", "TeacherId");
            AddForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "SubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropColumn("dbo.Subjects", "TeacherId");
            CreateIndex("dbo.Teachers", "SubjectId");
            AddForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
