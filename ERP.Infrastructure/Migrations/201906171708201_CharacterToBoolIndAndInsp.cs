namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterToBoolIndAndInsp : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.IndDomestics", "IndentStatus", c => c.Boolean(nullable: false));
            //AddColumn("dbo.IndDomestics", "NodePatch", c => c.Boolean(nullable: false));
            //AddColumn("dbo.IndDomestics", "isClosed", c => c.Boolean(nullable: false));
            //AddColumn("dbo.IndDomestics", "IsUpdated", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "HeadBands", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "ShadeVarivation", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "Stamped", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "ReadMarks", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "RubbingMarks", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "PolyYarn", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "Contination", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "Others", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "BuyerSampleStatus", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "BuyerSampleDesign", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "PickList", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "Marking", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "FaceMarking", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "PackingConditions", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.FabricInspReportLocals", "ShipmentSample", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.IndDomestics", "IsApproved", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.IndDomestics", "IsSubmitForApproval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.IndDomestics", "IsSubmitForApproval", c => c.String(maxLength: 1));
            //AlterColumn("dbo.IndDomestics", "IsApproved", c => c.String(maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "ShipmentSample", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "PackingConditions", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "FaceMarking", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "Marking", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "PickList", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "BuyerSampleDesign", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "BuyerSampleStatus", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "Others", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "Contination", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "PolyYarn", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "RubbingMarks", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "ReadMarks", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "Stamped", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "ShadeVarivation", c => c.String(nullable: false, maxLength: 1));
            //AlterColumn("dbo.FabricInspReportLocals", "HeadBands", c => c.String(nullable: false, maxLength: 1));
            //DropColumn("dbo.IndDomestics", "IsUpdated");
            //DropColumn("dbo.IndDomestics", "isClosed");
            //DropColumn("dbo.IndDomestics", "NodePatch");
            //DropColumn("dbo.IndDomestics", "IndentStatus");
        }
    }
}
