namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indentsInspectionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExRDate = c.DateTime(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        SellingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate120Selling = c.String(nullable: false, maxLength: 10),
                        Rate120Buying = c.String(nullable: false, maxLength: 10),
                        OpenMktSelling = c.String(nullable: false, maxLength: 10),
                        OpenMktBuying = c.String(nullable: false, maxLength: 10),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.FabricInspReportLocals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionDate = c.DateTime(nullable: false),
                        InspRepoSr = c.String(nullable: false, maxLength: 10),
                        InspRepoNo = c.String(nullable: false, maxLength: 10),
                        ForMarket = c.String(nullable: false, maxLength: 1),
                        CompanyId = c.Int(nullable: false),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        FabInspStandardId = c.Int(nullable: false),
                        FabInspTypeId = c.Int(nullable: false),
                        LoomTypeId = c.Int(nullable: false),
                        FabricTypeId = c.Int(nullable: false),
                        InspCalculationBasedOn = c.String(nullable: false, maxLength: 1),
                        InspStatusId = c.Int(nullable: false),
                        QcInspectorId = c.Int(nullable: false),
                        RollsInspected = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerAcceptancePoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bb_ends = c.Int(nullable: false),
                        bb_picks = c.Int(nullable: false),
                        bb_width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bb_gsm = c.Int(nullable: false),
                        ab_ends = c.Int(nullable: false),
                        ab_picks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ab_width = c.Int(nullable: false),
                        ab_gsm = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 1000),
                        width = c.Int(nullable: false),
                        QuantityInspected = c.Int(nullable: false),
                        RollsAvailable = c.Int(nullable: false),
                        HeadBands = c.String(nullable: false, maxLength: 1),
                        ShadeVarivation = c.String(nullable: false, maxLength: 1),
                        Stamped = c.String(nullable: false, maxLength: 1),
                        ReadMarks = c.String(nullable: false, maxLength: 1),
                        RubbingMarks = c.String(nullable: false, maxLength: 1),
                        PolyYarn = c.String(nullable: false, maxLength: 1),
                        Contination = c.String(nullable: false, maxLength: 1),
                        Others = c.String(nullable: false, maxLength: 1),
                        firstLine = c.DateTime(nullable: false),
                        secondLine = c.DateTime(nullable: false),
                        TearingSWrap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TearingSWeft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Shirinkage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PieceRatioLog = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PieceRatioShort = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolyPropLine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cockled = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerSampleStatus = c.String(nullable: false, maxLength: 1),
                        BuyerSampleDesign = c.String(nullable: false, maxLength: 1),
                        SelvedgeWeaves = c.String(nullable: false, maxLength: 10),
                        SelvedgeIdentify = c.String(nullable: false, maxLength: 20),
                        SelvedgeBindingWidth = c.String(nullable: false, maxLength: 20),
                        SelvedgeSize = c.String(nullable: false, maxLength: 20),
                        YarnSupplyWrap = c.String(nullable: false, maxLength: 50),
                        YarnSupplyWeft = c.String(nullable: false, maxLength: 50),
                        TotalEnds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReedCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReedSapce = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndsPerDent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PickInsertion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PickList = c.String(nullable: false, maxLength: 1),
                        Marking = c.String(nullable: false, maxLength: 1),
                        FaceMarking = c.String(nullable: false, maxLength: 1),
                        PackingConditions = c.String(nullable: false, maxLength: 1),
                        WrapDirection = c.String(nullable: false, maxLength: 50),
                        ShipmentSample = c.String(nullable: false, maxLength: 1),
                        Camdirection = c.String(nullable: false, maxLength: 50),
                        NumberOfLooms = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricInspLoomTypes", t => t.LoomTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FabricInspStandards", t => t.FabInspStandardId, cascadeDelete: true)
                .ForeignKey("dbo.FabricInspStatus", t => t.InspStatusId, cascadeDelete: true)
                .ForeignKey("dbo.FabricInspTypes", t => t.FabInspTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FabricTypes", t => t.FabricTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: true)
                .ForeignKey("dbo.QcInspectors", t => t.QcInspectorId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.IndentId)
                .Index(t => t.FabInspStandardId)
                .Index(t => t.FabInspTypeId)
                .Index(t => t.LoomTypeId)
                .Index(t => t.FabricTypeId)
                .Index(t => t.InspStatusId)
                .Index(t => t.QcInspectorId);
            
            CreateTable(
                "dbo.FabInspReportLocalSums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FabInspReportId = c.Int(nullable: false),
                        InspRepoSr = c.String(nullable: false, maxLength: 10),
                        SlubsKnotes = c.Int(nullable: false),
                        PolyYarn = c.Int(nullable: false),
                        Holes = c.Int(nullable: false),
                        MissPick = c.Int(nullable: false),
                        ThickDoublePick = c.Int(nullable: false),
                        WeftBar = c.Int(nullable: false),
                        LooseEndsThickEnds = c.Int(nullable: false),
                        ReedMarksBrokenWraps = c.Int(nullable: false),
                        ThiinPlaces = c.Int(nullable: false),
                        TotalPointsPerRoll = c.Int(nullable: false),
                        PointsPer100Sqy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TPointsPer100Sqy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointsPer100M = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FabricInspReportLocals", t => t.FabInspReportId, cascadeDelete: true)
                .Index(t => t.FabInspReportId);
            
            CreateTable(
                "dbo.FabricInspLoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FabricInspReportLocalDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FabInspReportId = c.Int(nullable: false),
                        InspRepoSr = c.String(nullable: false, maxLength: 10),
                        RollOn = c.Int(nullable: false),
                        NoteMeters = c.Int(nullable: false),
                        ActualMeters = c.Int(nullable: false),
                        SlubsKnotes = c.Int(nullable: false),
                        PolyYarnRed = c.Int(nullable: false),
                        PolyYarnBlue = c.Int(nullable: false),
                        Holes = c.Int(nullable: false),
                        MissPack1 = c.Int(nullable: false),
                        MissPack2 = c.Int(nullable: false),
                        MissPack3 = c.Int(nullable: false),
                        MissPack4 = c.Int(nullable: false),
                        ThickDoublePick = c.Int(nullable: false),
                        ThickDoublePick2 = c.Int(nullable: false),
                        ThickDoublePick3 = c.Int(nullable: false),
                        ThickDoublePick4 = c.Int(nullable: false),
                        WeftBar = c.Int(nullable: false),
                        LooseEndsThickEnds1 = c.Int(nullable: false),
                        LooseEndsThickEnds2 = c.Int(nullable: false),
                        LooseEndsThickEnds3 = c.Int(nullable: false),
                        LooseEndsThickEnds4 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap1 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap2 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap3 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap4 = c.Int(nullable: false),
                        TotalPointsPerRoll = c.Int(nullable: false),
                        Points100SqYards = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualWidth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ends = c.Int(nullable: false),
                        Pick = c.Int(nullable: false),
                        NoOfCutFault = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MildWetBar = c.Int(nullable: false),
                        SmallslubKnotes = c.Int(nullable: false),
                        WeightPerRoll = c.Int(nullable: false),
                        ActualGramSqr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FabricInspReportLocals", t => t.FabInspReportId, cascadeDelete: true)
                .Index(t => t.FabInspReportId);
            
            CreateTable(
                "dbo.FabricInspStandards",
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
                "dbo.FabricInspStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusId = c.String(nullable: false, maxLength: 1),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FabricInspTypes",
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
                "dbo.FabricTypes",
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
                "dbo.QcInspectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        isActive = c.Boolean(nullable: false),
                        CommodityId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityId, cascadeDelete: true)
                .Index(t => t.CommodityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FabricInspReportLocals", "QcInspectorId", "dbo.QcInspectors");
            DropForeignKey("dbo.QcInspectors", "CommodityId", "dbo.CommodityTypes");
            DropForeignKey("dbo.FabricInspReportLocals", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.FabricInspReportLocals", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.FabricInspReportLocals", "FabricTypeId", "dbo.FabricTypes");
            DropForeignKey("dbo.FabricInspReportLocals", "FabInspTypeId", "dbo.FabricInspTypes");
            DropForeignKey("dbo.FabricInspReportLocals", "InspStatusId", "dbo.FabricInspStatus");
            DropForeignKey("dbo.FabricInspReportLocals", "FabInspStandardId", "dbo.FabricInspStandards");
            DropForeignKey("dbo.FabricInspReportLocalDetails", "FabInspReportId", "dbo.FabricInspReportLocals");
            DropForeignKey("dbo.FabricInspReportLocals", "LoomTypeId", "dbo.FabricInspLoomTypes");
            DropForeignKey("dbo.FabInspReportLocalSums", "FabInspReportId", "dbo.FabricInspReportLocals");
            DropForeignKey("dbo.ExchangeRates", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.QcInspectors", new[] { "CommodityId" });
            DropIndex("dbo.FabricInspReportLocalDetails", new[] { "FabInspReportId" });
            DropIndex("dbo.FabInspReportLocalSums", new[] { "FabInspReportId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "QcInspectorId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "InspStatusId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabricTypeId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "LoomTypeId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabInspTypeId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabInspStandardId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "IndentId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "CompanyId" });
            DropIndex("dbo.ExchangeRates", new[] { "CurrencyId" });
            DropTable("dbo.QcInspectors");
            DropTable("dbo.FabricTypes");
            DropTable("dbo.FabricInspTypes");
            DropTable("dbo.FabricInspStatus");
            DropTable("dbo.FabricInspStandards");
            DropTable("dbo.FabricInspReportLocalDetails");
            DropTable("dbo.FabricInspLoomTypes");
            DropTable("dbo.FabInspReportLocalSums");
            DropTable("dbo.FabricInspReportLocals");
            DropTable("dbo.ExchangeRates");
        }
    }
}
