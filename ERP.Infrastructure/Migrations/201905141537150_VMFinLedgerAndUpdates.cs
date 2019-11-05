namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VMFinLedgerAndUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VM_FinLedger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        l1Code = c.String(),
                        l1_Title = c.String(),
                        l2Code = c.String(),
                        l2_Title = c.String(),
                        l3Code = c.String(),
                        l3_Title = c.String(),
                        l4Code = c.String(),
                        l4_Title = c.String(),
                        l5Code = c.String(maxLength: 18),
                        l5_Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        VKey = c.String(maxLength: 20),
                        GlCode = c.String(),
                        Detail = c.String(),
                        ChequeDate = c.DateTime(nullable: false),
                        ClearingDate = c.DateTime(nullable: false),
                        ChequeNo = c.String(),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.l5Code)
                .ForeignKey("dbo.FinVouchers", t => t.VKey)
                .Index(t => t.l5Code)
                .Index(t => t.VKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VM_FinLedger", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.VM_FinLedger", "l5Code", "dbo.CoaL5");
            DropIndex("dbo.VM_FinLedger", new[] { "VKey" });
            DropIndex("dbo.VM_FinLedger", new[] { "l5Code" });
            DropTable("dbo.VM_FinLedger");
        }
    }
}
