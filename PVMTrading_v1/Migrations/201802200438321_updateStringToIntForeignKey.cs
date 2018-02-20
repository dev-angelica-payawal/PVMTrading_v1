namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStringToIntForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CashTransactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products");
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropIndex("dbo.CashTransactionItems", new[] { "ProductId" });
            DropIndex("dbo.CashTransactions", new[] { "CustomerId" });
            CreateIndex("dbo.AspNetUsers", "BranchId");
            AddForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            DropTable("dbo.CashTransactionItems");
            DropTable("dbo.CashTransactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CashTransactions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TotalDiscountedAmount = c.Double(nullable: false),
                        OriginalTotalAmount = c.Double(nullable: false),
                        CashTransactionDate = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        IsVoid = c.Boolean(nullable: false),
                        Remarks = c.String(maxLength: 500),
                        OR = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashTransactionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashTransactionId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branches");
            DropIndex("dbo.AspNetUsers", new[] { "BranchId" });
            CreateIndex("dbo.CashTransactions", "CustomerId");
            CreateIndex("dbo.CashTransactionItems", "ProductId");
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            AddForeignKey("dbo.CashTransactionItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions", "Id");
            AddForeignKey("dbo.CashTransactions", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
