namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigrationforwaqar : DbMigration
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
                .ForeignKey("dbo.AdminModules", t => t.AModuleId, cascadeDelete: false)
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
                .ForeignKey("dbo.AdminModules", t => t.ModuleId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 60),
                        Password = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        DateOfBirth = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        ContactNumber = c.String(maxLength: 20),
                        ChangePasswordWhenLogon = c.Boolean(nullable: false),
                        PasswordNeverExpire = c.Boolean(nullable: false),
                        IncludedCEOInEmail = c.Boolean(nullable: false),
                        ExpiresOn = c.DateTime(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        IsManagmentRepresentative = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
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
                .ForeignKey("dbo.AdminModuleDetails", t => t.ModuleDtlId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
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
                .ForeignKey("dbo.Cities", t => t.Ctcode, cascadeDelete: false)
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
                .ForeignKey("dbo.States", t => t.StId, cascadeDelete: false)
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
                .ForeignKey("dbo.Cities", t => t.CityCode, cascadeDelete: false)
                .Index(t => t.Title, unique: true, name: "IX_Party_Inventory")
                .Index(t => t.CityCode);
            
            CreateTable(
                "dbo.CoaL5",
                c => new
                    {
                        L5Code = c.String(nullable: false, maxLength: 18),
                        Title = c.String(nullable: false, maxLength: 50),
                        BookType = c.String(maxLength: 1),
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
                .ForeignKey("dbo.CoaL4", t => t.L4Code, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.FinParties_Id)
                .Index(t => t.L4Code)
                .Index(t => t.FinParties_Id);
            
            CreateTable(
                "dbo.CoaL4",
                c => new
                    {
                        L4Code = c.String(nullable: false, maxLength: 13),
                        Title = c.String(nullable: false, maxLength: 80),
                        Active = c.Boolean(nullable: false),
                        L3Code = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.L4Code)
                .ForeignKey("dbo.CoaL3", t => t.L3Code, cascadeDelete: false)
                .Index(t => t.L3Code);
            
            CreateTable(
                "dbo.CoaL3",
                c => new
                    {
                        L3Code = c.String(nullable: false, maxLength: 9),
                        Title = c.String(nullable: false, maxLength: 70),
                        Active = c.Boolean(nullable: false),
                        L2Code = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.L3Code)
                .ForeignKey("dbo.CoaL2", t => t.L2Code, cascadeDelete: false)
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
                .ForeignKey("dbo.CoaL1", t => t.L1Code, cascadeDelete: false)
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
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: false)
                .Index(t => t.GlCode);
            
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
                        DeptId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                        LocId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: false)
                .ForeignKey("dbo.FinVouchers", t => t.VKey, cascadeDelete: false)
                .Index(t => t.VKey)
                .Index(t => t.GlCode);
            
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
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.GlCode, cascadeDelete: false)
                .ForeignKey("dbo.FinVouchers", t => t.VKey, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.FinParty_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.VKey)
                .Index(t => t.GlCode)
                .Index(t => t.FinParty_Id)
                .Index(t => t.City_Id);
            
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
                .ForeignKey("dbo.Brands", t => t.Bid, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true, name: "IX_Brand_Inventory");
            
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
                .ForeignKey("dbo.Certifications", t => t.CertifyId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
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
                .ForeignKey("dbo.Machines", t => t.ContTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
                .Index(t => t.ContTypeId)
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
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
                .ForeignKey("dbo.Machines", t => t.MId, cascadeDelete: false)
                .Index(t => t.MId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.CustomerContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        PartyId = c.Int(nullable: false),
                        ContTypeId = c.Int(nullable: false),
                        ContactType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Machines", t => t.ContTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
                .ForeignKey("dbo.ContactTypes", t => t.ContactType_Id)
                .Index(t => t.PartyId)
                .Index(t => t.ContTypeId)
                .Index(t => t.ContactType_Id);
            
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
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
                .ForeignKey("dbo.Socials", t => t.Sid, cascadeDelete: false)
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
                .ForeignKey("dbo.FinParties", t => t.PartyId, cascadeDelete: false)
                .ForeignKey("dbo.SpecialInstructions", t => t.CiId, cascadeDelete: false)
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
                "dbo.FabricInspReportLocals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionDate = c.DateTime(nullable: false),
                        InspRepoSr = c.String(nullable: false, maxLength: 10),
                        InspRepoNo = c.String(nullable: false, maxLength: 10),
                        ForMarket = c.String(nullable: false, maxLength: 1),
                        CompanyId = c.Int(nullable: false),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        FabInspStandardId = c.Int(nullable: false),
                        FabInspTypeId = c.Int(nullable: false),
                        LoomTypeId = c.Int(nullable: false),
                        FabricTypeId = c.Int(nullable: false),
                        InspCalculationBasedOn = c.String(nullable: false, maxLength: 1),
                        InspStatusId = c.Int(nullable: false),
                        QcInspectorId = c.Int(nullable: false),
                        RollsInspected = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerAcceptancePoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bb_ends = c.Int(nullable: false),
                        bb_picks = c.Int(nullable: false),
                        bb_width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        bb_gsm = c.Int(nullable: false),
                        ab_ends = c.Int(nullable: false),
                        ab_picks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ab_width = c.Int(nullable: false),
                        ab_gsm = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 1000),
                        width = c.Int(nullable: false),
                        QuantityInspected = c.Int(nullable: false),
                        RollsAvailable = c.Int(nullable: false),
                        HeadBands = c.String(nullable: false, maxLength: 1),
                        ShadeVarivation = c.String(nullable: false, maxLength: 1),
                        Stamped = c.String(nullable: false, maxLength: 1),
                        ReadMarks = c.String(nullable: false, maxLength: 1),
                        RubbingMarks = c.String(nullable: false, maxLength: 1),
                        PolyYarn = c.String(nullable: false, maxLength: 1),
                        Contination = c.String(nullable: false, maxLength: 1),
                        Others = c.String(nullable: false, maxLength: 1),
                        firstLine = c.DateTime(nullable: false),
                        secondLine = c.DateTime(nullable: false),
                        TearingSWrap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TearingSWeft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Shirinkage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PieceRatioLog = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PieceRatioShort = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolyPropLine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cockled = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerSampleStatus = c.String(nullable: false, maxLength: 1),
                        BuyerSampleDesign = c.String(nullable: false, maxLength: 1),
                        SelvedgeWeaves = c.String(nullable: false, maxLength: 10),
                        SelvedgeIdentify = c.String(nullable: false, maxLength: 20),
                        SelvedgeBindingWidth = c.String(nullable: false, maxLength: 20),
                        SelvedgeSize = c.String(nullable: false, maxLength: 20),
                        YarnSupplyWrap = c.String(nullable: false, maxLength: 50),
                        YarnSupplyWeft = c.String(nullable: false, maxLength: 50),
                        TotalEnds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReedCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReedSapce = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndsPerDent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PickInsertion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PickList = c.String(nullable: false, maxLength: 1),
                        Marking = c.String(nullable: false, maxLength: 1),
                        FaceMarking = c.String(nullable: false, maxLength: 1),
                        PackingConditions = c.String(nullable: false, maxLength: 1),
                        WrapDirection = c.String(nullable: false, maxLength: 50),
                        ShipmentSample = c.String(nullable: false, maxLength: 1),
                        Camdirection = c.String(nullable: false, maxLength: 50),
                        NumberOfLooms = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricInspLoomTypes", t => t.LoomTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FabricInspStandards", t => t.FabInspStandardId, cascadeDelete: false)
                .ForeignKey("dbo.FabricInspStatus", t => t.InspStatusId, cascadeDelete: false)
                .ForeignKey("dbo.FabricInspTypes", t => t.FabInspTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FabricTypes", t => t.FabricTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .ForeignKey("dbo.QcInspectors", t => t.QcInspectorId, cascadeDelete: false)
                .Index(t => t.CompanyId)
                .Index(t => t.IndentId)
                .Index(t => t.FabInspStandardId)
                .Index(t => t.FabInspTypeId)
                .Index(t => t.LoomTypeId)
                .Index(t => t.FabricTypeId)
                .Index(t => t.InspStatusId)
                .Index(t => t.QcInspectorId);
            
            CreateTable(
                "dbo.FabInspReportLocalSums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FabInspReportId = c.Int(nullable: false),
                        InspRepoSr = c.String(nullable: false, maxLength: 10),
                        SlubsKnotes = c.Int(nullable: false),
                        PolyYarn = c.Int(nullable: false),
                        Holes = c.Int(nullable: false),
                        MissPick = c.Int(nullable: false),
                        ThickDoublePick = c.Int(nullable: false),
                        WeftBar = c.Int(nullable: false),
                        LooseEndsThickEnds = c.Int(nullable: false),
                        ReedMarksBrokenWraps = c.Int(nullable: false),
                        ThiinPlaces = c.Int(nullable: false),
                        TotalPointsPerRoll = c.Int(nullable: false),
                        PointsPer100Sqy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TPointsPer100Sqy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointsPer100M = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FabricInspReportLocals", t => t.FabInspReportId, cascadeDelete: false)
                .Index(t => t.FabInspReportId);
            
            CreateTable(
                "dbo.FabricInspLoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FabricInspReportLocalDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FabInspReportId = c.Int(nullable: false),
                        InspRepoSr = c.String(nullable: false, maxLength: 10),
                        RollOn = c.Int(nullable: false),
                        NoteMeters = c.Int(nullable: false),
                        ActualMeters = c.Int(nullable: false),
                        SlubsKnotes = c.Int(nullable: false),
                        PolyYarnRed = c.Int(nullable: false),
                        PolyYarnBlue = c.Int(nullable: false),
                        Holes = c.Int(nullable: false),
                        MissPack1 = c.Int(nullable: false),
                        MissPack2 = c.Int(nullable: false),
                        MissPack3 = c.Int(nullable: false),
                        MissPack4 = c.Int(nullable: false),
                        ThickDoublePick = c.Int(nullable: false),
                        ThickDoublePick2 = c.Int(nullable: false),
                        ThickDoublePick3 = c.Int(nullable: false),
                        ThickDoublePick4 = c.Int(nullable: false),
                        WeftBar = c.Int(nullable: false),
                        LooseEndsThickEnds1 = c.Int(nullable: false),
                        LooseEndsThickEnds2 = c.Int(nullable: false),
                        LooseEndsThickEnds3 = c.Int(nullable: false),
                        LooseEndsThickEnds4 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap1 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap2 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap3 = c.Int(nullable: false),
                        ReedMarkBrokenEndsWrap4 = c.Int(nullable: false),
                        TotalPointsPerRoll = c.Int(nullable: false),
                        Points100SqYards = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualWidth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ends = c.Int(nullable: false),
                        Pick = c.Int(nullable: false),
                        NoOfCutFault = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MildWetBar = c.Int(nullable: false),
                        SmallslubKnotes = c.Int(nullable: false),
                        WeightPerRoll = c.Int(nullable: false),
                        ActualGramSqr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FabricInspReportLocals", t => t.FabInspReportId, cascadeDelete: false)
                .Index(t => t.FabInspReportId);
            
            CreateTable(
                "dbo.FabricInspStandards",
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
                "dbo.FabricInspStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusId = c.String(nullable: false, maxLength: 1),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FabricInspTypes",
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
                "dbo.FabricTypes",
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
                "dbo.IndDomestics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        IndentDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerIDasSeller = c.Int(nullable: false),
                        CustomerBuyerName = c.String(),
                        CustomerIDasBuyer = c.Int(nullable: false),
                        CustomerSellerName = c.String(),
                        CustomerIDasLocalAgent = c.Int(nullable: false),
                        CustomerAsLocalAgent = c.String(),
                        OfferDate = c.DateTime(nullable: false),
                        confirmDate = c.DateTime(nullable: false),
                        CommodityGroups = c.Int(nullable: false),
                        CommodityTypeId = c.Int(nullable: false),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        DepartmentID = c.Int(nullable: false),
                        PaymenTermsId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityVariance = c.String(maxLength: 10),
                        TotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValueOnCommRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackingRemarks = c.String(maxLength: 1500),
                        DeliveryRemarks = c.String(maxLength: 1500),
                        DeliveryRemarksBuyer = c.String(maxLength: 1000),
                        GeneralRemarks = c.String(maxLength: 2000),
                        SpecialConditions = c.String(maxLength: 1500),
                        SpecialConditionsBuyer = c.String(maxLength: 1500),
                        SpecialConditionsSeller = c.String(maxLength: 1500),
                        PicesLength = c.String(maxLength: 1500),
                        QualityRemarks = c.String(maxLength: 1500),
                        FinancialRemarks = c.String(maxLength: 1500),
                        Specificatiions = c.String(maxLength: 1500),
                        PriceTerms = c.String(maxLength: 200),
                        Destination = c.String(maxLength: 200),
                        CottonSource = c.String(maxLength: 200),
                        CostingSheetRef = c.String(maxLength: 50),
                        RevisionNumber = c.Int(nullable: false),
                        ClosingRemaks = c.String(maxLength: 200),
                        closedDate = c.DateTime(nullable: false),
                        ExecutedTotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsScheduleGenerated = c.Boolean(nullable: false),
                        DelDateValidUpto = c.DateTime(nullable: false),
                        IsApproved = c.String(maxLength: 1),
                        LastApprovedOn = c.DateTime(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        MarketedBy = c.Int(nullable: false),
                        IsSubmitForApproval = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.InquiryId, cascadeDelete: false)
                .ForeignKey("dbo.IndPaymentTerms", t => t.PaymenTermsId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.CommodityTypeId)
                .Index(t => t.InquiryId)
                .Index(t => t.DepartmentID)
                .Index(t => t.PaymenTermsId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.CommInvoiceAgentComms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleContractCommID = c.String(nullable: false, maxLength: 13),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        CommissionId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CommPaidTo = c.Int(nullable: false),
                        CommPaidFrom = c.Int(nullable: false),
                        CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isLocalCurrency = c.Boolean(nullable: false),
                        CommissionType = c.String(nullable: false, maxLength: 1),
                        CommissionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommissionDiscountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesTaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommissionNetValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommissionDiscountRemarks = c.String(nullable: false, maxLength: 100),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.IndCommissions", t => t.CommissionId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.CommissionId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.IndCommissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleContractCommID = c.String(nullable: false, maxLength: 13),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        CustomerIdCommPaidTo = c.Int(nullable: false),
                        CustomerIdCommPaidFrom = c.Int(nullable: false),
                        CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommissionType = c.String(nullable: false, maxLength: 1),
                        IsinLocalCurrecncy = c.Boolean(nullable: false),
                        CommissionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 20),
                        CalculatedCommissionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                        TTRoutingInstructions = c.String(maxLength: 500),
                        IsPrintable = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .Index(t => t.IndentId);
            
            CreateTable(
                "dbo.CommodityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        ScheduleType = c.String(maxLength: 1),
                        DomesticMarket = c.String(maxLength: 1),
                        ScheduleTypeDomestic = c.String(maxLength: 1),
                        InternationalMarket = c.String(maxLength: 1),
                        ScheduleTypeInternational = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDomesticInquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        Companyid = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        CommodityTypeId = c.Int(nullable: false),
                        InquiryDate = c.DateTime(nullable: false),
                        InquiryClosedDate = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        PaymenTermsId = c.Int(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        IndPaymentTerms_Id = c.Int(),
                        IndPaymentTerms_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityTypeId, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.IndPaymentTerms", t => t.IndPaymentTerms_Id)
                .ForeignKey("dbo.IndPaymentTerms", t => t.IndPaymentTerms_Id1)
                .ForeignKey("dbo.IndPaymentTerms", t => t.PaymenTermsId, cascadeDelete: false)
                .Index(t => t.DepartmentID)
                .Index(t => t.CommodityTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymenTermsId)
                .Index(t => t.IndPaymentTerms_Id)
                .Index(t => t.IndPaymentTerms_Id1);
            
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
                "dbo.IndDomesticInquiryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UosId = c.Int(nullable: false),
                        IndDomesticInquiry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomestics", t => t.InquiryId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.UnitOfSales", t => t.UosId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.IndDomesticInquiry_Id)
                .Index(t => t.InquiryId)
                .Index(t => t.ProductId)
                .Index(t => t.UosId)
                .Index(t => t.IndDomesticInquiry_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 250),
                        isValueAdded = c.String(maxLength: 1),
                        StuffedQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CommodityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityId, cascadeDelete: false)
                .Index(t => t.CommodityId);
            
            CreateTable(
                "dbo.UnitOfSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        UomID = c.Int(nullable: false),
                        UorID = c.Int(nullable: false),
                        StuffingUnit = c.String(maxLength: 2),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardUOM = c.Int(nullable: false),
                        StandardUOMFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 200),
                        ShipmentSchedule = c.String(maxLength: 1),
                        RequireStuffing = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndUnitOfMeasures", t => t.UomID, cascadeDelete: false)
                .ForeignKey("dbo.UnitOfRates", t => t.UorID, cascadeDelete: false)
                .Index(t => t.UomID)
                .Index(t => t.UorID);
            
            CreateTable(
                "dbo.IndCommissionInvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommissionInvoiceNo = c.Int(nullable: false),
                        CommissionInvoiceKey = c.String(nullable: false, maxLength: 10),
                        UnitOfSaleId = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.IndCommissionInvoices", t => t.CommissionInvoiceNo, cascadeDelete: false)
                .ForeignKey("dbo.UnitOfSales", t => t.UnitOfSaleId, cascadeDelete: false)
                .Index(t => t.CommissionInvoiceNo)
                .Index(t => t.UnitOfSaleId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.IndCommissionInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommissionInvoiceKey = c.String(nullable: false, maxLength: 10),
                        InvoiceDate = c.DateTime(nullable: false),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        SuppliorInvoiceNo = c.String(nullable: false, maxLength: 250),
                        SuppliorInvoiceDate = c.DateTime(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Signature = c.String(nullable: false, maxLength: 200),
                        IsPosted = c.Boolean(nullable: false),
                        IsncludeSalesTax = c.Boolean(nullable: false),
                        IsWithHoldTax = c.Boolean(nullable: false),
                        SalesTaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxOfficeId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        PostedBy = c.Int(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        DispatchIncludeFrom = c.DateTime(nullable: false),
                        DispatchIncludeTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .ForeignKey("dbo.SalesTaxOffices", t => t.TaxOfficeId, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.CurrencyId)
                .Index(t => t.TaxOfficeId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Symbol = c.String(maxLength: 5),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExRDate = c.DateTime(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        SellingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate120Selling = c.String(nullable: false, maxLength: 10),
                        Rate120Buying = c.String(nullable: false, maxLength: 10),
                        OpenMktSelling = c.String(nullable: false, maxLength: 10),
                        OpenMktBuying = c.String(nullable: false, maxLength: 10),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: false)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.SalesTaxOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Abbrivation = c.String(nullable: false, maxLength: 10),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndUnitOfMeasures",
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
                "dbo.UnitOfRates",
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
                "dbo.IndDomesticInquiryOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        OfferMadeOn = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OfferedBy = c.String(nullable: false, maxLength: 50),
                        OfferedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermsId = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 200),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.InquiryId, cascadeDelete: false)
                .ForeignKey("dbo.IndPaymentTerms", t => t.PaymentTermsId, cascadeDelete: false)
                .Index(t => t.InquiryId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentTermsId);
            
            CreateTable(
                "dbo.IndPaymentTerms",
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Description, unique: true, name: "IX_PaymentTerms_Indent");
            
            CreateTable(
                "dbo.IndDomesticInquiryReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryReviewQuestion = c.String(nullable: false, maxLength: 250),
                        InquiryId = c.Int(nullable: false),
                        InquiryKey = c.String(nullable: false, maxLength: 13),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomesticInquiries", t => t.InquiryId, cascadeDelete: false)
                .Index(t => t.InquiryId);
            
            CreateTable(
                "dbo.IndInquiryReviewQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InquiryReviewQuestion = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        ForMarket = c.String(maxLength: 1),
                        IndDomesticInquiryReview_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomesticInquiryReviews", t => t.IndDomesticInquiryReview_Id)
                .Index(t => t.IndDomesticInquiryReview_Id);
            
            CreateTable(
                "dbo.QcInspectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        isActive = c.Boolean(nullable: false),
                        CommodityId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityTypes", t => t.CommodityId, cascadeDelete: false)
                .Index(t => t.CommodityId);
            
            CreateTable(
                "dbo.IndDomesticDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesContractDetailID = c.String(maxLength: 13),
                        IndentId = c.Int(nullable: false),
                        IndentKey = c.String(nullable: false, maxLength: 10),
                        CommodityId = c.Int(nullable: false),
                        CommoditySpecification = c.String(maxLength: 200),
                        UosID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stuffing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeCode = c.Int(nullable: false),
                        SizeSpecifications = c.String(maxLength: 500),
                        GSM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerPieceWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerPieceUnitWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LabDip = c.String(maxLength: 500),
                        LabDipOption = c.String(maxLength: 5),
                        LabDipDate = c.DateTime(nullable: false),
                        WeightDispatched = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeColor = c.String(maxLength: 1),
                        FabricWidth = c.String(maxLength: 30),
                        QuantityReq = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitQuantityReq = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BarCode = c.String(maxLength: 20),
                        TotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValueOnCommRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExecutedQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExecutedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityPerFCL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColourId = c.Int(nullable: false),
                        SuppliorCode = c.Int(nullable: false),
                        DesignId = c.Int(nullable: false),
                        DesignNo = c.String(maxLength: 30),
                        FinParty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndColours", t => t.ColourId, cascadeDelete: false)
                .ForeignKey("dbo.IndDesigns", t => t.DesignId, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .ForeignKey("dbo.IndSizes", t => t.SizeCode, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.CommodityId, cascadeDelete: false)
                .ForeignKey("dbo.UnitOfSales", t => t.UosID, cascadeDelete: false)
                .ForeignKey("dbo.FinParties", t => t.FinParty_Id)
                .Index(t => t.IndentId)
                .Index(t => t.CommodityId)
                .Index(t => t.UosID)
                .Index(t => t.SizeCode)
                .Index(t => t.ColourId)
                .Index(t => t.DesignId)
                .Index(t => t.FinParty_Id);
            
            CreateTable(
                "dbo.IndColours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeId = c.Double(nullable: false),
                        ColourId = c.Double(nullable: false),
                        ColourDescription = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDesigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Symbol = c.String(maxLength: 5),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        PriorityinGroup = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeGroupId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndSizeGroups", t => t.SizeGroupId, cascadeDelete: false)
                .Index(t => t.SizeGroupId);
            
            CreateTable(
                "dbo.IndSizeGroups",
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
                "dbo.IndDomesticDispatchSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalDispatchNo = c.String(nullable: false, maxLength: 13),
                        BiltyNo = c.String(nullable: false, maxLength: 20),
                        TransDate = c.DateTime(nullable: false),
                        ContractedDeliveryDate = c.DateTime(nullable: false),
                        TypeOfTransaction = c.String(nullable: false, maxLength: 1),
                        IndentId = c.Int(nullable: false),
                        SalesContractDetail = c.String(nullable: false, maxLength: 13),
                        CompanyId = c.Int(nullable: false),
                        VehicleNo = c.String(nullable: false, maxLength: 20),
                        IsReceivedStinv = c.String(nullable: false, maxLength: 20),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GoodsFarwarderID = c.Int(nullable: false),
                        SalestaxInvoiceNo = c.String(nullable: false, maxLength: 255),
                        SalestaxInvoiceDate = c.DateTime(nullable: false),
                        IsDelayed = c.String(nullable: false, maxLength: 1),
                        DelayShipmentReason = c.String(nullable: false, maxLength: 2),
                        DelayShipmentReasonDescription = c.String(nullable: false, maxLength: 250),
                        IsComplaint = c.String(nullable: false, maxLength: 1),
                        isFirstDispatch = c.String(nullable: false, maxLength: 1),
                        isActive = c.Boolean(nullable: false),
                        isInvoiced = c.Boolean(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GovtTaxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivableAfterTaxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeTaxPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeTaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetReceviable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(nullable: false, maxLength: 200),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsForwarders", t => t.GoodsFarwarderID, cascadeDelete: false)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: false)
                .Index(t => t.IndentId)
                .Index(t => t.GoodsFarwarderID);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_IndentGForward_Indent");
            
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
                .ForeignKey("dbo.Countries", t => t.CId, cascadeDelete: false)
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
                .ForeignKey("dbo.Regions", t => t.RCode, cascadeDelete: false)
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
                .ForeignKey("dbo.BusinessTypes", t => t.BusId, cascadeDelete: false)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: false)
                .Index(t => t.CityId)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinBookTypes",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 60),
                        BookType = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.FinFescalYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        YearKey = c.String(nullable: false, maxLength: 14),
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
                        MonthKey = c.String(nullable: false, maxLength: 20),
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
                .ForeignKey("dbo.FinFescalYears", t => t.YearId, cascadeDelete: false)
                .Index(t => t.YearId);
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Description, unique: true, name: "IX_IndentGdesc_Indent");
            
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
                "dbo.IndDelayShipmentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 10),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndDelayShipmentReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 10),
                        DelayShipCategoryID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDelayShipmentCategories", t => t.DelayShipCategoryID, cascadeDelete: false)
                .Index(t => t.DelayShipCategoryID);
            
            CreateTable(
                "dbo.IndLeadTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
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
                        Abbrivation = c.String(nullable: false, maxLength: 15),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Description, unique: true, name: "IX_PTerms_Indent");
            
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ShipLine_Indent");
            
            CreateTable(
                "dbo.VM_FinLedger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        l1Code = c.String(),
                        l1_Title = c.String(),
                        l2Code = c.String(),
                        l2_Title = c.String(),
                        l3Code = c.String(),
                        l3_Title = c.String(),
                        l4Code = c.String(),
                        l4_Title = c.String(),
                        l5Code = c.String(maxLength: 18),
                        l5_Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        VKey = c.String(maxLength: 20),
                        GlCode = c.String(),
                        Detail = c.String(),
                        ChequeDate = c.DateTime(nullable: false),
                        ClearingDate = c.DateTime(nullable: false),
                        ChequeNo = c.String(),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoaL5", t => t.l5Code)
                .ForeignKey("dbo.FinVouchers", t => t.VKey)
                .Index(t => t.l5Code)
                .Index(t => t.VKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VM_FinLedger", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.VM_FinLedger", "l5Code", "dbo.CoaL5");
            DropForeignKey("dbo.IndDelayShipmentReasons", "DelayShipCategoryID", "dbo.IndDelayShipmentCategories");
            DropForeignKey("dbo.FinFescalYearDetails", "YearId", "dbo.FinFescalYears");
            DropForeignKey("dbo.CustomerContacts", "ContactType_Id", "dbo.ContactTypes");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Companies", "BusId", "dbo.BusinessTypes");
            DropForeignKey("dbo.Areas", "Ctcode", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StId", "dbo.States");
            DropForeignKey("dbo.States", "CId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "RCode", "dbo.Regions");
            DropForeignKey("dbo.FinVoucherDetails", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.IndDomesticDetails", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.FinVoucherDetails", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.FabricInspReportLocals", "QcInspectorId", "dbo.QcInspectors");
            DropForeignKey("dbo.FabricInspReportLocals", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndDomestics", "PaymenTermsId", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomestics", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticDispatchSchedules", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndDomesticDispatchSchedules", "GoodsFarwarderID", "dbo.GoodsForwarders");
            DropForeignKey("dbo.IndDomesticDetails", "UosID", "dbo.UnitOfSales");
            DropForeignKey("dbo.IndDomesticDetails", "CommodityId", "dbo.Products");
            DropForeignKey("dbo.IndDomesticDetails", "SizeCode", "dbo.IndSizes");
            DropForeignKey("dbo.IndSizes", "SizeGroupId", "dbo.IndSizeGroups");
            DropForeignKey("dbo.IndDomesticDetails", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndDomesticDetails", "DesignId", "dbo.IndDesigns");
            DropForeignKey("dbo.IndDomesticDetails", "ColourId", "dbo.IndColours");
            DropForeignKey("dbo.IndDomestics", "DepartmentID", "dbo.HrDepartments");
            DropForeignKey("dbo.IndDomestics", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomestics", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.IndDomestics", "CommodityTypeId", "dbo.CommodityTypes");
            DropForeignKey("dbo.QcInspectors", "CommodityId", "dbo.CommodityTypes");
            DropForeignKey("dbo.IndDomesticInquiries", "PaymenTermsId", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndInquiryReviewQuestions", "IndDomesticInquiryReview_Id", "dbo.IndDomesticInquiryReviews");
            DropForeignKey("dbo.IndDomesticInquiryReviews", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticInquiryOffers", "PaymentTermsId", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiries", "IndPaymentTerms_Id1", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiries", "IndPaymentTerms_Id", "dbo.IndPaymentTerms");
            DropForeignKey("dbo.IndDomesticInquiryOffers", "InquiryId", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticInquiryOffers", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "IndDomesticInquiry_Id", "dbo.IndDomesticInquiries");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "UosId", "dbo.UnitOfSales");
            DropForeignKey("dbo.UnitOfSales", "UorID", "dbo.UnitOfRates");
            DropForeignKey("dbo.UnitOfSales", "UomID", "dbo.IndUnitOfMeasures");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "UnitOfSaleId", "dbo.UnitOfSales");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "CommissionInvoiceNo", "dbo.IndCommissionInvoices");
            DropForeignKey("dbo.IndCommissionInvoices", "TaxOfficeId", "dbo.SalesTaxOffices");
            DropForeignKey("dbo.IndCommissionInvoices", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndCommissionInvoices", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.ExchangeRates", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CommodityId", "dbo.CommodityTypes");
            DropForeignKey("dbo.IndDomesticInquiryDetails", "InquiryId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndDomesticInquiries", "DepartmentID", "dbo.HrDepartments");
            DropForeignKey("dbo.IndDomesticInquiries", "CustomerId", "dbo.FinParties");
            DropForeignKey("dbo.IndDomesticInquiries", "CommodityTypeId", "dbo.CommodityTypes");
            DropForeignKey("dbo.CommInvoiceAgentComms", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.CommInvoiceAgentComms", "CommissionId", "dbo.IndCommissions");
            DropForeignKey("dbo.IndCommissions", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.CommInvoiceAgentComms", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.FabricInspReportLocals", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.FabricInspReportLocals", "FabricTypeId", "dbo.FabricTypes");
            DropForeignKey("dbo.FabricInspReportLocals", "FabInspTypeId", "dbo.FabricInspTypes");
            DropForeignKey("dbo.FabricInspReportLocals", "InspStatusId", "dbo.FabricInspStatus");
            DropForeignKey("dbo.FabricInspReportLocals", "FabInspStandardId", "dbo.FabricInspStandards");
            DropForeignKey("dbo.FabricInspReportLocalDetails", "FabInspReportId", "dbo.FabricInspReportLocals");
            DropForeignKey("dbo.FabricInspReportLocals", "LoomTypeId", "dbo.FabricInspLoomTypes");
            DropForeignKey("dbo.FabInspReportLocalSums", "FabInspReportId", "dbo.FabricInspReportLocals");
            DropForeignKey("dbo.CustomerInstructions", "CiId", "dbo.SpecialInstructions");
            DropForeignKey("dbo.CustomerInstructions", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerSocials", "Sid", "dbo.Socials");
            DropForeignKey("dbo.CustomerSocials", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerContacts", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerContacts", "ContTypeId", "dbo.Machines");
            DropForeignKey("dbo.CustomerContactPersons", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerContactPersons", "ContTypeId", "dbo.Machines");
            DropForeignKey("dbo.CustomerMachines", "MId", "dbo.Machines");
            DropForeignKey("dbo.CustomerMachines", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerCertifications", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerCertifications", "CertifyId", "dbo.Certifications");
            DropForeignKey("dbo.CustomerBrands", "PartyId", "dbo.FinParties");
            DropForeignKey("dbo.CustomerBrands", "Bid", "dbo.Brands");
            DropForeignKey("dbo.CoaL5", "FinParties_Id", "dbo.FinParties");
            DropForeignKey("dbo.FinLedgers", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.FinVoucherDetails", "VKey", "dbo.FinVouchers");
            DropForeignKey("dbo.FinVoucherDetails", "GlCode", "dbo.CoaL5");
            DropForeignKey("dbo.FinLedgers", "GlCode", "dbo.CoaL5");
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
            DropIndex("dbo.VM_FinLedger", new[] { "VKey" });
            DropIndex("dbo.VM_FinLedger", new[] { "l5Code" });
            DropIndex("dbo.ShipingLines", "IX_ShipLine_Indent");
            DropIndex("dbo.IndPriceTerms", "IX_PTerms_Indent");
            DropIndex("dbo.IndDelayShipmentReasons", new[] { "DelayShipCategoryID" });
            DropIndex("dbo.IndGeneralDescriptions", "IX_IndentGdesc_Indent");
            DropIndex("dbo.FinVTypes", new[] { "Key" });
            DropIndex("dbo.FinFescalYearDetails", new[] { "YearId" });
            DropIndex("dbo.Companies", new[] { "BusId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.Countries", new[] { "RCode" });
            DropIndex("dbo.States", new[] { "CId" });
            DropIndex("dbo.GoodsForwarders", "IX_IndentGForward_Indent");
            DropIndex("dbo.IndDomesticDispatchSchedules", new[] { "GoodsFarwarderID" });
            DropIndex("dbo.IndDomesticDispatchSchedules", new[] { "IndentId" });
            DropIndex("dbo.IndSizes", new[] { "SizeGroupId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "FinParty_Id" });
            DropIndex("dbo.IndDomesticDetails", new[] { "DesignId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "ColourId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "SizeCode" });
            DropIndex("dbo.IndDomesticDetails", new[] { "UosID" });
            DropIndex("dbo.IndDomesticDetails", new[] { "CommodityId" });
            DropIndex("dbo.IndDomesticDetails", new[] { "IndentId" });
            DropIndex("dbo.QcInspectors", new[] { "CommodityId" });
            DropIndex("dbo.IndInquiryReviewQuestions", new[] { "IndDomesticInquiryReview_Id" });
            DropIndex("dbo.IndDomesticInquiryReviews", new[] { "InquiryId" });
            DropIndex("dbo.IndPaymentTerms", "IX_PaymentTerms_Indent");
            DropIndex("dbo.IndDomesticInquiryOffers", new[] { "PaymentTermsId" });
            DropIndex("dbo.IndDomesticInquiryOffers", new[] { "CustomerId" });
            DropIndex("dbo.IndDomesticInquiryOffers", new[] { "InquiryId" });
            DropIndex("dbo.ExchangeRates", new[] { "CurrencyId" });
            DropIndex("dbo.IndCommissionInvoices", new[] { "TaxOfficeId" });
            DropIndex("dbo.IndCommissionInvoices", new[] { "CurrencyId" });
            DropIndex("dbo.IndCommissionInvoices", new[] { "IndentId" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CompanyId" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "UnitOfSaleId" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CommissionInvoiceNo" });
            DropIndex("dbo.UnitOfSales", new[] { "UorID" });
            DropIndex("dbo.UnitOfSales", new[] { "UomID" });
            DropIndex("dbo.Products", new[] { "CommodityId" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "IndDomesticInquiry_Id" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "UosId" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "ProductId" });
            DropIndex("dbo.IndDomesticInquiryDetails", new[] { "InquiryId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "IndPaymentTerms_Id1" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "IndPaymentTerms_Id" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "PaymenTermsId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "CustomerId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "CommodityTypeId" });
            DropIndex("dbo.IndDomesticInquiries", new[] { "DepartmentID" });
            DropIndex("dbo.IndCommissions", new[] { "IndentId" });
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "CompanyId" });
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "CommissionId" });
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "IndentId" });
            DropIndex("dbo.IndDomestics", new[] { "CurrencyId" });
            DropIndex("dbo.IndDomestics", new[] { "PaymenTermsId" });
            DropIndex("dbo.IndDomestics", new[] { "DepartmentID" });
            DropIndex("dbo.IndDomestics", new[] { "InquiryId" });
            DropIndex("dbo.IndDomestics", new[] { "CommodityTypeId" });
            DropIndex("dbo.IndDomestics", new[] { "CustomerId" });
            DropIndex("dbo.FabricInspReportLocalDetails", new[] { "FabInspReportId" });
            DropIndex("dbo.FabInspReportLocalSums", new[] { "FabInspReportId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "QcInspectorId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "InspStatusId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabricTypeId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "LoomTypeId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabInspTypeId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "FabInspStandardId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "IndentId" });
            DropIndex("dbo.FabricInspReportLocals", new[] { "CompanyId" });
            DropIndex("dbo.CustomerInstructions", new[] { "PartyId" });
            DropIndex("dbo.CustomerInstructions", new[] { "CiId" });
            DropIndex("dbo.CustomerSocials", new[] { "PartyId" });
            DropIndex("dbo.CustomerSocials", new[] { "Sid" });
            DropIndex("dbo.CustomerContacts", new[] { "ContactType_Id" });
            DropIndex("dbo.CustomerContacts", new[] { "ContTypeId" });
            DropIndex("dbo.CustomerContacts", new[] { "PartyId" });
            DropIndex("dbo.CustomerMachines", new[] { "PartyId" });
            DropIndex("dbo.CustomerMachines", new[] { "MId" });
            DropIndex("dbo.CustomerContactPersons", new[] { "PartyId" });
            DropIndex("dbo.CustomerContactPersons", new[] { "ContTypeId" });
            DropIndex("dbo.CustomerCertifications", new[] { "CertifyId" });
            DropIndex("dbo.CustomerCertifications", new[] { "PartyId" });
            DropIndex("dbo.Brands", "IX_Brand_Inventory");
            DropIndex("dbo.CustomerBrands", new[] { "PartyId" });
            DropIndex("dbo.CustomerBrands", new[] { "Bid" });
            DropIndex("dbo.FinVoucherDetails", new[] { "City_Id" });
            DropIndex("dbo.FinVoucherDetails", new[] { "FinParty_Id" });
            DropIndex("dbo.FinVoucherDetails", new[] { "GlCode" });
            DropIndex("dbo.FinVoucherDetails", new[] { "VKey" });
            DropIndex("dbo.FinLedgers", new[] { "GlCode" });
            DropIndex("dbo.FinLedgers", new[] { "VKey" });
            DropIndex("dbo.FinBudgets", new[] { "GlCode" });
            DropIndex("dbo.CoaL2", new[] { "L1Code" });
            DropIndex("dbo.CoaL3", new[] { "L2Code" });
            DropIndex("dbo.CoaL4", new[] { "L3Code" });
            DropIndex("dbo.CoaL5", new[] { "FinParties_Id" });
            DropIndex("dbo.CoaL5", new[] { "L4Code" });
            DropIndex("dbo.FinParties", new[] { "CityCode" });
            DropIndex("dbo.FinParties", "IX_Party_Inventory");
            DropIndex("dbo.Cities", new[] { "StId" });
            DropIndex("dbo.Areas", new[] { "Ctcode" });
            DropIndex("dbo.UserModuleDetails", new[] { "ModuleDtlId" });
            DropIndex("dbo.UserModuleDetails", new[] { "UserId" });
            DropIndex("dbo.UserModules", new[] { "ModuleId" });
            DropIndex("dbo.UserModules", new[] { "UserId" });
            DropIndex("dbo.AdminModuleDetails", new[] { "AModuleId" });
            DropTable("dbo.VM_FinLedger");
            DropTable("dbo.ShipingLines");
            DropTable("dbo.IndPriceTerms");
            DropTable("dbo.IndLeadTimes");
            DropTable("dbo.IndDelayShipmentReasons");
            DropTable("dbo.IndDelayShipmentCategories");
            DropTable("dbo.HrEmployees");
            DropTable("dbo.IndGeneralDescriptions");
            DropTable("dbo.FinVTypes");
            DropTable("dbo.FinFescalYearDetails");
            DropTable("dbo.FinFescalYears");
            DropTable("dbo.FinBookTypes");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.Regions");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.GoodsForwarders");
            DropTable("dbo.IndDomesticDispatchSchedules");
            DropTable("dbo.IndSizeGroups");
            DropTable("dbo.IndSizes");
            DropTable("dbo.IndDesigns");
            DropTable("dbo.IndColours");
            DropTable("dbo.IndDomesticDetails");
            DropTable("dbo.QcInspectors");
            DropTable("dbo.IndInquiryReviewQuestions");
            DropTable("dbo.IndDomesticInquiryReviews");
            DropTable("dbo.IndPaymentTerms");
            DropTable("dbo.IndDomesticInquiryOffers");
            DropTable("dbo.UnitOfRates");
            DropTable("dbo.IndUnitOfMeasures");
            DropTable("dbo.SalesTaxOffices");
            DropTable("dbo.ExchangeRates");
            DropTable("dbo.Currencies");
            DropTable("dbo.IndCommissionInvoices");
            DropTable("dbo.IndCommissionInvoiceDetails");
            DropTable("dbo.UnitOfSales");
            DropTable("dbo.Products");
            DropTable("dbo.IndDomesticInquiryDetails");
            DropTable("dbo.HrDepartments");
            DropTable("dbo.IndDomesticInquiries");
            DropTable("dbo.CommodityTypes");
            DropTable("dbo.IndCommissions");
            DropTable("dbo.CommInvoiceAgentComms");
            DropTable("dbo.IndDomestics");
            DropTable("dbo.FabricTypes");
            DropTable("dbo.FabricInspTypes");
            DropTable("dbo.FabricInspStatus");
            DropTable("dbo.FabricInspStandards");
            DropTable("dbo.FabricInspReportLocalDetails");
            DropTable("dbo.FabricInspLoomTypes");
            DropTable("dbo.FabInspReportLocalSums");
            DropTable("dbo.FabricInspReportLocals");
            DropTable("dbo.SpecialInstructions");
            DropTable("dbo.CustomerInstructions");
            DropTable("dbo.Socials");
            DropTable("dbo.CustomerSocials");
            DropTable("dbo.CustomerContacts");
            DropTable("dbo.CustomerMachines");
            DropTable("dbo.Machines");
            DropTable("dbo.CustomerContactPersons");
            DropTable("dbo.Certifications");
            DropTable("dbo.CustomerCertifications");
            DropTable("dbo.Brands");
            DropTable("dbo.CustomerBrands");
            DropTable("dbo.FinVoucherDetails");
            DropTable("dbo.FinVouchers");
            DropTable("dbo.FinLedgers");
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
