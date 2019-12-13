namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FNLACCOUNTRelations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FNLAccounts");
            AddColumn("dbo.FNLAccounts", "PartyId", c => c.Int(nullable: false));
            AlterColumn("dbo.FNLAccounts", "FNLAccountID", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.FNLAccounts", "FNLAccountID");
            CreateIndex("dbo.FNLAccounts", "PartyId");
            AddForeignKey("dbo.FNLAccounts", "PartyId", "dbo.FinParties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FNLAccounts", "PartyId", "dbo.FinParties");
            DropIndex("dbo.FNLAccounts", new[] { "PartyId" });
            DropPrimaryKey("dbo.FNLAccounts");
            AlterColumn("dbo.FNLAccounts", "FNLAccountID", c => c.String(nullable: false, maxLength: 18));
            DropColumn("dbo.FNLAccounts", "PartyId");
            AddPrimaryKey("dbo.FNLAccounts", "FNLAccountID");
        }
    }
}
