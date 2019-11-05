namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailAndEfilingEfilingDovTypeEtc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailContractApprovals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        FromEmail = c.String(maxLength: 50),
                        ToEmail = c.String(maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                        comments = c.String(maxLength: 1000),
                        approved = c.Boolean(nullable: false),
                        emailComments = c.Boolean(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        ApprovedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndentInspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(maxLength: 10),
                        InspSrno = c.String(maxLength: 11),
                        SalesContractDetail = c.String(maxLength: 13),
                        CommodityTypeId = c.Int(nullable: false),
                        DispatchId = c.Int(nullable: false),
                        LocalDispatchKey = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityTypeId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.DispatchId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.CommodityTypeId)
                .Index(t => t.DispatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndentInspections", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndentInspections", "DispatchId", "dbo.IndDomesticDispatchSchedules");
            DropForeignKey("dbo.IndentInspections", "CommodityTypeId", "dbo.CommodityTypes");
            DropIndex("dbo.IndentInspections", new[] { "DispatchId" });
            DropIndex("dbo.IndentInspections", new[] { "CommodityTypeId" });
            DropIndex("dbo.IndentInspections", new[] { "IndentId" });
            DropTable("dbo.IndentInspections");
            DropTable("dbo.EmailContractApprovals");
        }
    }
}
