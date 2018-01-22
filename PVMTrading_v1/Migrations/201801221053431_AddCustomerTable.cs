namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        MiddleName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        NameExtension = c.String(nullable: false, maxLength: 255),
                        Mobile = c.Int(nullable: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Birthdate = c.DateTime(nullable: false),
                        CivilStatusId = c.Int(nullable: false),
                        Sexid = c.Int(nullable: false),
                        RegisteredDateCreated = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(nullable: false),
                        Nationality = c.String(nullable: false, maxLength: 255),
                        TaxIdentificationNumber = c.Int(nullable: false),
                        CustomerTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CivilStatus", t => t.CivilStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Sexes", t => t.Sexid, cascadeDelete: true)
                .Index(t => t.CivilStatusId)
                .Index(t => t.Sexid);
            
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Sexid", "dbo.Sexes");
            DropForeignKey("dbo.Customers", "CivilStatusId", "dbo.CivilStatus");
            DropIndex("dbo.Customers", new[] { "Sexid" });
            DropIndex("dbo.Customers", new[] { "CivilStatusId" });
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.Customers");
        }
    }
}
