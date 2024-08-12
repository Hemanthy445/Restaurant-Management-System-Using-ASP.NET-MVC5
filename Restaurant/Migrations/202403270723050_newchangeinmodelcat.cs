namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchangeinmodelcat : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropForeignKey("dbo.menus", "category_CategoryId", "dbo.categories");
            DropIndex("dbo.menus", new[] { "category_CategoryId" });
            DropColumn("dbo.menus", "category_CategoryId");
            DropTable("dbo.categories");
        }
    }
}
