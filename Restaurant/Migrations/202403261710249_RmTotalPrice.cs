namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RmTotalPrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.orders", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
