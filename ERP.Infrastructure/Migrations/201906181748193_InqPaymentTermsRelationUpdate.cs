namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InqPaymentTermsRelationUpdate : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.IndDomesticInquiries", new[] { "PaymenTermsId" });
            //DropColumn("dbo.IndDomesticInquiries", "PaymenTermsId");
            //RenameColumn(table: "dbo.IndDomesticInquiries", name: "IndPaymentTerms_Id", newName: "PaymenTermsId");
            //AlterColumn("dbo.IndDomesticInquiries", "PaymenTermsId", c => c.Int(nullable: false));
           // CreateIndex("dbo.IndDomesticInquiries", "PaymenTermsId");
            //AddForeignKey("dbo.IndDomesticInquiries", "PaymenTermsId", "dbo.IndPaymentTerms", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
           // DropForeignKey("dbo.IndDomesticInquiries", "PaymenTermsId", "dbo.IndPaymentTerms");
            //DropIndex("dbo.IndDomesticInquiries", new[] { "PaymenTermsId" });
            //AlterColumn("dbo.IndDomesticInquiries", "PaymenTermsId", c => c.Int());
            //AddColumn("dbo.IndDomesticInquiries", "PaymenTermsId", c => c.Int(nullable: false));
            //CreateIndex("dbo.IndDomesticInquiries", "PaymenTermsId");
        }
    }
}
