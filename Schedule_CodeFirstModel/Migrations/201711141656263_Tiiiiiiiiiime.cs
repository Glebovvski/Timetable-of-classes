namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tiiiiiiiiiime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "StartTime", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Classes", "EndTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "EndTime", c => c.String());
            AlterColumn("dbo.Classes", "StartTime", c => c.String());
        }
    }
}
