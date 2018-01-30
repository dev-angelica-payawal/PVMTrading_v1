namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeForProductPriceTableColumnsAndUpdateDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductPrices", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.ProductPrices", "SellingPrice", c => c.Double(nullable: false));
            CreateIndex("dbo.ProductPrices", "ProductId");
            AddForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
            AlterColumn("dbo.ProductPrices", "SellingPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductPrices", "UnitPrice", c => c.Int(nullable: false));
        }
    }
}
