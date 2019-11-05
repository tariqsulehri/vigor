namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationTableAdd1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationID = c.String(nullable: false, maxLength: 4),
                        LocationDescription = c.String(nullable: false, maxLength: 50),
                        Company = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FinVoucherDetails", "Locations_Id", c => c.Int());
            CreateIndex("dbo.FinVoucherDetails", "Locations_Id");
            AddForeignKey("dbo.FinVoucherDetails", "Locations_Id", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinVoucherDetails", "Locations_Id", "dbo.Locations");
            DropIndex("dbo.FinVoucherDetails", new[] { "Locations_Id" });
            DropColumn("dbo.FinVoucherDetails", "Locations_Id");
            DropTable("dbo.Locations");
        }
    }
}
