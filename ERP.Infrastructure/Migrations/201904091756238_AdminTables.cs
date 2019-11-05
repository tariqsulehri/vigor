namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminModuleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(nullable: false, maxLength: 50),
                        Key = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 100),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        AModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminModules", t => t.AModuleId, cascadeDelete: true)
                .Index(t => t.AModuleId);
            
            CreateTable(
                "dbo.AdminModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(nullable: false, maxLength: 50),
                        Key = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 100),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminModules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.UserModuleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ModuleDtlId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminModuleDetails", t => t.ModuleDtlId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ModuleDtlId);
            
            AddColumn("dbo.FinVouchers", "CheqNo", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminModuleDetails", "AModuleId", "dbo.AdminModules");
            DropForeignKey("dbo.UserModules", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserModuleDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserModuleDetails", "ModuleDtlId", "dbo.AdminModuleDetails");
            DropForeignKey("dbo.UserModules", "ModuleId", "dbo.AdminModules");
            DropIndex("dbo.UserModuleDetails", new[] { "ModuleDtlId" });
            DropIndex("dbo.UserModuleDetails", new[] { "UserId" });
            DropIndex("dbo.UserModules", new[] { "ModuleId" });
            DropIndex("dbo.UserModules", new[] { "UserId" });
            DropIndex("dbo.AdminModuleDetails", new[] { "AModuleId" });
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.FinVouchers", "CheqNo");
            DropTable("dbo.UserModuleDetails");
            DropTable("dbo.UserModules");
            DropTable("dbo.AdminModules");
            DropTable("dbo.AdminModuleDetails");
        }
    }
}
