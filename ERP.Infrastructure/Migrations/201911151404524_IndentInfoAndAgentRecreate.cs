namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndentInfoAndAgentRecreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndentAgents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentId = c.Int(nullable: false),
                        SalesContractNo = c.String(maxLength: 10),
                        CustomerIDasAgentID = c.Int(nullable: false),
                        CustomerIDasAgentCodeRef = c.String(maxLength: 6),
                        AgentStatus = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentId = c.Int(nullable: false),
                        SalesContractNo = c.String(maxLength: 10),
                        CompanyID = c.String(maxLength: 3),
                        SellerContractNo = c.String(maxLength: 25),
                        SellerContractDate = c.DateTime(),
                        PurchaseOrderNo = c.String(maxLength: 25),
                        BuyerReferenceNo = c.String(maxLength: 20),
                        foreignIndentNo = c.String(maxLength: 20),
                        foreignIndentDate = c.DateTime(),
                        BrandId = c.Int(nullable: false),
                        BrandCode = c.String(maxLength: 4),
                        BasicFabric = c.String(maxLength: 250),
                        BlendRatio = c.String(maxLength: 250),
                        LoomType = c.String(maxLength: 250),
                        FinishedWeight = c.String(maxLength: 250),
                        PriceTermId = c.Int(nullable: false),
                        PriceTermCode = c.String(maxLength: 4),
                        GoodsDes = c.String(maxLength: 1000),
                        ProductionSource = c.String(maxLength: 200),
                        GsmWeight = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        GsmUnit = c.String(maxLength: 3),
                        SampleSwatchDate = c.DateTime(),
                        SampleReceived = c.Boolean(),
                        FabricSampleReadyDate = c.DateTime(),
                        IndentDomestic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomestics", t => t.IndentDomestic_Id)
                .Index(t => t.IndentDomestic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndentInfoes", "IndentDomestic_Id", "dbo.IndDomestics");
            DropIndex("dbo.IndentInfoes", new[] { "IndentDomestic_Id" });
            DropTable("dbo.IndentInfoes");
            DropTable("dbo.IndentAgents");
        }
    }
}
