namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeForeignKeyCashtransactionId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransaction_Id" });
            DropColumn("dbo.CashTransactionItems", "CashTransactionId");
            RenameColumn(table: "dbo.CashTransactionItems", name: "CashTransaction_Id", newName: "CashTransactionId");
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CashTransactionItems", "CashTransactionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CashTransactionItems", new[] { "CashTransactionId" });
            AlterColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CashTransactionItems", name: "CashTransactionId", newName: "CashTransaction_Id");
            AddColumn("dbo.CashTransactionItems", "CashTransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.CashTransactionItems", "CashTransaction_Id");
        }
    }
}
