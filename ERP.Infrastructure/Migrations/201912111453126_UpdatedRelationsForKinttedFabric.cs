namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRelationsForKinttedFabric : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.KnittedFabricInspBleacheds");
            DropPrimaryKey("dbo.KnittedFabricInspDyeds");
            DropPrimaryKey("dbo.KnittedFabricInspectionAttachments");
            DropPrimaryKey("dbo.KnittedFabricInspGreys");
            AddColumn("dbo.KnittedFabricInspBleacheds", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.KnittedFabricInspBleacheds", "InspectionID", c => c.String(maxLength: 9));
            AddColumn("dbo.KnittedFabricInspDyeds", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.KnittedFabricInspDyeds", "InspectionID", c => c.String(maxLength: 9));
            AddColumn("dbo.KnittedFabricInspectionAttachments", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.KnittedFabricInspectionAttachments", "InspectionID", c => c.String(maxLength: 9));
            AddColumn("dbo.KnittedFabricInspGreys", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.KnittedFabricInspGreys", "InspectionID", c => c.String(maxLength: 9));
            AddPrimaryKey("dbo.KnittedFabricInspBleacheds", "id");
            AddPrimaryKey("dbo.KnittedFabricInspDyeds", "id");
            AddPrimaryKey("dbo.KnittedFabricInspectionAttachments", "id");
            AddPrimaryKey("dbo.KnittedFabricInspGreys", "id");
            CreateIndex("dbo.KnittedFabricInspBleacheds", "InspectionID");
            CreateIndex("dbo.KnittedFabricInspDyeds", "InspectionID");
            CreateIndex("dbo.KnittedFabricInspectionAttachments", "InspectionID");
            CreateIndex("dbo.KnittedFabricInspGreys", "InspectionID");
            AddForeignKey("dbo.KnittedFabricInspBleacheds", "InspectionID", "dbo.KnittedFabricInspections", "InspectionID");
            AddForeignKey("dbo.KnittedFabricInspDyeds", "InspectionID", "dbo.KnittedFabricInspections", "InspectionID");
            AddForeignKey("dbo.KnittedFabricInspectionAttachments", "InspectionID", "dbo.KnittedFabricInspections", "InspectionID");
            AddForeignKey("dbo.KnittedFabricInspGreys", "InspectionID", "dbo.KnittedFabricInspections", "InspectionID");
            DropColumn("dbo.KnittedFabricInspBleacheds", "InspectionCode");
            DropColumn("dbo.KnittedFabricInspDyeds", "InspectionCode");
            DropColumn("dbo.KnittedFabricInspectionAttachments", "InspectionCode");
            DropColumn("dbo.KnittedFabricInspGreys", "InspectionCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KnittedFabricInspGreys", "InspectionCode", c => c.String(nullable: false, maxLength: 9));
            AddColumn("dbo.KnittedFabricInspectionAttachments", "InspectionCode", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.KnittedFabricInspDyeds", "InspectionCode", c => c.String(nullable: false, maxLength: 9));
            AddColumn("dbo.KnittedFabricInspBleacheds", "InspectionCode", c => c.String(nullable: false, maxLength: 9));
            DropForeignKey("dbo.KnittedFabricInspGreys", "InspectionID", "dbo.KnittedFabricInspections");
            DropForeignKey("dbo.KnittedFabricInspectionAttachments", "InspectionID", "dbo.KnittedFabricInspections");
            DropForeignKey("dbo.KnittedFabricInspDyeds", "InspectionID", "dbo.KnittedFabricInspections");
            DropForeignKey("dbo.KnittedFabricInspBleacheds", "InspectionID", "dbo.KnittedFabricInspections");
            DropIndex("dbo.KnittedFabricInspGreys", new[] { "InspectionID" });
            DropIndex("dbo.KnittedFabricInspectionAttachments", new[] { "InspectionID" });
            DropIndex("dbo.KnittedFabricInspDyeds", new[] { "InspectionID" });
            DropIndex("dbo.KnittedFabricInspBleacheds", new[] { "InspectionID" });
            DropPrimaryKey("dbo.KnittedFabricInspGreys");
            DropPrimaryKey("dbo.KnittedFabricInspectionAttachments");
            DropPrimaryKey("dbo.KnittedFabricInspDyeds");
            DropPrimaryKey("dbo.KnittedFabricInspBleacheds");
            DropColumn("dbo.KnittedFabricInspGreys", "InspectionID");
            DropColumn("dbo.KnittedFabricInspGreys", "id");
            DropColumn("dbo.KnittedFabricInspectionAttachments", "InspectionID");
            DropColumn("dbo.KnittedFabricInspectionAttachments", "id");
            DropColumn("dbo.KnittedFabricInspDyeds", "InspectionID");
            DropColumn("dbo.KnittedFabricInspDyeds", "id");
            DropColumn("dbo.KnittedFabricInspBleacheds", "InspectionID");
            DropColumn("dbo.KnittedFabricInspBleacheds", "id");
            AddPrimaryKey("dbo.KnittedFabricInspGreys", "InspectionCode");
            AddPrimaryKey("dbo.KnittedFabricInspectionAttachments", "InspectionCode");
            AddPrimaryKey("dbo.KnittedFabricInspDyeds", "InspectionCode");
            AddPrimaryKey("dbo.KnittedFabricInspBleacheds", "InspectionCode");
        }
    }
}
