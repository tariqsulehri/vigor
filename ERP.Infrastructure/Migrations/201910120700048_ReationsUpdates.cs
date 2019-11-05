namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReationsUpdates : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HR_LoanAdvanceApplication", new[] { "companyID" });
            DropIndex("dbo.IndGeneralDescriptions", "IX_IndentGdesc_Indent");
            DropIndex("dbo.ShipingLines", "IX_ShipLine_Indent");
            AddColumn("dbo.HR_LoanAdvanceApplication", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_LoanAdvanceApplication", "companyID", c => c.Int(nullable: false));
            AlterColumn("dbo.IndGeneralDescriptions", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.ShipingLines", "Name", c => c.String(nullable: false, maxLength: 250));
            CreateIndex("dbo.HR_LoanAdvanceApplication", "companyID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HR_LoanAdvanceApplication", new[] { "companyID" });
            AlterColumn("dbo.ShipingLines", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.IndGeneralDescriptions", "Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HR_LoanAdvanceApplication", "companyID", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.HR_LoanAdvanceApplication", "CompanyKey");
            CreateIndex("dbo.ShipingLines", "Name", unique: true, name: "IX_ShipLine_Indent");
            CreateIndex("dbo.IndGeneralDescriptions", "Description", unique: true, name: "IX_IndentGdesc_Indent");
            CreateIndex("dbo.HR_LoanAdvanceApplication", "companyID");
        }
    }
}
