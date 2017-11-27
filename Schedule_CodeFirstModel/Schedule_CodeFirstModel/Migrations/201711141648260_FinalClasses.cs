namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "StartTime", c => c.String());
            AlterColumn("dbo.Classes", "EndTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Classes", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Classes", "Number");
        }
    }
}
