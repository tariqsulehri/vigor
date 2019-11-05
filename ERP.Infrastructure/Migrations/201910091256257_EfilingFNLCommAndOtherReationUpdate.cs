namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EfilingFNLCommAndOtherReationUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndDomesticDetails", "ColourId", "dbo.IndColours");
            DropForeignKey("dbo.IndDomesticDetails", "DesignId", "dbo.IndDesigns");
            DropForeignKey("dbo.IndDomesticDetails", "SizeCode", "dbo.IndSizes");
            DropIndex("dbo.IndPaymentTerms", "IX_PaymentTerms_Indent");
            DropIndex("dbo.IndPriceTerms", "IX_PTerms_Indent");
            DropIndex("dbo.IndDomesticDetails", new[] { "SizeCode" });
            DropIndex("dbo.IndDomesticDetails", new[] { "ColourId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "DesignId" });
            CreateTable(
                "dbo.DocumentEFilingTypes",
                c => new
                    {
                        DocumentID = c.String(nullable: false, maxLength: 2),
                        Description = c.String(nullable: false, maxLength: 50),
                        Scope = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.DocumentID);
            
            CreateTable(
                "dbo.EFilingSystems",
                c => new
                    {
                        EFilingID = c.String(nullable: false, maxLength: 10),
                        DocumentType = c.String(maxLength: 2),
                        TranType = c.Int(nullable: false),
                        FileDescription = c.String(maxLength: 200),
                        FileAttached = c.String(maxLength: 150),
                        CompanyId = c.Int(nullable: false),
                        Company_Key = c.String(maxLength: 3),
                        ReferenceID1 = c.String(maxLength: 20),
                        ReferenceID2 = c.String(maxLength: 20),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EFilingID);
            
            CreateTable(
                "dbo.FNL_CommissionPaymentDetail",
                c => new
                    {
                        FNLCommission_invoice = c.String(nullable: false, maxLength: 12),
                        FNLCommissionBillID = c.String(maxLength: 12),
                        AmountReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsBankCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsMiscCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmountReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsBankChargesLC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsMiscChargesLC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmountReceivedLC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsIncomeTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnableCurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        ReturnableCurency_Key = c.String(maxLength: 3),
                        ReturnableAmountinFCafterDeductBCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FNLCommission_invoice);
            
            AddColumn("dbo.HrDepartments", "DepartmentID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.CommodityTypes", "CommType_Key", c => c.String(maxLength: 2));
            AddColumn("dbo.IndDomesticInquiries", "DepartmentID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.Products", "ProductID_Key", c => c.String(maxLength: 6));
            AddColumn("dbo.UnitOfSales", "UOSID_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.IndUnitOfMeasures", "UOMID_Key", c => c.String(maxLength: 2));
            AddColumn("dbo.UnitOfRates", "UORID_Key", c => c.String(maxLength: 2));
            AddColumn("dbo.IndPaymentTerms", "PaymentTermID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndPriceTerms", "PriceTermID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndColours", "ColourCodeID_Key", c => c.String(maxLength: 5));
            AddColumn("dbo.IndDesigns", "DesignID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndSizes", "SizeID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndSizeGroups", "SizeGroupID_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.Companies", "CompanyId_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.Companies", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.IndDomesticInquiries", "Companyid", c => c.String(maxLength: 3));
            AlterColumn("dbo.IndDomesticInquiries", "InquiryMarket", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.IndDomesticInquiries", "InquiryStatus", c => c.String(maxLength: 1));
            AlterColumn("dbo.IndDomesticInquiries", "IsClosed", c => c.String(maxLength: 1));
            AlterColumn("dbo.IndDomesticInquiries", "WalkingCustomer", c => c.String(maxLength: 100));
            DropColumn("dbo.HrDepartments", "RefDepartmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HrDepartments", "RefDepartmentID", c => c.String(maxLength: 4));
            AlterColumn("dbo.IndDomesticInquiries", "WalkingCustomer", c => c.String(maxLength: 50));
            AlterColumn("dbo.IndDomesticInquiries", "IsClosed", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.IndDomesticInquiries", "InquiryStatus", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.IndDomesticInquiries", "InquiryMarket", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.IndDomesticInquiries", "Companyid", c => c.String());
            DropColumn("dbo.Companies", "Status");
            DropColumn("dbo.Companies", "CompanyId_Key");
            DropColumn("dbo.IndSizeGroups", "SizeGroupID_Key");
            DropColumn("dbo.IndSizes", "SizeID_Key");
            DropColumn("dbo.IndDesigns", "DesignID_Key");
            DropColumn("dbo.IndColours", "ColourCodeID_Key");
            DropColumn("dbo.IndPriceTerms", "PriceTermID_Key");
            DropColumn("dbo.IndPaymentTerms", "PaymentTermID_Key");
            DropColumn("dbo.UnitOfRates", "UORID_Key");
            DropColumn("dbo.IndUnitOfMeasures", "UOMID_Key");
            DropColumn("dbo.UnitOfSales", "UOSID_Key");
            DropColumn("dbo.Products", "ProductID_Key");
            DropColumn("dbo.IndDomesticInquiries", "DepartmentID_Key");
            DropColumn("dbo.CommodityTypes", "CommType_Key");
            DropColumn("dbo.HrDepartments", "DepartmentID_Key");
            DropTable("dbo.FNL_CommissionPaymentDetail");
            DropTable("dbo.EFilingSystems");
            DropTable("dbo.DocumentEFilingTypes");
            CreateIndex("dbo.IndDomesticDetails", "DesignId");
            CreateIndex("dbo.IndDomesticDetails", "ColourId");
            CreateIndex("dbo.IndDomesticDetails", "SizeCode");
            CreateIndex("dbo.IndPriceTerms", "Description", unique: true, name: "IX_PTerms_Indent");
            CreateIndex("dbo.IndPaymentTerms", "Description", unique: true, name: "IX_PaymentTerms_Indent");
            AddForeignKey("dbo.IndDomesticDetails", "SizeCode", "dbo.IndSizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndDomesticDetails", "DesignId", "dbo.IndDesigns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndDomesticDetails", "ColourId", "dbo.IndColours", "Id", cascadeDelete: true);
        }
    }
}
