namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColoursFieldsUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndColours", "ColorCode", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.IndColours", "ColourID", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IndColours", "ColourID", c => c.Double(nullable: false));
            DropColumn("dbo.IndColours", "ColorCode");
        }
    }
}
