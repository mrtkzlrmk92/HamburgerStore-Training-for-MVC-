namespace hamburger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forenkeyolusturma : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Orders", "ProductId");
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
        }
    }
}
