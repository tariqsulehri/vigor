namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTables : DbMigration
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 60),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Ctcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.Ctcode, cascadeDelete: true)
                .Index(t => t.Ctcode);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Ccode = c.Int(nullable: false),
                        StId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StId, cascadeDelete: true)
                .Index(t => t.StId);
            
            CreateTable(
                "dbo.FinParties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 30),
                        Fax = c.String(maxLength: 30),
                        MailingAddress = c.String(maxLength: 30),
                        DispatchAddress = c.String(maxLength: 100),
                        EmailAddress = c.String(maxLength: 50),
                        WebPage = c.String(maxLength: 100),
                        NtnNo = c.String(maxLength: 50),
                        GstNo = c.String(maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        IsSeller = c.Boolean(nullable: false),
                        IsBuyer = c.Boolean(nullable: false),
                        IsAgent = c.Boolean(nullable: false),
                        IsCust = c.Boolean(nullable: false),
                        IsDomestic = c.Boolean(nullable: false),
                        IsInternational = c.Boolean(nullable: false),
                        CountryCode = c.Int(nullable: false),
                        CityCode = c.Int(nullable: false),
                        GlCode = c.String(nullable: false, maxLength: 18),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityCode, cascadeDelete: true)
                .Index(t => t.CityCode);
            
            CreateTable(
                "dbo.CoaL5",
                c => new
                    {
                        L5Code = c.String(nullable: false, maxLength: 18),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        IsDept = c.Boolean(nullable: false),
                        IsLoc = c.Boolean(nullable: false),
                        IsEmp = c.Boolean(nullable: false),
                        IsCust = c.Boolean(nullable: false),
                        L4Code = c.String(nullable: false, maxLength: 13),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        FinParties_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.L5Code)
                .ForeignKey("dbo.CoaL4", t => t.L4Code, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.FinParties_Id)
                .Index(t => t.L4Code)
                .Index(t => t.FinParties_Id);
            
            CreateTable(
                "dbo.CoaL4",
                c => new
                    {
                        L4Code = c.String(nullable: false, maxLength: 13),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        L3Code = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.L4Code)
                .ForeignKey("dbo.CoaL3", t => t.L3Code, cascadeDelete: true)
                .Index(t => t.L3Code);
            
            CreateTable(
                "dbo.CoaL3",
                c => new
                    {
                        L3Code = c.String(nullable: false, maxLength: 9),
                        Title = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        L2Code = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.L3Code)
                .ForeignKey("dbo.CoaL2", t => t.L2Code, cascadeDelete: true)
                .Index(t => t.L2Code);
            
            CreateTable(
                "dbo.CoaL2",
                c => new
                    {
                        L2Code = c.String(nullable: false, maxLength: 5),
                        Title = c.String(nullable: false, maxLength: 30),
                        Active = c.Boolean(nullable: false),
                        L1Code = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.L2Code)
                .ForeignKey("dbo.CoaL1", t => t.L1Code, cascadeDelete: true)
                .Index(t => t.L1Code);
            
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
                "dbo.CustomerBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        Bid = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Bid, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.Bid)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Active = c.Boolean(nullable: false),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerCertifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartyId = c.Int(nullable: false),
                        CertifyId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IssuedOn = c.DateTime(nullable: false),
                        ValidTill = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certifications", t => t.CertifyId, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.CertifyId);
            
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
                "dbo.CustomerContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Jobtitle = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        ContTypeId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.ContTypeId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        PartyId = c.Int(nullable: false),
                        ContTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.ContTypeId);
            
            CreateTable(
                "dbo.CustomerMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(nullable: false, maxLength: 100),
                        NumOfMachines = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        MId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Machines", t => t.MId, cascadeDelete: true)
                .Index(t => t.MId)
                .Index(t => t.PartyId);
            
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
                "dbo.CustomerSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        Sid = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Socials", t => t.Sid, cascadeDelete: true)
                .Index(t => t.Sid)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Detail = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerInstructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        CiId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.SpecialInstructions", t => t.CiId, cascadeDelete: true)
                .Index(t => t.CiId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.SpecialInstructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinVoucherDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VKey = c.String(nullable: false, maxLength: 20),
                        GlCode = c.String(nullable: false, maxLength: 18),
                        Detail = c.String(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        ClearingDate = c.DateTime(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeNo = c.String(maxLength: 25),
                        DeptId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                        LocId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        FinParty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.LocId, cascadeDelete: true)
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: true)
                .ForeignKey("dbo.FinVouchers", t => t.VKey, cascadeDelete: true)
                .ForeignKey("dbo.HrDepartments", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.HrEmployees", t => t.EmpId, cascadeDelete: true)
                .ForeignKey("dbo.FinParties", t => t.FinParty_Id)
                .Index(t => t.VKey)
                .Index(t => t.GlCode)
                .Index(t => t.DeptId)
                .Index(t => t.EmpId)
                .Index(t => t.LocId)
                .Index(t => t.FinParty_Id);
            
            CreateTable(
                "dbo.FinVouchers",
                c => new
                    {
                        VKey = c.String(nullable: false, maxLength: 20),
                        VoucherNo = c.Int(nullable: false),
                        FescalMonth = c.String(nullable: false, maxLength: 10),
                        Vtype = c.String(nullable: false, maxLength: 3),
                        VoucherDate = c.DateTime(nullable: false),
                        TotalDebit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheqNo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Detail = c.String(),
                        IsPosted = c.Boolean(nullable: false),
                        IsEdited = c.Boolean(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        PostedUserId = c.Int(nullable: false),
                        VerifyUserId = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VKey);
            
            CreateTable(
                "dbo.HrDepartments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HrEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Stcode = c.String(nullable: false, maxLength: 6),
                        CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CId, cascadeDelete: true)
                .Index(t => t.CId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Ccode = c.String(nullable: false, maxLength: 4),
                        RCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RCode, cascadeDelete: true)
                .Index(t => t.RCode);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.FinFescalYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinFescalYearDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        YearId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinFescalYears", t => t.YearId, cascadeDelete: true)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.FinLedgers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        VKey = c.String(nullable: false, maxLength: 20),
                        GlCode = c.String(nullable: false, maxLength: 18),
                        Detail = c.String(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        ClearingDate = c.DateTime(nullable: false),
                        ChequeNo = c.String(maxLength: 25),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: true)
                .ForeignKey("dbo.FinVouchers", t => t.VKey, cascadeDelete: true)
                .Index(t => t.VKey)
                .Index(t => t.GlCode);
            
            CreateTable(
                "dbo.FinVTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vtype = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 50),
                        Key = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinLedgers", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.FinLedgers", "GlCode", "dbo.CoaL5");
            DropForeignKey("dbo.FinFescalYearDetails", "YearId", "dbo.FinFescalYears");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Companies", "BusId", "dbo.BusinessTypes");
            DropForeignKey("dbo.Areas", "Ctcode", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StId", "dbo.States");
            DropForeignKey("dbo.States", "CId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "RCode", "dbo.Regions");
            DropForeignKey("dbo.FinVoucherDetails", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.FinVoucherDetails", "EmpId", "dbo.HrEmployees");
            DropForeignKey("dbo.FinVoucherDetails", "DeptId", "dbo.HrDepartments");
            DropForeignKey("dbo.FinVoucherDetails", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.FinVoucherDetails", "GlCode", "dbo.CoaL5");
            DropForeignKey("dbo.FinVoucherDetails", "LocId", "dbo.Cities");
            DropForeignKey("dbo.CustomerInstructions", "CiId", "dbo.SpecialInstructions");
            DropForeignKey("dbo.CustomerInstructions", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerSocials", "Sid", "dbo.Socials");
            DropForeignKey("dbo.CustomerSocials", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerMachines", "MId", "dbo.Machines");
            DropForeignKey("dbo.CustomerMachines", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerContactPersons", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerContactPersons", "ContTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.CustomerContacts", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerContacts", "ContTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.CustomerCertifications", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerCertifications", "CertifyId", "dbo.Certifications");
            DropForeignKey("dbo.CustomerBrands", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerBrands", "Bid", "dbo.Brands");
            DropForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties");
            DropForeignKey("dbo.FinBudgets", "GlCode", "dbo.CoaL5");
            DropForeignKey("dbo.CoaL5", "L4Code", "dbo.CoaL4");
            DropForeignKey("dbo.CoaL4", "L3Code", "dbo.CoaL3");
            DropForeignKey("dbo.CoaL3", "L2Code", "dbo.CoaL2");
            DropForeignKey("dbo.CoaL2", "L1Code", "dbo.CoaL1");
            DropForeignKey("dbo.FinParties", "CityCode", "dbo.Cities");
            DropForeignKey("dbo.AdminModuleDetails", "AModuleId", "dbo.AdminModules");
            DropForeignKey("dbo.UserModules", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserModuleDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserModuleDetails", "ModuleDtlId", "dbo.AdminModuleDetails");
            DropForeignKey("dbo.UserModules", "ModuleId", "dbo.AdminModules");
            DropIndex("dbo.FinVTypes", new[] { "Key" });
            DropIndex("dbo.FinLedgers", new[] { "GlCode" });
            DropIndex("dbo.FinLedgers", new[] { "VKey" });
            DropIndex("dbo.FinFescalYearDetails", new[] { "YearId" });
            DropIndex("dbo.Companies", new[] { "BusId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.Countries", new[] { "RCode" });
            DropIndex("dbo.States", new[] { "CId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "FinParty_Id" });
            DropIndex("dbo.FinVoucherDetails", new[] { "LocId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "EmpId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "DeptId" });
            DropIndex("dbo.FinVoucherDetails", new[] { "GlCode" });
            DropIndex("dbo.FinVoucherDetails", new[] { "VKey" });
            DropIndex("dbo.CustomerInstructions", new[] { "PartyId" });
            DropIndex("dbo.CustomerInstructions", new[] { "CiId" });
            DropIndex("dbo.CustomerSocials", new[] { "PartyId" });
            DropIndex("dbo.CustomerSocials", new[] { "Sid" });
            DropIndex("dbo.CustomerMachines", new[] { "PartyId" });
            DropIndex("dbo.CustomerMachines", new[] { "MId" });
            DropIndex("dbo.CustomerContacts", new[] { "ContTypeId" });
            DropIndex("dbo.CustomerContacts", new[] { "PartyId" });
            DropIndex("dbo.CustomerContactPersons", new[] { "PartyId" });
            DropIndex("dbo.CustomerContactPersons", new[] { "ContTypeId" });
            DropIndex("dbo.CustomerCertifications", new[] { "CertifyId" });
            DropIndex("dbo.CustomerCertifications", new[] { "PartyId" });
            DropIndex("dbo.CustomerBrands", new[] { "PartyId" });
            DropIndex("dbo.CustomerBrands", new[] { "Bid" });
            DropIndex("dbo.FinBudgets", new[] { "GlCode" });
            DropIndex("dbo.CoaL2", new[] { "L1Code" });
            DropIndex("dbo.CoaL3", new[] { "L2Code" });
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropIndex("dbo.CoaL5", new[] { "FinParties_Id" });
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropIndex("dbo.FinParties", new[] { "CityCode" });
            DropIndex("dbo.Cities", new[] { "StId" });
            DropIndex("dbo.Areas", new[] { "Ctcode" });
            DropIndex("dbo.UserModuleDetails", new[] { "ModuleDtlId" });
            DropIndex("dbo.UserModuleDetails", new[] { "UserId" });
            DropIndex("dbo.UserModules", new[] { "ModuleId" });
            DropIndex("dbo.UserModules", new[] { "UserId" });
            DropIndex("dbo.AdminModuleDetails", new[] { "AModuleId" });
            DropTable("dbo.ShipingLines");
            DropTable("dbo.IndPriceTerms");
            DropTable("dbo.GoodsForwarders");
            DropTable("dbo.IndGeneralDescriptions");
            DropTable("dbo.FinVTypes");
            DropTable("dbo.FinLedgers");
            DropTable("dbo.FinFescalYearDetails");
            DropTable("dbo.FinFescalYears");
            DropTable("dbo.Companies");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.Regions");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.HrEmployees");
            DropTable("dbo.HrDepartments");
            DropTable("dbo.FinVouchers");
            DropTable("dbo.FinVoucherDetails");
            DropTable("dbo.SpecialInstructions");
            DropTable("dbo.CustomerInstructions");
            DropTable("dbo.Socials");
            DropTable("dbo.CustomerSocials");
            DropTable("dbo.Machines");
            DropTable("dbo.CustomerMachines");
            DropTable("dbo.CustomerContacts");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.CustomerContactPersons");
            DropTable("dbo.Certifications");
            DropTable("dbo.CustomerCertifications");
            DropTable("dbo.Brands");
            DropTable("dbo.CustomerBrands");
            DropTable("dbo.FinBudgets");
            DropTable("dbo.CoaL1");
            DropTable("dbo.CoaL2");
            DropTable("dbo.CoaL3");
            DropTable("dbo.CoaL4");
            DropTable("dbo.CoaL5");
            DropTable("dbo.FinParties");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
            DropTable("dbo.UserModuleDetails");
            DropTable("dbo.Users");
            DropTable("dbo.UserModules");
            DropTable("dbo.AdminModules");
            DropTable("dbo.AdminModuleDetails");
        }
    }
}
