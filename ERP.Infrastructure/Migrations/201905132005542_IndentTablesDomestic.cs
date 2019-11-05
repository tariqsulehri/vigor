namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndentTablesDomestic : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries");
            AddColumn("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", c => c.Int());
            CreateIndex("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id");
            AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomestics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomestics");
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndDomesticInquiry_Id" });
            DropColumn("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id");
            AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries", "Id", cascadeDelete: true);
        }
    }
}
