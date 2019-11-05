namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinVoucherDetails", "AreaCode", "dbo.Areas");
            DropForeignKey("dbo.CoaL3", "L2Code", "dbo.CoaL2");
            DropForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3");
            DropForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4");
            DropForeignKey("dbo.FinVoucherDetails", "GlCode", "dbo.CoaL5");
            DropIndex("dbo.CoaL3", new[] { "L2Code" });
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropIndex("dbo.FinVoucherDetails", new[] { "GlCode" });
            DropIndex("dbo.FinVoucherDetails", new[] { "AreaCode" });
            DropPrimaryKey("dbo.CoaL2");
            DropPrimaryKey("dbo.CoaL3");
            DropPrimaryKey("dbo.CoaL4");
            DropPrimaryKey("dbo.CoaL5");
            CreateTable(
                "dbo.FinParties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        IsSeller = c.Boolean(nullable: false),
                        IsBuyer = c.Boolean(nullable: false),
                        IsAgent = c.Boolean(nullable: false),
                        IsCust = c.Boolean(nullable: false),
                        GlCode = c.String(nullable: false, maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CoaL5", "IsDept", c => c.Boolean(nullable: false));
            AddColumn("dbo.CoaL5", "IsLoc", c => c.Boolean(nullable: false));
            AddColumn("dbo.CoaL5", "IsEmp", c => c.Boolean(nullable: false));
            AddColumn("dbo.CoaL5", "IsCust", c => c.Boolean(nullable: false));
            AddColumn("dbo.CoaL5", "FinParties_Id", c => c.Int(nullable: false));
            AddColumn("dbo.FinFescalYears", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.FinFescalYearDetails", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.FinVouchers", "City_Id", c => c.Int());
            AddColumn("dbo.FinVoucherDetails", "LocId", c => c.Int(nullable: false));
            AddColumn("dbo.FinVoucherDetails", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.CoaL2", "L2Code", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.CoaL3", "L3Code", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.CoaL3", "L2Code", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.CoaL4", "L4Code", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.CoaL4", "L3Code", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.CoaL5", "L5Code", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.CoaL5", "L4Code", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.FinVoucherDetails", "GlCode", c => c.String(nullable: false, maxLength: 18));
            AddPrimaryKey("dbo.CoaL2", "L2Code");
            AddPrimaryKey("dbo.CoaL3", "L3Code");
            AddPrimaryKey("dbo.CoaL4", "L4Code");
            AddPrimaryKey("dbo.CoaL5", "L5Code");
            CreateIndex("dbo.FinVouchers", "City_Id");
            CreateIndex("dbo.FinVoucherDetails", "GlCode");
            CreateIndex("dbo.FinVoucherDetails", "LocId");
            CreateIndex("dbo.FinVoucherDetails", "CustomerId");
            CreateIndex("dbo.CoaL5", "L4Code");
            CreateIndex("dbo.CoaL5", "FinParties_Id");
            CreateIndex("dbo.CoaL4", "L3Code");
            CreateIndex("dbo.CoaL3", "L2Code");
            AddForeignKey("dbo.FinVoucherDetails", "LocId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties", "Id");
            AddForeignKey("dbo.FinVoucherDetails", "CustomerId", "dbo.FinParties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FinVouchers", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.CoaL3", "L2Code", "dbo.CoaL2", "L2Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3", "L3Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4", "L4Code", cascadeDelete: true);
            AddForeignKey("dbo.FinVoucherDetails", "GlCode", "dbo.CoaL5", "L5Code", cascadeDelete: true);
            DropColumn("dbo.FinVoucherDetails", "AreaCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinVoucherDetails", "AreaCode", c => c.Int(nullable: false));
            DropForeignKey("dbo.FinVoucherDetails", "GlCode", "dbo.CoaL5");
            DropForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4");
            DropForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3");
            DropForeignKey("dbo.CoaL3", "L2Code", "dbo.CoaL2");
            DropForeignKey("dbo.FinVouchers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.FinVoucherDetails", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties");
            DropForeignKey("dbo.FinVoucherDetails", "LocId", "dbo.Cities");
            DropIndex("dbo.CoaL3", new[] { "L2Code" });
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropIndex("dbo.CoaL5", new[] { "FinParties_Id" });
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropIndex("dbo.FinVoucherDetails", new[] { "CustomerId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "LocId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "GlCode" });
            DropIndex("dbo.FinVouchers", new[] { "City_Id" });
            DropPrimaryKey("dbo.CoaL5");
            DropPrimaryKey("dbo.CoaL4");
            DropPrimaryKey("dbo.CoaL3");
            DropPrimaryKey("dbo.CoaL2");
            AlterColumn("dbo.FinVoucherDetails", "GlCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.CoaL5", "L4Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL5", "L5Code", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.CoaL4", "L3Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL4", "L4Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL3", "L2Code", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.CoaL3", "L3Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CoaL2", "L2Code", c => c.String(nullable: false, maxLength: 2));
            DropColumn("dbo.FinVoucherDetails", "CustomerId");
            DropColumn("dbo.FinVoucherDetails", "LocId");
            DropColumn("dbo.FinVouchers", "City_Id");
            DropColumn("dbo.FinFescalYearDetails", "Active");
            DropColumn("dbo.FinFescalYears", "Active");
            DropColumn("dbo.CoaL5", "FinParties_Id");
            DropColumn("dbo.CoaL5", "IsCust");
            DropColumn("dbo.CoaL5", "IsEmp");
            DropColumn("dbo.CoaL5", "IsLoc");
            DropColumn("dbo.CoaL5", "IsDept");
            DropTable("dbo.FinParties");
            AddPrimaryKey("dbo.CoaL5", "L5Code");
            AddPrimaryKey("dbo.CoaL4", "L4Code");
            AddPrimaryKey("dbo.CoaL3", "L3Code");
            AddPrimaryKey("dbo.CoaL2", "L2Code");
            CreateIndex("dbo.FinVoucherDetails", "AreaCode");
            CreateIndex("dbo.FinVoucherDetails", "GlCode");
            CreateIndex("dbo.CoaL5", "L4Code");
            CreateIndex("dbo.CoaL4", "L3Code");
            CreateIndex("dbo.CoaL3", "L2Code");
            AddForeignKey("dbo.FinVoucherDetails", "GlCode", "dbo.CoaL5", "L5Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4", "L4Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3", "L3Code", cascadeDelete: true);
            AddForeignKey("dbo.CoaL3", "L2Code", "dbo.CoaL2", "L2Code", cascadeDelete: true);
            AddForeignKey("dbo.FinVoucherDetails", "AreaCode", "dbo.Areas", "Id", cascadeDelete: true);
        }
    }
}
