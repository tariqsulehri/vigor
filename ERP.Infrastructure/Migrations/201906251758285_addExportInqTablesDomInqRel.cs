namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExportInqTablesDomInqRel : DbMigration
    {
        public override void Up()
        {
        //    DropForeignKey("dbo.IndDomestics", "InquiryId", "dbo.IndDomesticInquiries");
        //    DropIndex("dbo.IndDomestics", new[] { "InquiryId" });
        //    CreateTable(
        //        "dbo.IndExportInquiries",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                InquiryKey = c.String(nullable: false, maxLength: 13),
        //                Companyid = c.String(),
        //                DepartmentID = c.Int(nullable: false),
        //                CommodityTypeId = c.Int(nullable: false),
        //                InquiryDate = c.DateTime(nullable: false),
        //                InquiryClosedDate = c.DateTime(),
        //                CustomerId = c.Int(nullable: false),
        //                PaymenTermsId = c.Int(nullable: false),
        //                PriceTermsId = c.Int(nullable: false),
        //                Remarks = c.String(maxLength: 200),
        //                Destination = c.String(maxLength: 200),
        //                Shipment = c.String(maxLength: 200),
        //                Programm = c.String(maxLength: 250),
        //                InquiryInfoCompletedOn = c.DateTime(),
        //                CreatedBy = c.Int(nullable: false),
        //                CreatedOn = c.DateTime(nullable: false),
        //                ModifiedBy = c.Int(nullable: false),
        //                ModifiedOn = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.CommodityTypes", t => t.CommodityTypeId, cascadeDelete: true)
        //        .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: true)
        //        .ForeignKey("dbo.HrDepartments", t => t.DepartmentID, cascadeDelete: true)
        //        .ForeignKey("dbo.IndPaymentTerms", t => t.PaymenTermsId, cascadeDelete: true)
        //        .ForeignKey("dbo.IndPriceTerms", t => t.PriceTermsId, cascadeDelete: true)
        //        .Index(t => t.DepartmentID)
        //        .Index(t => t.CommodityTypeId)
        //        .Index(t => t.CustomerId)
        //        .Index(t => t.PaymenTermsId)
        //        .Index(t => t.PriceTermsId);
            
        //    CreateTable(
        //        "dbo.IndExportInquiryDetails",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                InquiryId = c.Int(nullable: false),
        //                InquiryKey = c.String(nullable: false, maxLength: 13),
        //                ProductId = c.Int(nullable: false),
        //                Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                UosId = c.Int(nullable: false),
        //                InquiryLineItemRemarks = c.String(maxLength: 150),
        //                SaleContractIssued = c.String(maxLength: 15),
        //                SizeAndSpecification = c.String(maxLength: 200),
        //                isSampleRecevied = c.Boolean(nullable: false),
        //                fabricDetail = c.Boolean(nullable: false),
        //                packingDetail = c.Boolean(nullable: false),
        //                trimDetail = c.Boolean(nullable: false),
        //                colorPantoneCode = c.Boolean(nullable: false),
        //                internalCosting = c.Boolean(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.IndExportInquiries", t => t.InquiryId, cascadeDelete: true)
        //        .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
        //        .ForeignKey("dbo.UnitOfSales", t => t.UosId, cascadeDelete: true)
        //        .Index(t => t.InquiryId)
        //        .Index(t => t.ProductId)
        //        .Index(t => t.UosId);
            
        //    AddColumn("dbo.IndDomestics", "isCancelled", c => c.Boolean(nullable: false));
        //    AddColumn("dbo.IndDomestics", "isShipments", c => c.Boolean(nullable: false));
        //    AddColumn("dbo.IndDomestics", "isInvoiced", c => c.Boolean(nullable: false));
        //    AddColumn("dbo.IndDomestics", "FabricWeight", c => c.String(maxLength: 50));
        //    AddColumn("dbo.IndDomestics", "BlendRatio", c => c.String(maxLength: 50));
        //    AddColumn("dbo.IndDomesticInquiries", "IndPriceTerms_Id", c => c.Int());
        //    AlterColumn("dbo.IndDomesticDetails", "TypeColor", c => c.String());
        //    CreateIndex("dbo.IndDomesticInquiries", "IndPriceTerms_Id");
        //    AddForeignKey("dbo.IndDomesticInquiries", "IndPriceTerms_Id", "dbo.IndPriceTerms", "Id");
        //}
        
        //public override void Down()
        //{
        //    DropForeignKey("dbo.IndExportInquiries", "PriceTermsId", "dbo.IndPriceTerms");
        //    DropForeignKey("dbo.IndDomesticInquiries", "IndPriceTerms_Id", "dbo.IndPriceTerms");
        //    DropForeignKey("dbo.IndExportInquiries", "PaymenTermsId", "dbo.IndPaymentTerms");
        //    DropForeignKey("dbo.IndExportInquiryDetails", "UosId", "dbo.UnitOfSales");
        //    DropForeignKey("dbo.IndExportInquiryDetails", "ProductId", "dbo.Products");
        //    DropForeignKey("dbo.IndExportInquiryDetails", "InquiryId", "dbo.IndExportInquiries");
        //    DropForeignKey("dbo.IndExportInquiries", "DepartmentID", "dbo.HrDepartments");
        //    DropForeignKey("dbo.IndExportInquiries", "CustomerId", "dbo.FinParties");
        //    DropForeignKey("dbo.IndExportInquiries", "CommodityTypeId", "dbo.CommodityTypes");
        //    DropIndex("dbo.IndExportInquiryDetails", new[] { "UosId" });
        //    DropIndex("dbo.IndExportInquiryDetails", new[] { "ProductId" });
        //    DropIndex("dbo.IndExportInquiryDetails", new[] { "InquiryId" });
        //    DropIndex("dbo.IndExportInquiries", new[] { "PriceTermsId" });
        //    DropIndex("dbo.IndExportInquiries", new[] { "PaymenTermsId" });
        //    DropIndex("dbo.IndExportInquiries", new[] { "CustomerId" });
        //    DropIndex("dbo.IndExportInquiries", new[] { "CommodityTypeId" });
        //    DropIndex("dbo.IndExportInquiries", new[] { "DepartmentID" });
        //    DropIndex("dbo.IndDomesticInquiries", new[] { "IndPriceTerms_Id" });
        //    AlterColumn("dbo.IndDomesticDetails", "TypeColor", c => c.String(maxLength: 1));
        //    DropColumn("dbo.IndDomesticInquiries", "IndPriceTerms_Id");
        //    DropColumn("dbo.IndDomestics", "BlendRatio");
        //    DropColumn("dbo.IndDomestics", "FabricWeight");
        //    DropColumn("dbo.IndDomestics", "isInvoiced");
        //    DropColumn("dbo.IndDomestics", "isShipments");
        //    DropColumn("dbo.IndDomestics", "isCancelled");
        //    DropTable("dbo.IndExportInquiryDetails");
        //    DropTable("dbo.IndExportInquiries");
        //    CreateIndex("dbo.IndDomestics", "InquiryId");
        //    AddForeignKey("dbo.IndDomestics", "InquiryId", "dbo.IndDomesticInquiries", "Id", cascadeDelete: true);
        }
    }
}
