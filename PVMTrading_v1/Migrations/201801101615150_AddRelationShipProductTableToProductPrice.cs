namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationShipProductTableToProductPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductPriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductPriceId");
            AddForeignKey("dbo.Products", "ProductPriceId", "dbo.ProductPrices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductPriceId", "dbo.ProductPrices");
            DropIndex("dbo.Products", new[] { "ProductPriceId" });
            DropColumn("dbo.Products", "ProductPriceId");
        }
    }
}
