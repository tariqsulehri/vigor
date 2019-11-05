namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymenTermsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndPaymentTerms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        MaturityDays = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Description, unique: true, name: "IX_PaymentTerms_Indent");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.IndPaymentTerms", "IX_PaymentTerms_Indent");
            DropTable("dbo.IndPaymentTerms");
        }
    }
}
