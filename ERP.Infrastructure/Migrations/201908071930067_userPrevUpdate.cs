namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userPrevUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPrevilages", "mKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPrevilages", "mKey");
        }
    }
}
