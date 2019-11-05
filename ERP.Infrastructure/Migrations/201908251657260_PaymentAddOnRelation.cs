namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentAddOnRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomesticPaymentAddOns", "domPaymentAddOnListId", c => c.Int(nullable: false));
            CreateIndex("dbo.IndDomesticPaymentAddOns", "domPaymentAddOnListId");
            AddForeignKey("dbo.IndDomesticPaymentAddOns", "domPaymentAddOnListId", "dbo.IndDomesticPaymentsAddOnLists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndDomesticPaymentAddOns", "domPaymentAddOnListId", "dbo.IndDomesticPaymentsAddOnLists");
            DropIndex("dbo.IndDomesticPaymentAddOns", new[] { "domPaymentAddOnListId" });
            DropColumn("dbo.IndDomesticPaymentAddOns", "domPaymentAddOnListId");
        }
    }
}
