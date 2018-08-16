namespace KemijskiSpojApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateChemicalTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into ChemicalTypes(Id,Name) Values(1,'Organski')");
            Sql("Insert into ChemicalTypes(Id,Name) Values(2,'Anorganski')");
            Sql("Insert into ChemicalTypes(Id,Name) Values(3,'Kovalentni')");
            Sql("Insert into ChemicalTypes(Id,Name) Values(4,'Ionski')");
        }
        
        public override void Down()
        {
        }
    }
}
