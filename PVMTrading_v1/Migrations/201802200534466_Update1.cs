namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropPrimaryKey("dbo.CashTransactions");
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.Int(nullable: false));
            AlterColumn("dbo.CashTransactions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CashTransactions", "Id");
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            CreateIndex("dbo.AspNetUsers", "BranchId");
            AddForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions");
            DropForeignKey("dbo.AspNetUsers", "BranchId", "dbo.Branches");
            DropIndex("dbo.AspNetUsers", new[] { "BranchId" });
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            DropPrimaryKey("dbo.CashTransactions");
            AlterColumn("dbo.CashTransactions", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.CashTransactions", "Id");
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
            AddForeignKey("dbo.CashTransactionItems", "CashTransactionId", "dbo.CashTransactions", "Id");
        }
    }
}
