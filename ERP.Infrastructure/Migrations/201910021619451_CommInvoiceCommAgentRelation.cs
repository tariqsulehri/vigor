namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommInvoiceCommAgentRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommInvoiceAgentComms", "CommissionInvoiceNo", c => c.Int(nullable: false));
            AddColumn("dbo.CommInvoiceAgentComms", "CommissionInvoiceKey", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.CommInvoiceAgentComms", "CommissionInvoiceNo");
            AddForeignKey("dbo.CommInvoiceAgentComms", "CommissionInvoiceNo", "dbo.IndCommissionInvoices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommInvoiceAgentComms", "CommissionInvoiceNo", "dbo.IndCommissionInvoices");
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "CommissionInvoiceNo" });
            DropColumn("dbo.CommInvoiceAgentComms", "CommissionInvoiceKey");
            DropColumn("dbo.CommInvoiceAgentComms", "CommissionInvoiceNo");
        }
    }
}
