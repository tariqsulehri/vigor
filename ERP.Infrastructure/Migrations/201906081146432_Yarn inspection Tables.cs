namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YarninspectionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YarnInspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionSerialID = c.String(nullable: false, maxLength: 11),
                        InspReportTypeId = c.Int(nullable: false),
                        YarnInsPectionGradeId = c.Int(nullable: false),
                        ShipmentScheduleId = c.Int(nullable: false),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        SalesContractDetailID = c.String(maxLength: 13),
                        RegisterNo = c.String(nullable: false, maxLength: 15),
                        InspectionDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerIDasSeller = c.Int(nullable: false),
                        CustomerBuyerName = c.String(),
                        CustomerIDasBuyer = c.Int(nullable: false),
                        CustomerSellerName = c.String(),
                        CommodityId = c.Int(nullable: false),
                        MillUnit = c.String(maxLength: 10),
                        FCL = c.String(),
                        QcInspectorID = c.Int(nullable: false),
                        AvgBagWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductionStartDate = c.DateTime(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        PConeColour = c.String(maxLength: 20),
                        tm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CrPolyester = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CrCotton = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolyFiber = c.String(maxLength: 15),
                        PolyDenier = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolyLength = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolyColour = c.String(maxLength: 15),
                        CottonArea = c.String(maxLength: 25),
                        CottonCountry = c.String(maxLength: 25),
                        CottonSlength = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonUr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonFFi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonStrength = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonMic = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonMicRange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonGrade = c.String(maxLength: 15),
                        CottonLots = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CottonColour = c.String(maxLength: 15),
                        CottonTrash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingActualCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingCv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingStr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingCvStr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingClsp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingRkm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingCvbOfU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingThin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingThick = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingNeps = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingIPI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingHairiness = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RingElongation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContainAutoConeResult = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeActualCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeCV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeStr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        aconeCvStr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeClsp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeRkm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeCvbOfU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeThin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeThick = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeNeps = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeIPI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeHairiness = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AconeElongation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedActualCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedCv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedStr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedCvStr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedClsp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedRkm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedCvbOfU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedThin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedThick = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedNeps = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedIPI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedHairiness = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackedElongation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lotno = c.String(maxLength: 20),
                        Shade = c.String(maxLength: 10),
                        bstrips = c.String(maxLength: 10),
                        moisture = c.String(maxLength: 10),
                        yarnlength = c.String(maxLength: 10),
                        CompanyID = c.String(),
                        ContainAttachments = c.Boolean(nullable: false),
                        ContainDispatches = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.ShipmentScheduleId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.CommodityId, cascadeDelete: false)
                .ForeignKey("dbo.QcInspectors", t => t.QcInspectorID, cascadeDelete: false)
                .ForeignKey("dbo.YarnInspectionGrades", t => t.YarnInsPectionGradeId, cascadeDelete: false)
                .ForeignKey("dbo.YarnInspectionReportTypes", t => t.InspReportTypeId, cascadeDelete: false)
                .Index(t => t.InspReportTypeId)
                .Index(t => t.YarnInsPectionGradeId)
                .Index(t => t.ShipmentScheduleId)
                .Index(t => t.IndentId)
                .Index(t => t.CustomerId)
                .Index(t => t.CommodityId)
                .Index(t => t.QcInspectorID);
            
            CreateTable(
                "dbo.YarnInspectionAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 150),
                        FileDescription = c.String(nullable: false, maxLength: 100),
                        isActive = c.Boolean(nullable: false),
                        YarnInspectionId = c.Int(nullable: false),
                        InspectionSerialID = c.String(nullable: false, maxLength: 11),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        DeleteBy = c.Int(nullable: false),
                        DeleteOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.YarnInspections", t => t.YarnInspectionId, cascadeDelete: false)
                .Index(t => t.YarnInspectionId);
            
            CreateTable(
                "dbo.YarnInspectionGrades",
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
                "dbo.YarnInspectionReportTypes",
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
                "dbo.YarnInspectionsUsterSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        UsterResultTypeId = c.String(nullable: false, maxLength: 2),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YarnInspectionId = c.Int(nullable: false),
                        InspectionSerialID = c.String(nullable: false, maxLength: 11),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.YarnInspections", t => t.YarnInspectionId, cascadeDelete: false)
                .Index(t => t.YarnInspectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YarnInspectionsUsterSettings", "YarnInspectionId", "dbo.YarnInspections");
            DropForeignKey("dbo.YarnInspections", "InspReportTypeId", "dbo.YarnInspectionReportTypes");
            DropForeignKey("dbo.YarnInspections", "YarnInsPectionGradeId", "dbo.YarnInspectionGrades");
            DropForeignKey("dbo.YarnInspectionAttachments", "YarnInspectionId", "dbo.YarnInspections");
            DropForeignKey("dbo.YarnInspections", "QcInspectorID", "dbo.QcInspectors");
            DropForeignKey("dbo.YarnInspections", "CommodityId", "dbo.Products");
            DropForeignKey("dbo.YarnInspections", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.YarnInspections", "ShipmentScheduleId", "dbo.IndDomesticDispatchSchedules");
            DropForeignKey("dbo.YarnInspections", "CustomerId", "dbo.FinParties");
            DropIndex("dbo.YarnInspectionsUsterSettings", new[] { "YarnInspectionId" });
            DropIndex("dbo.YarnInspectionAttachments", new[] { "YarnInspectionId" });
            DropIndex("dbo.YarnInspections", new[] { "QcInspectorID" });
            DropIndex("dbo.YarnInspections", new[] { "CommodityId" });
            DropIndex("dbo.YarnInspections", new[] { "CustomerId" });
            DropIndex("dbo.YarnInspections", new[] { "IndentId" });
            DropIndex("dbo.YarnInspections", new[] { "ShipmentScheduleId" });
            DropIndex("dbo.YarnInspections", new[] { "YarnInsPectionGradeId" });
            DropIndex("dbo.YarnInspections", new[] { "InspReportTypeId" });
            DropTable("dbo.YarnInspectionsUsterSettings");
            DropTable("dbo.YarnInspectionReportTypes");
            DropTable("dbo.YarnInspectionGrades");
            DropTable("dbo.YarnInspectionAttachments");
            DropTable("dbo.YarnInspections");
        }
    }
}
