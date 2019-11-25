namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DispatchScheduleIsReceviedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndDomesticDispatchSchedules", "SalestaxInvoiceDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndDomesticDispatchSchedules", "SalestaxInvoiceDate", c => c.DateTime(nullable: false));
        }
    }
}
