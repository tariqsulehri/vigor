namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldsRevised : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FabricInspTypes", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FabricInspTypes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FabricInspTypes", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FabricInspTypes", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.IndCommissions", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.IndCommissions", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.IndCommissions", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.IndCommissions", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndCommissions", "ModifiedOn");
            DropColumn("dbo.IndCommissions", "ModifiedBy");
            DropColumn("dbo.IndCommissions", "CreatedOn");
            DropColumn("dbo.IndCommissions", "CreatedBy");
            DropColumn("dbo.FabricInspTypes", "ModifiedOn");
            DropColumn("dbo.FabricInspTypes", "ModifiedBy");
            DropColumn("dbo.FabricInspTypes", "CreatedOn");
            DropColumn("dbo.FabricInspTypes", "CreatedBy");
        }
    }
}
