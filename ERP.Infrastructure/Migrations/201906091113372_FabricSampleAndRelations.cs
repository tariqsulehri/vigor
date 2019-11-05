namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FabricSampleAndRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FabricSamples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        SalesContractDetailID = c.String(maxLength: 13),
                        SampleReceiveDate = c.DateTime(nullable: false),
                        quantity = c.Double(nullable: false),
                        SpecSheetOn = c.DateTime(nullable: false),
                        StorageNo = c.String(nullable: false, maxLength: 20),
                        CommodityId = c.Int(nullable: false),
                        CheckedByID = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        tally = c.Boolean(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 250),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.CommodityId, cascadeDelete: false)
                .ForeignKey("dbo.QcInspectors", t => t.CheckedByID, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.CommodityId)
                .Index(t => t.CheckedByID)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FabricSamples", "CheckedByID", "dbo.QcInspectors");
            DropForeignKey("dbo.FabricSamples", "CommodityId", "dbo.Products");
            DropForeignKey("dbo.FabricSamples", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.FabricSamples", "CustomerId", "dbo.FinParties");
            DropIndex("dbo.FabricSamples", new[] { "CustomerId" });
            DropIndex("dbo.FabricSamples", new[] { "CheckedByID" });
            DropIndex("dbo.FabricSamples", new[] { "CommodityId" });
            DropIndex("dbo.FabricSamples", new[] { "IndentId" });
            DropTable("dbo.FabricSamples");
        }
    }
}
