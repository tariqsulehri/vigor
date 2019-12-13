namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LCTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndExportLCDetails",
                c => new
                    {
                        LcSerialNo = c.String(nullable: false, maxLength: 12),
                        CompanyId = c.Int(nullable: false),
                        IndentId = c.Int(nullable: false),
                        SalesContractKey = c.String(nullable: false, maxLength: 10),
                        LcNo = c.String(nullable: false, maxLength: 20),
                        LcDate = c.DateTime(nullable: false),
                        LastShipmentDate = c.DateTime(),
                        LcAmount = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        CurrencyId = c.Int(nullable: false),
                        IsCommissionDeducted = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LcSerialNo)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndExportLCDetails", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndExportLCDetails", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.IndExportLCDetails", new[] { "CurrencyId" });
            DropIndex("dbo.IndExportLCDetails", new[] { "IndentId" });
            DropTable("dbo.IndExportLCDetails");
        }
    }
}
