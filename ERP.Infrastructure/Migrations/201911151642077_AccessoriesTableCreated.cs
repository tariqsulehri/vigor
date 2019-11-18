namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessoriesTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndAccessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefId = c.String(maxLength: 5),
                        Description = c.String(nullable: false, maxLength: 100),
                        CommodityType = c.Int(nullable: false),
                        CommodityTypeRef = c.String(nullable: false, maxLength: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IndAccessories");
        }
    }
}
