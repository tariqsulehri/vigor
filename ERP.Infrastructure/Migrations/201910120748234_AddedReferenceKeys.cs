namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReferenceKeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FinParties", "IX_Party_Inventory");
            DropIndex("dbo.GoodsForwarders", "IX_IndentGForward_Indent");
            AddColumn("dbo.CommodityTypes", "CommTypeKey", c => c.String(maxLength: 2));
            AddColumn("dbo.FinParties", "CustomerIdKey", c => c.String(maxLength: 6));
            AddColumn("dbo.Countries", "CountryIdKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Regions", "RegionIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.ContactTypes", "ContactTypeKey", c => c.String(maxLength: 2));
            AddColumn("dbo.Currencies", "CurrencyIdKey", c => c.String(maxLength: 3));
            AddColumn("dbo.ExchangeRates", "CurrencyIDKey", c => c.String(maxLength: 3));
            AddColumn("dbo.QcInspectors", "QcInspectorIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.GoodsForwarders", "GoodsForwarderIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndDomesticPaymentAddOns", "AddonIDKey", c => c.String(maxLength: 2));
            AddColumn("dbo.IndPaymentTerms", "PaymentTermIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndPriceTerms", "PriceTermIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.SalesTaxOffices", "SalesTaxOfficeIDKey", c => c.String(maxLength: 2));
            AddColumn("dbo.IndInquiryReviewQuestions", "InquiryReviewQuestionIDKey", c => c.String(maxLength: 2));
            AddColumn("dbo.MarkeetDealsIns", "MarketDealIDKey", c => c.String(maxLength: 1));
            AddColumn("dbo.IndGeneralDescriptions", "GeneralDescIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndColours", "ColourKey", c => c.String(maxLength: 5));
            AddColumn("dbo.IndDelayShipmentReasons", "DelayShipmentReasonID", c => c.String(maxLength: 2));
            AddColumn("dbo.IndDesigns", "DesignIDKey", c => c.String(maxLength: 4));
            AddColumn("dbo.IndLeadTimes", "LeadTimeID", c => c.String(maxLength: 2));
            AddColumn("dbo.Locations", "LocationIDKey", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.ShipingLines", "ShippingLineIdKey", c => c.String(maxLength: 4));
            AddColumn("dbo.YarnInspUsters", "UsterResultTypeIdKey", c => c.String(maxLength: 2));
            DropColumn("dbo.CommodityTypes", "CommType_Key");
            DropColumn("dbo.IndPaymentTerms", "PaymentTermID_Key");
            DropColumn("dbo.IndPriceTerms", "PriceTermID_Key");
            DropColumn("dbo.IndColours", "ColourCodeID_Key");
            DropColumn("dbo.IndDesigns", "DesignID_Key");
            DropColumn("dbo.Locations", "LocationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "LocationID", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.IndDesigns", "DesignID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndColours", "ColourCodeID_Key", c => c.String(maxLength: 5));
            AddColumn("dbo.IndPriceTerms", "PriceTermID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.IndPaymentTerms", "PaymentTermID_Key", c => c.String(maxLength: 4));
            AddColumn("dbo.CommodityTypes", "CommType_Key", c => c.String(maxLength: 2));
            DropColumn("dbo.YarnInspUsters", "UsterResultTypeIdKey");
            DropColumn("dbo.ShipingLines", "ShippingLineIdKey");
            DropColumn("dbo.Locations", "LocationIDKey");
            DropColumn("dbo.IndLeadTimes", "LeadTimeID");
            DropColumn("dbo.IndDesigns", "DesignIDKey");
            DropColumn("dbo.IndDelayShipmentReasons", "DelayShipmentReasonID");
            DropColumn("dbo.IndColours", "ColourKey");
            DropColumn("dbo.IndGeneralDescriptions", "GeneralDescIDKey");
            DropColumn("dbo.MarkeetDealsIns", "MarketDealIDKey");
            DropColumn("dbo.IndInquiryReviewQuestions", "InquiryReviewQuestionIDKey");
            DropColumn("dbo.SalesTaxOffices", "SalesTaxOfficeIDKey");
            DropColumn("dbo.IndPriceTerms", "PriceTermIDKey");
            DropColumn("dbo.IndPaymentTerms", "PaymentTermIDKey");
            DropColumn("dbo.IndDomesticPaymentAddOns", "AddonIDKey");
            DropColumn("dbo.GoodsForwarders", "GoodsForwarderIDKey");
            DropColumn("dbo.QcInspectors", "QcInspectorIDKey");
            DropColumn("dbo.ExchangeRates", "CurrencyIDKey");
            DropColumn("dbo.Currencies", "CurrencyIdKey");
            DropColumn("dbo.ContactTypes", "ContactTypeKey");
            DropColumn("dbo.Regions", "RegionIDKey");
            DropColumn("dbo.Countries", "CountryIdKey");
            DropColumn("dbo.FinParties", "CustomerIdKey");
            DropColumn("dbo.CommodityTypes", "CommTypeKey");
            CreateIndex("dbo.GoodsForwarders", "Name", unique: true, name: "IX_IndentGForward_Indent");
            CreateIndex("dbo.FinParties", "Title", unique: true, name: "IX_Party_Inventory");
        }
    }
}
