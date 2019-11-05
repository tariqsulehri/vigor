namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRupdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HrDepartments", "ShowQtyinBVolume", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HrDepartments", "ShowQtyinBVolume", c => c.String(maxLength: 1));
        }
    }
}
