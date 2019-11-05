namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacttypeandcomodityRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerContacts", "ContactType_Id", "dbo.ContactTypes");
            DropIndex("dbo.CustomerContacts", new[] { "ContTypeId" });
            DropIndex("dbo.CustomerContacts", new[] { "ContactType_Id" });
            AddColumn("dbo.IndDomesticDispatchSchedules", "CommodityId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerContacts", "ContTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerContacts", "ContTypeId");
            CreateIndex("dbo.IndDomesticDispatchSchedules", "CommodityId");
            AddForeignKey("dbo.IndDomesticDispatchSchedules", "CommodityId", "dbo.Products", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CustomerContacts", "ContTypeId", "dbo.ContactTypes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerContacts", "ContTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.IndDomesticDispatchSchedules", "CommodityId", "dbo.Products");
            DropIndex("dbo.IndDomesticDispatchSchedules", new[] { "CommodityId" });
            DropIndex("dbo.CustomerContacts", new[] { "ContTypeId" });
            AlterColumn("dbo.CustomerContacts", "ContTypeId", c => c.Int());
            DropColumn("dbo.IndDomesticDispatchSchedules", "CommodityId");
            RenameColumn(table: "dbo.CustomerContacts", name: "ContTypeId", newName: "ContactType_Id");
            AddColumn("dbo.CustomerContacts", "ContTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerContacts", "ContactType_Id");
            CreateIndex("dbo.CustomerContacts", "ContTypeId");
            AddForeignKey("dbo.CustomerContacts", "ContactType_Id", "dbo.ContactTypes", "Id");
        }
    }
}
