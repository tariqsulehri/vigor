namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domesticPaymentAddOnsAddittionStringLength : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomesticAddOnTemplates", "AddOnType", c => c.String(maxLength: 2));
            AddColumn("dbo.IndDomesticAddOnTemplates", "AddOnEffect", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndDomesticAddOnTemplates", "AddOnEffect");
            DropColumn("dbo.IndDomesticAddOnTemplates", "AddOnType");
        }
    }
}
