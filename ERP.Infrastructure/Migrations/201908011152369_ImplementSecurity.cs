namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementSecurity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemOptions",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        OptionDescription = c.String(nullable: false, maxLength: 150),
                        OptionLevel = c.Int(nullable: false),
                        ParentID = c.Int(),
                        IsMenuOption = c.String(maxLength: 1),
                        Allowed = c.Boolean(nullable: false),
                        FormObject = c.String(maxLength: 50),
                        IsFunction = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.SystemOptions", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.UserPrevilages",
                c => new
                    {
                        UserPrevilageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        Allowed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserPrevilageId);
            
            DropColumn("dbo.SalesTaxOffices", "code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesTaxOffices", "code", c => c.String(nullable: false, maxLength: 2));
            DropForeignKey("dbo.SystemOptions", "ParentID", "dbo.SystemOptions");
            DropIndex("dbo.SystemOptions", new[] { "ParentID" });
            DropTable("dbo.UserPrevilages");
            DropTable("dbo.SystemOptions");
        }
    }
}
