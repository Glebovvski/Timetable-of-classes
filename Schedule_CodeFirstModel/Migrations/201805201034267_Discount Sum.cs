namespace Schedule_CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountSum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookkeepings", "DiscountSum", c => c.Double(nullable: false,defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookkeepings", "DiscountSum");
        }
    }
}
