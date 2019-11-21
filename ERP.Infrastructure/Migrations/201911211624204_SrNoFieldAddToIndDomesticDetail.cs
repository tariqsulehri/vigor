namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SrNoFieldAddToIndDomesticDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomesticDetails", "srno", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndDomesticDetails", "srno");
        }
    }
}
