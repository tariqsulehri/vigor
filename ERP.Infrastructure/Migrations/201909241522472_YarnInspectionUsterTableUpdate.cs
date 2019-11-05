namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YarnInspectionUsterTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YarnInspUsters", "ResultTypeDescription", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.YarnInspUsters", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YarnInspUsters", "Description", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.YarnInspUsters", "ResultTypeDescription");
        }
    }
}
