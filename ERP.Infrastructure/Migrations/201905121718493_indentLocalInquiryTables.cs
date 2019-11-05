namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indentLocalInquiryTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndDomesticInquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        Companyid = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        CommodityTypeId = c.Int(nullable: false),
                        InquiryDate = c.DateTime(nullable: false),
                        InquiryClosedDate = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        PaymenTermsId = c.Int(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IndPaymentTerms_Id = c.Int(),
                        IndPaymentTerms_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.IndPaymentTerms", t => t.IndPaymentTerms_Id)
                .ForeignKey("dbo.IndPaymentTerms", t => t.IndPaymentTerms_Id1)
                .ForeignKey("dbo.IndPaymentTerms", t => t.PaymenTermsId, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.CommodityTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymenTermsId)
                .Index(t => t.IndPaymentTerms_Id)
                .Index(t => t.IndPaymentTerms_Id1);
            
            CreateTable(
                "dbo.CommodityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        ScheduleType = c.String(maxLength: 1),
                        DomesticMarket = c.String(maxLength: 1),
                        ScheduleTypeDomestic = c.String(maxLength: 1),
                        InternationalMarket = c.String(maxLength: 1),
                        ScheduleTypeInternational = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 250),
                        isValueAdded = c.String(maxLength: 1),
                        StuffedQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CommodityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityId, cascadeDelete: true)
                .Index(t => t.CommodityId);
            
            CreateTable(
                "dbo.IndDomesticInquiryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UOSID = c.String(),
                        IndDomesticInquiry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.IndDomesticInquiry_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.IndDomesticInquiry_Id);
            
            CreateTable(
                "dbo.IndDomesticInquiryOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        OfferMadeOn = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OfferedBy = c.String(nullable: false, maxLength: 50),
                        OfferedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermsId = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 200),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.InquiryId, cascadeDelete: false)
                .ForeignKey("dbo.IndPaymentTerms", t => t.PaymentTermsId, cascadeDelete: false)
                .Index(t => t.InquiryId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentTermsId);
            
            CreateTable(
                "dbo.IndDomesticInquiryReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryReviewQuestion = c.String(nullable: false, maxLength: 250),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.InquiryId, cascadeDelete: true)
                .Index(t => t.InquiryId);
            
            CreateTable(
                "dbo.IndUnitOfMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IndPriceTerms", "Abbrivation", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.IndPriceTerms", "MaturityDays");
            DropColumn("dbo.IndPriceTerms", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndPriceTerms", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.IndPriceTerms", "MaturityDays", c => c.Int(nullable: false));
            DropForeignKey("dbo.IndDomesticInquiryReviews", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticInquiries", "PaymenTermsId", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiries", "IndPaymentTerms_Id1", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiries", "IndPaymentTerms_Id", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiryOffers", "PaymentTermsId", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiryOffers", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticInquiryOffers", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomesticInquiries", "DepartmentID", "dbo.HrDepartments");
            DropForeignKey("dbo.IndDomesticInquiries", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomesticInquiries", "CommodityTypeId", "dbo.CommodityTypes");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.Products", "CommodityId", "dbo.CommodityTypes");
            DropIndex("dbo.IndDomesticInquiryReviews", new[] { "InquiryId" });
            DropIndex("dbo.IndDomesticInquiryOffers", new[] { "PaymentTermsId" });
            DropIndex("dbo.IndDomesticInquiryOffers", new[] { "CustomerId" });
            DropIndex("dbo.IndDomesticInquiryOffers", new[] { "InquiryId" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndDomesticInquiry_Id" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CommodityId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "IndPaymentTerms_Id1" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "IndPaymentTerms_Id" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "PaymenTermsId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "CustomerId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "CommodityTypeId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "DepartmentID" });
            DropColumn("dbo.IndPriceTerms", "Abbrivation");
            DropTable("dbo.IndUnitOfMeasures");
            DropTable("dbo.IndDomesticInquiryReviews");
            DropTable("dbo.IndDomesticInquiryOffers");
            DropTable("dbo.IndDomesticInquiryDetails");
            DropTable("dbo.Products");
            DropTable("dbo.CommodityTypes");
            DropTable("dbo.IndDomesticInquiries");
        }
    }
}
