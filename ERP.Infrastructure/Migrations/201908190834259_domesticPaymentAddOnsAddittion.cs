namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domesticPaymentAddOnsAddittion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndDomesticPaymentsAddOnLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddOnId = c.String(nullable: false, maxLength: 3),
                        AddOnDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IndDomesticAddOnTemplates", "TaxDeptId", c => c.Int(nullable: false));
            AddColumn("dbo.IndDomesticAddOnTemplates", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.IndDomesticAddOnTemplates", "TotalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.IndDomesticAddOnTemplates", "DomesticPaymentAddonCalculatedOn", c => c.String(maxLength: 3));
            AlterColumn("dbo.IndDomesticAddOnTemplates", "AddOnId", c => c.Int(nullable: false));
            CreateIndex("dbo.IndDomesticAddOnTemplates", "TaxDeptId");
            CreateIndex("dbo.IndDomesticAddOnTemplates", "AddOnId");
            AddForeignKey("dbo.IndDomesticAddOnTemplates", "AddOnId", "dbo.IndDomesticPaymentsAddOnLists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IndDomesticAddOnTemplates", "TaxDeptId", "dbo.SalesTaxOffices", "Id", cascadeDelete: true);
            DropColumn("dbo.IndDomesticAddOnTemplates", "AddOnDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndDomesticAddOnTemplates", "AddOnDescription", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.IndDomesticAddOnTemplates", "TaxDeptId", "dbo.SalesTaxOffices");
            DropForeignKey("dbo.IndDomesticAddOnTemplates", "AddOnId", "dbo.IndDomesticPaymentsAddOnLists");
            DropIndex("dbo.IndDomesticAddOnTemplates", new[] { "AddOnId" });
            DropIndex("dbo.IndDomesticAddOnTemplates", new[] { "TaxDeptId" });
            AlterColumn("dbo.IndDomesticAddOnTemplates", "AddOnId", c => c.String(nullable: false, maxLength: 2));
            DropColumn("dbo.IndDomesticAddOnTemplates", "DomesticPaymentAddonCalculatedOn");
            DropColumn("dbo.IndDomesticAddOnTemplates", "TotalValue");
            DropColumn("dbo.IndDomesticAddOnTemplates", "Amount");
            DropColumn("dbo.IndDomesticAddOnTemplates", "TaxDeptId");
            DropTable("dbo.IndDomesticPaymentsAddOnLists");
        }
    }
}
