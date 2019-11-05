namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUnitsAndRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerBrands", "Bid", "dbo.Brands");
            DropForeignKey("dbo.CustomerMachines", "MId", "dbo.Machines");
            DropIndex("dbo.CustomerBrands", new[] { "Bid" });
            DropIndex("dbo.CustomerMachines", new[] { "MId" });
            CreateTable(
                "dbo.CustomerUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        mKey = c.String(nullable: false, maxLength: 6),
                        UnitTitle = c.String(nullable: false, maxLength: 50),
                        Details = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 20),
                        PersonEmail = c.String(nullable: false, maxLength: 30),
                        ContactPersonPhone = c.String(nullable: false, maxLength: 20),
                        PartyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId);
            
            AddColumn("dbo.CustomerBrands", "mKey", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.CustomerBrands", "BrandName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CustomerMachines", "mKey", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.CustomerMachines", "MachineName", c => c.String(nullable: false, maxLength: 6));
            DropColumn("dbo.CustomerBrands", "Bid");
            DropColumn("dbo.CustomerMachines", "MId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerMachines", "MId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerBrands", "Bid", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomerUnits", "PartyId", "dbo.FinParties");
            DropIndex("dbo.CustomerUnits", new[] { "PartyId" });
            DropColumn("dbo.CustomerMachines", "MachineName");
            DropColumn("dbo.CustomerMachines", "mKey");
            DropColumn("dbo.CustomerBrands", "BrandName");
            DropColumn("dbo.CustomerBrands", "mKey");
            DropTable("dbo.CustomerUnits");
            CreateIndex("dbo.CustomerMachines", "MId");
            CreateIndex("dbo.CustomerBrands", "Bid");
            AddForeignKey("dbo.CustomerMachines", "MId", "dbo.Machines", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerBrands", "Bid", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
