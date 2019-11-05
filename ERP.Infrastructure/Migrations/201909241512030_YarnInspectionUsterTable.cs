namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YarnInspectionUsterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YarnInspUsters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        UsterResultTypeId = c.String(nullable: false, maxLength: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.FinParties", "CompanyName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FinParties", "CompanyName", c => c.String());
            DropTable("dbo.YarnInspUsters");
        }
    }
}
