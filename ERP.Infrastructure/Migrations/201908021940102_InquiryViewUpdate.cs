namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InquiryViewUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndDomesticInquiries", "IsClosed", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndDomesticInquiries", "IsClosed", c => c.Boolean(nullable: false));
        }
    }
}
