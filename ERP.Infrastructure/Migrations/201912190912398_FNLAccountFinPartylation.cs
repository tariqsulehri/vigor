namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FNLAccountFinPartylation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FNLAccounts", "FinParty_Id", "dbo.FinParties");
            DropIndex("dbo.FNLAccounts", new[] { "FinParty_Id" });
            RenameColumn(table: "dbo.FNLAccounts", name: "FinParty_Id", newName: "PartyId");
            AlterColumn("dbo.FNLAccounts", "PartyId", c => c.Int(nullable: false));
            CreateIndex("dbo.FNLAccounts", "PartyId");
            AddForeignKey("dbo.FNLAccounts", "PartyId", "dbo.FinParties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FNLAccounts", "PartyId", "dbo.FinParties");
            DropIndex("dbo.FNLAccounts", new[] { "PartyId" });
            AlterColumn("dbo.FNLAccounts", "PartyId", c => c.Int());
            RenameColumn(table: "dbo.FNLAccounts", name: "PartyId", newName: "FinParty_Id");
            CreateIndex("dbo.FNLAccounts", "FinParty_Id");
            AddForeignKey("dbo.FNLAccounts", "FinParty_Id", "dbo.FinParties", "Id");
        }
    }
}
