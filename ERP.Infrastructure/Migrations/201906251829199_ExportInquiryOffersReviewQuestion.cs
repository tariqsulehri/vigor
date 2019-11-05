namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExportInquiryOffersReviewQuestion : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.IndExportInquiryOffers",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                InquiryId = c.Int(nullable: false),
        //                InquiryKey = c.String(nullable: false, maxLength: 13),
        //                OfferMadeOn = c.DateTime(nullable: false),
        //                CustomerId = c.Int(nullable: false),
        //                OfferedBy = c.String(nullable: false, maxLength: 50),
        //                OfferedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                PaymentTermsId = c.Int(nullable: false),
        //                Remarks = c.String(nullable: false, maxLength: 200),
        //                CreatedBy = c.Int(nullable: false),
        //                CreatedOn = c.DateTime(nullable: false),
        //                ModifiedBy = c.Int(nullable: false),
        //                ModifiedOn = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
        //        .ForeignKey("dbo.IndExportInquiries", t => t.InquiryId, cascadeDelete: false)
        //        .ForeignKey("dbo.IndPaymentTerms", t => t.PaymentTermsId, cascadeDelete: false)
        //        .Index(t => t.InquiryId)
        //        .Index(t => t.CustomerId)
        //        .Index(t => t.PaymentTermsId);
            
        //    CreateTable(
        //        "dbo.IndExportInquiryReviews",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                InquiryReviewQuestion = c.String(nullable: false, maxLength: 250),
        //                InquiryId = c.Int(nullable: false),
        //                InquiryKey = c.String(nullable: false, maxLength: 13),
        //                Status = c.Boolean(nullable: false),
        //                CreatedBy = c.Int(nullable: false),
        //                CreatedOn = c.DateTime(nullable: false),
        //                ModifiedBy = c.Int(nullable: false),
        //                ModifiedOn = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.IndExportInquiries", t => t.InquiryId, cascadeDelete: true)
        //        .Index(t => t.InquiryId);
            
        //    CreateTable(
        //        "dbo.IndExportInquiryReviewQuestions",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                InquiryReviewQuestion = c.String(nullable: false, maxLength: 150),
        //                IsActive = c.Boolean(nullable: false),
        //                ForMarket = c.String(maxLength: 1),
        //                IndExportInquiryReview_Id = c.Int(),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.IndExportInquiryReviews", t => t.IndExportInquiryReview_Id)
        //        .Index(t => t.IndExportInquiryReview_Id);
            
        //}
        
        //public override void Down()
        //{
        //    DropForeignKey("dbo.IndExportInquiryReviewQuestions", "IndExportInquiryReview_Id", "dbo.IndExportInquiryReviews");
        //    DropForeignKey("dbo.IndExportInquiryReviews", "InquiryId", "dbo.IndExportInquiries");
        //    DropForeignKey("dbo.IndExportInquiryOffers", "PaymentTermsId", "dbo.IndPaymentTerms");
        //    DropForeignKey("dbo.IndExportInquiryOffers", "InquiryId", "dbo.IndExportInquiries");
        //    DropForeignKey("dbo.IndExportInquiryOffers", "CustomerId", "dbo.FinParties");
        //    DropIndex("dbo.IndExportInquiryReviewQuestions", new[] { "IndExportInquiryReview_Id" });
        //    DropIndex("dbo.IndExportInquiryReviews", new[] { "InquiryId" });
        //    DropIndex("dbo.IndExportInquiryOffers", new[] { "PaymentTermsId" });
        //    DropIndex("dbo.IndExportInquiryOffers", new[] { "CustomerId" });
        //    DropIndex("dbo.IndExportInquiryOffers", new[] { "InquiryId" });
        //    DropTable("dbo.IndExportInquiryReviewQuestions");
        //    DropTable("dbo.IndExportInquiryReviews");
        //    DropTable("dbo.IndExportInquiryOffers");
        }
    }
}
