namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomesticIndentTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries");
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndDomesticInquiry_Id" });
            RenameColumn(table: "dbo.IndDomesticInquiryDetails", name: "IndDomesticInquiry_Id", newName: "InquiryId");
            CreateTable(
                "dbo.UnitOfSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        UomID = c.Int(nullable: false),
                        UorID = c.Int(nullable: false),
                        StuffingUnit = c.String(maxLength: 2),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardUOM = c.Int(nullable: false),
                        StandardUOMFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 200),
                        ShipmentSchedule = c.String(maxLength: 1),
                        RequireStuffing = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndUnitOfMeasures", t => t.UomID, cascadeDelete: false)
                .ForeignKey("dbo.UnitOfRates", t => t.UorID, cascadeDelete: false)
                .Index(t => t.UomID)
                .Index(t => t.UorID);
            
            CreateTable(
                "dbo.UnitOfRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDomestics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        IndentDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerIDasSeller = c.Int(nullable: false),
                        CustomerBuyerName = c.String(),
                        CustomerIDasBuyer = c.Int(nullable: false),
                        CustomerSellerName = c.String(),
                        CustomerIDasLocalAgent = c.Int(nullable: false),
                        CustomerAsLocalAgent = c.String(),
                        OfferDate = c.DateTime(nullable: false),
                        confirmDate = c.DateTime(nullable: false),
                        CommodityGroups = c.Int(nullable: false),
                        CommodityTypeId = c.Int(nullable: false),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        DepartmentID = c.Int(nullable: false),
                        PaymenTermsId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityVariance = c.String(maxLength: 10),
                        TotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValueOnCommRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackingRemarks = c.String(maxLength: 1500),
                        DeliveryRemarks = c.String(maxLength: 1500),
                        DeliveryRemarksBuyer = c.String(maxLength: 1000),
                        GeneralRemarks = c.String(maxLength: 2000),
                        SpecialConditions = c.String(maxLength: 1500),
                        SpecialConditionsBuyer = c.String(maxLength: 1500),
                        SpecialConditionsSeller = c.String(maxLength: 1500),
                        PicesLength = c.String(maxLength: 1500),
                        QualityRemarks = c.String(maxLength: 1500),
                        FinancialRemarks = c.String(maxLength: 1500),
                        Specificatiions = c.String(maxLength: 1500),
                        PriceTerms = c.String(maxLength: 200),
                        Destination = c.String(maxLength: 200),
                        CottonSource = c.String(maxLength: 200),
                        CostingSheetRef = c.String(maxLength: 50),
                        RevisionNumber = c.Int(nullable: false),
                        ClosingRemaks = c.String(maxLength: 200),
                        closedDate = c.DateTime(nullable: false),
                        ExecutedTotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsScheduleGenerated = c.Boolean(nullable: false),
                        DelDateValidUpto = c.DateTime(nullable: false),
                        IsApproved = c.String(maxLength: 1),
                        LastApprovedOn = c.DateTime(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        MarketedBy = c.Int(nullable: false),
                        IsSubmitForApproval = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.InquiryId, cascadeDelete: false)
                .ForeignKey("dbo.IndPaymentTerms", t => t.PaymenTermsId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.CommodityTypeId)
                .Index(t => t.InquiryId)
                .Index(t => t.DepartmentID)
                .Index(t => t.PaymenTermsId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Symbol = c.String(maxLength: 5),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDomesticDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesContractDetailID = c.String(maxLength: 13),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        CommodityId = c.Int(nullable: false),
                        CommoditySpecification = c.String(maxLength: 200),
                        UosID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stuffing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeCode = c.Int(nullable: false),
                        SizeSpecifications = c.String(maxLength: 500),
                        GSM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerPieceWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerPieceUnitWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LabDip = c.String(maxLength: 500),
                        LabDipOption = c.String(maxLength: 5),
                        LabDipDate = c.DateTime(nullable: false),
                        WeightDispatched = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeColor = c.String(maxLength: 1),
                        FabricWidth = c.String(maxLength: 30),
                        QuantityReq = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitQuantityReq = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BarCode = c.String(maxLength: 20),
                        TotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValueOnCommRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExecutedQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExecutedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityPerFCL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColourId = c.Int(nullable: false),
                        SuppliorCode = c.Int(nullable: false),
                        DesignId = c.Int(nullable: false),
                        DesignNo = c.String(maxLength: 30),
                        FinParty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndColours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.IndDesigns", t => t.DesignId, cascadeDelete: true)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: true)
                .ForeignKey("dbo.IndSizes", t => t.SizeCode, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.CommodityId, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfSales", t => t.UosID, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.FinParty_Id)
                .Index(t => t.IndentId)
                .Index(t => t.CommodityId)
                .Index(t => t.UosID)
                .Index(t => t.SizeCode)
                .Index(t => t.ColourId)
                .Index(t => t.DesignId)
                .Index(t => t.FinParty_Id);
            
            CreateTable(
                "dbo.IndColours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeId = c.Double(nullable: false),
                        ColourId = c.Double(nullable: false),
                        ColourDescription = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDesigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Symbol = c.String(maxLength: 5),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        PriorityinGroup = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeGroupId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndSizeGroups", t => t.SizeGroupId, cascadeDelete: true)
                .Index(t => t.SizeGroupId);
            
            CreateTable(
                "dbo.IndSizeGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.IndDomesticInquiryDetails", "UosId", c => c.Int(nullable: false));
            AlterColumn("dbo.IndDomesticInquiryDetails", "InquiryId", c => c.Int(nullable: false));
            CreateIndex("dbo.IndDomesticInquiryDetails", "InquiryId");
            CreateIndex("dbo.IndDomesticInquiryDetails", "UosId");
            AddForeignKey("dbo.IndDomesticInquiryDetails", "UosId", "dbo.UnitOfSales", "Id", cascadeDelete: false);
            AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticDetails", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.IndDomesticDetails", "UosID", "dbo.UnitOfSales");
            DropForeignKey("dbo.IndDomesticDetails", "CommodityId", "dbo.Products");
            DropForeignKey("dbo.IndDomesticDetails", "SizeCode", "dbo.IndSizes");
            DropForeignKey("dbo.IndSizes", "SizeGroupId", "dbo.IndSizeGroups");
            DropForeignKey("dbo.IndDomesticDetails", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndDomesticDetails", "DesignId", "dbo.IndDesigns");
            DropForeignKey("dbo.IndDomesticDetails", "ColourId", "dbo.IndColours");
            DropForeignKey("dbo.IndDomestics", "PaymenTermsId", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomestics", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomestics", "DepartmentID", "dbo.HrDepartments");
            DropForeignKey("dbo.IndDomestics", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomestics", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.IndDomestics", "CommodityTypeId", "dbo.CommodityTypes");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "UosId", "dbo.UnitOfSales");
            DropForeignKey("dbo.UnitOfSales", "UorID", "dbo.UnitOfRates");
            DropForeignKey("dbo.UnitOfSales", "UomID", "dbo.IndUnitOfMeasures");
            DropIndex("dbo.IndSizes", new[] { "SizeGroupId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "FinParty_Id" });
            DropIndex("dbo.IndDomesticDetails", new[] { "DesignId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "ColourId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "SizeCode" });
            DropIndex("dbo.IndDomesticDetails", new[] { "UosID" });
            DropIndex("dbo.IndDomesticDetails", new[] { "CommodityId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "IndentId" });
            DropIndex("dbo.IndDomestics", new[] { "CurrencyId" });
            DropIndex("dbo.IndDomestics", new[] { "PaymenTermsId" });
            DropIndex("dbo.IndDomestics", new[] { "DepartmentID" });
            DropIndex("dbo.IndDomestics", new[] { "InquiryId" });
            DropIndex("dbo.IndDomestics", new[] { "CommodityTypeId" });
            DropIndex("dbo.IndDomestics", new[] { "CustomerId" });
            DropIndex("dbo.UnitOfSales", new[] { "UorID" });
            DropIndex("dbo.UnitOfSales", new[] { "UomID" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "UosId" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "InquiryId" });
            AlterColumn("dbo.IndDomesticInquiryDetails", "InquiryId", c => c.Int());
            AlterColumn("dbo.IndDomesticInquiryDetails", "UosId", c => c.String());
            DropTable("dbo.IndSizeGroups");
            DropTable("dbo.IndSizes");
            DropTable("dbo.IndDesigns");
            DropTable("dbo.IndColours");
            DropTable("dbo.IndDomesticDetails");
            DropTable("dbo.Currencies");
            DropTable("dbo.IndDomestics");
            DropTable("dbo.UnitOfRates");
            DropTable("dbo.UnitOfSales");
            RenameColumn(table: "dbo.IndDomesticInquiryDetails", name: "InquiryId", newName: "IndDomesticInquiry_Id");
            CreateIndex("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id");
            AddForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries", "Id");
        }
    }
}
