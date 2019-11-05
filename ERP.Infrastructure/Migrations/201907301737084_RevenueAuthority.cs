namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevenueAuthority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesTaxOffices", "code", c => c.String(nullable: false, maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesTaxOffices", "code");
        }
    }
}
