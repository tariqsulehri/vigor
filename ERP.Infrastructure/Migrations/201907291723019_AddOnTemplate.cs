namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOnTemplate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndDomesticAddOnTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddOnId = c.String(nullable: false, maxLength: 2),
                        AddOnDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IndDomesticAddOnTemplates");
        }
    }
}
