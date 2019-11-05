namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties");
            DropIndex("dbo.CoaL5", new[] { "FinParties_Id" });
            DropColumn("dbo.FinParties", "GlCode");
            RenameColumn(table: "dbo.FinParties", name: "FinParties_Id", newName: "GlCode");
            AddColumn("dbo.IndDomesticInquiries", "InquiryStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndDomesticInquiries", "IsClosed", c => c.Boolean(nullable: false));
            AddColumn("dbo.IndDomesticInquiries", "ProductName", c => c.String());
            CreateIndex("dbo.FinParties", "GlCode");
            AddForeignKey("dbo.FinParties", "GlCode", "dbo.CoaL5", "L5Code", cascadeDelete: true);
            DropColumn("dbo.CoaL5", "FinParties_Id");
        }
        public override void Down()
        {
            AddColumn("dbo.CoaL5", "FinParties_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.FinParties", "GlCode", "dbo.CoaL5");
            DropIndex("dbo.FinParties", new[] { "GlCode" });
            DropColumn("dbo.IndDomesticInquiries", "ProductName");
            DropColumn("dbo.IndDomesticInquiries", "IsClosed");
            DropColumn("dbo.IndDomesticInquiries", "InquiryStatus");
            RenameColumn(table: "dbo.FinParties", name: "GlCode", newName: "FinParties_Id");
            AddColumn("dbo.FinParties", "GlCode", c => c.String(nullable: false, maxLength: 18));
            CreateIndex("dbo.CoaL5", "FinParties_Id");
            AddForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties", "Id");
        }
    }
}
