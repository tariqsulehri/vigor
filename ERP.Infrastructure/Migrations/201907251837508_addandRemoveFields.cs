namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addandRemoveFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndDomesticInquiries", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.IndDomesticInquiries", new[] { "CurrencyId" });
            AddColumn("dbo.IndDomesticInquiries", "Delivery", c => c.String(maxLength: 200));
            AddColumn("dbo.IndDomesticInquiries", "InquiryMarket", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.IndDomesticInquiries", "CustomerAsBuyer", c => c.String(maxLength: 100));
            AddColumn("dbo.IndDomesticInquiries", "InquiryStatus", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.IndDomesticInquiries", "IsClosed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndDomesticDispatchSchedules", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.IndDomesticDispatchSchedules", "IsReturn", c => c.String(maxLength: 2));
            AddColumn("dbo.IndExportInquiries", "CustomerAsBuyer", c => c.String(maxLength: 100));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "TypeOfTransaction", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsReceivedStinv", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsDelayed", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsComplaint", c => c.String(maxLength: 2));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "isFirstDispatch", c => c.String(maxLength: 2));
            AlterColumn("dbo.IndDelayShipmentReasons", "Description", c => c.String(nullable: false, maxLength: 80));
            DropColumn("dbo.IndDomesticInquiries", "CurrencyId");
            DropColumn("dbo.IndDomesticInquiries", "InquieryStatus");
            DropColumn("dbo.IndDomesticInquiries", "InquiryClosed");
            DropColumn("dbo.IndDomesticInquiryDetails", "WalkInCustomer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndDomesticInquiryDetails", "WalkInCustomer", c => c.String(maxLength: 100));
            AddColumn("dbo.IndDomesticInquiries", "InquiryClosed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndDomesticInquiries", "InquieryStatus", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.IndDomesticInquiries", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("dbo.IndDelayShipmentReasons", "Description", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "isFirstDispatch", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsComplaint", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsDelayed", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsReceivedStinv", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "TypeOfTransaction", c => c.String(nullable: false, maxLength: 1));
            DropColumn("dbo.IndExportInquiries", "CustomerAsBuyer");
            DropColumn("dbo.IndDomesticDispatchSchedules", "IsReturn");
            DropColumn("dbo.IndDomesticDispatchSchedules", "Balance");
            DropColumn("dbo.IndDomesticInquiries", "IsClosed");
            DropColumn("dbo.IndDomesticInquiries", "InquiryStatus");
            DropColumn("dbo.IndDomesticInquiries", "CustomerAsBuyer");
            DropColumn("dbo.IndDomesticInquiries", "InquiryMarket");
            DropColumn("dbo.IndDomesticInquiries", "Delivery");
            CreateIndex("dbo.IndDomesticInquiries", "CurrencyId");
            AddForeignKey("dbo.IndDomesticInquiries", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
        }
    }
}
