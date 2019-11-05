namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinVouchers", "City_Id", "dbo.Cities");
            DropIndex("dbo.FinVouchers", new[] { "City_Id" });
            DropColumn("dbo.FinVouchers", "City_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinVouchers", "City_Id", c => c.Int());
            CreateIndex("dbo.FinVouchers", "City_Id");
            AddForeignKey("dbo.FinVouchers", "City_Id", "dbo.Cities", "Id");
        }
    }
}
