namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefIdInConfigModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HrDepartments", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.CommodityTypes", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.FinParties", "RefId", c => c.String(maxLength: 6));
            AddColumn("dbo.Cities", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.Countries", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.Regions", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.Certifications", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.ContactTypes", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.Currencies", "RefId", c => c.String(maxLength: 3));
            AddColumn("dbo.ExchangeRates", "RefId", c => c.String(maxLength: 3));
            AddColumn("dbo.Products", "RefId", c => c.String(maxLength: 6));
            AddColumn("dbo.QcInspectors", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.GoodsForwarders", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.UnitOfSales", "RefId", c => c.String(maxLength: 3));
            AddColumn("dbo.IndUnitOfMeasures", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.UnitOfRates", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.IndDomesticPaymentAddOns", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.IndPaymentTerms", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.IndInquiryReviewQuestions", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.IndPriceTerms", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.SalesTaxOffices", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.MarkeetDealsIns", "RefId", c => c.String(maxLength: 1));
            AddColumn("dbo.Companies", "RefId", c => c.String(maxLength: 3));
            AddColumn("dbo.Brands", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.DocumentEFilingTypes", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.IndGeneralDescriptions", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.IndColours", "RefId", c => c.String(maxLength: 5));
            AddColumn("dbo.IndDelayShipmentCategories", "RefId", c => c.String(maxLength: 1));
            AddColumn("dbo.IndDelayShipmentReasons", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.IndDesigns", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.IndLeadTimes", "RefId", c => c.String(maxLength: 2));
            AddColumn("dbo.IndSizes", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.IndSizeGroups", "RefId", c => c.String(maxLength: 3));
            AddColumn("dbo.Locations", "RefId", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.ShipingLines", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.YarnInspUsters", "RefId", c => c.String(maxLength: 2));
            DropColumn("dbo.HrDepartments", "DepartmentKey");
            DropColumn("dbo.CommodityTypes", "CommTypeKey");
            DropColumn("dbo.FinParties", "CustomerIdKey");
            DropColumn("dbo.Cities", "CityKey");
            DropColumn("dbo.Countries", "CountryIdKey");
            DropColumn("dbo.Regions", "RegionIDKey");
            DropColumn("dbo.ContactTypes", "ContactTypeKey");
            DropColumn("dbo.Currencies", "CurrencyIdKey");
            DropColumn("dbo.ExchangeRates", "CurrencyIDKey");
            DropColumn("dbo.Products", "ProductID_Key");
            DropColumn("dbo.QcInspectors", "QcInspectorIDKey");
            DropColumn("dbo.GoodsForwarders", "GoodsForwarderIDKey");
            DropColumn("dbo.UnitOfSales", "UOSID_Key");
            DropColumn("dbo.IndUnitOfMeasures", "UOMID_Key");
            DropColumn("dbo.UnitOfRates", "UORID_Key");
            DropColumn("dbo.IndDomesticPaymentAddOns", "AddonIDKey");
            DropColumn("dbo.IndPaymentTerms", "PaymentTermIDKey");
            DropColumn("dbo.IndInquiryReviewQuestions", "InquiryReviewQuestionIDKey");
            DropColumn("dbo.IndPriceTerms", "PriceTermIDKey");
            DropColumn("dbo.SalesTaxOffices", "SalesTaxOfficeIDKey");
            DropColumn("dbo.MarkeetDealsIns", "MarketDealIDKey");
            DropColumn("dbo.Companies", "Company_Key");
            DropColumn("dbo.IndGeneralDescriptions", "GeneralDescIDKey");
            DropColumn("dbo.IndColours", "ColourKey");
            DropColumn("dbo.IndDesigns", "DesignIDKey");
            DropColumn("dbo.IndLeadTimes", "LeadTimeID");
            DropColumn("dbo.IndSizes", "SizeID_Key");
            DropColumn("dbo.IndSizeGroups", "SizeGroupID_Key");
            DropColumn("dbo.Locations", "LocationIDKey");
            DropColumn("dbo.ShipingLines", "ShippingLineIdKey");
            DropColumn("dbo.YarnInspUsters", "UsterResultTypeIdKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YarnInspUsters", "UsterResultTypeIdKey", c => c.String(maxLength: 2));
            AddColumn("dbo.ShipingLines", "ShippingLineIdKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Locations", "LocationIDKey", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.IndSizeGroups", "SizeGroupID_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.IndSizes", "SizeID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndLeadTimes", "LeadTimeID", c => c.String(maxLength: 2));
            AddColumn("dbo.IndDesigns", "DesignIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndColours", "ColourKey", c => c.String(maxLength: 5));
            AddColumn("dbo.IndGeneralDescriptions", "GeneralDescIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Companies", "Company_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.MarkeetDealsIns", "MarketDealIDKey", c => c.String(maxLength: 1));
            AddColumn("dbo.SalesTaxOffices", "SalesTaxOfficeIDKey", c => c.String(maxLength: 2));
            AddColumn("dbo.IndPriceTerms", "PriceTermIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndInquiryReviewQuestions", "InquiryReviewQuestionIDKey", c => c.String(maxLength: 2));
            AddColumn("dbo.IndPaymentTerms", "PaymentTermIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndDomesticPaymentAddOns", "AddonIDKey", c => c.String(maxLength: 2));
            AddColumn("dbo.UnitOfRates", "UORID_Key", c => c.String(maxLength: 2));
            AddColumn("dbo.IndUnitOfMeasures", "UOMID_Key", c => c.String(maxLength: 2));
            AddColumn("dbo.UnitOfSales", "UOSID_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.GoodsForwarders", "GoodsForwarderIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.QcInspectors", "QcInspectorIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Products", "ProductID_Key", c => c.String(maxLength: 6));
            AddColumn("dbo.ExchangeRates", "CurrencyIDKey", c => c.String(maxLength: 3));
            AddColumn("dbo.Currencies", "CurrencyIdKey", c => c.String(maxLength: 3));
            AddColumn("dbo.ContactTypes", "ContactTypeKey", c => c.String(maxLength: 2));
            AddColumn("dbo.Regions", "RegionIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Countries", "CountryIdKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Cities", "CityKey", c => c.String(maxLength: 4));
            AddColumn("dbo.FinParties", "CustomerIdKey", c => c.String(maxLength: 6));
            AddColumn("dbo.CommodityTypes", "CommTypeKey", c => c.String(maxLength: 2));
            AddColumn("dbo.HrDepartments", "DepartmentKey", c => c.String(maxLength: 4));
            DropColumn("dbo.YarnInspUsters", "RefId");
            DropColumn("dbo.ShipingLines", "RefId");
            DropColumn("dbo.Locations", "RefId");
            DropColumn("dbo.IndSizeGroups", "RefId");
            DropColumn("dbo.IndSizes", "RefId");
            DropColumn("dbo.IndLeadTimes", "RefId");
            DropColumn("dbo.IndDesigns", "RefId");
            DropColumn("dbo.IndDelayShipmentReasons", "RefId");
            DropColumn("dbo.IndDelayShipmentCategories", "RefId");
            DropColumn("dbo.IndColours", "RefId");
            DropColumn("dbo.IndGeneralDescriptions", "RefId");
            DropColumn("dbo.DocumentEFilingTypes", "RefId");
            DropColumn("dbo.Brands", "RefId");
            DropColumn("dbo.Companies", "RefId");
            DropColumn("dbo.MarkeetDealsIns", "RefId");
            DropColumn("dbo.SalesTaxOffices", "RefId");
            DropColumn("dbo.IndPriceTerms", "RefId");
            DropColumn("dbo.IndInquiryReviewQuestions", "RefId");
            DropColumn("dbo.IndPaymentTerms", "RefId");
            DropColumn("dbo.IndDomesticPaymentAddOns", "RefId");
            DropColumn("dbo.UnitOfRates", "RefId");
            DropColumn("dbo.IndUnitOfMeasures", "RefId");
            DropColumn("dbo.UnitOfSales", "RefId");
            DropColumn("dbo.GoodsForwarders", "RefId");
            DropColumn("dbo.QcInspectors", "RefId");
            DropColumn("dbo.Products", "RefId");
            DropColumn("dbo.ExchangeRates", "RefId");
            DropColumn("dbo.Currencies", "RefId");
            DropColumn("dbo.ContactTypes", "RefId");
            DropColumn("dbo.Certifications", "RefId");
            DropColumn("dbo.Regions", "RefId");
            DropColumn("dbo.Countries", "RefId");
            DropColumn("dbo.Cities", "RefId");
            DropColumn("dbo.FinParties", "RefId");
            DropColumn("dbo.CommodityTypes", "RefId");
            DropColumn("dbo.HrDepartments", "RefId");
        }
    }
}
