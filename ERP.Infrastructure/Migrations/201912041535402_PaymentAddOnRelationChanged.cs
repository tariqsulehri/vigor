namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentAddOnRelationChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndDomesticPaymentAddOns", "LocalDispatchNo", "dbo.IndDomesticDispatchSchedules");
            DropIndex("dbo.IndDomesticPaymentAddOns", new[] { "LocalDispatchNo" });
            DropColumn("dbo.IndDomesticPaymentAddOns", "LocalDispatchNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndDomesticPaymentAddOns", "LocalDispatchNo", c => c.Int(nullable: false));
            CreateIndex("dbo.IndDomesticPaymentAddOns", "LocalDispatchNo");
            AddForeignKey("dbo.IndDomesticPaymentAddOns", "LocalDispatchNo", "dbo.IndDomesticDispatchSchedules", "Id", cascadeDelete: true);
        }
    }
}
