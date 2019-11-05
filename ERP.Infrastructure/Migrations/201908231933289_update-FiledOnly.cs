namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFiledOnly : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndInquiryReviewQuestions", "IndDomesticInquiryReview_Id", "dbo.IndDomesticInquiryReviews");
            DropIndex("dbo.IndInquiryReviewQuestions", new[] { "IndDomesticInquiryReview_Id" });
            CreateTable(
                "dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews",
                c => new
                    {
                        IndInquiryReviewQuestion_Id = c.Int(nullable: false),
                        IndDomesticInquiryReview_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IndInquiryReviewQuestion_Id, t.IndDomesticInquiryReview_Id })
                .ForeignKey("dbo.IndInquiryReviewQuestions", t => t.IndInquiryReviewQuestion_Id)
                .ForeignKey("dbo.IndDomesticInquiryReviews", t => t.IndDomesticInquiryReview_Id)
                .Index(t => t.IndInquiryReviewQuestion_Id)
                .Index(t => t.IndDomesticInquiryReview_Id);
            
            AddColumn("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.IndDomesticInquiryReviews", "InquiryReviewQuestion");
            DropColumn("dbo.IndInquiryReviewQuestions", "IndDomesticInquiryReview_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndInquiryReviewQuestions", "IndDomesticInquiryReview_Id", c => c.Int());
            AddColumn("dbo.IndDomesticInquiryReviews", "InquiryReviewQuestion", c => c.String(nullable: false, maxLength: 250));
            DropForeignKey("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndDomesticInquiryReview_Id", "dbo.IndDomesticInquiryReviews");
            DropForeignKey("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", "IndInquiryReviewQuestion_Id", "dbo.IndInquiryReviewQuestions");
            DropIndex("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", new[] { "IndDomesticInquiryReview_Id" });
            DropIndex("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews", new[] { "IndInquiryReviewQuestion_Id" });
            DropColumn("dbo.IndDomesticInquiryReviews", "InqReviewQuestionId");
            DropTable("dbo.IndInquiryReviewQuestionIndDomesticInquiryReviews");
            CreateIndex("dbo.IndInquiryReviewQuestions", "IndDomesticInquiryReview_Id");
            AddForeignKey("dbo.IndInquiryReviewQuestions", "IndDomesticInquiryReview_Id", "dbo.IndDomesticInquiryReviews", "Id");
        }
    }
}
