namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "WarrantyId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            AlterColumn("dbo.Customers", "MiddleName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "NameExtension", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "SerialNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Barcode", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "WarrantyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "WarrantyId", c => c.Int());
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            AlterColumn("dbo.Products", "BrandId", c => c.Int());
            AlterColumn("dbo.Products", "Barcode", c => c.Int());
            AlterColumn("dbo.Products", "Model", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "SerialNumber", c => c.Int());
            AlterColumn("dbo.Customers", "NameExtension", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "MiddleName", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "WarrantyId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id");
            AddForeignKey("dbo.Products", "WarrantyId", "dbo.Warranties", "Id");
        }
    }
}
