namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinVouchers", "PostFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinVouchers", "PostFlag");
        }
    }
}
