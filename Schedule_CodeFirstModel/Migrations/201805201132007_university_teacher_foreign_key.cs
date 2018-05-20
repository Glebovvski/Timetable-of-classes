namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class university_teacher_foreign_key : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "UniversityId", c => c.Int(nullable: false,defaultValue:1));
            CreateIndex("dbo.Teachers", "UniversityId");
            AddForeignKey("dbo.Teachers", "UniversityId", "dbo.Universities", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "UniversityId", "dbo.Universities");
            DropIndex("dbo.Teachers", new[] { "UniversityId" });
            DropColumn("dbo.Teachers", "UniversityId");
        }
    }
}
