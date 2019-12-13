namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FNLAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FNLAccounts",
                c => new
                    {
                        FNLAccountID = c.String(nullable: false, maxLength: 18),
                        PartyAccount = c.String(maxLength: 18),
                        DebtorAccount = c.String(maxLength: 18),
                        FNLAccountIDRef = c.String(maxLength: 6),
                        PartyAccountRef = c.String(maxLength: 6),
                        DebtorAccountRef = c.String(maxLength: 6),
                        CurrencyID = c.Int(nullable: false),
                        Returnable = c.Boolean(),
                        ReturnableCurrency = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        InActiveSince = c.DateTime(),
                        LinkedAccount = c.Decimal(precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.FNLAccountID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FNLAccounts");
        }
    }
}
