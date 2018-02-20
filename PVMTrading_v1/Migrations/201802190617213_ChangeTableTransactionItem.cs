namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableTransactionItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CashTransactionItems", "ProductPriceId", "dbo.ProductPrices");
            DropIndex("dbo.CashTransactionItems", new[] { "ProductPriceId" });
            AddColumn("dbo.CashTransactionItems", "ProductPrice", c => c.Double(nullable: false));
            DropColumn("dbo.CashTransactionItems", "ProductPriceId");
            DropColumn("dbo.CashTransactionItems", "DiscountedAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CashTransactionItems", "DiscountedAmount", c => c.Double(nullable: false));
            AddColumn("dbo.CashTransactionItems", "ProductPriceId", c => c.Int(nullable: false));
            DropColumn("dbo.CashTransactionItems", "ProductPrice");
            CreateIndex("dbo.CashTransactionItems", "ProductPriceId");
            AddForeignKey("dbo.CashTransactionItems", "ProductPriceId", "dbo.ProductPrices", "Id", cascadeDelete: true);
        }
    }
}
