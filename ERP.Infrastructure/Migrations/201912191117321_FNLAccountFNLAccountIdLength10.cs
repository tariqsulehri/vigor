namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FNLAccountFNLAccountIdLength10 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FNLAccounts");
            AlterColumn("dbo.FNLAccounts", "FNLAccountID", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.FNLAccounts", "FNLAccountID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FNLAccounts");
            AlterColumn("dbo.FNLAccounts", "FNLAccountID", c => c.String(nullable: false, maxLength: 18));
            AddPrimaryKey("dbo.FNLAccounts", "FNLAccountID");
        }
    }
}
