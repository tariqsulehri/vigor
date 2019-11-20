namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndInquiryTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndentInfoes", "IndentDomestic_Id", "dbo.IndDomestics");
            DropIndex("dbo.IndentInfoes", new[] { "IndentDomestic_Id" });
            AddColumn("dbo.IndExportInquiryDetails", "CostingSheetRef", c => c.String(maxLength: 20));
            AddColumn("dbo.IndExportInquiryDetails", "CostingPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.IndExportInquiryDetails", "Status", c => c.String(maxLength: 1));
            DropColumn("dbo.IndentInfoes", "IndentDomestic_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndentInfoes", "IndentDomestic_Id", c => c.Int());
            DropColumn("dbo.IndExportInquiryDetails", "Status");
            DropColumn("dbo.IndExportInquiryDetails", "CostingPrice");
            DropColumn("dbo.IndExportInquiryDetails", "CostingSheetRef");
            CreateIndex("dbo.IndentInfoes", "IndentDomestic_Id");
            AddForeignKey("dbo.IndentInfoes", "IndentDomestic_Id", "dbo.IndDomestics", "Id");
        }
    }
}
