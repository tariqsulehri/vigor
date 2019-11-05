namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewQuestionAndOtherChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndInquiryReviewQuestion_Id", "dbo.IndInquiryReviewQuestions");
            DropForeignKey("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndDomesticInquiryReview_Id", "dbo.IndDomesticInquiryReviews");
            DropIndex("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", new[] { "IndInquiryReviewQuestion_Id" });
            DropIndex("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", new[] { "IndDomesticInquiryReview_Id" });
            AddColumn("dbo.IndDomesticInquiryReviews", "BuyerId", c => c.Int(nullable: false));
            AddColumn("dbo.IndDomesticInquiryReviews", "SellerId", c => c.Int(nullable: false));
            AlterColumn("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId");
            AddForeignKey("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId", "dbo.IndInquiryReviewQuestions", "Id", cascadeDelete: false);
            DropTable("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews",
                c => new
                    {
                        IndInquiryReviewQuestion_Id = c.Int(nullable: false),
                        IndDomesticInquiryReview_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IndInquiryReviewQuestion_Id, t.IndDomesticInquiryReview_Id });
            
            DropForeignKey("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId", "dbo.IndInquiryReviewQuestions");
            DropIndex("dbo.IndDomesticInquiryReviews", new[] { "InqReviewQuestionId" });
            AlterColumn("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.IndDomesticInquiryReviews", "SellerId");
            DropColumn("dbo.IndDomesticInquiryReviews", "BuyerId");
            CreateIndex("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndDomesticInquiryReview_Id");
            CreateIndex("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndInquiryReviewQuestion_Id");
            AddForeignKey("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndDomesticInquiryReview_Id", "dbo.IndDomesticInquiryReviews", "Id");
            AddForeignKey("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndInquiryReviewQuestion_Id", "dbo.IndInquiryReviewQuestions", "Id");
        }
    }
}
