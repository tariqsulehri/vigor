namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminrelupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserModuleDetails", "ModuleDtlId", "dbo.AdminModuleDetails");
            DropIndex("dbo.UserModuleDetails", new[] { "ModuleDtlId" });
            RenameColumn(table: "dbo.UserModuleDetails", name: "ModuleDtlId", newName: "AdminModuleDetails_Id");
            AddColumn("dbo.UserModuleDetails", "ModulelId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserModuleDetails", "AdminModuleDetails_Id", c => c.Int());
            CreateIndex("dbo.UserModuleDetails", "ModulelId");
            CreateIndex("dbo.UserModuleDetails", "AdminModuleDetails_Id");
           }
        
        public override void Down()
        {
            DropIndex("dbo.UserModuleDetails", new[] { "AdminModuleDetails_Id" });
            DropIndex("dbo.UserModuleDetails", new[] { "ModulelId" });
            AlterColumn("dbo.UserModuleDetails", "AdminModuleDetails_Id", c => c.Int(nullable: false));
            DropColumn("dbo.UserModuleDetails", "ModulelId");
            RenameColumn(table: "dbo.UserModuleDetails", name: "AdminModuleDetails_Id", newName: "ModuleDtlId");
            CreateIndex("dbo.UserModuleDetails", "ModuleDtlId");
                   }
    }
}
