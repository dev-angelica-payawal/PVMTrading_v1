namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateBranchesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Branches VALUES('Branch 1','Arayat')");
            Sql("INSERT INTO Branches VALUES('Main Branch','Arayat')");
            Sql("INSERT INTO Branches VALUES('Branch 3','Mexico')");
        }

        public override void Down()
        {
        }
    }
}
