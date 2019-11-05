namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InspectionLocalExportTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FabricInspReportLocals", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.YarnInspections", "CustomerId", "dbo.FinParties");
            DropIndex("dbo.FabricInspReportLocals", new[] { "CompanyId" });
            DropIndex("dbo.YarnInspections", new[] { "CustomerId" });
            CreateTable(
                "dbo.FabricInspReportExports",
                c => new
                    {
                        InspectionSerialNoID = c.String(nullable: false, maxLength: 8),
                        InspectionDate = c.DateTime(nullable: false),
                        company = c.String(nullable: false, maxLength: 3),
                        FabricTypeId = c.Int(nullable: false),
                        LoomTypeId = c.Int(nullable: false),
                        InspReportNo = c.String(maxLength: 20),
                        ForMarket = c.String(nullable: false, maxLength: 1),
                        IndentExportKey = c.String(nullable: false, maxLength: 10),
                        ShipmentScheduleId = c.Int(nullable: false),
                        ShipmentScheduleKey = c.String(nullable: false, maxLength: 13),
                        sr_no = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        FabInspStandardId = c.Int(nullable: false),
                        FabInspRepFormat = c.String(maxLength: 1),
                        InspCalculationBasedOn = c.String(maxLength: 1),
                        InspTypePerformed = c.String(maxLength: 1),
                        InspectionStatusId = c.Int(nullable: false),
                        BuyerAcceptablePoints = c.Int(),
                        QcInspCode = c.String(nullable: false, maxLength: 4),
                        RollsInspected = c.Int(nullable: false),
                        bb_ends = c.Int(),
                        bb_picks = c.Int(),
                        bb_width = c.Double(),
                        bb_gsm = c.Int(),
                        ab_ends = c.Int(),
                        ab_picks = c.Double(),
                        ab_width = c.Int(),
                        ab_gsm = c.Int(),
                        Remarks = c.String(maxLength: 1000),
                        width = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        QuantityInspected = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        rollsAvailable = c.Int(),
                        HeadBands = c.String(maxLength: 1),
                        ShadeVariation = c.String(maxLength: 1),
                        Stamped = c.String(maxLength: 1),
                        ReedMarks = c.String(maxLength: 1),
                        RubbingMarks = c.String(maxLength: 1),
                        PolyYarn = c.String(maxLength: 1),
                        Contamination = c.String(maxLength: 1),
                        other = c.String(maxLength: 1),
                        firstinline = c.DateTime(),
                        secondinline = c.DateTime(),
                        TearingSWarp = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        TearingSWeft = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        Shrinkage = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        PieceRatioLong = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        PieceRatioShort = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        PolyPropline = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        Cockled = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        BuyerSampleStatus = c.String(maxLength: 1),
                        BuyerSampleDesign = c.String(maxLength: 1),
                        SelvedgeWeave = c.String(maxLength: 10),
                        SelvedgeIdentify = c.String(maxLength: 20),
                        SelvedgeBindingWith = c.String(maxLength: 20),
                        SelvedgeSize = c.String(maxLength: 10),
                        YarnSupplyWarp = c.String(maxLength: 50),
                        YarnSupplyWeft = c.String(maxLength: 50),
                        TotalEnds = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        ReedCount = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        ReedSapce = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        EndsPerDent = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        PickInsertion = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        PackingList = c.String(maxLength: 1),
                        Marking = c.String(maxLength: 1),
                        FaceMarking = c.String(maxLength: 1),
                        PackingCondition = c.String(maxLength: 1),
                        WrappingDirection = c.String(maxLength: 50),
                        ShipmentSample = c.String(maxLength: 1),
                        CamDirection = c.String(maxLength: 50),
                        NumberofLooms = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        FabricInspType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.InspectionSerialNoID)
                .ForeignKey("dbo.FabricInspTypes", t => t.FabricInspType_Id)
                .ForeignKey("dbo.FabInspTypePerformeds", t => t.InspTypePerformed)
                .ForeignKey("dbo.FabricInspLoomTypes", t => t.LoomTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FabricInspStandards", t => t.FabInspStandardId, cascadeDelete: false)
                .ForeignKey("dbo.FabricInspStatus", t => t.InspectionStatusId, cascadeDelete: false)
                .ForeignKey("dbo.FabricTypes", t => t.FabricTypeId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.ShipmentScheduleId, cascadeDelete: false)
                .Index(t => t.FabricTypeId)
                .Index(t => t.LoomTypeId)
                .Index(t => t.ShipmentScheduleId)
                .Index(t => t.FabInspStandardId)
                .Index(t => t.InspTypePerformed)
                .Index(t => t.InspectionStatusId)
                .Index(t => t.FabricInspType_Id);
            
            CreateTable(
                "dbo.FabInspTypePerformeds",
                c => new
                    {
                        InspTypePerformedID = c.String(nullable: false, maxLength: 1),
                        InspTypePerformedDesc = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.InspTypePerformedID);
            
            CreateTable(
                "dbo.KnittedFabricInspections",
                c => new
                    {
                        InspectionID = c.String(nullable: false, maxLength: 9),
                        InsepctionDate = c.DateTime(nullable: false),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        ShipmentScheduleId = c.Int(nullable: false),
                        ShipmentScheduleKey = c.String(nullable: false, maxLength: 13),
                        SalesContractDetailId = c.Int(nullable: false),
                        SalesContractDetailKey = c.String(nullable: false, maxLength: 13),
                        FCL = c.String(maxLength: 6),
                        Lotno = c.String(maxLength: 10),
                        SampleRequiredOn = c.DateTime(),
                        BabyConesReceivedOn = c.DateTime(),
                        GreyReceivedOn = c.DateTime(),
                        DyedReceivedOn = c.DateTime(),
                        Remarks = c.String(maxLength: 3000),
                        ContainGrey = c.String(maxLength: 1),
                        ContainDyed = c.String(maxLength: 1),
                        ContainBleached = c.String(maxLength: 1),
                        CompyanyID = c.Int(nullable: false),
                        CompanyKey = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.InspectionID)
                .ForeignKey("dbo.IndDomesticDetails", t => t.SalesContractDetailId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.ShipmentScheduleId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.ShipmentScheduleId)
                .Index(t => t.SalesContractDetailId);
            
            CreateTable(
                "dbo.CPAAttachments_2BDeleted",
                c => new
                    {
                        CpaNo = c.String(nullable: false, maxLength: 8),
                        FileName = c.String(maxLength: 250),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CpaNo);
            
            CreateTable(
                "dbo.FabricInspReportExport4PointDetails",
                c => new
                    {
                        InspectionSerialNo = c.String(nullable: false, maxLength: 8),
                        SrNo = c.String(maxLength: 4),
                        RollNo = c.Int(),
                        NotedMeters = c.Int(),
                        ActualMeters = c.Int(),
                        SlubsKnots = c.Int(),
                        PolyYarnRed = c.Int(),
                        PolyYarnRed1 = c.Int(),
                        PolyYarnRed2 = c.Int(),
                        PolyYarnRed3 = c.Int(),
                        PolyYarnBlue = c.Int(),
                        PolyYarnBlue1 = c.Int(),
                        PolyYarnBlue2 = c.Int(),
                        PolyYarnBlue3 = c.Int(),
                        Holes = c.Int(),
                        MissPack1 = c.Int(),
                        MissPack2 = c.Int(),
                        MissPack3 = c.Int(),
                        MissPack4 = c.Int(),
                        ThickDoublePick = c.Int(),
                        ThickDoublePick2 = c.Int(),
                        ThickDoublePick3 = c.Int(),
                        ThickDoublePick4 = c.Int(),
                        WeftBar = c.Int(),
                        LooseEndsThickEnds1 = c.Int(),
                        LooseEndsThickEnds2 = c.Int(),
                        LooseEndsThickEnds3 = c.Int(),
                        LooseEndsThickEnds4 = c.Int(),
                        ReedMarkBrokenWrap1 = c.Int(),
                        ReedMarkBrokenWrap2 = c.Int(),
                        ReedMarkBrokenWrap3 = c.Int(),
                        ReedMarkBrokenWrap4 = c.Int(),
                        ThinPlaces = c.Int(),
                        TotalPointsPerRoll = c.Int(),
                        Points100SqYard = c.Decimal(precision: 18, scale: 2),
                        FabricGrade = c.String(),
                        ActualWidth = c.Decimal(precision: 18, scale: 2),
                        Ends = c.Int(),
                        Pick = c.Int(),
                        NoOfCutFaults = c.Decimal(precision: 18, scale: 2),
                        MildWeftBar = c.Int(),
                        SmallSlubsKnots = c.Int(),
                        TotalPoints = c.Decimal(precision: 18, scale: 2),
                        WeightPerRoll = c.Decimal(precision: 18, scale: 2),
                        ActualGramSqr = c.Int(),
                    })
                .PrimaryKey(t => t.InspectionSerialNo);
            
            CreateTable(
                "dbo.FabricInspReportExport4PointResults",
                c => new
                    {
                        InspectionSerialNoID = c.String(nullable: false, maxLength: 8),
                        InspectionTypePerformed = c.String(maxLength: 25),
                        Construction = c.String(maxLength: 50),
                        Width = c.String(maxLength: 10),
                        IC_quantitiesSubmitted = c.String(maxLength: 1),
                        IC_Style = c.String(maxLength: 1),
                        IC_Workmanship = c.String(maxLength: 1),
                        IC_Packing = c.String(maxLength: 1),
                        IC_Marking = c.String(maxLength: 1),
                        IC_DataMeasurement = c.String(maxLength: 1),
                        PC_Style = c.String(maxLength: 1),
                        PC_Material = c.String(maxLength: 1),
                        PC_Color = c.String(maxLength: 1),
                        PC_Griege = c.String(maxLength: 1),
                        ReferenceSample = c.String(maxLength: 1),
                        PieceLengthCheck = c.String(maxLength: 200),
                        PieceLength = c.String(maxLength: 200),
                        RollsLengthCheck = c.String(maxLength: 200),
                        SizeMeasurement = c.String(maxLength: 20),
                        IndividualPacking = c.String(maxLength: 1),
                        InnerPacking = c.String(maxLength: 1),
                        ExportPacking = c.String(maxLength: 1),
                        PackingAssortment = c.String(maxLength: 200),
                        ML_BarCode = c.String(maxLength: 1),
                        ML_ShippingMarks = c.String(maxLength: 1),
                        ML_OtherMarks = c.String(maxLength: 1),
                        ML_SideMark = c.String(maxLength: 1),
                        ML_MainLabel = c.String(maxLength: 1),
                        ML_Care = c.String(maxLength: 1),
                        ML_Size = c.String(maxLength: 1),
                        ML_Country = c.String(maxLength: 1),
                        ML_HangTag = c.String(maxLength: 1),
                        ML_PolyBag = c.String(maxLength: 1),
                        ML_InnerBox = c.String(maxLength: 1),
                        ML_OtherLabel = c.String(maxLength: 1),
                        Lighting = c.String(maxLength: 200),
                        LightingStatus = c.String(maxLength: 200),
                        InspectionPlace = c.String(maxLength: 200),
                        InspectionDoneOn = c.String(maxLength: 200),
                        Cleanliness = c.String(maxLength: 200),
                        WeatherCondition = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.InspectionSerialNoID);
            
            CreateTable(
                "dbo.FabricInspRptExp4PFormat2",
                c => new
                    {
                        InspectionSerialNo = c.String(nullable: false, maxLength: 8),
                        SrNo = c.String(maxLength: 4),
                        Rollno = c.Int(),
                        NotedMeters = c.Int(),
                        ActualMeters = c.Int(),
                        CoarseYarn1 = c.Int(),
                        SlackLooseWarp2 = c.Int(),
                        BrokenWarp3 = c.Int(),
                        Shortend4 = c.Int(),
                        CoarseYarn5 = c.Int(),
                        SlackLooseWarp6 = c.Int(),
                        CoarseYarn7 = c.Int(),
                        SlackLooseWarp8 = c.Int(),
                        Coarseyarn9 = c.Int(),
                        CockledYarn10 = c.Int(),
                        ColorCont11 = c.Int(),
                        coarseYarn12 = c.Int(),
                        WeftCrackiness13 = c.Int(),
                        StartingMarks14 = c.Int(),
                        MissPick15 = c.Int(),
                        DoublePick16 = c.Int(),
                        CoarseYarn17 = c.Int(),
                        MissPick18 = c.Int(),
                        DoublePick19 = c.Int(),
                        CoarseYarn20 = c.Int(),
                        CoarseYarn21 = c.Int(),
                        LongHair22 = c.Int(),
                        ColorCont23 = c.Int(),
                        ScorePerRollPiece = c.Int(),
                        AveragegPoint = c.Decimal(precision: 18, scale: 2),
                        FabricGrade = c.String(maxLength: 1),
                        Width = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InspectionSerialNo);
            
            CreateTable(
                "dbo.KnittedFabricInspBleacheds",
                c => new
                    {
                        InspectionCode = c.String(nullable: false, maxLength: 9),
                        ShadeColour = c.String(maxLength: 30),
                        Type = c.String(maxLength: 30),
                        Length = c.String(maxLength: 30),
                        Width = c.String(maxLength: 30),
                        Gsm = c.String(maxLength: 30),
                        Guage = c.String(maxLength: 30),
                        DIA = c.String(maxLength: 30),
                        Evenness = c.String(maxLength: 50),
                        Dyability = c.String(maxLength: 30),
                        Barre = c.String(maxLength: 30),
                        Contamination = c.String(maxLength: 30),
                        Slubs = c.String(maxLength: 30),
                        LongThin = c.String(maxLength: 30),
                        LongThick = c.String(maxLength: 30),
                        DeadCottonLevel = c.String(maxLength: 30),
                        Other = c.String(maxLength: 100),
                        isSampleSentBuyer = c.String(maxLength: 1),
                        SampleSentBuyer = c.Decimal(precision: 18, scale: 2),
                        SampleSentBuyerDate = c.DateTime(),
                        isSampleSentSeller = c.String(maxLength: 1),
                        SampleSentSeller = c.Decimal(precision: 18, scale: 2),
                        SampleSentSellerDate = c.DateTime(),
                        isSampleoffice = c.String(maxLength: 1),
                        SampleOffice = c.Decimal(precision: 18, scale: 2),
                        SampleOfficeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.InspectionCode);
            
            CreateTable(
                "dbo.KnittedFabricInspDyeds",
                c => new
                    {
                        InspectionCode = c.String(nullable: false, maxLength: 9),
                        ShadeColour = c.String(maxLength: 30),
                        Type = c.String(maxLength: 30),
                        Length = c.String(maxLength: 30),
                        Width = c.String(maxLength: 30),
                        Gsm = c.String(maxLength: 30),
                        Guage = c.String(maxLength: 30),
                        DIA = c.String(maxLength: 30),
                        Evenness = c.String(maxLength: 50),
                        Dyability = c.String(maxLength: 30),
                        Barre = c.String(maxLength: 30),
                        Contamination = c.String(maxLength: 30),
                        Slubs = c.String(maxLength: 30),
                        LongThin = c.String(maxLength: 30),
                        LongThick = c.String(maxLength: 30),
                        DeadCottonLevel = c.String(maxLength: 30),
                        Other = c.String(maxLength: 100),
                        isSampleSentBuyer = c.String(maxLength: 1),
                        SampleSentBuyer = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        SampleSentBuyerDate = c.DateTime(),
                        isSampleSentSeller = c.String(maxLength: 1),
                        SampleSentSeller = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        SampleSentSellerDate = c.DateTime(),
                        isSampleoffice = c.String(maxLength: 1),
                        SampleOffice = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        SampleOfficeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.InspectionCode);
            
            CreateTable(
                "dbo.KnittedFabricInspectionAttachments",
                c => new
                    {
                        InspectionCode = c.String(nullable: false, maxLength: 11),
                        FileName = c.String(maxLength: 150),
                        FileDescription = c.String(maxLength: 100),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InspectionCode);
            
            CreateTable(
                "dbo.KnittedFabricInspGreys",
                c => new
                    {
                        InspectionCode = c.String(nullable: false, maxLength: 9),
                        IsGreyOrMelange = c.String(maxLength: 1),
                        ShadeColour = c.String(maxLength: 30),
                        Type = c.String(maxLength: 30),
                        Length = c.String(maxLength: 30),
                        Width = c.String(maxLength: 30),
                        Gsm = c.String(maxLength: 30),
                        Guage = c.String(maxLength: 30),
                        DIA = c.String(maxLength: 30),
                        Evenness = c.String(maxLength: 50),
                        Dyability = c.String(maxLength: 30),
                        Barre = c.String(maxLength: 30),
                        Contamination = c.String(maxLength: 30),
                        Slubs = c.String(maxLength: 30),
                        LongThin = c.String(maxLength: 30),
                        LongThick = c.String(maxLength: 30),
                        DeadCottonLevel = c.String(maxLength: 30),
                        Other = c.String(maxLength: 100),
                        isSampleSentBuyer = c.String(maxLength: 1),
                        SampleSentBuyer = c.Decimal(precision: 18, scale: 2),
                        SampleSentBuyerDate = c.DateTime(),
                        isSampleSentSeller = c.String(maxLength: 1),
                        SampleSentSeller = c.Decimal(precision: 18, scale: 2),
                        SampleSentSellerDate = c.DateTime(),
                        isSampleoffice = c.String(maxLength: 1),
                        SampleOffice = c.Decimal(precision: 18, scale: 2),
                        SampleOfficeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.InspectionCode);
            
            AddColumn("dbo.FabricInspReportLocals", "CompanyKey", c => c.String(maxLength: 3));
            AddColumn("dbo.FabricInspReportLocals", "FabInspTypePerformed_InspTypePerformedID", c => c.String(maxLength: 1));
            AddColumn("dbo.YarnInspections", "CustomerKey", c => c.String());
            CreateIndex("dbo.FabricInspReportLocals", "FabInspTypePerformed_InspTypePerformedID");
            AddForeignKey("dbo.FabricInspReportLocals", "FabInspTypePerformed_InspTypePerformedID", "dbo.FabInspTypePerformeds", "InspTypePerformedID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KnittedFabricInspections", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.KnittedFabricInspections", "ShipmentScheduleId", "dbo.IndDomesticDispatchSchedules");
            DropForeignKey("dbo.KnittedFabricInspections", "SalesContractDetailId", "dbo.IndDomesticDetails");
            DropForeignKey("dbo.FabricInspReportExports", "ShipmentScheduleId", "dbo.IndDomesticDispatchSchedules");
            DropForeignKey("dbo.FabricInspReportExports", "FabricTypeId", "dbo.FabricTypes");
            DropForeignKey("dbo.FabricInspReportExports", "InspectionStatusId", "dbo.FabricInspStatus");
            DropForeignKey("dbo.FabricInspReportExports", "FabInspStandardId", "dbo.FabricInspStandards");
            DropForeignKey("dbo.FabricInspReportExports", "LoomTypeId", "dbo.FabricInspLoomTypes");
            DropForeignKey("dbo.FabricInspReportExports", "InspTypePerformed", "dbo.FabInspTypePerformeds");
            DropForeignKey("dbo.FabricInspReportLocals", "FabInspTypePerformed_InspTypePerformedID", "dbo.FabInspTypePerformeds");
            DropForeignKey("dbo.FabricInspReportExports", "FabricInspType_Id", "dbo.FabricInspTypes");
            DropIndex("dbo.KnittedFabricInspections", new[] { "SalesContractDetailId" });
            DropIndex("dbo.KnittedFabricInspections", new[] { "ShipmentScheduleId" });
            DropIndex("dbo.KnittedFabricInspections", new[] { "IndentId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabInspTypePerformed_InspTypePerformedID" });
            DropIndex("dbo.FabricInspReportExports", new[] { "FabricInspType_Id" });
            DropIndex("dbo.FabricInspReportExports", new[] { "InspectionStatusId" });
            DropIndex("dbo.FabricInspReportExports", new[] { "InspTypePerformed" });
            DropIndex("dbo.FabricInspReportExports", new[] { "FabInspStandardId" });
            DropIndex("dbo.FabricInspReportExports", new[] { "ShipmentScheduleId" });
            DropIndex("dbo.FabricInspReportExports", new[] { "LoomTypeId" });
            DropIndex("dbo.FabricInspReportExports", new[] { "FabricTypeId" });
            DropColumn("dbo.YarnInspections", "CustomerKey");
            DropColumn("dbo.FabricInspReportLocals", "FabInspTypePerformed_InspTypePerformedID");
            DropColumn("dbo.FabricInspReportLocals", "CompanyKey");
            DropTable("dbo.KnittedFabricInspGreys");
            DropTable("dbo.KnittedFabricInspectionAttachments");
            DropTable("dbo.KnittedFabricInspDyeds");
            DropTable("dbo.KnittedFabricInspBleacheds");
            DropTable("dbo.FabricInspRptExp4PFormat2");
            DropTable("dbo.FabricInspReportExport4PointResults");
            DropTable("dbo.FabricInspReportExport4PointDetails");
            DropTable("dbo.CPAAttachments_2BDeleted");
            DropTable("dbo.KnittedFabricInspections");
            DropTable("dbo.FabInspTypePerformeds");
            DropTable("dbo.FabricInspReportExports");
            CreateIndex("dbo.YarnInspections", "CustomerId");
            CreateIndex("dbo.FabricInspReportLocals", "CompanyId");
            AddForeignKey("dbo.YarnInspections", "CustomerId", "dbo.FinParties", "Id", cascadeDelete: false);
            AddForeignKey("dbo.FabricInspReportLocals", "CompanyId", "dbo.FinParties", "Id", cascadeDelete: false);
        }
    }
}
