namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommTablesUpdation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommInvoiceAgentComms", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "CompanyId", "dbo.FinParties");
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "CompanyId" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CompanyId" });
            AddColumn("dbo.CommInvoiceAgentComms", "CommissionInvoiceNoKey", c => c.String(nullable: false, maxLength: 13));
            AddColumn("dbo.CommInvoiceAgentComms", "SalesContractCommCode", c => c.String(maxLength: 13));
            AddColumn("dbo.CommInvoiceAgentComms", "Company", c => c.String(maxLength: 3));
            AddColumn("dbo.CommInvoiceAgentComms", "CustomerIDCommPaidTo_Ref", c => c.String(maxLength: 6));
            AddColumn("dbo.CommInvoiceAgentComms", "CustomerIDCommPaidFrom_Ref", c => c.String(maxLength: 6));
            AddColumn("dbo.IndCommissionInvoices", "company", c => c.String(maxLength: 3));
            AddColumn("dbo.IndCommissionInvoices", "ShipmentScheduleShipmentNo", c => c.String(maxLength: 13));
            AddColumn("dbo.IndCommissionInvoiceDetails", "SalesContractDetailID_RefKey", c => c.String(maxLength: 13));
            AddColumn("dbo.IndCommissionInvoiceDetails", "IndentId", c => c.Int(nullable: false));
            AddColumn("dbo.IndCommissionInvoiceDetails", "IndentKey", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.IndCommissionInvoiceDetails", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.IndCommissionInvoiceDetails", "FinParty_Id", c => c.Int());
            AlterColumn("dbo.IndCommissionInvoiceDetails", "CompanyId", c => c.String(maxLength: 3));
            CreateIndex("dbo.IndCommissionInvoiceDetails", "IndentId");
            CreateIndex("dbo.IndCommissionInvoiceDetails", "FinParty_Id");
            AddForeignKey("dbo.IndCommissionInvoiceDetails", "IndentId", "dbo.IndDomestics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndCommissionInvoiceDetails", "FinParty_Id", "dbo.FinParties", "Id");
            DropColumn("dbo.CommInvoiceAgentComms", "SaleContractCommID");
            DropColumn("dbo.CommInvoiceAgentComms", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommInvoiceAgentComms", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.CommInvoiceAgentComms", "SaleContractCommID", c => c.String(nullable: false, maxLength: 13));
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "IndentId", "dbo.IndDomestics");
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "FinParty_Id" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "IndentId" });
            AlterColumn("dbo.IndCommissionInvoiceDetails", "CompanyId", c => c.Int(nullable: false));
            DropColumn("dbo.IndCommissionInvoiceDetails", "FinParty_Id");
            DropColumn("dbo.IndCommissionInvoiceDetails", "Quantity");
            DropColumn("dbo.IndCommissionInvoiceDetails", "IndentKey");
            DropColumn("dbo.IndCommissionInvoiceDetails", "IndentId");
            DropColumn("dbo.IndCommissionInvoiceDetails", "SalesContractDetailID_RefKey");
            DropColumn("dbo.IndCommissionInvoices", "ShipmentScheduleShipmentNo");
            DropColumn("dbo.IndCommissionInvoices", "company");
            DropColumn("dbo.CommInvoiceAgentComms", "CustomerIDCommPaidFrom_Ref");
            DropColumn("dbo.CommInvoiceAgentComms", "CustomerIDCommPaidTo_Ref");
            DropColumn("dbo.CommInvoiceAgentComms", "Company");
            DropColumn("dbo.CommInvoiceAgentComms", "SalesContractCommCode");
            DropColumn("dbo.CommInvoiceAgentComms", "CommissionInvoiceNoKey");
            CreateIndex("dbo.IndCommissionInvoiceDetails", "CompanyId");
            CreateIndex("dbo.CommInvoiceAgentComms", "CompanyId");
            AddForeignKey("dbo.IndCommissionInvoiceDetails", "CompanyId", "dbo.FinParties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommInvoiceAgentComms", "CompanyId", "dbo.FinParties", "Id", cascadeDelete: true);
        }
    }
}
