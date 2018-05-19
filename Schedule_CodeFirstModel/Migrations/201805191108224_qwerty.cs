namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "UniversityId", c => c.Int(defaultValue:1));
            AddForeignKey("dbo.Groups", "UniversityId", "dbo.Universities","Id", cascadeDelete:true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "UniversityId");
            DropColumn("dbo.Groups", "UniversityId");
        }
    }
}
