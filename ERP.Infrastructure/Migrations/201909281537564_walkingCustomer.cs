namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class walkingCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomesticInquiries", "WalkingCustomer", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndDomesticInquiries", "WalkingCustomer");
        }
    }
}
