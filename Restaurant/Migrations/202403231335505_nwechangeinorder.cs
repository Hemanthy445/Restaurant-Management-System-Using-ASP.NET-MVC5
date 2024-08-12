namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nwechangeinorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.orders", "UserId", "dbo.users");
            DropForeignKey("dbo.carts", "UserId", "dbo.users");
            DropIndex("dbo.carts", new[] { "UserId" });
            DropIndex("dbo.orders", new[] { "UserId" });
            AddColumn("dbo.orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.orders", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.carts", "UserId");
            DropColumn("dbo.orderdetails", "OrderDate");
            DropColumn("dbo.orderdetails", "Foodprice");
            DropTable("dbo.users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.orderdetails", "Foodprice", c => c.Int(nullable: false));
            AddColumn("dbo.orderdetails", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.carts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.orders", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.orders", "TotalAmount");
            CreateIndex("dbo.orders", "UserId");
            CreateIndex("dbo.carts", "UserId");
            AddForeignKey("dbo.carts", "UserId", "dbo.users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.orders", "UserId", "dbo.users", "UserId", cascadeDelete: true);
        }
    }
}
