namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommissionInvoiceTables : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: true)
                .ForeignKey("dbo.SalesTaxOffices", t => t.TaxOfficeId, cascadeDelete: true)
                .Index(t => t.IndentId)
                .Index(t => t.CurrencyId)
                .Index(t => t.TaxOfficeId);
            
            CreateTable(
                "dbo.IndCommissionInvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommissionInvoiceNo = c.Int(nullable: false),
                        CommissionInvoiceKey = c.String(nullable: false, maxLength: 10),
                        UnitOfSale = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinParties", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.IndCommissionInvoices", t => t.CommissionInvoiceNo, cascadeDelete: false)
                .ForeignKey("dbo.UnitOfSales", t => t.UnitOfSale, cascadeDelete: false)
                .Index(t => t.CommissionInvoiceNo)
                .Index(t => t.UnitOfSale)
                .Index(t => t.CompanyId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommInvoiceAgentComms", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.CommInvoiceAgentComms", "CommissionId", "dbo.IndCommissions");
            DropForeignKey("dbo.CommInvoiceAgentComms", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.IndCommissionInvoices", "TaxOfficeId", "dbo.SalesTaxOffices");
            DropForeignKey("dbo.IndCommissionInvoices", "IndentId", "dbo.IndDomestics");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "UnitOfSale", "dbo.UnitOfSales");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "CommissionInvoiceNo", "dbo.IndCommissionInvoices");
            DropForeignKey("dbo.IndCommissionInvoiceDetails", "CompanyId", "dbo.FinParties");
            DropForeignKey("dbo.IndCommissionInvoices", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "CompanyId" });
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "CommissionId" });
            DropIndex("dbo.CommInvoiceAgentComms", new[] { "IndentId" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CompanyId" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "UnitOfSale" });
            DropIndex("dbo.IndCommissionInvoiceDetails", new[] { "CommissionInvoiceNo" });
            DropIndex("dbo.IndCommissionInvoices", new[] { "TaxOfficeId" });
            DropIndex("dbo.IndCommissionInvoices", new[] { "CurrencyId" });
            DropIndex("dbo.IndCommissionInvoices", new[] { "IndentId" });
            DropTable("dbo.CommInvoiceAgentComms");
            DropTable("dbo.SalesTaxOffices");
            DropTable("dbo.IndCommissionInvoiceDetails");
            DropTable("dbo.IndCommissionInvoices");
        }
    }
}
