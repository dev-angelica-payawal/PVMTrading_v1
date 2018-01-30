namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationandForeignKeyToProductInclusionsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductInclusions", "Quantity", c => c.Int());
            CreateIndex("dbo.ProductInclusions", "ProductId");
            AddForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInclusions", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductInclusions", new[] { "ProductId" });
            AlterColumn("dbo.ProductInclusions", "Quantity", c => c.Int(nullable: false));
        }
    }
}
