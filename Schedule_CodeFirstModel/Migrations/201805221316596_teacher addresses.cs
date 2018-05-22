namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacheraddresses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Address", c => c.String());
            AddColumn("dbo.Teachers", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Teachers", "lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "lng");
            DropColumn("dbo.Teachers", "lat");
            DropColumn("dbo.Teachers", "Address");
        }
    }
}
