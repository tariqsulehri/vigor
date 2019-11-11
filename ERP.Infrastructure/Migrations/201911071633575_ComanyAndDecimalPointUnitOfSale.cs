namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComanyAndDecimalPointUnitOfSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "LocalCurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "ForeignCurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "domesticAgentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "domesticAgentID");
            DropColumn("dbo.Companies", "ForeignCurrencyId");
            DropColumn("dbo.Companies", "LocalCurrencyId");
        }
    }
}
