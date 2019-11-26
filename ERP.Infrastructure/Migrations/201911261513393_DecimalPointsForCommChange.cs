namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecimalPointsForCommChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndCommissions", "CommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndCommissions", "CommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
    }
}
