namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndentCommissionAndSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndCommissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleContractCommID = c.String(nullable: false, maxLength: 13),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        CustomerIdCommPaidTo = c.Int(nullable: false),
                        CustomerIdCommPaidFrom = c.Int(nullable: false),
                        CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommissionType = c.String(nullable: false, maxLength: 1),
                        IsinLocalCurrecncy = c.Boolean(nullable: false),
                        CommissionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 20),
                        CalculatedCommissionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                        TTRoutingInstructions = c.String(maxLength: 500),
                        IsPrintable = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: true)
                .Index(t => t.IndentId);
            
            CreateTable(
                "dbo.IndDomesticDispatchSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalDispatchNo = c.String(nullable: false, maxLength: 13),
                        BiltyNo = c.String(nullable: false, maxLength: 20),
                        TransDate = c.DateTime(nullable: false),
                        ContractedDeliveryDate = c.DateTime(nullable: false),
                        TypeOfTransaction = c.String(nullable: false, maxLength: 1),
                        IndentId = c.Int(nullable: false),
                        SalesContractDetail = c.String(nullable: false, maxLength: 13),
                        CompanyId = c.Int(nullable: false),
                        VehicleNo = c.String(nullable: false, maxLength: 20),
                        IsReceivedStinv = c.String(nullable: false, maxLength: 20),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GoodsFarwarderID = c.Int(nullable: false),
                        SalestaxInvoiceNo = c.String(nullable: false, maxLength: 255),
                        SalestaxInvoiceDate = c.DateTime(nullable: false),
                        IsDelayed = c.String(nullable: false, maxLength: 1),
                        DelayShipmentReason = c.String(nullable: false, maxLength: 2),
                        DelayShipmentReasonDescription = c.String(nullable: false, maxLength: 250),
                        IsComplaint = c.String(nullable: false, maxLength: 1),
                        isFirstDispatch = c.String(nullable: false, maxLength: 1),
                        isActive = c.Boolean(nullable: false),
                        isInvoiced = c.Boolean(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GovtTaxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivableAfterTaxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeTaxPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeTaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetReceviable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(nullable: false, maxLength: 200),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsForwarders", t => t.GoodsFarwarderID, cascadeDelete: true)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: true)
                .Index(t => t.IndentId)
                .Index(t => t.GoodsFarwarderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndDomesticDispatchSchedules", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndDomesticDispatchSchedules", "GoodsFarwarderID", "dbo.GoodsForwarders");
            DropForeignKey("dbo.IndCommissions", "IndentId", "dbo.IndDomestics");
            DropIndex("dbo.IndDomesticDispatchSchedules", new[] { "GoodsFarwarderID" });
            DropIndex("dbo.IndDomesticDispatchSchedules", new[] { "IndentId" });
            DropIndex("dbo.IndCommissions", new[] { "IndentId" });
            DropTable("dbo.IndDomesticDispatchSchedules");
            DropTable("dbo.IndCommissions");
        }
    }
}
