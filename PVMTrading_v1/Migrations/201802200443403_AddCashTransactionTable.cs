namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCashTransactionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalDiscountedAmount = c.Double(nullable: false),
                        OriginalTotalAmount = c.Double(nullable: false),
                        CashTransactionDate = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        IsVoid = c.Boolean(nullable: false),
                        Remarks = c.String(maxLength: 500),
                        OR = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashTransactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CashTransactions", new[] { "CustomerId" });
            DropTable("dbo.CashTransactions");
        }
    }
}
