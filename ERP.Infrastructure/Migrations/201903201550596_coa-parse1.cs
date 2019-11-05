namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coaparse1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoaL1",
                c => new
                    {
                        L1Code = c.String(nullable: false, maxLength: 2),
                        Title = c.String(nullable: false, maxLength: 30),
                        Type = c.String(nullable: false, maxLength: 2),
                        Active = c.Boolean(nullable: false),
                        Co = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.L1Code);
            
            CreateTable(
                "dbo.CoaL2",
                c => new
                    {
                        L2Code = c.String(nullable: false, maxLength: 3),
                        Title = c.String(nullable: false, maxLength: 30),
                        Active = c.Boolean(nullable: false),
                        L1Code = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.L2Code)
                .ForeignKey("dbo.CoaL1", t => t.L1Code, cascadeDelete: true)
                .Index(t => t.L1Code);
            
            CreateTable(
                "dbo.CoaL3",
                c => new
                    {
                        L3Code = c.String(nullable: false, maxLength: 3),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        L2Code = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.L3Code)
                .ForeignKey("dbo.CoaL2", t => t.L2Code, cascadeDelete: true)
                .Index(t => t.L2Code);
            
            CreateTable(
                "dbo.CoaL4",
                c => new
                    {
                        L4Code = c.String(nullable: false, maxLength: 3),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        L3Code = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.L4Code)
                .ForeignKey("dbo.CoaL3", t => t.L3Code, cascadeDelete: true)
                .Index(t => t.L3Code);
            
            CreateTable(
                "dbo.CoaL5",
                c => new
                    {
                        L5Code = c.String(nullable: false, maxLength: 4),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        L4Code = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.L5Code)
                .ForeignKey("dbo.CoaL4", t => t.L4Code, cascadeDelete: true)
                .Index(t => t.L4Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4");
            DropForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3");
            DropForeignKey("dbo.CoaL3", "L2Code", "dbo.CoaL2");
            DropForeignKey("dbo.CoaL2", "L1Code", "dbo.CoaL1");
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropIndex("dbo.CoaL3", new[] { "L2Code" });
            DropIndex("dbo.CoaL2", new[] { "L1Code" });
            DropTable("dbo.CoaL5");
            DropTable("dbo.CoaL4");
            DropTable("dbo.CoaL3");
            DropTable("dbo.CoaL2");
            DropTable("dbo.CoaL1");
        }
    }
}
