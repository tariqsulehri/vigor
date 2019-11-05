namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InquiryRelationUpdate : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.IndDomesticInquiryDetails", "InquiryId");
            //AddColumn("dbo.IndDomesticInquiryDetails", "IndentId", c => c.Int(nullable: false));
            //AddColumn("dbo.IndDomesticInquiryDetails", "IndentKey", c => c.String(nullable: false, maxLength: 10));
            //AlterColumn("dbo.IndDomesticInquiryDetails", "InquiryId", c => c.Int(nullable: false));
            //CreateIndex("dbo.IndDomesticInquiryDetails", "IndentId");
            ////CreateIndex("dbo.IndDomesticInquiryDetails", "InquiryId");
            //AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries", "Id", cascadeDelete: false);
            //AddForeignKey("dbo.IndDomesticInquiryDetails", "IndentId", "dbo.IndDomestics", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.IndDomesticInquiryDetails", "IndentId", "dbo.IndDomestics");
            //DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomesticInquiries");
            //DropIndex("dbo.IndDomesticInquiryDetails", new[] { "InquiryId" });
           // DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndentId" });
          //  AlterColumn("dbo.IndDomesticInquiryDetails", "InquiryId", c => c.Int());
            //DropColumn("dbo.IndDomesticInquiryDetails", "IndentKey");
            //DropColumn("dbo.IndDomesticInquiryDetails", "IndentId");
            //AddColumn("dbo.IndDomesticInquiryDetails", "InquiryId", c => c.Int(nullable: false));
           // CreateIndex("dbo.IndDomesticInquiryDetails", "InquiryId");
           // AddForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomestics", "Id", cascadeDelete: false);
            //AddForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries", "Id");
        }
    }
}
