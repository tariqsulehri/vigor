namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFieldsExport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomestics", "CompanyId", c => c.String(maxLength: 3));
            AddColumn("dbo.IndDomestics", "IndentTypeId", c => c.String(maxLength: 1));
            AddColumn("dbo.IndExportInquiries", "Customer", c => c.String(maxLength: 100));
            AddColumn("dbo.IndExportInquiries", "IsClosed", c => c.String(maxLength: 1));
            AddColumn("dbo.IndExportInquiryDetails", "InquiryNoDetailIDRef", c => c.String(maxLength: 16));
            AddColumn("dbo.IndExportInquiryReviews", "InqReviewQuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.IndExportInquiryReviews", "CompanyKey", c => c.String(maxLength: 3));
            AlterColumn("dbo.IndExportInquiries", "Companyid", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.IndExportInquiries", "CustomerasBuyer", c => c.Int(nullable: false));
            AlterColumn("dbo.IndExportInquiries", "Remarks", c => c.String(maxLength: 1000));
            AlterColumn("dbo.IndExportInquiries", "InquieryStatus", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.IndExportInquiryDetails", "SaleContractIssued", c => c.String(maxLength: 10));
            CreateIndex("dbo.IndExportInquiryReviews", "InqReviewQuestionId");
            AddForeignKey("dbo.IndExportInquiryReviews", "InqReviewQuestionId", "dbo.IndInquiryReviewQuestions", "Id", cascadeDelete: true);
            DropColumn("dbo.IndExportInquiries", "InquiryClosed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndExportInquiries", "InquiryClosed", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.IndExportInquiryReviews", "InqReviewQuestionId", "dbo.IndInquiryReviewQuestions");
            DropIndex("dbo.IndExportInquiryReviews", new[] { "InqReviewQuestionId" });
            AlterColumn("dbo.IndExportInquiryDetails", "SaleContractIssued", c => c.String(maxLength: 15));
            AlterColumn("dbo.IndExportInquiries", "InquieryStatus", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.IndExportInquiries", "Remarks", c => c.String(maxLength: 200));
            AlterColumn("dbo.IndExportInquiries", "CustomerasBuyer", c => c.String(maxLength: 100));
            AlterColumn("dbo.IndExportInquiries", "Companyid", c => c.String());
            DropColumn("dbo.IndExportInquiryReviews", "CompanyKey");
            DropColumn("dbo.IndExportInquiryReviews", "InqReviewQuestionId");
            DropColumn("dbo.IndExportInquiryDetails", "InquiryNoDetailIDRef");
            DropColumn("dbo.IndExportInquiries", "IsClosed");
            DropColumn("dbo.IndExportInquiries", "Customer");
            DropColumn("dbo.IndDomestics", "IndentTypeId");
            DropColumn("dbo.IndDomestics", "CompanyId");
        }
    }
}
