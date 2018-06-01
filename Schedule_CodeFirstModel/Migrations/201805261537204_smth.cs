namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Discriminator");
        }
    }
}
