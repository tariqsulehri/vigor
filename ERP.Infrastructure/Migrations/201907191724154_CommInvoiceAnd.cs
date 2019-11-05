namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommInvoiceAnd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeptDealsInCommodityTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        ComodityType = c.Int(nullable: false),
                        ComodityTypeName = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CommodityTypes", t => t.ComodityType, cascadeDelete: true)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.ComodityType);
            
            CreateTable(
                "dbo.DeptDealsInMarkeets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        DealsInId = c.Int(nullable: false),
                        MarkeetName = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.MarkeetDealsIns", t => t.DealsInId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DealsInId);
            
            CreateTable(
                "dbo.MarkeetDealsIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 30),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeptDealsInCommodityTypes", "DepartmentId", "dbo.HrDepartments");
            DropForeignKey("dbo.DeptDealsInMarkeets", "DealsInId", "dbo.MarkeetDealsIns");
            DropForeignKey("dbo.DeptDealsInMarkeets", "DepartmentId", "dbo.HrDepartments");
            DropForeignKey("dbo.DeptDealsInCommodityTypes", "ComodityType", "dbo.CommodityTypes");
            DropIndex("dbo.DeptDealsInMarkeets", new[] { "DealsInId" });
            DropIndex("dbo.DeptDealsInMarkeets", new[] { "DepartmentId" });
            DropIndex("dbo.DeptDealsInCommodityTypes", new[] { "ComodityType" });
            DropIndex("dbo.DeptDealsInCommodityTypes", new[] { "DepartmentId" });
            DropTable("dbo.MarkeetDealsIns");
            DropTable("dbo.DeptDealsInMarkeets");
            DropTable("dbo.DeptDealsInCommodityTypes");
        }
    }
}
