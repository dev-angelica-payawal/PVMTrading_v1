namespace PVMTrading_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateBranchesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Branches VALUES(1,'Branch 1','Arayat')");
            Sql("INSERT INTO Branches VALUES(2,'Main Branch','Arayat')");
            Sql("INSERT INTO Branches VALUES(3,'Branch 3','Mexico')");
        }

        public override void Down()
        {
        }
    }
}
