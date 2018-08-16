namespace KemijskiSpojApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChemicalCompoundTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChemicalCompounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ChemicalSymbol = c.String(),
                        ChemicalTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChemicalTypes", t => t.ChemicalTypeId, cascadeDelete: true)
                .Index(t => t.ChemicalTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChemicalCompounds", "ChemicalTypeId", "dbo.ChemicalTypes");
            DropIndex("dbo.ChemicalCompounds", new[] { "ChemicalTypeId" });
            DropTable("dbo.ChemicalCompounds");
        }
    }
}
