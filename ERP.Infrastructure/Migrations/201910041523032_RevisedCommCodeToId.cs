namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevisedCommCodeToId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommInvoiceAgentComms", "SaleContractCommID", c => c.String(nullable: false, maxLength: 13));
            DropColumn("dbo.CommInvoiceAgentComms", "SalesContractCommCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommInvoiceAgentComms", "SalesContractCommCode", c => c.String(maxLength: 13));
            DropColumn("dbo.CommInvoiceAgentComms", "SaleContractCommID");
        }
    }
}
