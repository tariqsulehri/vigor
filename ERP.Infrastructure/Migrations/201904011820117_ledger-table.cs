namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ledgertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinLedgers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        VKey = c.String(nullable: false, maxLength: 20),
                        GlCode = c.String(nullable: false, maxLength: 18),
                        Detail = c.String(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        ClearingDate = c.DateTime(nullable: false),
                        ChequeNo = c.String(maxLength: 25),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: true)
                .ForeignKey("dbo.FinVouchers", t => t.VKey, cascadeDelete: true)
                .Index(t => t.VKey)
                .Index(t => t.GlCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinLedgers", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.FinLedgers", "GlCode", "dbo.CoaL5");
            DropIndex("dbo.FinLedgers", new[] { "GlCode" });
            DropIndex("dbo.FinLedgers", new[] { "VKey" });
            DropTable("dbo.FinLedgers");
        }
    }
}
