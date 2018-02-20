namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCashTransactionItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashTransactionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashTransactionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashTransactions", t => t.CashTransactionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CashTransactionId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropIndex("dbo.CashTransactionItems", new[] { "ProductId" });
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropTable("dbo.CashTransactionItems");
        }
    }
}
