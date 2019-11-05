namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPoNumberandSuppContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomestics", "IsSample", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndDomestics", "SuppContract", c => c.String(maxLength: 50));
            AddColumn("dbo.IndDomestics", "PONumber", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndDomestics", "PONumber");
            DropColumn("dbo.IndDomestics", "SuppContract");
            DropColumn("dbo.IndDomestics", "IsSample");
        }
    }
}
