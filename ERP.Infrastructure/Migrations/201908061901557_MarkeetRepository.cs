namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkeetRepository : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeptDealsInCommodityTypes", "mkey", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.DeptDealsInMarkeets", "mkey", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeptDealsInMarkeets", "mkey");
            DropColumn("dbo.DeptDealsInCommodityTypes", "mkey");
        }
    }
}
