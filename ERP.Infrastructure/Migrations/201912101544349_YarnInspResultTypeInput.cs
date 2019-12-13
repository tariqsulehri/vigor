namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YarnInspResultTypeInput : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HrTaskRegisters", "HrTaskRegister_Id", "dbo.HrTaskRegisters");
            DropIndex("dbo.HrTaskRegisters", new[] { "HrTaskRegister_Id" });
            AddColumn("dbo.YarnInspections", "ResultInputType", c => c.String(maxLength: 1));
            DropColumn("dbo.HrTaskRegisters", "HrTaskRegister_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HrTaskRegisters", "HrTaskRegister_Id", c => c.Int());
            DropColumn("dbo.YarnInspections", "ResultInputType");
            CreateIndex("dbo.HrTaskRegisters", "HrTaskRegister_Id");
            AddForeignKey("dbo.HrTaskRegisters", "HrTaskRegister_Id", "dbo.HrTaskRegisters", "Id");
        }
    }
}
