namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InqPaymentTermsRelationUpdate1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.IndDomesticInquiryDetails", "IndentId", "dbo.IndDomestics");
            //DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndentId" });
            //DropColumn("dbo.IndDomesticInquiryDetails", "IndentId");
            //DropColumn("dbo.IndDomesticInquiryDetails", "IndentKey");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.IndDomesticInquiryDetails", "IndentKey", c => c.String(nullable: false, maxLength: 10));
            //AddColumn("dbo.IndDomesticInquiryDetails", "IndentId", c => c.Int(nullable: false));
            //CreateIndex("dbo.IndDomesticInquiryDetails", "IndentId");
            //AddForeignKey("dbo.IndDomesticInquiryDetails", "IndentId", "dbo.IndDomestics", "Id", cascadeDelete: true);
        }
    }
}
