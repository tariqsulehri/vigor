namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndentDomesticPaymentAddOn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.IndPaymentTerms", "IX_PaymentTerms_Indent");
            CreateTable(
                "dbo.IndDomesticPaymentAddOns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionNo = c.String(nullable: false, maxLength: 13),
                        SerialNumber = c.Int(nullable: false),
                        LocalDispatchNo = c.Int(nullable: false),
                        LocalDispatchKey = c.String(nullable: false, maxLength: 13),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetReceviable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        AddOnType = c.String(nullable: false, maxLength: 2),
                        AddOnEffect = c.String(nullable: false, maxLength: 2),
                        DomesticPaymentAddonCalculatedOn = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomesticDispatchSchedules", t => t.LocalDispatchNo, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.LocalDispatchNo)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.IndDomestics", "InvoiceNo", c => c.String(nullable: false, maxLength: 13));
            AddColumn("dbo.IndDomestics", "InvoiceDueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.IndDomesticInquiries", "CurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.IndDomesticInquiries", "InquieryStatus", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.IndDomesticInquiries", "InquiryClosed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndDomesticInquiryDetails", "NewCommodity", c => c.String(maxLength: 13));
            AddColumn("dbo.IndDomesticInquiryDetails", "WalkInCustomer", c => c.String(maxLength: 100));
            AddColumn("dbo.IndExportInquiries", "InquiryMarket", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.IndExportInquiries", "InquieryStatus", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.IndExportInquiries", "InquiryClosed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndExportInquiries", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("dbo.FinParties", "CompanyName", c => c.String());
            AlterColumn("dbo.IndPaymentTerms", "Description", c => c.String(nullable: false, maxLength: 250));
            CreateIndex("dbo.IndDomesticInquiries", "CurrencyId");
            CreateIndex("dbo.IndExportInquiries", "CurrencyId");
            //CreateIndex("dbo.IndPaymentTerms", "Description", unique: true, name: "IX_PaymentTerms_Indent");
            AddForeignKey("dbo.IndExportInquiries", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndDomesticInquiries", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndDomesticInquiries", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.IndExportInquiries", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.IndDomesticPaymentAddOns", "ProductId", "dbo.Products");
            DropForeignKey("dbo.IndDomesticPaymentAddOns", "LocalDispatchNo", "dbo.IndDomesticDispatchSchedules");
            DropIndex("dbo.IndPaymentTerms", "IX_PaymentTerms_Indent");
            DropIndex("dbo.IndExportInquiries", new[] { "CurrencyId" });
            DropIndex("dbo.IndDomesticPaymentAddOns", new[] { "ProductId" });
            DropIndex("dbo.IndDomesticPaymentAddOns", new[] { "LocalDispatchNo" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "CurrencyId" });
            AlterColumn("dbo.IndPaymentTerms", "Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FinParties", "CompanyName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.IndExportInquiries", "CurrencyId");
            DropColumn("dbo.IndExportInquiries", "InquiryClosed");
            DropColumn("dbo.IndExportInquiries", "InquieryStatus");
            DropColumn("dbo.IndExportInquiries", "InquiryMarket");
            DropColumn("dbo.IndDomesticInquiryDetails", "WalkInCustomer");
            DropColumn("dbo.IndDomesticInquiryDetails", "NewCommodity");
            DropColumn("dbo.IndDomesticInquiries", "InquiryClosed");
            DropColumn("dbo.IndDomesticInquiries", "InquieryStatus");
            DropColumn("dbo.IndDomesticInquiries", "CurrencyId");
            DropColumn("dbo.IndDomestics", "InvoiceDueDate");
            DropColumn("dbo.IndDomestics", "InvoiceNo");
            DropTable("dbo.IndDomesticPaymentAddOns");
            CreateIndex("dbo.IndPaymentTerms", "Description", unique: true, name: "IX_PaymentTerms_Indent");
        }
    }
}
