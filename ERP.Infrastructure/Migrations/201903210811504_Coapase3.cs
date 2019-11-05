namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coapase3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3");
            DropForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4");
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropPrimaryKey("dbo.CoaL3");
            DropPrimaryKey("dbo.CoaL4");
            DropPrimaryKey("dbo.CoaL5");
            AlterColumn("dbo.CoaL3", "L3Code", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.CoaL4", "L4Code", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.CoaL4", "L3Code", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.CoaL5", "L5Code", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.CoaL5", "L4Code", c => c.String(nullable: false, maxLength: 13));
            AddPrimaryKey("dbo.CoaL3", "L3Code");
            AddPrimaryKey("dbo.CoaL4", "L4Code");
            AddPrimaryKey("dbo.CoaL5", "L5Code");
            CreateIndex("dbo.CoaL4", "L3Code");
            CreateIndex("dbo.CoaL5", "L4Code");
            AddForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3", "L3Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4", "L4Code", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4");
            DropForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3");
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropPrimaryKey("dbo.CoaL5");
            DropPrimaryKey("dbo.CoaL4");
            DropPrimaryKey("dbo.CoaL3");
            AlterColumn("dbo.CoaL5", "L4Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL5", "L5Code", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.CoaL4", "L3Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL4", "L4Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL3", "L3Code", c => c.String(nullable: false, maxLength: 3));
            AddPrimaryKey("dbo.CoaL5", "L5Code");
            AddPrimaryKey("dbo.CoaL4", "L4Code");
            AddPrimaryKey("dbo.CoaL3", "L3Code");
            CreateIndex("dbo.CoaL5", "L4Code");
            CreateIndex("dbo.CoaL4", "L3Code");
            AddForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4", "L4Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3", "L3Code", cascadeDelete: true);
        }
    }
}
