namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkingDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orderdetails", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.orderdetails", "OrderDate");
        }
    }
}
