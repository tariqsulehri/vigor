namespace VIGOR.ImportUtility
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImportDataModel : DbContext
    {
        public ImportDataModel()
            : base("name=ImportDataModel")
        {
        }

        public virtual DbSet<CC_Accessory> CC_Accessory { get; set; }
        public virtual DbSet<CC_BusinessNature> CC_BusinessNature { get; set; }
        public virtual DbSet<CC_Certifications> CC_Certifications { get; set; }
        public virtual DbSet<CC_City> CC_City { get; set; }
        public virtual DbSet<CC_Colors> CC_Colors { get; set; }
        public virtual DbSet<CC_CommodityType> CC_CommodityType { get; set; }
        public virtual DbSet<CC_ContactTypes> CC_ContactTypes { get; set; }
        public virtual DbSet<CC_Country> CC_Country { get; set; }
        public virtual DbSet<CC_Currency> CC_Currency { get; set; }
        public virtual DbSet<CC_Customer> CC_Customer { get; set; }
        public virtual DbSet<CC_DelayShipmentCategory> CC_DelayShipmentCategory { get; set; }
        public virtual DbSet<CC_DelayShipmentReason> CC_DelayShipmentReason { get; set; }
        public virtual DbSet<CC_Designs> CC_Designs { get; set; }
        public virtual DbSet<CC_DocumentEFilingType> CC_DocumentEFilingType { get; set; }
        public virtual DbSet<CC_DomesticPaymentAddOn> CC_DomesticPaymentAddOn { get; set; }
        public virtual DbSet<CC_GeneralDesc> CC_GeneralDesc { get; set; }
        public virtual DbSet<CC_GoodsForwarders> CC_GoodsForwarders { get; set; }
        public virtual DbSet<CC_InquiryReviewQuestions> CC_InquiryReviewQuestions { get; set; }
        public virtual DbSet<CC_LeadTime> CC_LeadTime { get; set; }
        public virtual DbSet<CC_PaymentTerms> CC_PaymentTerms { get; set; }
        public virtual DbSet<CC_PriceTerms> CC_PriceTerms { get; set; }
        public virtual DbSet<CC_Products> CC_Products { get; set; }
        public virtual DbSet<CC_Regions> CC_Regions { get; set; }
        public virtual DbSet<CC_ShippingLines> CC_ShippingLines { get; set; }
        public virtual DbSet<CC_SizeGroups> CC_SizeGroups { get; set; }
        public virtual DbSet<CC_Sizes> CC_Sizes { get; set; }
        public virtual DbSet<CC_UnitofMeasure> CC_UnitofMeasure { get; set; }
        public virtual DbSet<CC_UnitofRate> CC_UnitofRate { get; set; }
        public virtual DbSet<CC_UnitofSale> CC_UnitofSale { get; set; }
        public virtual DbSet<CompanyDefinition> CompanyDefinitions { get; set; }
        public virtual DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual DbSet<CompanyEOBISetting> CompanyEOBISettings { get; set; }
        public virtual DbSet<CPAFindingNature> CPAFindingNatures { get; set; }
        public virtual DbSet<CPAFindingNCType> CPAFindingNCTypes { get; set; }
        public virtual DbSet<CPAFindingNCTypeSub> CPAFindingNCTypeSubs { get; set; }
        public virtual DbSet<CPAFindingType> CPAFindingTypes { get; set; }
        public virtual DbSet<CpaNcType> CpaNcTypes { get; set; }
        public virtual DbSet<Cpa> Cpas { get; set; }
        public virtual DbSet<CpaType> CpaTypes { get; set; }
        public virtual DbSet<FabInspFabricType> FabInspFabricTypes { get; set; }
        public virtual DbSet<FabInspLoomType> FabInspLoomTypes { get; set; }
        public virtual DbSet<FabricInspReportExport> FabricInspReportExports { get; set; }
        public virtual DbSet<FabricSample> FabricSamples { get; set; }
        public virtual DbSet<FCTTExportSaleInvoice> FCTTExportSaleInvoices { get; set; }
        public virtual DbSet<FCTTLedger> FCTTLedgers { get; set; }
        public virtual DbSet<FNLAccount> FNLAccounts { get; set; }
        public virtual DbSet<FNLCOA> FNLCOAs { get; set; }
        public virtual DbSet<FNLCommissionBill> FNLCommissionBills { get; set; }
        public virtual DbSet<GL_BookType> GL_BookType { get; set; }
        public virtual DbSet<GL_Budgeting> GL_Budgeting { get; set; }
        public virtual DbSet<GL_ChequeStatuses> GL_ChequeStatuses { get; set; }
        public virtual DbSet<GL_COA> GL_COA { get; set; }
        public virtual DbSet<GL_FiscalPeriod> GL_FiscalPeriod { get; set; }
        public virtual DbSet<GL_FiscalPeriodVoucherCounter> GL_FiscalPeriodVoucherCounter { get; set; }
        public virtual DbSet<GL_FiscalYear> GL_FiscalYear { get; set; }
        public virtual DbSet<Gl_InvoiceBalances> Gl_InvoiceBalances { get; set; }
        public virtual DbSet<Gl_PostDatedChq> Gl_PostDatedChq { get; set; }
        public virtual DbSet<GL_VoucherMaster> GL_VoucherMaster { get; set; }
        public virtual DbSet<HR_AllowanceModes> HR_AllowanceModes { get; set; }
        public virtual DbSet<HR_AttendanceTimings> HR_AttendanceTimings { get; set; }
        public virtual DbSet<HR_CINCR> HR_CINCR { get; set; }
        public virtual DbSet<HR_DayStatus> HR_DayStatus { get; set; }
        public virtual DbSet<HR_Degree> HR_Degree { get; set; }
        public virtual DbSet<HR_Designation> HR_Designation { get; set; }
        public virtual DbSet<HR_Employee> HR_Employee { get; set; }
        public virtual DbSet<HR_EmployeeLoanAdvanceBalance> HR_EmployeeLoanAdvanceBalance { get; set; }
        public virtual DbSet<HR_EmployeeType> HR_EmployeeType { get; set; }
        public virtual DbSet<HR_GazzettedDays> HR_GazzettedDays { get; set; }
        public virtual DbSet<HR_History> HR_History { get; set; }
        public virtual DbSet<Hr_LoanAdvance> Hr_LoanAdvance { get; set; }
        public virtual DbSet<HR_LoanAdvanceApplication> HR_LoanAdvanceApplication { get; set; }
        public virtual DbSet<HR_MonthlyAttendance> HR_MonthlyAttendance { get; set; }
        public virtual DbSet<HR_SalaryMaster> HR_SalaryMaster { get; set; }
        public virtual DbSet<HR_ShortLeaves> HR_ShortLeaves { get; set; }
        public virtual DbSet<KnittedFabricInspection> KnittedFabricInspections { get; set; }
        public virtual DbSet<MinutesOfMeeting> MinutesOfMeetings { get; set; }
        public virtual DbSet<QEmail> QEmails { get; set; }
        public virtual DbSet<SampleHomeTextile> SampleHomeTextiles { get; set; }
        public virtual DbSet<SoftwareModule> SoftwareModules { get; set; }
        public virtual DbSet<SS_CommissionInvoice> SS_CommissionInvoice { get; set; }
        public virtual DbSet<SS_DispacthScheduleDomestic> SS_DispacthScheduleDomestic { get; set; }
        public virtual DbSet<SS_DomesticInquiryDetails> SS_DomesticInquiryDetails { get; set; }
        public virtual DbSet<SS_DomesticInquiryOffers> SS_DomesticInquiryOffers { get; set; }
        public virtual DbSet<SS_IndentAccessory> SS_IndentAccessory { get; set; }
        public virtual DbSet<SS_IndentCommission> SS_IndentCommission { get; set; }
        public virtual DbSet<SS_IndentDetails> SS_IndentDetails { get; set; }
        public virtual DbSet<SS_IndentMaster> SS_IndentMaster { get; set; }
        public virtual DbSet<SS_InquiryDetails> SS_InquiryDetails { get; set; }
        public virtual DbSet<SS_InquiryMaster> SS_InquiryMaster { get; set; }
        public virtual DbSet<SS_LcDetails> SS_LcDetails { get; set; }
        public virtual DbSet<SS_ShipmentScheduleMaster> SS_ShipmentScheduleMaster { get; set; }
        public virtual DbSet<Store_Document> Store_Document { get; set; }
        public virtual DbSet<Store_Po> Store_Po { get; set; }
        public virtual DbSet<Store_PoDetails> Store_PoDetails { get; set; }
        public virtual DbSet<Store_SIR> Store_SIR { get; set; }
        public virtual DbSet<Store_Voucher> Store_Voucher { get; set; }
        public virtual DbSet<StoreItem> StoreItems { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<StoreUnitConvert> StoreUnitConverts { get; set; }
        public virtual DbSet<StoreUnit> StoreUnits { get; set; }
        public virtual DbSet<SuppEvalForm> SuppEvalForms { get; set; }
        public virtual DbSet<SupplierEvaluationForm> SupplierEvaluationForms { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaskRegister> TaskRegisters { get; set; }
        public virtual DbSet<UMRole> UMRoles { get; set; }
        public virtual DbSet<UMUser> UMUsers { get; set; }
        public virtual DbSet<YarnInspectionReportType> YarnInspectionReportTypes { get; set; }
        public virtual DbSet<YarnInspection> YarnInspections { get; set; }
        public virtual DbSet<ADM_SystemOptions> ADM_SystemOptions { get; set; }
        public virtual DbSet<ADM_SystemOptions11> ADM_SystemOptions11 { get; set; }
        public virtual DbSet<ADM_SystemOptions123> ADM_SystemOptions123 { get; set; }
        public virtual DbSet<ADM_SystemOptions132> ADM_SystemOptions132 { get; set; }
        public virtual DbSet<ApprovedSupplier> ApprovedSuppliers { get; set; }
        public virtual DbSet<BasicIntegration> BasicIntegrations { get; set; }
        public virtual DbSet<CC_Counter> CC_Counter { get; set; }
        public virtual DbSet<CC_CustomerBrands> CC_CustomerBrands { get; set; }
        public virtual DbSet<CC_CustomerCertifications> CC_CustomerCertifications { get; set; }
        public virtual DbSet<CC_CustomerContact> CC_CustomerContact { get; set; }
        public virtual DbSet<CC_CustomerContactPerson> CC_CustomerContactPerson { get; set; }
        public virtual DbSet<CC_CustomerMachineryDetails> CC_CustomerMachineryDetails { get; set; }
        public virtual DbSet<CC_CustomerSpecialInstructions> CC_CustomerSpecialInstructions { get; set; }
        public virtual DbSet<CC_DeparmentDealsIn> CC_DeparmentDealsIn { get; set; }
        public virtual DbSet<CC_DeparmentMarkets> CC_DeparmentMarkets { get; set; }
        public virtual DbSet<CC_DepartPLRatios> CC_DepartPLRatios { get; set; }
        public virtual DbSet<CC_ExchangeRate> CC_ExchangeRate { get; set; }
        public virtual DbSet<CC_Locations> CC_Locations { get; set; }
        public virtual DbSet<CC_MarketDealsIn> CC_MarketDealsIn { get; set; }
        public virtual DbSet<CC_MessageType> CC_MessageType { get; set; }
        public virtual DbSet<CC_QualityControlInspectors> CC_QualityControlInspectors { get; set; }
        public virtual DbSet<CC_SalestaxOffices> CC_SalestaxOffices { get; set; }
        public virtual DbSet<CC_UsterResultType> CC_UsterResultType { get; set; }
        public virtual DbSet<ConfigApp> ConfigApps { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<CPAAttachments_2BDeleted> CPAAttachments_2BDeleted { get; set; }
        public virtual DbSet<CpaFcl> CpaFcls { get; set; }
        public virtual DbSet<CPALogSheet> CPALogSheets { get; set; }
        public virtual DbSet<DocumentCounter> DocumentCounters { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<EFilingSystem> EFilingSystems { get; set; }
        public virtual DbSet<ErrorInContract> ErrorInContracts { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<FabInspReportLocal> FabInspReportLocals { get; set; }
        public virtual DbSet<FabInspReportLocal_222> FabInspReportLocal_222 { get; set; }
        public virtual DbSet<FabInspReportLocalDetail> FabInspReportLocalDetails { get; set; }
        public virtual DbSet<FabInspStandard> FabInspStandards { get; set; }
        public virtual DbSet<FabInspStatu> FabInspStatus { get; set; }
        public virtual DbSet<FabInspTypePerformed> FabInspTypePerformeds { get; set; }
        public virtual DbSet<FabricInspReportExport4PointDetails> FabricInspReportExport4PointDetails { get; set; }
        public virtual DbSet<FabricInspReportExport4PointResults> FabricInspReportExport4PointResults { get; set; }
        public virtual DbSet<FabricInspRptExp4PFormat2> FabricInspRptExp4PFormat2 { get; set; }
        public virtual DbSet<FCTransferAccount> FCTransferAccounts { get; set; }
        public virtual DbSet<FCTTLedgerDetail> FCTTLedgerDetails { get; set; }
        public virtual DbSet<FNL_CommissionPaymentDetail> FNL_CommissionPaymentDetail { get; set; }
        public virtual DbSet<FNLESI> FNLESIs { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GeneralTask> GeneralTasks { get; set; }
        public virtual DbSet<GL_AccountBalance> GL_AccountBalance { get; set; }
        public virtual DbSet<GL_AccountFamily> GL_AccountFamily { get; set; }
        public virtual DbSet<GL_LinkCustomers> GL_LinkCustomers { get; set; }
        public virtual DbSet<GL_Settings> GL_Settings { get; set; }
        public virtual DbSet<GL_VoucherDetails> GL_VoucherDetails { get; set; }
        public virtual DbSet<GL_VoucherInvoices> GL_VoucherInvoices { get; set; }
        public virtual DbSet<GL_VoucherType> GL_VoucherType { get; set; }
        public virtual DbSet<HR_Allowances> HR_Allowances { get; set; }
        public virtual DbSet<HR_EmployeeAllowances> HR_EmployeeAllowances { get; set; }
        public virtual DbSet<HR_EmployeeExperience> HR_EmployeeExperience { get; set; }
        public virtual DbSet<HR_EmployeeLeaveBalance> HR_EmployeeLeaveBalance { get; set; }
        public virtual DbSet<HR_EmployeeQualification> HR_EmployeeQualification { get; set; }
        public virtual DbSet<HR_HistoryDetails> HR_HistoryDetails { get; set; }
        public virtual DbSet<Hr_LeaveRequest> Hr_LeaveRequest { get; set; }
        public virtual DbSet<HR_SalaryDetail> HR_SalaryDetail { get; set; }
        public virtual DbSet<KnittedFabricInspBleached> KnittedFabricInspBleacheds { get; set; }
        public virtual DbSet<KnittedFabricInspDyed> KnittedFabricInspDyeds { get; set; }
        public virtual DbSet<KnittedFabricInspectionAttachment> KnittedFabricInspectionAttachments { get; set; }
        public virtual DbSet<KnittedFabricInspGrey> KnittedFabricInspGreys { get; set; }
        public virtual DbSet<LinkedUser> LinkedUsers { get; set; }
        public virtual DbSet<ManualActionLog> ManualActionLogs { get; set; }
        public virtual DbSet<MeetingLogType> MeetingLogTypes { get; set; }
        public virtual DbSet<MinutesOfMeetingAttachments2bDeleted> MinutesOfMeetingAttachments2bDeleted { get; set; }
        public virtual DbSet<MinutesOfMeetingOfficial> MinutesOfMeetingOfficials { get; set; }
        public virtual DbSet<PNLTemplate> PNLTemplates { get; set; }
        public virtual DbSet<ReferenceRegister> ReferenceRegisters { get; set; }
        public virtual DbSet<SnpBudgetVariance> SnpBudgetVariances { get; set; }
        public virtual DbSet<SS_CommissionInvoiceAgentComm> SS_CommissionInvoiceAgentComm { get; set; }
        public virtual DbSet<SS_CommissionInvoiceDetail> SS_CommissionInvoiceDetail { get; set; }
        public virtual DbSet<SS_DELCommissionInvoice> SS_DELCommissionInvoice { get; set; }
        public virtual DbSet<SS_DELCommissionInvoiceAgentComm> SS_DELCommissionInvoiceAgentComm { get; set; }
        public virtual DbSet<SS_DELCommissionInvoiceDetail> SS_DELCommissionInvoiceDetail { get; set; }
        public virtual DbSet<SS_DomesticInquiryMaster> SS_DomesticInquiryMaster { get; set; }
        public virtual DbSet<SS_DomesticInquiryReview> SS_DomesticInquiryReview { get; set; }
        public virtual DbSet<SS_DomesticPaymentAddon> SS_DomesticPaymentAddon { get; set; }
        public virtual DbSet<SS_DomesticPaymentAddon12> SS_DomesticPaymentAddon12 { get; set; }
        public virtual DbSet<SS_DomesticPaymentAddonTemplate> SS_DomesticPaymentAddonTemplate { get; set; }
        public virtual DbSet<SS_DomesticSaleEFiling> SS_DomesticSaleEFiling { get; set; }
        public virtual DbSet<SS_IndentAgents> SS_IndentAgents { get; set; }
        public virtual DbSet<SS_IndentInfo> SS_IndentInfo { get; set; }
        public virtual DbSet<SS_IndentInspection> SS_IndentInspection { get; set; }
        public virtual DbSet<SS_indentRevisionLog> SS_indentRevisionLog { get; set; }
        public virtual DbSet<SS_InquiryReview> SS_InquiryReview { get; set; }
        public virtual DbSet<SS_SampleRegisterDomesticFabrics> SS_SampleRegisterDomesticFabrics { get; set; }
        public virtual DbSet<SS_ShipmentScheduleDetail> SS_ShipmentScheduleDetail { get; set; }
        public virtual DbSet<Store_SIRDetail> Store_SIRDetail { get; set; }
        public virtual DbSet<Store_VoucherDetails> Store_VoucherDetails { get; set; }
        public virtual DbSet<StoreCounter> StoreCounters { get; set; }
        public virtual DbSet<StoreItemBalance> StoreItemBalances { get; set; }
        public virtual DbSet<SuppEvalFormDet> SuppEvalFormDets { get; set; }
        public virtual DbSet<SuppEvalFormSection> SuppEvalFormSections { get; set; }
        public virtual DbSet<SuppEvalQuestionType> SuppEvalQuestionTypes { get; set; }
        public virtual DbSet<SystemUpdateLog> SystemUpdateLogs { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<TaskAttachments_2BDeleted> TaskAttachments_2BDeleted { get; set; }
        public virtual DbSet<TaskProgress> TaskProgresses { get; set; }
        public virtual DbSet<tempabc> tempabcs { get; set; }
        public virtual DbSet<tempabc1> tempabc1 { get; set; }
        public virtual DbSet<TransectionYear> TransectionYears { get; set; }
        public virtual DbSet<UMProfile> UMProfiles { get; set; }
        public virtual DbSet<UserCompany> UserCompanies { get; set; }
        public virtual DbSet<ValidNTN> ValidNTNs { get; set; }
        public virtual DbSet<YarnInspectionAttachment> YarnInspectionAttachments { get; set; }
        public virtual DbSet<YarnInspectionGrade> YarnInspectionGrades { get; set; }
        public virtual DbSet<YarnInspectionsUsterSetting> YarnInspectionsUsterSettings { get; set; }
        public virtual DbSet<YearlyCounter> YearlyCounters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CC_Accessory>()
                .Property(e => e.AccessoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Accessory>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Accessory>()
                .Property(e => e.CommodityType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Accessory>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Accessory>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_BusinessNature>()
                .Property(e => e.BusinessID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_BusinessNature>()
                .Property(e => e.BusinessDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Certifications>()
                .Property(e => e.CertificationID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Certifications>()
                .Property(e => e.CertificationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_City>()
                .Property(e => e.CityID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_City>()
                .Property(e => e.CountryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_City>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_City>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_City>()
                .Property(e => e.IsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.ColourCodeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.CodeID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.ColourID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.ColorCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.ColorDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.Userid_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Colors>()
                .Property(e => e.Userid_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.CommodityTypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.CommodityTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.ScheduleType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.DomesticMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.ScheduleTypeDomestic)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.InternationalMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CommodityType>()
                .Property(e => e.ScheduleTypeInternational)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ContactTypes>()
                .Property(e => e.ContactTypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ContactTypes>()
                .Property(e => e.ContactTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Country>()
                .Property(e => e.CountryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Country>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Country>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Currency>()
                .Property(e => e.CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Currency>()
                .Property(e => e.CurrencyDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Currency>()
                .Property(e => e.CurrencySymbol)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Currency>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Currency>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.CustomerID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.CustomerFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.ReferedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.Country)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.DispatchAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.WebPage)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.NTNNo)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.GSTNo)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Customer>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DelayShipmentCategory>()
                .Property(e => e.DelayShipmentCategoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DelayShipmentCategory>()
                .Property(e => e.DelayShipmentCategoryDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DelayShipmentReason>()
                .Property(e => e.DelayShipmentReasonID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DelayShipmentReason>()
                .Property(e => e.DelayShipmentReasonDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DelayShipmentReason>()
                .Property(e => e.DelayShipmentCategory)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Designs>()
                .Property(e => e.DesignID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Designs>()
                .Property(e => e.DesignDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Designs>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Designs>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DocumentEFilingType>()
                .Property(e => e.DocumentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DocumentEFilingType>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DocumentEFilingType>()
                .Property(e => e.Scope)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DomesticPaymentAddOn>()
                .Property(e => e.AddonID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DomesticPaymentAddOn>()
                .Property(e => e.AddonDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_GeneralDesc>()
                .Property(e => e.GeneralDescID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_GeneralDesc>()
                .Property(e => e.GeneralDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_GeneralDesc>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_GeneralDesc>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.GoodsForwarderID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.GoodsForwarderName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_GoodsForwarders>()
                .Property(e => e.UserId_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_InquiryReviewQuestions>()
                .Property(e => e.InquiryReviewQuestionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_InquiryReviewQuestions>()
                .Property(e => e.InquiryReviewQuestion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_InquiryReviewQuestions>()
                .Property(e => e.ForMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_LeadTime>()
                .Property(e => e.LeadTimeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_LeadTime>()
                .Property(e => e.LeadTimeDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_PaymentTerms>()
                .Property(e => e.PaymentTermID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_PaymentTerms>()
                .Property(e => e.PaymentTermDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_PaymentTerms>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_PaymentTerms>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_PriceTerms>()
                .Property(e => e.PriceTermID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_PriceTerms>()
                .Property(e => e.PriceTermDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_PriceTerms>()
                .Property(e => e.PriceTermAbbrv)
                .IsUnicode(false);

            modelBuilder.Entity<CC_PriceTerms>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_PriceTerms>()
                .Property(e => e.UserId_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.ProductID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.CommodityType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.IsValueAdded)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.StuffedQty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Products>()
                .Property(e => e.Userid_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Regions>()
                .Property(e => e.RegionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Regions>()
                .Property(e => e.RegionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Regions>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Regions>()
                .Property(e => e.Userid_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.ShippingLineId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.ShippingLineFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ShippingLines>()
                .Property(e => e.UserId_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_SizeGroups>()
                .Property(e => e.SizeGroupID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_SizeGroups>()
                .Property(e => e.SizeGroupDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Sizes>()
                .Property(e => e.SizeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Sizes>()
                .Property(e => e.SizeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Sizes>()
                .Property(e => e.PriorityinGroup)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Sizes>()
                .Property(e => e.SizeGroup)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Sizes>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Sizes>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofMeasure>()
                .Property(e => e.UOMID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofMeasure>()
                .Property(e => e.UOMDescription)
                .IsFixedLength();

            modelBuilder.Entity<CC_UnitofMeasure>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofMeasure>()
                .Property(e => e.UserId_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofRate>()
                .Property(e => e.UORID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofRate>()
                .Property(e => e.UORDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofRate>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofRate>()
                .Property(e => e.UserId_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.UOSDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.UOMID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.UORID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.StuffingUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.Factor)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.StandardUOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.StandardUOMFactor)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.UserId_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.ShipmentSchedule)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UnitofSale>()
                .Property(e => e.RequireStuffing)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.CompanyName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.MailingAddress)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.isDefault)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.TelephoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.WebSite)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.BusinessID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.LetterHeadFile)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.LetterHeadLegalFile)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.CompanyLogoFile)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.Abbreviation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.LocalCurrecyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.ForeignCurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.CustomerAsLocalAgent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.VoucherPostKey)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .Property(e => e.VoucherUnpostKey)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDefinition>()
                .HasMany(e => e.UserCompanies)
                .WithRequired(e => e.CompanyDefinition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.DepartmentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.DeptDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.DeptHead)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.DeptEmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.isActve)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.DeptNature)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.MarketNature)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.ScheduleType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.ContractAbbreviation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.RequireAllColumns)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.FCSalesCommissionAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.BadDebtAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.ClaimAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.ShowQtyinBVolume)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.StandardUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyDepartment>()
                .Property(e => e.ValidShipmentDelayDays)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CompanyEOBISetting>()
                .Property(e => e.EoBiSettingID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyEOBISetting>()
                .Property(e => e.CompanyCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CompanyEOBISetting>()
                .Property(e => e.EOBISalaryLowLimit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CompanyEOBISetting>()
                .Property(e => e.EOBISalaryHighLimit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CPAFindingNature>()
                .Property(e => e.CPAFindingNatureDesc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CPAFindingNCType>()
                .Property(e => e.CPAFindingNCTypeDesc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CPAFindingNCTypeSub>()
                .Property(e => e.DESCRIPTION)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CPAFindingType>()
                .Property(e => e.CPAFindingType1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaNcType>()
                .Property(e => e.CPaNcType1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaNcType>()
                .Property(e => e.CpaNcName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaNcType>()
                .Property(e => e.isCustomerComplaint)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaNcType>()
                .HasMany(e => e.Cpas)
                .WithRequired(e => e.CpaNcType1)
                .HasForeignKey(e => e.CpaNcType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CpaNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.ReportedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.ReportByDepartment)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CpaNcType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.Problem)
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CpaContain)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CprAssignedTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CprAssignedToDept)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.IsCpaRejected)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CprRejected)
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.DeptManager)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.RootCause)
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CorrectiveAction)
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.PreventiveAction)
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.cpataken)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.cpaEffective)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CheckedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.ConfirmBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.Agentcode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.BuyerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.Sellercode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.IndentNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CpaClose)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CpaProved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.CpaType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.ClaimId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cpa>()
                .Property(e => e.Userid_as_CreatedBY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaType>()
                .Property(e => e.CpaType1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaType>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaType>()
                .HasMany(e => e.Cpas)
                .WithOptional(e => e.CpaType1)
                .HasForeignKey(e => e.CpaType);

            modelBuilder.Entity<FabInspFabricType>()
                .Property(e => e.TypeofFabric)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspFabricType>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspLoomType>()
                .Property(e => e.LoomTypeID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspLoomType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.InspectionSerialNoID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.TypeofFabric)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.LoomType)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.InspReportNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.ForMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.ShipmentScheduleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.sr_no)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.FabInspRepFormat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.InspCalculationBasedOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.InspTypePerformed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.InspectionStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.QcInspCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.width)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.QuantityInspected)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.HeadBands)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.ShadeVariation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.Stamped)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.ReedMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.RubbingMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.PolyYarn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.Contamination)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.other)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.TearingSWarp)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.TearingSWeft)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.BuyerSampleStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.BuyerSampleDesign)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.SelvedgeWeave)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.SelvedgeIdentify)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.SelvedgeBindingWith)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.SelvedgeSize)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.YarnSupplyWarp)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.YarnSupplyWeft)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.PackingList)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.Marking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.FaceMarking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.PackingCondition)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.WrappingDirection)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.ShipmentSample)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.CamDirection)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.NumberofLooms)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.SampleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.SalesContractDetail)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.StorageNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.checkedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.Tally)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricSample>()
                .Property(e => e.UserId_as_Modifiedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTExportSaleInvoice>()
                .Property(e => e.ESInvoiceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTExportSaleInvoice>()
                .Property(e => e.FCTTAccountCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTExportSaleInvoice>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FCTTExportSaleInvoice>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTExportSaleInvoice>()
                .Property(e => e.IsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.TTTransectionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.RefTRanID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.IsRequest)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.RequestID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.FNLAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.TranType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.Narration)
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.AccountAsTaxDeducted)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.AccountAsReceivedinBankAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.TTRouting)
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.UserId_as_createdBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedger>()
                .Property(e => e.IsPosted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.FNLAccountID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.PartyAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.DebtorAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.ReturnableCurrency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.LinkedAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLAccount>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.FNLAccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.FNLAccountCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.AccountTitleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.AccountTitle)
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.ParentID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.FNLParentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.LevelOfAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCOA>()
                .Property(e => e.ChildAccounts)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.FNLCommissionBillID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.FNLAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.TranType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.Responsibility)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.AccountAsTaxDeducted)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.AccountAsReceivedinBankAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.Narration)
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.ReturnableCurrencyRate)
                .HasPrecision(18, 5);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.ReturnableCurency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.UserId_as_createdBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.RequirePosting)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.PaymentPosted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLCommissionBill>()
                .Property(e => e.SenderRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<GL_BookType>()
                .Property(e => e.BookID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_BookType>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_BookType>()
                .Property(e => e.Abbreviation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Budgeting>()
                .Property(e => e.BudgetID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Budgeting>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Budgeting>()
                .Property(e => e.FiscalYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_ChequeStatuses>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.BookTypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.AccountCode)
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.AccountTitle)
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.ParentAccount)
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_COA>()
                .HasMany(e => e.Gl_InvoiceBalances)
                .WithRequired(e => e.GL_COA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GL_COA>()
                .HasMany(e => e.GL_VoucherDetails)
                .WithRequired(e => e.GL_COA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GL_COA>()
                .HasMany(e => e.Store_Po)
                .WithRequired(e => e.GL_COA)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GL_FiscalPeriod>()
                .Property(e => e.FiscalPeriodID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriod>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriod>()
                .Property(e => e.FiscalYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriod>()
                .Property(e => e.FiscalPeriodDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriod>()
                .Property(e => e.IsCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriod>()
                .Property(e => e.CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriodVoucherCounter>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriodVoucherCounter>()
                .Property(e => e.FiscalYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriodVoucherCounter>()
                .Property(e => e.FiscalPeriodID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalPeriodVoucherCounter>()
                .Property(e => e.VoucherTypeID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_FiscalPeriodVoucherCounter>()
                .Property(e => e.LastVoucherNumber)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.FiscalYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.IsFinalized)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.IsCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.InvoicePosted)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_FiscalYear>()
                .Property(e => e.ChqCounter)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.InvoiceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.DepartmentId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.InvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.AmountCleared)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.ReceiveableOrPayable)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.IncludeInSalesTax)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.StInvIssued)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.SalestaxOfficeCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.FinYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.FinMonth)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.STInvNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.STInvNoCreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_InvoiceBalances>()
                .Property(e => e.Voucher)
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.PostDatedChqID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.FiscalYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.FromAccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.ChqNo)
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.ChequeStatusID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.UserId_PostedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.Userid_Inactive_By)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.Userid_Last_Modified)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gl_PostDatedChq>()
                .Property(e => e.PostToAccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.VoucherNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.VoucherTypeID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.FiscalYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.FiscalPeriodID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.ChqNo)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.Userid_as_ApprovedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.BookDefinitionID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.InActiveBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.InActiveTime)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.JVVoucherType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.PostDatedChqID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.OldVoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherMaster>()
                .Property(e => e.Attachedfilename)
                .IsUnicode(false);

            modelBuilder.Entity<HR_AllowanceModes>()
                .Property(e => e.AllowanceMode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AllowanceModes>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.EmployeeAttendanceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.AttendanceMonth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.AttendanceYear)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.InputType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.IsLate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.TimeCheckin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.TimeCheckout)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.Hours)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.Minutes)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_AttendanceTimings>()
                .Property(e => e.UserID_As_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.EmpDept)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.ReportedBY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.Incident)
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.TypeofIncident)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.Userid_as_CreatedBY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_CINCR>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_DayStatus>()
                .Property(e => e.DayStatusID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_DayStatus>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_DayStatus>()
                .Property(e => e.Abbreviation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_DayStatus>()
                .Property(e => e.CountAs)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Degree>()
                .Property(e => e.DegreeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Degree>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.DesignationId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.RequiredEducation)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.Experience)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.SkillsRequired)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.HirarchyPriority)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.UserID_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Designation>()
                .Property(e => e.UserID_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.EmployeeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.AttendanceCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.FatherHusbandName)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Age)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Salutation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.NICNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.DrivingLiecenseNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.LiesenceIssueBy)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.NTNNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.PassportNo)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.PersonalEmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.MaritalStatus)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Religion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.PermanentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.PermanentCityId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.TemporaryAddress)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.TemporaryCityId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.LandLine1)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.LandLine2)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Mobile1)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Mobile2)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.BloodGroup)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.PhotoPath)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.SignaturePath)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.EmployeeType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Designation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.CompanyEmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.CurrentBasicSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.CurrentAllowances)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.CurrentGrossSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.IncomeTax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.HealthInsurance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.LunchPayment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.ProfessionalTax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.RestDay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.TerminateStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.TerminateReason)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Userid_as_TerminatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.YearlyLeavesAllowed)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Companyid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.OfficeTimeIn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.OfficeTimeOut)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.SalaryMode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.BankAccountNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.BankAccountTitle)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.EOBINumber)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Reference1)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.Reference2)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.OreintationConductedBy)
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Employee>()
                .HasMany(e => e.Store_SIR)
                .WithRequired(e => e.HR_Employee)
                .HasForeignKey(e => e.RequiredBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.LoanAdvanceID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.LoanOpenBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.AdvanceopenBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.LoanAmountBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.AdvanceAmountBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeLoanAdvanceBalance>()
                .Property(e => e.LoanInstalment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeType>()
                .Property(e => e.EmployeeTypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeType>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_GazzettedDays>()
                .Property(e => e.GazzettedDateId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_GazzettedDays>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<HR_GazzettedDays>()
                .Property(e => e.TranYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_GazzettedDays>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_GazzettedDays>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.HistoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.PromotionType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.psBasic)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.psAllowance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.psCurrent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.nsBasic)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.nsAllowance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.nsCurrent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.PreviousDepartment)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.PreviousDesignation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.PreviousCompany)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.NewDepartment)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.NewDesignation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.NewCompany)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_History>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.LoanAdvLedID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.IsDeduction)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.LoanAdvanceApplicationNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.SalarySlipNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.BonusMasterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.VoucherNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LoanAdvance>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.LoanAdvanceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.RequiredAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.LoanInstalment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.ApprovedAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.ApprovedLoanInstalment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.isActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.UserId_as_ApprovedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.IsPending)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.IsApproved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.IsPosted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.UserId_as_PostedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_LoanAdvanceApplication>()
                .Property(e => e.oldAppId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.EmployeeAttendanceId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Designation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Visits)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day01)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day02)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day03)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day04)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day05)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day06)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day07)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day08)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day09)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day10)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day11)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day12)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day13)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day14)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day15)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day16)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day17)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day18)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day19)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day20)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day21)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day22)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day23)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day24)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day25)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day26)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day27)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day28)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day29)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day30)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_MonthlyAttendance>()
                .Property(e => e.Day31)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.EmployeeSalaryMasterId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.DepartmentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.DesignationCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.Isterminated)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.CurrentMonthGrossSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.CurrentMonthBasicSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.CurrentMonthAllowances)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.CurrentMonthNetSalary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.LoanAdjusted)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.AdvanceAdjusted)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.IncomeTax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.HealthInsurance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.SalaryMode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.EOBIEmployerContribution)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.EOBIEmployeeContribution)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryMaster>()
                .Property(e => e.NoticePeriod)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.EmployeeAttendanceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.AttendanceYear)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.AttendanceMonth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.TimeCheckin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.TimeCheckout)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.Hours)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.Minutes)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<HR_ShortLeaves>()
                .Property(e => e.UserID_As_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.InspectionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.ShipmentScheduleId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.FCL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.Lotno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.ContainGrey)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.ContainDyed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.ContainBleached)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspection>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.SUBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Agenda)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Venue)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Minuts)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Participants)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.ReportedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Userid_as_Createdby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeeting>()
                .HasMany(e => e.MinutesOfMeetingAttachments2bDeleted)
                .WithRequired(e => e.MinutesOfMeeting)
                .HasForeignKey(e => e.MeetingID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.AlertID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.ToEmailIDs)
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.SMSTo)
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.EmailSubject)
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.EmailText)
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.IsSent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QEmail>()
                .Property(e => e.SMS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.SampleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.StoredAt)
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SampleHomeTextile>()
                .Property(e => e.UserId_as_Modifiedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SoftwareModule>()
                .Property(e => e.SoftwareModuleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SoftwareModule>()
                .Property(e => e.ModuleDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.ShipmentScheduleShipmentNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.SupplierInvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.InvoiceDiscount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.SalesTaxOffice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoice>()
                .Property(e => e.UserId_as_PostedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.LocalDispatchNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.TypeOfTransection)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.SalesContractDetail)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.GoodsForwarder)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.BiltyNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.VehicleNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.IsReceivedStinv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.SalestaxInvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.Isdelayed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.DelayShipmentReason)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.DelayShipmentReasonDescription)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.IsComplaint)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.isFirstDispatch)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.GrossAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.GovtTaxes)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.ReceivableAfterTaxes)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.IncomeTaxAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.NetReceivable)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.LeadTimeDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DispacthScheduleDomestic>()
                .Property(e => e.Userid_as_ModfiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryDetails>()
                .Property(e => e.InquiryNoDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryDetails>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryDetails>()
                .Property(e => e.CommodityCode)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryDetails>()
                .Property(e => e.Commodity)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryDetails>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticInquiryDetails>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryOffers>()
                .Property(e => e.OfferID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryOffers>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryOffers>()
                .Property(e => e.OfferedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryOffers>()
                .Property(e => e.PaymentTerms)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryOffers>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAccessory>()
                .Property(e => e.AccessorySeqNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAccessory>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAccessory>()
                .Property(e => e.AccessoryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAccessory>()
                .Property(e => e.descriptionValue)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.SalesContractCommID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.CustomerIdCommPaidTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.CustomerIdCommPaidFrom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.CommissionRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.CommissionType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.Remarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.CalculatedCommissionValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentCommission>()
                .Property(e => e.TTRoutingInstructions)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.CommodityId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.CommoditySpecification)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.Rate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.CommRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.SizeCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.ColorCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.SupplierCode)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.SizeSpecifications)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.Design)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.DesignNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.PerPieceWeight)
                .HasPrecision(18, 6);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.PerPieceUnitWeight)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.Labdip)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.Lab_dip_option)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.LabdipDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.TypeColor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.FabricWidth)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.QuantityReq)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.UnitQuantityReq)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentDetails>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.IndentTypeId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CommodityType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.DepartmentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CustomerIDasSeller)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CustomerIDasBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CustomerIDasLocalAgent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.PaymentTermID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.ExchangeRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.QuantityVariance)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.PackingRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.DeliveryRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.DeliveryRemarksBuyer)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.GeneralRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.SpecialConditions)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.SpecialConditionsForSeller)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.SpecialConditionsForBuyer)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.PieceLength)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.QualityRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.FinancialRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.Specificatiions)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.PriceTerm)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.Destination)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.IndentStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CottonSource)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.CostingSheetRef)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.UserID_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.isUpdated)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.UserId_as_UpdatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.ClosingRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.IsClosed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.IsApproved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.ApprovedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.MarketedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentMaster>()
                .Property(e => e.IsSubmitForApproval)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.InquiryNoDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.CommodityCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.Commodity)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.CostingSheetRef)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.InquiryLineItemRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.SalesContractIssued)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryDetails>()
                .Property(e => e.SizeAndSpecification)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.Companyid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.DepartmentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.CommType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.InquiryMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.Customer)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.CustomerasBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.PaymentTerm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.PriceTerm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.Destination)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.Shipment)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.Program)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.InquiryRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.InquiryStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.IsClosed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryMaster>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.LcSerialNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.LcNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_LcDetails>()
                .Property(e => e.userid_as_modifiedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ShipmentScheduleId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.Fcl)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.TotalFcls)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ShippedQuantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ShippedWeight)
                .HasPrecision(21, 2);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.InspSrNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.LcSerialNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.SellerContractedShipmentDateRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.BuyerContractedShipmentDateRemarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ShippingLineId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ContainerNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.DestinationPort)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.VesselName)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ShipmentStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ShipmentRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ComplaintCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ComplaintRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.InspectionRemarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.InvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.LeadTimeDescriptionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.DelayShipmentReasonID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ProductionStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.ProductionRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.BLNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.SuplierReferenceNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.UserID_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.UserId_as_RevisedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.UserId_as_UpdatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.companyid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleMaster>()
                .Property(e => e.FollowupSheetRefNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Document>()
                .Property(e => e.StoreDocID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Document>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Document>()
                .Property(e => e.Nature)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Document>()
                .Property(e => e.Abbrv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.PoNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.CustomerId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.PaymentTerm)
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.DeliveryTerm)
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.isClosed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.isApproved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .Property(e => e.Userid_as_modifiedon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Po>()
                .HasMany(e => e.Store_PoDetails)
                .WithRequired(e => e.Store_Po)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store_PoDetails>()
                .Property(e => e.PODetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_PoDetails>()
                .Property(e => e.PoNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_PoDetails>()
                .Property(e => e.StoreItemID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_PoDetails>()
                .Property(e => e.UnitID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_PoDetails>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.SIRNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.FiscalYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.RequiredBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.isApproved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.Userid_as_ModifiedOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.IsClosed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIR>()
                .Property(e => e.ClosingRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.DocumentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.DocNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.StoreDocID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.PoNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.SIRNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.CustomerID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.EmployeeId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.Departmentid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.IsPosted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.Userid_as_PostedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.VoucherId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.IsCashPurchase)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_Voucher>()
                .Property(e => e.Supplier)
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.ParentCode)
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.ParentID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.MaxLevel)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.ReorderLevel)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.UnitConvertFactor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.PurchaseUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.SaleUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreItem>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreLocation>()
                .Property(e => e.StoreLocationID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreLocation>()
                .Property(e => e.StoreLocationDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreLocation>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.UnitConvertID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.PurchaseUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.IssueUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.ConvertFactor)
                .HasPrecision(18, 4);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.userid_as_createdby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnitConvert>()
                .Property(e => e.userid_as_modifiedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnit>()
                .Property(e => e.UnitId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnit>()
                .Property(e => e.UnitDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnit>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreUnit>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalForm>()
                .Property(e => e.SuppEvalformId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalForm>()
                .Property(e => e.FormDescription)
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalForm>()
                .Property(e => e.IsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.EvaluationFormID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.Customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.SuppEvalform)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.informationProvidedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.FormFilledBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.RemarksByDeptManager)
                .IsUnicode(false);

            modelBuilder.Entity<SupplierEvaluationForm>()
                .Property(e => e.IsApproved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.TaskID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.AssignedTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.DepartmentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.AssignedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskRegister>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMRole>()
                .Property(e => e.RoleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMRole>()
                .Property(e => e.RoleDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.UserID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.UserDescription)
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.LoginID)
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.LoginPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.IsFirstLogin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.UserMustChangePassword)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.PasswordNeverExpire)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.RoleId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .Property(e => e.IncludeCEO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMUser>()
                .HasOptional(e => e.UMProfile)
                .WithRequired(e => e.UMUser);

            modelBuilder.Entity<UMUser>()
                .HasMany(e => e.UserCompanies)
                .WithRequired(e => e.UMUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<YarnInspectionReportType>()
                .Property(e => e.InspectionReportType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionReportType>()
                .Property(e => e.InspectionReportTypeDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.InspectionSerialID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.InspReportType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.InspectionForMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.InspectionGrade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.ShipmentScheduleId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.RegisterNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CustomerID_as_Seller)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CustomerID_as_Buyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CommodityId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.MillUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.FCL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.QcInspector)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.PConeColour)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.PolyFiber)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.PolyColour)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CottonArea)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CottonCountry)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CottonSlength)
                .HasPrecision(18, 4);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CottonGrade)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CottonColour)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.ResultInputType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.Lotno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.Shade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.bstrips)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.moisture)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.yarnlength)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspection>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions>()
                .Property(e => e.OptionId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions>()
                .Property(e => e.OptionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions>()
                .Property(e => e.ParentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions>()
                .Property(e => e.IsMenuOption)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions>()
                .Property(e => e.FormObject)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions>()
                .Property(e => e.IsFunction)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions11>()
                .Property(e => e.OptionId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions11>()
                .Property(e => e.OptionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions11>()
                .Property(e => e.ParentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions11>()
                .Property(e => e.IsMenuOption)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions11>()
                .Property(e => e.FormObject)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions11>()
                .Property(e => e.IsFunction)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions123>()
                .Property(e => e.OptionId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions123>()
                .Property(e => e.OptionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions123>()
                .Property(e => e.ParentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions123>()
                .Property(e => e.IsMenuOption)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions123>()
                .Property(e => e.FormObject)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions123>()
                .Property(e => e.IsFunction)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions132>()
                .Property(e => e.OptionId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions132>()
                .Property(e => e.OptionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions132>()
                .Property(e => e.ParentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions132>()
                .Property(e => e.IsMenuOption)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions132>()
                .Property(e => e.FormObject)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADM_SystemOptions132>()
                .Property(e => e.IsFunction)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApprovedSupplier>()
                .Property(e => e.ASID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApprovedSupplier>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApprovedSupplier>()
                .Property(e => e.Commodity)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApprovedSupplier>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApprovedSupplier>()
                .Property(e => e.Customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApprovedSupplier>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BasicIntegration>()
                .Property(e => e.TransectionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<BasicIntegration>()
                .Property(e => e.IntegrationID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Regions)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.PriceTerms)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.PaymentTerms)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.GeneralDesc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.UnitOfMeasure)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.UnitOfRate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.UnitOfSale)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Currency)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.GoodsForwarder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.ShippingLine)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.DelayShipmentReason)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.LeadTime)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.CommodityType)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Customers)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.CustomerBrands)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Country)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.City)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Product)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Modules)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.QualityControllers)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Designation)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.Degree)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_Counter>()
                .Property(e => e.EmployeeNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_CustomerBrands>()
                .Property(e => e.CustomerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerBrands>()
                .Property(e => e.BrandID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerBrands>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerCertifications>()
                .Property(e => e.CustomerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerCertifications>()
                .Property(e => e.CertificationCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerCertifications>()
                .Property(e => e.IsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContact>()
                .Property(e => e.CustomerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContact>()
                .Property(e => e.ContactType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContact>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContactPerson>()
                .Property(e => e.CustomerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContactPerson>()
                .Property(e => e.ContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContactPerson>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerContactPerson>()
                .Property(e => e.ContactType)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_CustomerContactPerson>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerMachineryDetails>()
                .Property(e => e.CustomerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerMachineryDetails>()
                .Property(e => e.MachineryDetails)
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerMachineryDetails>()
                .Property(e => e.Qauntity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CC_CustomerSpecialInstructions>()
                .Property(e => e.CustomerCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_CustomerSpecialInstructions>()
                .Property(e => e.SpecialInstructions)
                .IsUnicode(false);

            modelBuilder.Entity<CC_DeparmentDealsIn>()
                .Property(e => e.DepartmentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DeparmentDealsIn>()
                .Property(e => e.CommodityType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DeparmentDealsIn>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DeparmentMarkets>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DeparmentMarkets>()
                .Property(e => e.MarketDeal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DeparmentMarkets>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DepartPLRatios>()
                .Property(e => e.FiscalPeriod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DepartPLRatios>()
                .Property(e => e.GeneralDepartCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_DepartPLRatios>()
                .Property(e => e.MarketingDepartCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.Exchanged_CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.ExchangeRateSelling)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.ExchangeRateBuying)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.ExchangeRate120Selling)
                .IsFixedLength();

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.ExchangeRate120Buying)
                .IsFixedLength();

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.ExchangeRateOpenMktBuying)
                .IsFixedLength();

            modelBuilder.Entity<CC_ExchangeRate>()
                .Property(e => e.ExchangeRateOpenMktSelling)
                .IsFixedLength();

            modelBuilder.Entity<CC_Locations>()
                .Property(e => e.LocationID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_Locations>()
                .Property(e => e.LocationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CC_Locations>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_MarketDealsIn>()
                .Property(e => e.MarketDealID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_MarketDealsIn>()
                .Property(e => e.MarketDealsDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_MessageType>()
                .Property(e => e.MESSTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_MessageType>()
                .Property(e => e.MESSNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CC_QualityControlInspectors>()
                .Property(e => e.QcInspectorID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_QualityControlInspectors>()
                .Property(e => e.InspectorFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CC_QualityControlInspectors>()
                .Property(e => e.CommoditytypeCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_SalestaxOffices>()
                .Property(e => e.SalesTaxOfficeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_SalestaxOffices>()
                .Property(e => e.SalesTaxOffice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_SalestaxOffices>()
                .Property(e => e.SalesTaxOfficeAbbrv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UsterResultType>()
                .Property(e => e.UsterResultTypeId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CC_UsterResultType>()
                .Property(e => e.UsterResultTypeDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ConfigApp>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ConfigApp>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Counter>()
                .Property(e => e.NoOfUsers)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.NoOfCompanies)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.NoOfDepartments)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.FiscalYears)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.FiscalPeriods)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.SystemOptions)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Counter>()
                .Property(e => e.FNLAccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CPAAttachments_2BDeleted>()
                .Property(e => e.CpaNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CPAAttachments_2BDeleted>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<CPAAttachments_2BDeleted>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaFcl>()
                .Property(e => e.CPaNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CpaFcl>()
                .Property(e => e.ShipmentScheduleid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CPALogSheet>()
                .Property(e => e.CpaNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CPALogSheet>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.Year)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.LocalSalesContract)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.ExportSalesContract)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.FNL_CommissionBill)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.FNL_CommissinPayment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.LocalCommissionInvoice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentCounter>()
                .Property(e => e.ExportCommissionInvoice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.DOCTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.DOCNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.EFilingID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.DocumentType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.FileDescription)
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.FileAttached)
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.ReferenceID1)
                .IsUnicode(false);

            modelBuilder.Entity<EFilingSystem>()
                .Property(e => e.ReferenceID2)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorInContract>()
                .Property(e => e.SalesContract)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ErrorInContract>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ErrorInContract>()
                .Property(e => e.Customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ErrorInContract>()
                .Property(e => e.SellerOrBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EventLog>()
                .Property(e => e.EventTime)
                .IsUnicode(false);

            modelBuilder.Entity<EventLog>()
                .Property(e => e.EventLog1)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.InspectionSerialNoID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.InspReportNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.ForMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.InspTypePerformed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.LoomType)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.TypeofFabric)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.InspCalculationBasedOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.InspectionStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.QcInspCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.width)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.QuantityInspected)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.HeadBands)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.ShadeVariation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.Stamped)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.ReedMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.RubbingMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.PolyYarn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.Contamination)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.other)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.TearingSWarp)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.TearingSWeft)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.BuyerSampleStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.BuyerSampleDesign)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.SelvedgeWeave)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.SelvedgeIdentify)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.SelvedgeBindingWith)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.SelvedgeSize)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.YarnSupplyWarp)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.YarnSupplyWeft)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.PackingList)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.Marking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.FaceMarking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.PackingCondition)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.WrappingDirection)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.ShipmentSample)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.CamDirection)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.NumberofLooms)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.InspectionSerialNoID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.InspReportNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.ForMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.InspTypePerformed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.LoomType)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.TypeofFabric)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.InspectionStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.QcInspCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.width)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.QuantityInspected)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.HeadBands)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.ShadeVariation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.Stamped)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.ReedMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.RubbingMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.PolyYarn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.Contamination)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.other)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.TearingSWarp)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.TearingSWeft)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocal_222>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocalDetail>()
                .Property(e => e.InspectionSerialNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocalDetail>()
                .Property(e => e.SrNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspReportLocalDetail>()
                .Property(e => e.FabricGrade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspStandard>()
                .Property(e => e.FabricInspectionStd)
                .HasPrecision(2, 0);

            modelBuilder.Entity<FabInspStandard>()
                .Property(e => e.FabricInspectionStdDesc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspStatu>()
                .Property(e => e.InspectionStatusID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspStatu>()
                .Property(e => e.InspectionStatusDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspTypePerformed>()
                .Property(e => e.InspTypePerformedID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabInspTypePerformed>()
                .Property(e => e.InspTypePerformedDesc)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointDetails>()
                .Property(e => e.InspectionSerialNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointDetails>()
                .Property(e => e.SrNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointDetails>()
                .Property(e => e.FabricGrade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.InspectionSerialNoID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.InspectionTypePerformed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.Construction)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.Width)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IC_quantitiesSubmitted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IC_Style)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IC_Workmanship)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IC_Packing)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IC_Marking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IC_DataMeasurement)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PC_Style)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PC_Material)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PC_Color)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PC_Griege)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ReferenceSample)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PieceLengthCheck)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PieceLength)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.RollsLengthCheck)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.SizeMeasurement)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.IndividualPacking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.InnerPacking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ExportPacking)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.PackingAssortment)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_BarCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_ShippingMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_OtherMarks)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_SideMark)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_MainLabel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_Care)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_Size)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_Country)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_HangTag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_PolyBag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_InnerBox)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.ML_OtherLabel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.Lighting)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.LightingStatus)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.InspectionPlace)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.InspectionDoneOn)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.Cleanliness)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspReportExport4PointResults>()
                .Property(e => e.WeatherCondition)
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspRptExp4PFormat2>()
                .Property(e => e.InspectionSerialNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspRptExp4PFormat2>()
                .Property(e => e.SrNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FabricInspRptExp4PFormat2>()
                .Property(e => e.FabricGrade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.FNLAccountID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.PartyAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.DebtorAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.CurrencyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.LinkedAccount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTransferAccount>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedgerDetail>()
                .Property(e => e.TTTransectionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedgerDetail>()
                .Property(e => e.TTTransectionSrNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedgerDetail>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedgerDetail>()
                .Property(e => e.RefTTTransectionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FCTTLedgerDetail>()
                .Property(e => e.RefTTTransectionCodeSrNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNL_CommissionPaymentDetail>()
                .Property(e => e.FNLCommissionBillID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNL_CommissionPaymentDetail>()
                .Property(e => e.FNLCommission_invoice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNL_CommissionPaymentDetail>()
                .Property(e => e.ReturnableCurency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLESI>()
                .Property(e => e.ESINo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLESI>()
                .Property(e => e.FiscalPeriodCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FNLESI>()
                .Property(e => e.Companycode)
                .IsFixedLength();

            modelBuilder.Entity<FNLESI>()
                .Property(e => e.FNLAccountCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.GenderID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.GeneralTaskID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.TaskProgress)
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.TaskAssignedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.TaskAssignedByDept)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.IsApproved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.IsCompleted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GeneralTask>()
                .Property(e => e.Userid_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_AccountBalance>()
                .Property(e => e.FiscalYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_AccountBalance>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_AccountBalance>()
                .Property(e => e.OpeningBalance)
                .HasPrecision(20, 2);

            modelBuilder.Entity<GL_AccountBalance>()
                .Property(e => e.IsManualUpdated)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_AccountBalance>()
                .Property(e => e.BalanceUpdatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_AccountFamily>()
                .Property(e => e.AccountTypeID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_AccountFamily>()
                .Property(e => e.AccountDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_LinkCustomers>()
                .Property(e => e.CustomerID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_LinkCustomers>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_LinkCustomers>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.PostToGeneralLedger)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.PostThroughGeneralLedger)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.IsVoucherReqAuthorise)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.VoucherAuthorizationCode)
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.IsFinancislCreated)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.LocalContractsDefCurrency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.ExportContractsDefCurrency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_Settings>()
                .Property(e => e.CompanyInCustomers)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.Narration)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.Debit)
                .HasPrecision(20, 2);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.VouchertypeId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.Department)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.Location)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.Employee)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherDetails>()
                .Property(e => e.Customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.VoucherID)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.InvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.StaxInvNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.InvoiceID)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.ReceiveableOrPayable)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.VoucherDeduction)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.VoucherRateDiff)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherInvoices>()
                .Property(e => e.VoucherSalesTaxAmount)
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherType>()
                .Property(e => e.VoucherTypeID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GL_VoucherType>()
                .Property(e => e.VoucherType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherType>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GL_VoucherType>()
                .Property(e => e.Abbreviation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.AllowanceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.SubType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.TaxStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.ApplyOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_Allowances>()
                .Property(e => e.UserID_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeAllowances>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeAllowances>()
                .Property(e => e.AllowanceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeAllowances>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_EmployeeAllowances>()
                .Property(e => e.Mode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeExperience>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeExperience>()
                .Property(e => e.Organization)
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeExperience>()
                .Property(e => e.Designation)
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeExperience>()
                .Property(e => e.ReasonToLeave)
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeLeaveBalance>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeLeaveBalance>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeLeaveBalance>()
                .Property(e => e.TransectionYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.DegreeId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.Institution)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.Marks_gpa)
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.Grade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.Division)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_EmployeeQualification>()
                .Property(e => e.DegreeSession)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_HistoryDetails>()
                .Property(e => e.HistoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_HistoryDetails>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_HistoryDetails>()
                .Property(e => e.AllowanceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_HistoryDetails>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_HistoryDetails>()
                .Property(e => e.Mode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.LeaveRequestMasterID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.FortheYear)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.EmployeeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.LeaveType)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.Userid_as_ApprovedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hr_LeaveRequest>()
                .Property(e => e.ApplicationType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.EmployeeSalaryMasterId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.EmployeeAllowanceID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.Mode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.LoanAdvanceID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.DeductedAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.DeductionType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.IsDeductedBySystem)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HR_SalaryDetail>()
                .Property(e => e.Deduction_ChangedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.InspectionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.ShadeColour)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Length)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Width)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Gsm)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Guage)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.DIA)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Evenness)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Dyability)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Barre)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Contamination)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Slubs)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.LongThin)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.LongThick)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.DeadCottonLevel)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.Other)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.isSampleSentBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.isSampleSentSeller)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspBleached>()
                .Property(e => e.isSampleoffice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.InspectionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.ShadeColour)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Length)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Width)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Gsm)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Guage)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.DIA)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Evenness)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Dyability)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Barre)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Contamination)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Slubs)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.LongThin)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.LongThick)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.DeadCottonLevel)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.Other)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.isSampleSentBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.isSampleSentSeller)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspDyed>()
                .Property(e => e.isSampleoffice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspectionAttachment>()
                .Property(e => e.InspectionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspectionAttachment>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspectionAttachment>()
                .Property(e => e.FileDescription)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspectionAttachment>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.InspectionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.IsGreyOrMelange)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.ShadeColour)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Length)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Width)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Gsm)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Guage)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.DIA)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Evenness)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Dyability)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Barre)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Contamination)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Slubs)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.LongThin)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.LongThick)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.DeadCottonLevel)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.Other)
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.isSampleSentBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.isSampleSentSeller)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KnittedFabricInspGrey>()
                .Property(e => e.isSampleoffice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LinkedUser>()
                .Property(e => e.MacAddress)
                .IsUnicode(false);

            modelBuilder.Entity<LinkedUser>()
                .Property(e => e.Login)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ManualActionLog>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<ManualActionLog>()
                .Property(e => e.ActionLog)
                .IsUnicode(false);

            modelBuilder.Entity<MeetingLogType>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MeetingLogType>()
                .Property(e => e.MeetingDesc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeetingAttachments2bDeleted>()
                .Property(e => e.MeetingID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeetingAttachments2bDeleted>()
                .Property(e => e.FileDescription)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeetingAttachments2bDeleted>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeetingAttachments2bDeleted>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeetingOfficial>()
                .Property(e => e.MeetingCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MinutesOfMeetingOfficial>()
                .Property(e => e.CompanyOfficial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PNLTemplate>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PNLTemplate>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PNLTemplate>()
                .Property(e => e.AccountID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.RefSr_no)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.ReferenceID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.DOCTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.MESSTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.CustomerID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.UserId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceRegister>()
                .Property(e => e.CompanyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.AccountCode)
                .IsUnicode(false);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Jul)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Aug)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Sep)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Oct)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Nov)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Dec)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Jan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Feb)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Mar)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Apr)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.May)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SnpBudgetVariance>()
                .Property(e => e.Jun)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.SalesContractCommCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.CustomerIDCommPaidTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.CustomerIDCommPaidFrom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.CommissionRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.CommissionType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceAgentComm>()
                .Property(e => e.CommissionDiscountRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SS_CommissionInvoiceDetail>()
                .Property(e => e.companyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.ShipmentScheduleShipmentNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.SupplierInvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.InvoiceDiscount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.SalesTaxOffice)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoice>()
                .Property(e => e.UserId_as_PostedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.SalesContractCommCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.CustomerIDCommPaidTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.CustomerIDCommPaidFrom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.CommissionRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.CommissionType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceAgentComm>()
                .Property(e => e.CommissionDiscountRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SS_DELCommissionInvoiceDetail>()
                .Property(e => e.companyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.Companyid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.DepartmentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.InquiryMarket)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.CommType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.InquiryStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.IsClosed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.Customer)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.CustomerasBuyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.PaymentTerm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.UserId_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryMaster>()
                .Property(e => e.UserId_as_ModifiedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryReview>()
                .Property(e => e.InquiryReviewQuestionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryReview>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticInquiryReview>()
                .Property(e => e.Companyid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.LocalDispatchNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.SerialNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.DomesticPaymentAddon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.AddonType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.AddonEffect)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.TotalValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticPaymentAddon>()
                .Property(e => e.DomesticPaymentAddonCalculatedOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.LocalDispatchNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.SerialNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.DomesticPaymentAddon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.AddonType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.AddonEffect)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.TotalValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticPaymentAddon12>()
                .Property(e => e.DomesticPaymentAddonCalculatedOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.DeparmentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.SerialNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.DomesticPaymentAddon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.AddonType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.AddonEffect)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.TotalValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_DomesticPaymentAddonTemplate>()
                .Property(e => e.DomesticPaymentAddonCalculatedOn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.EfilingCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.DocumentType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.SaleContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.LocalDispatchNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.FileDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.FileAttached)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.DocFileType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_DomesticSaleEFiling>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAgents>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAgents>()
                .Property(e => e.CustomerIDasAgentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentAgents>()
                .Property(e => e.AgentStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.SellerContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.PurchaseOrderNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.BuyerReferenceNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.foreignIndentNo)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.BrandCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.BasicFabric)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.BlendRatio)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.LoomType)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.FinishedWeight)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.PriceTermCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.GoodsDes)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.ProductionSource)
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.GsmWeight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_IndentInfo>()
                .Property(e => e.GsmUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInspection>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInspection>()
                .Property(e => e.InspSrno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInspection>()
                .Property(e => e.SalesContractDetail)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInspection>()
                .Property(e => e.CommodityType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_IndentInspection>()
                .Property(e => e.LocalDispatchNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_indentRevisionLog>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_indentRevisionLog>()
                .Property(e => e.Userid_RevisedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_indentRevisionLog>()
                .Property(e => e.RevisedReason)
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryReview>()
                .Property(e => e.InquiryReviewQuestionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryReview>()
                .Property(e => e.InquiryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_InquiryReview>()
                .Property(e => e.Companyid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.SampleID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.SalesContractDetail)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.StorageNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.checkedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.Tally)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.Userid_as_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_SampleRegisterDomesticFabrics>()
                .Property(e => e.UserId_as_Modifiedby)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.ShipmentScheduleId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.InspStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.Rate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<SS_ShipmentScheduleDetail>()
                .Property(e => e.TotalWeight)
                .HasPrecision(21, 2);

            modelBuilder.Entity<Store_SIRDetail>()
                .Property(e => e.SIRDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIRDetail>()
                .Property(e => e.SIRNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_SIRDetail>()
                .Property(e => e.StoreItemID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_SIRDetail>()
                .Property(e => e.Issueunit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.DocumentID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.PODetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.StoreItemID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.PurchaseUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.IssueUnit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.Brand)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.UnitConvertID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.IssuedQuantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store_VoucherDetails>()
                .Property(e => e.Isposted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreCounter>()
                .Property(e => e.StoreItemCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItemBalance>()
                .Property(e => e.FiscalYear)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreItemBalance>()
                .Property(e => e.StoreItem)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StoreItemBalance>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StoreItemBalance>()
                .Property(e => e.StoreLocation)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormDet>()
                .Property(e => e.SuppEvalformDetID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormDet>()
                .Property(e => e.SuppEvalformCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormDet>()
                .Property(e => e.SuppEvalformSection)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormDet>()
                .Property(e => e.SuppEvalQuestionType)
                .IsFixedLength();

            modelBuilder.Entity<SuppEvalFormDet>()
                .Property(e => e.SequenceID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SuppEvalFormDet>()
                .Property(e => e.QuestionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormSection>()
                .Property(e => e.SuppEvalSectionID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormSection>()
                .Property(e => e.SuppEvalformCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalFormSection>()
                .Property(e => e.SectionDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SuppEvalQuestionType>()
                .Property(e => e.SuppEvalQuestionType1)
                .IsFixedLength();

            modelBuilder.Entity<SuppEvalQuestionType>()
                .Property(e => e.SuppEvalQuestionTypeDesc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SystemUpdateLog>()
                .Property(e => e.SustemUpdate)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.SystemUser1)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<TaskAttachments_2BDeleted>()
                .Property(e => e.TaskID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskAttachments_2BDeleted>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskAttachments_2BDeleted>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TaskAttachments_2BDeleted>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskProgress>()
                .Property(e => e.TaskProgressID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskProgress>()
                .Property(e => e.TaskID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaskProgress>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<TaskProgress>()
                .Property(e => e.PostedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tempabc>()
                .Property(e => e.companyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.CommissionInvoiceNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.SalesContractNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.SalesContractDetailID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.UOSID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tempabc1>()
                .Property(e => e.companyId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransectionYear>()
                .Property(e => e.TranYearID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransectionYear>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransectionYear>()
                .Property(e => e.Description)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransectionYear>()
                .Property(e => e.IsFinalized)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransectionYear>()
                .Property(e => e.IsCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.UserID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<UMProfile>()
                .Property(e => e.EmpCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserCompany>()
                .Property(e => e.CompanyID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserCompany>()
                .Property(e => e.UserID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ValidNTN>()
                .Property(e => e.NTN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ValidNTN>()
                .Property(e => e.Pntn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ValidNTN>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionAttachment>()
                .Property(e => e.InspectionSerialID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionAttachment>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionAttachment>()
                .Property(e => e.FileDescription)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionAttachment>()
                .Property(e => e.IsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionAttachment>()
                .Property(e => e.UserId_CreatedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionAttachment>()
                .Property(e => e.Userid_DeletedBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionGrade>()
                .Property(e => e.InspectionGrade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionGrade>()
                .Property(e => e.InspectionGradeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionsUsterSetting>()
                .Property(e => e.InspectionSerialID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionsUsterSetting>()
                .Property(e => e.UsterResultTypeId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YarnInspectionsUsterSetting>()
                .Property(e => e.Value)
                .HasPrecision(8, 2);

            modelBuilder.Entity<YearlyCounter>()
                .Property(e => e.Year)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YearlyCounter>()
                .Property(e => e.LocalInquiryNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YearlyCounter>()
                .Property(e => e.ExportInquiryNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YearlyCounter>()
                .Property(e => e.LocalindentNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YearlyCounter>()
                .Property(e => e.ExportIndentNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YearlyCounter>()
                .Property(e => e.FNLCommissionBill)
                .HasPrecision(18, 0);
        }
    }
}
