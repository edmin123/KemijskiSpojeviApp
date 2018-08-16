namespace KemijskiSpojApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnotationForChemicalCompounds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChemicalCompounds", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ChemicalCompounds", "ChemicalSymbol", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChemicalCompounds", "ChemicalSymbol", c => c.String());
            AlterColumn("dbo.ChemicalCompounds", "Name", c => c.String());
        }
    }
}
