namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FabExport_detail_merge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FabricInspReportExports", "InspectionTypePerformed", c => c.String(maxLength: 25));
            AddColumn("dbo.FabricInspReportExports", "Construction", c => c.String(maxLength: 50));
            AddColumn("dbo.FabricInspReportExports", "IC_quantitiesSubmitted", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "IC_Style", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "IC_Workmanship", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "IC_Packing", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "IC_Marking", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "IC_DataMeasurement", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "PC_Style", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "PC_Material", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "PC_Color", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "PC_Griege", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ReferenceSample", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "PieceLengthCheck", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "PieceLength", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "RollsLengthCheck", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "SizeMeasurement", c => c.String(maxLength: 20));
            AddColumn("dbo.FabricInspReportExports", "IndividualPacking", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "InnerPacking", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ExportPacking", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "PackingAssortment", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "ML_BarCode", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_ShippingMarks", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_OtherMarks", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_SideMark", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_MainLabel", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_Care", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_Size", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_Country", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_HangTag", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_PolyBag", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_InnerBox", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "ML_OtherLabel", c => c.String(maxLength: 1));
            AddColumn("dbo.FabricInspReportExports", "Lighting", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "LightingStatus", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "InspectionPlace", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "InspectionDoneOn", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "Cleanliness", c => c.String(maxLength: 200));
            AddColumn("dbo.FabricInspReportExports", "WeatherCondition", c => c.String(maxLength: 200));
            AlterColumn("dbo.FabricInspReportExports", "Width", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FabricInspReportExports", "Width", c => c.Decimal(precision: 18, scale: 2, storeType: "numeric"));
            DropColumn("dbo.FabricInspReportExports", "WeatherCondition");
            DropColumn("dbo.FabricInspReportExports", "Cleanliness");
            DropColumn("dbo.FabricInspReportExports", "InspectionDoneOn");
            DropColumn("dbo.FabricInspReportExports", "InspectionPlace");
            DropColumn("dbo.FabricInspReportExports", "LightingStatus");
            DropColumn("dbo.FabricInspReportExports", "Lighting");
            DropColumn("dbo.FabricInspReportExports", "ML_OtherLabel");
            DropColumn("dbo.FabricInspReportExports", "ML_InnerBox");
            DropColumn("dbo.FabricInspReportExports", "ML_PolyBag");
            DropColumn("dbo.FabricInspReportExports", "ML_HangTag");
            DropColumn("dbo.FabricInspReportExports", "ML_Country");
            DropColumn("dbo.FabricInspReportExports", "ML_Size");
            DropColumn("dbo.FabricInspReportExports", "ML_Care");
            DropColumn("dbo.FabricInspReportExports", "ML_MainLabel");
            DropColumn("dbo.FabricInspReportExports", "ML_SideMark");
            DropColumn("dbo.FabricInspReportExports", "ML_OtherMarks");
            DropColumn("dbo.FabricInspReportExports", "ML_ShippingMarks");
            DropColumn("dbo.FabricInspReportExports", "ML_BarCode");
            DropColumn("dbo.FabricInspReportExports", "PackingAssortment");
            DropColumn("dbo.FabricInspReportExports", "ExportPacking");
            DropColumn("dbo.FabricInspReportExports", "InnerPacking");
            DropColumn("dbo.FabricInspReportExports", "IndividualPacking");
            DropColumn("dbo.FabricInspReportExports", "SizeMeasurement");
            DropColumn("dbo.FabricInspReportExports", "RollsLengthCheck");
            DropColumn("dbo.FabricInspReportExports", "PieceLength");
            DropColumn("dbo.FabricInspReportExports", "PieceLengthCheck");
            DropColumn("dbo.FabricInspReportExports", "ReferenceSample");
            DropColumn("dbo.FabricInspReportExports", "PC_Griege");
            DropColumn("dbo.FabricInspReportExports", "PC_Color");
            DropColumn("dbo.FabricInspReportExports", "PC_Material");
            DropColumn("dbo.FabricInspReportExports", "PC_Style");
            DropColumn("dbo.FabricInspReportExports", "IC_DataMeasurement");
            DropColumn("dbo.FabricInspReportExports", "IC_Marking");
            DropColumn("dbo.FabricInspReportExports", "IC_Packing");
            DropColumn("dbo.FabricInspReportExports", "IC_Workmanship");
            DropColumn("dbo.FabricInspReportExports", "IC_Style");
            DropColumn("dbo.FabricInspReportExports", "IC_quantitiesSubmitted");
            DropColumn("dbo.FabricInspReportExports", "Construction");
            DropColumn("dbo.FabricInspReportExports", "InspectionTypePerformed");
        }
    }
}
