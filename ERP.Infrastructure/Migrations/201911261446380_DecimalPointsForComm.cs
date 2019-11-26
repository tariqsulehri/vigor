namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecimalPointsForComm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndCommissions", "CommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndCommissions", "CommissionRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
