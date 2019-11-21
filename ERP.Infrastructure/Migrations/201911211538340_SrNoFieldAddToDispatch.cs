namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SrNoFieldAddToDispatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndDomesticDispatchSchedules", "srno", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndDomesticDispatchSchedules", "srno");
        }
    }
}
