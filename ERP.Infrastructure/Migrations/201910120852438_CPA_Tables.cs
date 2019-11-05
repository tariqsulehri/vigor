namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CPA_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CpaFcls",
                c => new
                    {
                        CPaNo = c.String(nullable: false, maxLength: 8),
                        ShipmentScheduleid = c.Int(nullable: false),
                        ShipmentScheduleidKey = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.CPaNo)
                .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.ShipmentScheduleid, cascadeDelete: true)
                .Index(t => t.ShipmentScheduleid);
            
            CreateTable(
                "dbo.CPAFindingNatures",
                c => new
                    {
                        CPAFindingNatureID = c.Int(nullable: false, identity: true),
                        CPAFindingNatureDesc = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.CPAFindingNatureID);
            
            CreateTable(
                "dbo.CPAFindingNCTypes",
                c => new
                    {
                        CPAFindingNCTypeID = c.Int(nullable: false, identity: true),
                        CPAFindingNCTypeDesc = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.CPAFindingNCTypeID);
            
            CreateTable(
                "dbo.CPAFindingNCTypeSubs",
                c => new
                    {
                        CPAFindingNCTypeSubID = c.Int(nullable: false, identity: true),
                        CPAFindingNCTypeID = c.Int(nullable: false),
                        DESCRIPTION = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.CPAFindingNCTypeSubID)
                .ForeignKey("dbo.CPAFindingNCTypes", t => t.CPAFindingNCTypeID, cascadeDelete: true)
                .Index(t => t.CPAFindingNCTypeID);
            
            CreateTable(
                "dbo.CPAFindingTypes",
                c => new
                    {
                        CPAFindingID = c.Int(nullable: false, identity: true),
                        CPAFindingType1 = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.CPAFindingID);
            
            CreateTable(
                "dbo.CPALogSheets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CpaNo = c.String(maxLength: 8),
                        Remarks = c.String(maxLength: 250),
                        Dated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cpas", t => t.CpaNo)
                .Index(t => t.CpaNo);
            
            CreateTable(
                "dbo.Cpas",
                c => new
                    {
                        CpaNo = c.String(nullable: false, maxLength: 8),
                        ReportedBy = c.String(nullable: false, maxLength: 5),
                        ReportByDepartmentId = c.String(),
                        ReportByDepartmentKey = c.String(maxLength: 4),
                        ReportDate = c.DateTime(nullable: false),
                        CpaNcTypeID = c.String(nullable: false, maxLength: 1),
                        Problem = c.String(nullable: false, maxLength: 1000),
                        CpaContain = c.String(nullable: false, maxLength: 1),
                        CprAssignedTo = c.String(maxLength: 5),
                        CprAssignedToDept = c.String(maxLength: 4),
                        IsCpaRejected = c.String(maxLength: 1),
                        CprRejected = c.String(maxLength: 500),
                        TargetDate = c.DateTime(),
                        DeptManager = c.String(maxLength: 5),
                        RootCause = c.String(maxLength: 1000),
                        CorrectiveAction = c.String(maxLength: 2000),
                        PreventiveAction = c.String(maxLength: 1000),
                        cpataken = c.String(maxLength: 1),
                        cpaEffective = c.String(maxLength: 1),
                        ActionCompletedDt = c.DateTime(),
                        Comments = c.String(maxLength: 2500),
                        CheckedBy = c.String(maxLength: 5),
                        CheckDate = c.DateTime(),
                        ConfirmBy = c.String(maxLength: 5),
                        Confirmdate = c.DateTime(),
                        Agentcode = c.String(maxLength: 6),
                        BuyerCode = c.String(maxLength: 6),
                        Sellercode = c.String(maxLength: 6),
                        IndentNo = c.String(maxLength: 10),
                        CpaClose = c.String(maxLength: 1),
                        CpaCloseDate = c.DateTime(),
                        CpaProved = c.String(maxLength: 1),
                        CpaType = c.String(maxLength: 1),
                        ClaimId = c.String(maxLength: 8),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CpaNo)
                .ForeignKey("dbo.CpaNcTypes", t => t.CpaNcTypeID, cascadeDelete: true)
                .ForeignKey("dbo.CpaTypes", t => t.CpaType)
                .Index(t => t.CpaNcTypeID)
                .Index(t => t.CpaType);
            
            CreateTable(
                "dbo.CpaNcTypes",
                c => new
                    {
                        CPaNcType1 = c.String(nullable: false, maxLength: 1),
                        CpaNcName = c.String(nullable: false, maxLength: 150),
                        CPAFindingID = c.Int(),
                        CPAFindingNatureID = c.Int(),
                        CPAFindingNCTypeID = c.Int(),
                        CPAFindingNCTypeSubID = c.Int(),
                        isCustomerComplaint = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.CPaNcType1);
            
            CreateTable(
                "dbo.CpaTypes",
                c => new
                    {
                        CpaType1 = c.String(nullable: false, maxLength: 1),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CpaType1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CPALogSheets", "CpaNo", "dbo.Cpas");
            DropForeignKey("dbo.Cpas", "CpaType", "dbo.CpaTypes");
            DropForeignKey("dbo.Cpas", "CpaNcTypeID", "dbo.CpaNcTypes");
            DropForeignKey("dbo.CPAFindingNCTypeSubs", "CPAFindingNCTypeID", "dbo.CPAFindingNCTypes");
            DropForeignKey("dbo.CpaFcls", "ShipmentScheduleid", "dbo.IndDomesticDispatchSchedules");
            DropIndex("dbo.Cpas", new[] { "CpaType" });
            DropIndex("dbo.Cpas", new[] { "CpaNcTypeID" });
            DropIndex("dbo.CPALogSheets", new[] { "CpaNo" });
            DropIndex("dbo.CPAFindingNCTypeSubs", new[] { "CPAFindingNCTypeID" });
            DropIndex("dbo.CpaFcls", new[] { "ShipmentScheduleid" });
            DropTable("dbo.CpaTypes");
            DropTable("dbo.CpaNcTypes");
            DropTable("dbo.Cpas");
            DropTable("dbo.CPALogSheets");
            DropTable("dbo.CPAFindingTypes");
            DropTable("dbo.CPAFindingNCTypeSubs");
            DropTable("dbo.CPAFindingNCTypes");
            DropTable("dbo.CPAFindingNatures");
            DropTable("dbo.CpaFcls");
        }
    }
}
