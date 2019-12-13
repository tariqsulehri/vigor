namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fabInspExport : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FabricInspReportExport4PointDetails");
            AddColumn("dbo.FabricInspReportExport4PointDetails", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FabricInspReportExports", "HeadBands", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "ShadeVariation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "Stamped", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "ReedMarks", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "RubbingMarks", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "PolyYarn", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "Contamination", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "other", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "BuyerSampleStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "BuyerSampleDesign", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "PackingList", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "Marking", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "FaceMarking", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "PackingCondition", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExports", "ShipmentSample", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FabricInspReportExport4PointDetails", "InspectionSerialNo", c => c.String(maxLength: 8));
            AddPrimaryKey("dbo.FabricInspReportExport4PointDetails", "id");
            CreateIndex("dbo.FabricInspReportExport4PointDetails", "InspectionSerialNo");
            AddForeignKey("dbo.FabricInspReportExport4PointDetails", "InspectionSerialNo", "dbo.FabricInspReportExports", "InspectionSerialNoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FabricInspReportExport4PointDetails", "InspectionSerialNo", "dbo.FabricInspReportExports");
            DropIndex("dbo.FabricInspReportExport4PointDetails", new[] { "InspectionSerialNo" });
            DropPrimaryKey("dbo.FabricInspReportExport4PointDetails");
            AlterColumn("dbo.FabricInspReportExport4PointDetails", "InspectionSerialNo", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.FabricInspReportExports", "ShipmentSample", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "PackingCondition", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "FaceMarking", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "Marking", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "PackingList", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "BuyerSampleDesign", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "BuyerSampleStatus", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "other", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "Contamination", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "PolyYarn", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "RubbingMarks", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "ReedMarks", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "Stamped", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "ShadeVariation", c => c.String(maxLength: 1));
            AlterColumn("dbo.FabricInspReportExports", "HeadBands", c => c.String(maxLength: 1));
            DropColumn("dbo.FabricInspReportExport4PointDetails", "id");
            AddPrimaryKey("dbo.FabricInspReportExport4PointDetails", "InspectionSerialNo");
        }
    }
}
