namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedForeignLedgertables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FNL_CommissionPaymentDetail");
            CreateTable(
                "dbo.IndExportShipmentScheduleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentScheduleId = c.Int(nullable: false),
                        ShipmentScheduleKey = c.String(maxLength: 13),
                        SalesContractDetailID = c.String(maxLength: 13),
                        srno = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        UosID = c.Int(nullable: false),
                        Quantity = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        QuantityDispatched = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        Bale_RoleNo = c.Int(),
                        InspStatus = c.String(maxLength: 1),
                        Rate = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        ShipmentAmount = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        TotalWeight = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        WeightDiff = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        NetWeight = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndExportShipmentScheduleMasters", t => t.ShipmentScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfSales", t => t.UosID, cascadeDelete: true)
                .Index(t => t.ShipmentScheduleId)
                .Index(t => t.UosID);
            
            CreateTable(
                "dbo.IndExportShipmentScheduleMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentScheduleKey = c.String(nullable: false, maxLength: 13),
                        IndentId = c.Int(nullable: false),
                        SalesContractKey = c.String(nullable: false, maxLength: 10),
                        SalesContractDetailKey = c.String(maxLength: 13),
                        Fcl = c.String(nullable: false, maxLength: 2),
                        TotalFcls = c.String(maxLength: 2),
                        ShippedQuantity = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        ShippedWeight = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        InspSrNo = c.String(maxLength: 10),
                        LcSerialNo = c.String(maxLength: 12),
                        DocumentReceived = c.Boolean(nullable: false),
                        DocumentConfirmed = c.Boolean(nullable: false),
                        DocumentFaxed = c.Boolean(nullable: false),
                        SellerContractedShipmentDate = c.DateTime(),
                        SellerContractedShipmentDateRemarks = c.String(maxLength: 40),
                        BuyerContractedShipmentDate = c.DateTime(),
                        BuyerContractedShipmentDateRemarks = c.String(maxLength: 40),
                        ExmillDate1 = c.DateTime(),
                        ExmillDate2 = c.DateTime(),
                        ExmillDate3 = c.DateTime(),
                        ETDate1 = c.DateTime(),
                        ETDate2 = c.DateTime(),
                        ETDate3 = c.DateTime(),
                        ActualExMillDate = c.DateTime(),
                        ActualETADate = c.DateTime(),
                        ActualETDate = c.DateTime(),
                        ShippingLineId = c.String(maxLength: 4),
                        ContainerNo = c.String(maxLength: 50),
                        DestinationPort = c.String(maxLength: 50),
                        VesselName = c.String(maxLength: 50),
                        ShipmentStatus = c.String(maxLength: 2),
                        ShipmentRemarks = c.String(maxLength: 500),
                        ComplaintCode = c.String(maxLength: 1),
                        ComplaintRemarks = c.String(maxLength: 500),
                        Reject = c.Boolean(nullable: false),
                        InspectionRemarks = c.String(maxLength: 1),
                        Remarks = c.String(maxLength: 500),
                        TransentPeriod = c.Int(),
                        InvoiceNo = c.String(maxLength: 10),
                        duedate = c.DateTime(),
                        InspectionDateFab = c.DateTime(),
                        LeadTimeDescriptionID = c.String(maxLength: 2),
                        DelayShipmentReasonID = c.String(maxLength: 2),
                        ShortPiece = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        ProductionStatus = c.String(maxLength: 1),
                        ProductionRemarks = c.String(maxLength: 255),
                        BLNo = c.String(maxLength: 30),
                        BLDate = c.DateTime(),
                        SuplierReferenceNo = c.String(maxLength: 30),
                        IsCancel = c.Boolean(nullable: false),
                        companyid = c.Int(nullable: false),
                        FabricSampleReadyDate = c.DateTime(),
                        FollowupSheetRefNo = c.String(maxLength: 7),
                        EInspectionDate = c.DateTime(),
                        InlineOneInspectionDate = c.DateTime(),
                        InlinetwoInspectionDate = c.DateTime(),
                        FinalInspectionDate = c.DateTime(),
                        TentativeExmill = c.DateTime(),
                        TentativeETA = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndDomestics", t => t.IndentId, cascadeDelete: true)
                .Index(t => t.IndentId);
            
            CreateTable(
                "dbo.FNLCommissionBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FNLCommissionBillKey = c.String(nullable: false, maxLength: 12),
                        BillDate = c.DateTime(nullable: false),
                        FNLAccount = c.String(maxLength: 18),
                        IsPostedBySystem = c.Boolean(),
                        IsOpeningBalance = c.Boolean(),
                        CompanyId = c.Int(nullable: false),
                        CompanyId_Key = c.String(maxLength: 3),
                        CurrencyId = c.Int(nullable: false),
                        Currency = c.String(maxLength: 3),
                        TranType = c.String(maxLength: 3),
                        DeptId = c.Int(nullable: false),
                        DepartmentID_Key = c.String(maxLength: 4),
                        CommissionInvoiceNo = c.Int(nullable: false),
                        CommissionInvoiceNo_Key = c.String(maxLength: 10),
                        CommissionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClearedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClearedAmountReceiveDate = c.DateTime(),
                        IsCleared = c.Boolean(),
                        Responsibility = c.String(maxLength: 6),
                        AmountCredited = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountAsMiscCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        exchangeRate_ID = c.Int(nullable: false),
                        ExchangeRate = c.Decimal(precision: 18, scale: 2),
                        TaxDeductedPercent = c.Decimal(precision: 18, scale: 2),
                        AccountAsTaxDeducted = c.Decimal(precision: 18, scale: 2),
                        AccountAsReceivedinBankAccount = c.Decimal(precision: 18, scale: 2),
                        Narration = c.String(maxLength: 250),
                        ReturnableCurrencyRate = c.Decimal(precision: 18, scale: 2),
                        ReturnableCurrencyId = c.Int(nullable: false),
                        ReturnableCurency_Key = c.String(maxLength: 3),
                        ReturnableFCAmount = c.Decimal(precision: 18, scale: 2),
                        RequirePosting = c.String(maxLength: 1),
                        PaymentPosted = c.String(maxLength: 1),
                        SenderRefNo = c.String(maxLength: 50),
                        SenderRefNoDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FNL_CommissionPaymentDetail", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBill_ID", c => c.Int(nullable: false));
            AddColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBillKey", c => c.String(maxLength: 12));
            AddColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommission_invoiceKey", c => c.String(maxLength: 12));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "DelayShipmentReasonDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.HrTaskRegisters", "Status", c => c.String(maxLength: 2));
            AlterColumn("dbo.HrTaskProgresses", "Comments", c => c.String(maxLength: 2500));
            AddPrimaryKey("dbo.FNL_CommissionPaymentDetail", "Id");
            CreateIndex("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBill_ID");
            AddForeignKey("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBill_ID", "dbo.FNLCommissionBills", "Id", cascadeDelete: true);
            DropColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommission_invoice");
            DropColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBillID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBillID", c => c.String(maxLength: 12));
            AddColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommission_invoice", c => c.String(nullable: false, maxLength: 12));
            DropForeignKey("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBill_ID", "dbo.FNLCommissionBills");
            DropForeignKey("dbo.IndExportShipmentScheduleDetails", "UosID", "dbo.UnitOfSales");
            DropForeignKey("dbo.IndExportShipmentScheduleDetails", "ShipmentScheduleId", "dbo.IndExportShipmentScheduleMasters");
            DropForeignKey("dbo.IndExportShipmentScheduleMasters", "IndentId", "dbo.IndDomestics");
            DropIndex("dbo.FNL_CommissionPaymentDetail", new[] { "FNLCommissionBill_ID" });
            DropIndex("dbo.IndExportShipmentScheduleMasters", new[] { "IndentId" });
            DropIndex("dbo.IndExportShipmentScheduleDetails", new[] { "UosID" });
            DropIndex("dbo.IndExportShipmentScheduleDetails", new[] { "ShipmentScheduleId" });
            DropPrimaryKey("dbo.FNL_CommissionPaymentDetail");
            AlterColumn("dbo.HrTaskProgresses", "Comments", c => c.String(nullable: false, maxLength: 2500));
            AlterColumn("dbo.HrTaskRegisters", "Status", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.IndDomesticDispatchSchedules", "DelayShipmentReasonDescription", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommission_invoiceKey");
            DropColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBillKey");
            DropColumn("dbo.FNL_CommissionPaymentDetail", "FNLCommissionBill_ID");
            DropColumn("dbo.FNL_CommissionPaymentDetail", "Id");
            DropTable("dbo.FNLCommissionBills");
            DropTable("dbo.IndExportShipmentScheduleMasters");
            DropTable("dbo.IndExportShipmentScheduleDetails");
            AddPrimaryKey("dbo.FNL_CommissionPaymentDetail", "FNLCommission_invoice");
        }
    }
}
