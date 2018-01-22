namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateAddressTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeRoles VALUES('Mortgaged')");
            Sql("INSERT INTO EmployeeRoles VALUES('Rented')");
            Sql("INSERT INTO EmployeeRoles VALUES('Owned')");
        }
        
        public override void Down()
        {
        }
    }
}
