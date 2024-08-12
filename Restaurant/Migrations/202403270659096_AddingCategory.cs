namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "TotalAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.orders", "TotalAmount");
        }
    }
}
