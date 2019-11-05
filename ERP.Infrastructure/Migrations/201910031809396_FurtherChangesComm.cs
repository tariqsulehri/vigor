namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurtherChangesComm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommInvoiceAgentComms", "CompanyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommInvoiceAgentComms", "CompanyId");
        }
    }
}
