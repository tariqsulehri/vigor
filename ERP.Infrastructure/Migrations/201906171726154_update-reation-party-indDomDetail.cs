namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatereationpartyindDomDetail : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.IndDomesticDetails", "FinParty_Id", "dbo.FinParties");
            //DropIndex("dbo.IndDomesticDetails", new[] { "FinParty_Id" });
            //DropColumn("dbo.IndDomesticDetails", "FinParty_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.IndDomesticDetails", "FinParty_Id", c => c.Int());
            //CreateIndex("dbo.IndDomesticDetails", "FinParty_Id");
            //AddForeignKey("dbo.IndDomesticDetails", "FinParty_Id", "dbo.FinParties", "Id");
        }
    }
}
