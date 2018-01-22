namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTypeForeignKeyToCustomersTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Customers", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
        }
    }
}
