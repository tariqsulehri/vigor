namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fabLocalInspReqRemove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FabricInspReportLocals", "Remarks", c => c.String(maxLength: 1000));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeWeaves", c => c.String(maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeIdentify", c => c.String(maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeBindingWidth", c => c.String(maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeSize", c => c.String(maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "YarnSupplyWrap", c => c.String(maxLength: 50));
            AlterColumn("dbo.FabricInspReportLocals", "YarnSupplyWeft", c => c.String(maxLength: 50));
            AlterColumn("dbo.FabricInspReportLocals", "WrapDirection", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FabricInspReportLocals", "WrapDirection", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FabricInspReportLocals", "YarnSupplyWeft", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FabricInspReportLocals", "YarnSupplyWrap", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeSize", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeBindingWidth", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeIdentify", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.FabricInspReportLocals", "SelvedgeWeaves", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.FabricInspReportLocals", "Remarks", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
