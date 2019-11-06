namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndDomesticAndHrUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndExportInquiryDetails", "InquiryDetailNo", c => c.String(nullable: false, maxLength: 16));
            AddColumn("dbo.IndExportInquiryOffers", "InquiryDetailNo", c => c.String(nullable: false, maxLength: 16));
            AddColumn("dbo.IndExportInquiryOffers", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndExportInquiryOffers", "ProductId");
            DropColumn("dbo.IndExportInquiryOffers", "InquiryDetailNo");
            DropColumn("dbo.IndExportInquiryDetails", "InquiryDetailNo");
        }
    }
}
