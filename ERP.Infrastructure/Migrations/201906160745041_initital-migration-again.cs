namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inititalmigrationagain : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties");
           // DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries");
            //DropIndex("dbo.CoaL5", new[] { "FinParties_Id" });
            //DropColumn("dbo.FinParties", "GlCode");
            //RenameColumn(table: "dbo.FinParties", name: "FinParties_Id", newName: "GlCode");
            //CreateTable(
            //    "dbo.CommInvoiceAgentComms",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            SaleContractCommID = c.String(nullable: false, maxLength: 13),
            //            IndentId = c.Int(nullable: false),
            //            IndentKey = c.String(nullable: false, maxLength: 10),
            //            CommissionId = c.Int(nullable: false),
            //            CompanyId = c.Int(nullable: false),
            //            CommPaidTo = c.Int(nullable: false),
            //            CommPaidFrom = c.Int(nullable: false),
            //            CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            isLocalCurrency = c.Boolean(nullable: false),
            //            CommissionType = c.String(nullable: false, maxLength: 1),
            //            CommissionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CommissionDiscountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SalesTaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CommissionNetValue = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CommissionDiscountRemarks = c.String(nullable: false, maxLength: 100),
            //            ModifiedBy = c.Int(nullable: false),
            //            ModifiedOn = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: false)
            //    .ForeignKey("dbo.IndCommissions", t => t.CommissionId, cascadeDelete: false)
            //    .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
            //    .Index(t => t.IndentId)
            //    .Index(t => t.CommissionId)
            //    .Index(t => t.CompanyId);
            
    //        CreateTable(
    //            "dbo.FabricSamples",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    IndentId = c.Int(nullable: false),
    //                    IndentKey = c.String(nullable: false, maxLength: 10),
    //                    SalesContractDetailID = c.String(maxLength: 13),
    //                    SampleReceiveDate = c.DateTime(nullable: false),
    //                    quantity = c.Double(nullable: false),
    //                    SpecSheetOn = c.DateTime(nullable: false),
    //                    StorageNo = c.String(nullable: false, maxLength: 20),
    //                    CommodityId = c.Int(nullable: false),
    //                    CheckedByID = c.Int(nullable: false),
    //                    CustomerId = c.Int(nullable: false),
    //                    tally = c.Boolean(nullable: false),
    //                    Remarks = c.String(nullable: false, maxLength: 250),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
    //            .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
    //            .ForeignKey("dbo.Products", t => t.CommodityId, cascadeDelete: false)
    //            .ForeignKey("dbo.QcInspectors", t => t.CheckedByID, cascadeDelete: false)
    //            .Index(t => t.IndentId)
    //            .Index(t => t.CommodityId)
    //            .Index(t => t.CheckedByID)
    //            .Index(t => t.CustomerId);
            
    //        CreateTable(
    //            "dbo.YarnInspections",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    InspectionSerialID = c.String(nullable: false, maxLength: 11),
    //                    InspReportTypeId = c.Int(nullable: false),
    //                    YarnInsPectionGradeId = c.Int(nullable: false),
    //                    ShipmentScheduleId = c.Int(nullable: false),
    //                    IndentId = c.Int(nullable: false),
    //                    IndentKey = c.String(nullable: false, maxLength: 10),
    //                    SalesContractDetailID = c.String(maxLength: 13),
    //                    RegisterNo = c.String(nullable: false, maxLength: 15),
    //                    InspectionDate = c.DateTime(nullable: false),
    //                    CustomerId = c.Int(nullable: false),
    //                    CustomerIDasSeller = c.Int(nullable: false),
    //                    CustomerBuyerName = c.String(),
    //                    CustomerIDasBuyer = c.Int(nullable: false),
    //                    CustomerSellerName = c.String(),
    //                    CommodityId = c.Int(nullable: false),
    //                    MillUnit = c.String(maxLength: 10),
    //                    FCL = c.String(),
    //                    QcInspectorID = c.Int(nullable: false),
    //                    AvgBagWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    ProductionStartDate = c.DateTime(nullable: false),
    //                    ProductionDate = c.DateTime(nullable: false),
    //                    PConeColour = c.String(maxLength: 20),
    //                    tm = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CrPolyester = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CrCotton = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PolyFiber = c.String(maxLength: 15),
    //                    PolyDenier = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PolyLength = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PolyColour = c.String(maxLength: 15),
    //                    CottonArea = c.String(maxLength: 25),
    //                    CottonCountry = c.String(maxLength: 25),
    //                    CottonSlength = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonUr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonFFi = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonStrength = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonMic = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonMicRange = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonGrade = c.String(maxLength: 15),
    //                    CottonLots = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CottonColour = c.String(maxLength: 15),
    //                    CottonTrash = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingActualCount = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingCv = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingStr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingCvStr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingClsp = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingRkm = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingU = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingCvbOfU = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingThin = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingThick = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingNeps = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingIPI = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingHairiness = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    RingElongation = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    ContainAutoConeResult = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeActualCount = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeCV = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeStr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    aconeCvStr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeClsp = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeRkm = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeU = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeCvbOfU = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeThin = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeThick = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeNeps = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeIPI = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeHairiness = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    AconeElongation = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedActualCount = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedCv = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedStr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedCvStr = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedClsp = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedRkm = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedU = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedCvbOfU = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedThin = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedThick = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedNeps = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedIPI = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedHairiness = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    PackedElongation = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    Lotno = c.String(maxLength: 20),
    //                    Shade = c.String(maxLength: 10),
    //                    bstrips = c.String(maxLength: 10),
    //                    moisture = c.String(maxLength: 10),
    //                    yarnlength = c.String(maxLength: 10),
    //                    CompanyID = c.String(),
    //                    ContainAttachments = c.Boolean(nullable: false),
    //                    ContainDispatches = c.Boolean(nullable: false),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
    //            .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.ShipmentScheduleId, cascadeDelete: false)
    //            .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
    //            .ForeignKey("dbo.Products", t => t.CommodityId, cascadeDelete: false)
    //            .ForeignKey("dbo.QcInspectors", t => t.QcInspectorID, cascadeDelete: false)
    //            .ForeignKey("dbo.YarnInspectionGrades", t => t.YarnInsPectionGradeId, cascadeDelete: false)
    //            .ForeignKey("dbo.YarnInspectionReportTypes", t => t.InspReportTypeId, cascadeDelete: false)
    //            .Index(t => t.InspReportTypeId)
    //            .Index(t => t.YarnInsPectionGradeId)
    //            .Index(t => t.ShipmentScheduleId)
    //            .Index(t => t.IndentId)
    //            .Index(t => t.CustomerId)
    //            .Index(t => t.CommodityId)
    //            .Index(t => t.QcInspectorID);
            
    //        CreateTable(
    //            "dbo.YarnInspectionAttachments",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    FileName = c.String(nullable: false, maxLength: 150),
    //                    FileDescription = c.String(nullable: false, maxLength: 100),
    //                    isActive = c.Boolean(nullable: false),
    //                    YarnInspectionId = c.Int(nullable: false),
    //                    InspectionSerialID = c.String(nullable: false, maxLength: 11),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    DeleteBy = c.Int(nullable: false),
    //                    DeleteOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.YarnInspections", t => t.YarnInspectionId, cascadeDelete: false)
    //            .Index(t => t.YarnInspectionId);
            
    //        CreateTable(
    //            "dbo.YarnInspectionGrades",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Description = c.String(nullable: false, maxLength: 50),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id);
            
    //        CreateTable(
    //            "dbo.YarnInspectionReportTypes",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Description = c.String(nullable: false, maxLength: 50),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id);
            
    //        CreateTable(
    //            "dbo.YarnInspectionsUsterSettings",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Description = c.String(nullable: false, maxLength: 50),
    //                    UsterResultTypeId = c.String(nullable: false, maxLength: 2),
    //                    value = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    YarnInspectionId = c.Int(nullable: false),
    //                    InspectionSerialID = c.String(nullable: false, maxLength: 11),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.YarnInspections", t => t.YarnInspectionId, cascadeDelete: false)
    //            .Index(t => t.YarnInspectionId);
            
    //        CreateTable(
    //            "dbo.IndCommissionInvoiceDetails",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    CommissionInvoiceNo = c.Int(nullable: false),
    //                    CommissionInvoiceKey = c.String(nullable: false, maxLength: 10),
    //                    UnitOfSaleId = c.Int(nullable: false),
    //                    Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    CompanyId = c.Int(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: false)
    //            .ForeignKey("dbo.IndCommissionInvoices", t => t.CommissionInvoiceNo, cascadeDelete: false)
    //            .ForeignKey("dbo.UnitOfSales", t => t.UnitOfSaleId, cascadeDelete: false)
    //            .Index(t => t.CommissionInvoiceNo)
    //            .Index(t => t.UnitOfSaleId)
    //            .Index(t => t.CompanyId);
            
    //        CreateTable(
    //            "dbo.IndCommissionInvoices",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    CommissionInvoiceKey = c.String(nullable: false, maxLength: 10),
    //                    InvoiceDate = c.DateTime(nullable: false),
    //                    IndentId = c.Int(nullable: false),
    //                    IndentKey = c.String(nullable: false, maxLength: 10),
    //                    SuppliorInvoiceNo = c.String(nullable: false, maxLength: 250),
    //                    SuppliorInvoiceDate = c.DateTime(nullable: false),
    //                    CurrencyId = c.Int(nullable: false),
    //                    ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    InvoiceTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    InvoiceDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    Signature = c.String(nullable: false, maxLength: 200),
    //                    IsPosted = c.Boolean(nullable: false),
    //                    IsncludeSalesTax = c.Boolean(nullable: false),
    //                    IsWithHoldTax = c.Boolean(nullable: false),
    //                    SalesTaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
    //                    TaxOfficeId = c.Int(nullable: false),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                    PostedBy = c.Int(nullable: false),
    //                    PostedOn = c.DateTime(nullable: false),
    //                    DispatchIncludeFrom = c.DateTime(nullable: false),
    //                    DispatchIncludeTo = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: false)
    //            .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
    //            .ForeignKey("dbo.SalesTaxOffices", t => t.TaxOfficeId, cascadeDelete: false)
    //            .Index(t => t.IndentId)
    //            .Index(t => t.CurrencyId)
    //            .Index(t => t.TaxOfficeId);
            
    //        CreateTable(
    //            "dbo.SalesTaxOffices",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Description = c.String(nullable: false, maxLength: 50),
    //                    Abbrivation = c.String(nullable: false, maxLength: 10),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id);
            
    //        CreateTable(
    //            "dbo.IndDelayShipmentCategories",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Description = c.String(nullable: false, maxLength: 10),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id);
            
    //        CreateTable(
    //            "dbo.IndDelayShipmentReasons",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    Description = c.String(nullable: false, maxLength: 10),
    //                    DelayShipCategoryID = c.Int(nullable: false),
    //                    CreatedBy = c.Int(nullable: false),
    //                    CreatedOn = c.DateTime(nullable: false),
    //                    ModifiedBy = c.Int(nullable: false),
    //                    ModifiedOn = c.DateTime(nullable: false),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.IndDelayShipmentCategories", t => t.DelayShipCategoryID, cascadeDelete: false)
    //            .Index(t => t.DelayShipCategoryID);
            
    //        //AddColumn("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", c => c.Int());
    //        AddColumn("dbo.IndDomesticDispatchSchedules", "CommodityId", c => c.Int(nullable: false));
    //       // CreateIndex("dbo.FinParties", "GlCode");
    //        //CreateIndex("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id");
    //        CreateIndex("dbo.IndDomesticDispatchSchedules", "CommodityId");
    //        //AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomestics", "Id", cascadeDelete: false);
    //        AddForeignKey("dbo.IndDomesticDispatchSchedules", "CommodityId", "dbo.Products", "Id", cascadeDelete: false);
    //       // AddForeignKey("dbo.FinParties", "GlCode", "dbo.CoaL5", "L5Code", cascadeDelete: false);
    //        //AddForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries", "Id");
    //        //DropColumn("dbo.CoaL5", "FinParties_Id");
    //    }
        
    //    public override void Down()
    //    {
    //        //AddColumn("dbo.CoaL5", "FinParties_Id", c => c.Int(nullable: false));
    //        //DropForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries");
    //        DropForeignKey("dbo.FinParties", "GlCode", "dbo.CoaL5");
    //        DropForeignKey("dbo.IndDelayShipmentReasons", "DelayShipCategoryID", "dbo.IndDelayShipmentCategories");
    //        DropForeignKey("dbo.IndCommissionInvoiceDetails", "UnitOfSaleId", "dbo.UnitOfSales");
    //        DropForeignKey("dbo.IndCommissionInvoiceDetails", "CommissionInvoiceNo", "dbo.IndCommissionInvoices");
    //        DropForeignKey("dbo.IndCommissionInvoices", "TaxOfficeId", "dbo.SalesTaxOffices");
    //        DropForeignKey("dbo.IndCommissionInvoices", "IndentId", "dbo.IndDomestics");
    //        DropForeignKey("dbo.IndCommissionInvoices", "CurrencyId", "dbo.Currencies");
    //        DropForeignKey("dbo.IndCommissionInvoiceDetails", "CompanyId", "dbo.FinParties");
    //        DropForeignKey("dbo.FabricSamples", "CheckedByID", "dbo.QcInspectors");
    //        DropForeignKey("dbo.YarnInspectionsUsterSettings", "YarnInspectionId", "dbo.YarnInspections");
    //        DropForeignKey("dbo.YarnInspections", "InspReportTypeId", "dbo.YarnInspectionReportTypes");
    //        DropForeignKey("dbo.YarnInspections", "YarnInsPectionGradeId", "dbo.YarnInspectionGrades");
    //        DropForeignKey("dbo.YarnInspectionAttachments", "YarnInspectionId", "dbo.YarnInspections");
    //        DropForeignKey("dbo.YarnInspections", "QcInspectorID", "dbo.QcInspectors");
    //        DropForeignKey("dbo.YarnInspections", "CommodityId", "dbo.Products");
    //        DropForeignKey("dbo.YarnInspections", "IndentId", "dbo.IndDomestics");
    //        DropForeignKey("dbo.YarnInspections", "ShipmentScheduleId", "dbo.IndDomesticDispatchSchedules");
    //        DropForeignKey("dbo.IndDomesticDispatchSchedules", "CommodityId", "dbo.Products");
    //        DropForeignKey("dbo.YarnInspections", "CustomerId", "dbo.FinParties");
    //        DropForeignKey("dbo.FabricSamples", "CommodityId", "dbo.Products");
    //        DropForeignKey("dbo.FabricSamples", "IndentId", "dbo.IndDomestics");
    //        DropForeignKey("dbo.FabricSamples", "CustomerId", "dbo.FinParties");
    //        //DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomestics");
    //        DropForeignKey("dbo.CommInvoiceAgentComms", "IndentId", "dbo.IndDomestics");
    //        DropForeignKey("dbo.CommInvoiceAgentComms", "CommissionId", "dbo.IndCommissions");
    //        DropForeignKey("dbo.CommInvoiceAgentComms", "CompanyId", "dbo.FinParties");
    //        DropIndex("dbo.IndDelayShipmentReasons", new[] { "DelayShipCategoryID" });
    //        DropIndex("dbo.IndCommissionInvoices", new[] { "TaxOfficeId" });
    //        DropIndex("dbo.IndCommissionInvoices", new[] { "CurrencyId" });
    //        DropIndex("dbo.IndCommissionInvoices", new[] { "IndentId" });
    //        DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CompanyId" });
    //        DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "UnitOfSaleId" });
    //        DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CommissionInvoiceNo" });
    //        DropIndex("dbo.YarnInspectionsUsterSettings", new[] { "YarnInspectionId" });
    //        DropIndex("dbo.YarnInspectionAttachments", new[] { "YarnInspectionId" });
    //        DropIndex("dbo.IndDomesticDispatchSchedules", new[] { "CommodityId" });
    //        DropIndex("dbo.YarnInspections", new[] { "QcInspectorID" });
    //        DropIndex("dbo.YarnInspections", new[] { "CommodityId" });
    //        DropIndex("dbo.YarnInspections", new[] { "CustomerId" });
    //        DropIndex("dbo.YarnInspections", new[] { "IndentId" });
    //        DropIndex("dbo.YarnInspections", new[] { "ShipmentScheduleId" });
    //        DropIndex("dbo.YarnInspections", new[] { "YarnInsPectionGradeId" });
    //        DropIndex("dbo.YarnInspections", new[] { "InspReportTypeId" });
    //        DropIndex("dbo.FabricSamples", new[] { "CustomerId" });
    //        DropIndex("dbo.FabricSamples", new[] { "CheckedByID" });
    //        DropIndex("dbo.FabricSamples", new[] { "CommodityId" });
    //        DropIndex("dbo.FabricSamples", new[] { "IndentId" });
    //        //DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndDomesticInquiry_Id" });
    //        DropIndex("dbo.CommInvoiceAgentComms", new[] { "CompanyId" });
    //        DropIndex("dbo.CommInvoiceAgentComms", new[] { "CommissionId" });
    //        DropIndex("dbo.CommInvoiceAgentComms", new[] { "IndentId" });
    //        DropIndex("dbo.FinParties", new[] { "GlCode" });
    //        DropColumn("dbo.IndDomesticDispatchSchedules", "CommodityId");
    //       // DropColumn("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id");
    //        DropTable("dbo.IndDelayShipmentReasons");
    //        DropTable("dbo.IndDelayShipmentCategories");
    //        DropTable("dbo.SalesTaxOffices");
    //        DropTable("dbo.IndCommissionInvoices");
    //        DropTable("dbo.IndCommissionInvoiceDetails");
    //        DropTable("dbo.YarnInspectionsUsterSettings");
    //        DropTable("dbo.YarnInspectionReportTypes");
    //        DropTable("dbo.YarnInspectionGrades");
    //        DropTable("dbo.YarnInspectionAttachments");
    //        DropTable("dbo.YarnInspections");
    //        DropTable("dbo.FabricSamples");
    //        DropTable("dbo.CommInvoiceAgentComms");
    //        //RenameColumn(table: "dbo.FinParties", name: "GlCode", newName: "FinParties_Id");
    //         AddColumn("dbo.FinParties", "GlCode", c => c.String(nullable: false, maxLength: 18));
    //         CreateIndex("dbo.CoaL5", "FinParties_Id");
    //         AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries", "Id", cascadeDelete: false);
    //        AddForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties", "Id");
        }
    }
}
