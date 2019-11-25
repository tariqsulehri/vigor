namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DispatchScheduleIsReceviedBoolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsReceivedStinv", c => c.Boolean(nullable: false));
            CreateIndex("dbo.IndentInfoes", "IndentId");
            AddForeignKey("dbo.IndentInfoes", "IndentId", "dbo.IndDomestics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndentInfoes", "IndentId", "dbo.IndDomestics");
            DropIndex("dbo.IndentInfoes", new[] { "IndentId" });
            AlterColumn("dbo.IndDomesticDispatchSchedules", "IsReceivedStinv", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
