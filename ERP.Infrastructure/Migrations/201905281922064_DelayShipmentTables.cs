namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelayShipmentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndDelayShipmentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 10),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDelayShipmentReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 10),
                        DelayShipCategoryID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDelayShipmentCategories", t => t.DelayShipCategoryID, cascadeDelete: true)
                .Index(t => t.DelayShipCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndDelayShipmentReasons", "DelayShipCategoryID", "dbo.IndDelayShipmentCategories");
            DropIndex("dbo.IndDelayShipmentReasons", new[] { "DelayShipCategoryID" });
            DropTable("dbo.IndDelayShipmentReasons");
            DropTable("dbo.IndDelayShipmentCategories");
        }
    }
}
