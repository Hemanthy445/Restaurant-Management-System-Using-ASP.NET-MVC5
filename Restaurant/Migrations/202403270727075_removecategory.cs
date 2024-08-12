namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.menus", "category_CategoryId", "dbo.categories");
            DropIndex("dbo.menus", new[] { "category_CategoryId" });
            DropColumn("dbo.menus", "category_CategoryId");
            DropTable("dbo.categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.menus", "category_CategoryId", c => c.Int());
            CreateIndex("dbo.menus", "category_CategoryId");
            AddForeignKey("dbo.menus", "category_CategoryId", "dbo.categories", "CategoryId");
        }
    }
}
