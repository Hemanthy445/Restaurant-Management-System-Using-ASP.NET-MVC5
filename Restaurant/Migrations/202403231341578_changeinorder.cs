namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.orders", "TotalPrice");
        }
    }
}
