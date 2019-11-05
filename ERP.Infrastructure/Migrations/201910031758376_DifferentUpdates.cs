namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DifferentUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FabricInspReportLocals", "InspectionSerialNoID", c => c.String(maxLength: 8));
            AddColumn("dbo.FabricInspTypes", "TypeofFabric_Ref", c => c.String(maxLength: 2));
            AddColumn("dbo.IndCommissions", "CustomerIdCommPaidTo_Ref", c => c.String(maxLength: 6));
            AddColumn("dbo.IndCommissions", "CustomerIdCommPaidFrom_Ref", c => c.String(maxLength: 6));
            AddColumn("dbo.IndCommissions", "CompanyId_Ref", c => c.String(maxLength: 3));
            DropColumn("dbo.FabricInspTypes", "CreatedBy");
            DropColumn("dbo.FabricInspTypes", "CreatedOn");
            DropColumn("dbo.FabricInspTypes", "ModifiedBy");
            DropColumn("dbo.FabricInspTypes", "ModifiedOn");
            DropColumn("dbo.CommInvoiceAgentComms", "CompanyId");
            DropColumn("dbo.IndCommissions", "CreatedBy");
            DropColumn("dbo.IndCommissions", "CreatedOn");
            DropColumn("dbo.IndCommissions", "ModifiedBy");
            DropColumn("dbo.IndCommissions", "ModifiedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndCommissions", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.IndCommissions", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.IndCommissions", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.IndCommissions", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.CommInvoiceAgentComms", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.FabricInspTypes", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FabricInspTypes", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FabricInspTypes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FabricInspTypes", "CreatedBy", c => c.Int(nullable: false));
            DropColumn("dbo.IndCommissions", "CompanyId_Ref");
            DropColumn("dbo.IndCommissions", "CustomerIdCommPaidFrom_Ref");
            DropColumn("dbo.IndCommissions", "CustomerIdCommPaidTo_Ref");
            DropColumn("dbo.FabricInspTypes", "TypeofFabric_Ref");
            DropColumn("dbo.FabricInspReportLocals", "InspectionSerialNoID");
        }
    }
}
