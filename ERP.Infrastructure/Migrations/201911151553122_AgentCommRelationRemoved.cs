namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgentCommRelationRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommInvoiceAgentComms", "IndentId", "dbo.IndDomestics");
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "IndentId" });
            AddColumn("dbo.CommInvoiceAgentComms", "IndDomestic_Id", c => c.Int());
            CreateIndex("dbo.CommInvoiceAgentComms", "IndDomestic_Id");
            AddForeignKey("dbo.CommInvoiceAgentComms", "IndDomestic_Id", "dbo.IndDomestics", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommInvoiceAgentComms", "IndDomestic_Id", "dbo.IndDomestics");
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "IndDomestic_Id" });
            DropColumn("dbo.CommInvoiceAgentComms", "IndDomestic_Id");
            CreateIndex("dbo.CommInvoiceAgentComms", "IndentId");
            AddForeignKey("dbo.CommInvoiceAgentComms", "IndentId", "dbo.IndDomestics", "Id", cascadeDelete: true);
        }
    }
}
