namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commonTablesAndEdits : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinVoucherDetails", "CustomerId", "dbo.FinParties");
            DropIndex("dbo.FinVoucherDetails", new[] { "CustomerId" });
            CreateTable(
                "dbo.FinBudgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GlCode = c.String(nullable: false, maxLength: 18),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDel = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: true)
                .Index(t => t.GlCode);
            
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessTitle = c.String(nullable: false, maxLength: 30),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MailAddress = c.String(maxLength: 100),
                        CityId = c.Int(nullable: false),
                        Phone = c.String(maxLength: 30),
                        Fax = c.String(maxLength: 30),
                        Email = c.String(maxLength: 40),
                        WebAddress = c.String(maxLength: 100),
                        BusId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessTypes", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CertificationName = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerCertifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedOn = c.DateTime(nullable: false),
                        ValidTill = c.DateTime(nullable: false),
                        Certifications_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certifications", t => t.Certifications_Id)
                .Index(t => t.Certifications_Id);
            
            CreateTable(
                "dbo.IndGeneralDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodsForwarders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Phone = c.String(),
                        EmailAddress = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndPriceTerms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        MaturityDays = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Details = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShipingLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 30),
                        Fax = c.String(maxLength: 30),
                        EmailAddress = c.String(maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FinVoucherDetails", "FinParty_Id", c => c.Int());
            AddColumn("dbo.CoaL5", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.CoaL5", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.CoaL5", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.CoaL5", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinParties", "CompanyName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.FinParties", "Phone", c => c.String(maxLength: 30));
            AddColumn("dbo.FinParties", "Fax", c => c.String(maxLength: 30));
            AddColumn("dbo.FinParties", "MailingAddress", c => c.String(maxLength: 30));
            AddColumn("dbo.FinParties", "DispatchAddress", c => c.String(maxLength: 100));
            AddColumn("dbo.FinParties", "EmailAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.FinParties", "WebPage", c => c.String(maxLength: 100));
            AddColumn("dbo.FinParties", "NtnNo", c => c.String(maxLength: 50));
            AddColumn("dbo.FinParties", "GstNo", c => c.String(maxLength: 50));
            AddColumn("dbo.FinParties", "IsDomestic", c => c.Boolean(nullable: false));
            AddColumn("dbo.FinParties", "IsInternational", c => c.Boolean(nullable: false));
            AddColumn("dbo.FinParties", "CountryCode", c => c.Int(nullable: false));
            AddColumn("dbo.FinParties", "CityCode", c => c.Int(nullable: false));
            AddColumn("dbo.FinParties", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FinParties", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinParties", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FinParties", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinVouchers", "VoucherDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinVouchers", "TotalDebit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FinVouchers", "TotalCredit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FinVouchers", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinVouchers", "IsVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.FinVouchers", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HrDepartments", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HrDepartments", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrDepartments", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HrDepartments", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HrEmployees", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HrEmployees", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinFescalYears", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FinFescalYears", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinFescalYears", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FinFescalYears", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinFescalYearDetails", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FinFescalYearDetails", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinFescalYearDetails", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.FinFescalYearDetails", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinVTypes", "Description", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.FinParties", "CityCode");
            CreateIndex("dbo.FinVoucherDetails", "FinParty_Id");
            CreateIndex("dbo.FinVTypes", "Key", unique: true);
            AddForeignKey("dbo.FinParties", "CityCode", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FinVoucherDetails", "FinParty_Id", "dbo.FinParties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinVoucherDetails", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.CustomerCertifications", "Certifications_Id", "dbo.Certifications");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Companies", "BusId", "dbo.BusinessTypes");
            DropForeignKey("dbo.FinBudgets", "GlCode", "dbo.CoaL5");
            DropForeignKey("dbo.FinParties", "CityCode", "dbo.Cities");
            DropIndex("dbo.FinVTypes", new[] { "Key" });
            DropIndex("dbo.CustomerCertifications", new[] { "Certifications_Id" });
            DropIndex("dbo.Companies", new[] { "BusId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "FinParty_Id" });
            DropIndex("dbo.FinBudgets", new[] { "GlCode" });
            DropIndex("dbo.FinParties", new[] { "CityCode" });
            DropColumn("dbo.FinVTypes", "Description");
            DropColumn("dbo.FinFescalYearDetails", "ModifiedOn");
            DropColumn("dbo.FinFescalYearDetails", "ModifiedBy");
            DropColumn("dbo.FinFescalYearDetails", "CreatedOn");
            DropColumn("dbo.FinFescalYearDetails", "CreatedBy");
            DropColumn("dbo.FinFescalYears", "ModifiedOn");
            DropColumn("dbo.FinFescalYears", "ModifiedBy");
            DropColumn("dbo.FinFescalYears", "CreatedOn");
            DropColumn("dbo.FinFescalYears", "CreatedBy");
            DropColumn("dbo.HrEmployees", "ModifiedOn");
            DropColumn("dbo.HrEmployees", "ModifiedBy");
            DropColumn("dbo.HrEmployees", "CreatedOn");
            DropColumn("dbo.HrEmployees", "CreatedBy");
            DropColumn("dbo.HrDepartments", "ModifiedOn");
            DropColumn("dbo.HrDepartments", "ModifiedBy");
            DropColumn("dbo.HrDepartments", "CreatedOn");
            DropColumn("dbo.HrDepartments", "CreatedBy");
            DropColumn("dbo.FinVouchers", "ModifiedBy");
            DropColumn("dbo.FinVouchers", "IsVerified");
            DropColumn("dbo.FinVouchers", "ModifiedOn");
            DropColumn("dbo.FinVouchers", "TotalCredit");
            DropColumn("dbo.FinVouchers", "TotalDebit");
            DropColumn("dbo.FinVouchers", "VoucherDate");
            DropColumn("dbo.FinParties", "ModifiedOn");
            DropColumn("dbo.FinParties", "ModifiedBy");
            DropColumn("dbo.FinParties", "CreatedOn");
            DropColumn("dbo.FinParties", "CreatedBy");
            DropColumn("dbo.FinParties", "CityCode");
            DropColumn("dbo.FinParties", "CountryCode");
            DropColumn("dbo.FinParties", "IsInternational");
            DropColumn("dbo.FinParties", "IsDomestic");
            DropColumn("dbo.FinParties", "GstNo");
            DropColumn("dbo.FinParties", "NtnNo");
            DropColumn("dbo.FinParties", "WebPage");
            DropColumn("dbo.FinParties", "EmailAddress");
            DropColumn("dbo.FinParties", "DispatchAddress");
            DropColumn("dbo.FinParties", "MailingAddress");
            DropColumn("dbo.FinParties", "Fax");
            DropColumn("dbo.FinParties", "Phone");
            DropColumn("dbo.FinParties", "CompanyName");
            DropColumn("dbo.CoaL5", "ModifiedOn");
            DropColumn("dbo.CoaL5", "ModifiedBy");
            DropColumn("dbo.CoaL5", "CreatedOn");
            DropColumn("dbo.CoaL5", "CreatedBy");
            DropColumn("dbo.FinVoucherDetails", "FinParty_Id");
            DropTable("dbo.Users");
            DropTable("dbo.ShipingLines");
            DropTable("dbo.Machines");
            DropTable("dbo.IndPriceTerms");
            DropTable("dbo.GoodsForwarders");
            DropTable("dbo.IndGeneralDescriptions");
            DropTable("dbo.CustomerCertifications");
            DropTable("dbo.Certifications");
            DropTable("dbo.Companies");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.FinBudgets");
            CreateIndex("dbo.FinVoucherDetails", "CustomerId");
            AddForeignKey("dbo.FinVoucherDetails", "CustomerId", "dbo.FinParties", "Id", cascadeDelete: true);
        }
    }
}
