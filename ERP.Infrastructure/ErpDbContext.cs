using ERP.Core.Models.Finance;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Common;
using ERP.Core.Models.Common.Party;
using ERP.Core.Models.HR;
using ERP.Core.Models.Indenting;
using ERP.Core.Models.Inventory;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Finance.GeneralVM;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Core.Models.HR.Task;
using ERP.Core.Models.Indenting.cpa;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Infrastructure
{
    public class ErpDbContext : DbContext
    {
        public ErpDbContext() : base("name=ErpDbContext")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<ErpDbContext>(null);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<IndCommission>().Property(e => e.CommissionRate).HasPrecision(18, 4);

            //    modelBuilder.Entity<FinParty>()
            //        .HasOptional(x => x.CoaL5)
            //        .WithRequired(pt => pt.FinParties);

            //    //modelBuilder.Entity<Region>()
            //    //    .HasIndex(b => b.Title)
            //    //    .IsUnique();

            //    //modelBuilder.Entity<CoaL5>()
            //    //    .HasOptional(x => x.FinParties)
            //    //    .WithRequired(pt => pt.CoaL5);

        }

        #region User Administration
        public DbSet<User> Users { get; set; }
        public DbSet<AdminModules> AdminModules { get; set; }
        public DbSet<AdminModuleDetails> AdminModuleDetails { get; set; }
        public DbSet<UserModules> UserModules { get; set; }
        public DbSet<UserModuleDetails> UserModuleDetails { get; set; }
        public DbSet<UserPrevilage> UserPrevilages { get; set; }
        public DbSet<SystemOption> SystemOptions { get; set;}
        public DbSet<AdminUserDealsInDepartment> AdminUserDealsInDepartments { get; set; }

        #endregion Uset Administation

        #region Financial Database Objects  
        public DbSet<CoaL1> CoaL1 { get; set; }
        public DbSet<CoaL2> CoaL2 { get; set; }
        public DbSet<CoaL3> CoaL3 { get; set; }
        public DbSet<CoaL4> CoaL4 { get; set; }
        public DbSet<CoaL5> CoaL5 { get; set; }

        public DbSet<FinVType> FinVType { get; set; }
        public DbSet<FinBookType> FinBookType { get; set; }

        public DbSet<FinFescalYear> FinFescalYear { get; set; }
        public DbSet<FinFescalYearDetail> FinFescalYearDetail { get; set; }
        public DbSet<FinVoucher> FinVoucher { get; set; }
        public DbSet<FinVoucherDetail> FinVoucherDetail { get; set; }
        public DbSet<FinLedger> FinLedger { get; set; }
        public DbSet<FinBudget> FinBudget { get; set; }

        #endregion Financial Database Objects 

       

        #region Parties Database Objects
        public DbSet<FinParty> FinParties { get; set; }
        public DbSet<CustomerBrand> CustomerBrands { get; set; }
        public DbSet<CustomerCertification> CustomerCertifications { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<CustomerContactPerson> CustomerContactPersons { get; set; }
        public DbSet<CustomerInstruction> CustomerInstructions { get; set; }
        public DbSet<CustomerMachine> CustomerMachines { get; set; }
        public DbSet<CustomerSocial> CustomerSocials { get; set; }

        #endregion Parties Database Objects  


        #region Region, Country, State, City, Area
        public DbSet<Region> Region { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<MarkeetDealsIn> MarketDealIn { get; set; }

        #endregion  Region, Country, State, City, Area, MarkeetDealsIn 

        #region IndentInspection
        public virtual DbSet<FabInspReportLocalSum> FabInspReportLocalSum { get; set; }
        public virtual  DbSet<FabricInspLoomType> FabricInspLoomType { get; set; }
        public virtual  DbSet<FabInspTypePerformed> FabInspTypePerformed { get; set; }
        public virtual  DbSet<FabricInspReportLocal> FabricInspReportLocal { get; set; }
        public virtual  DbSet<FabricInspReportLocalDetail> FabricInspReportLocalDetail { get; set; }
        public virtual  DbSet<FabricInspStandard> FabricInspStandard { get; set; }
        public virtual  DbSet<FabricInspStatus> FabricInspStatus { get; set; }
        public virtual  DbSet<FabricInspType> FabricInspType { get; set; }
        public virtual  DbSet<FabricType> FabricType { get; set; }
        public virtual  DbSet<QcInspector> QcInspector { get; set; }
        public virtual  DbSet<SalesTaxOffice> SalesTaxOffice { get; set; }
        public virtual  DbSet<YarnInspection> YarnInspection { get; set; }
        public virtual  DbSet<YarnInspectionGrade> YarnInspectionGrade { get; set; }
        public virtual  DbSet<YarnInspectionReportType> YarnInspectionReportType { get; set; }
        public virtual  DbSet<YarnInspectionsUsterSetting> YarnInspectionsUsterSetting { get; set; }
        public virtual  DbSet<YarnInspUsters> YarnInspUsters { get; set;}
        public virtual  DbSet<IndentInspection> IndentInspections { get; set; }
        public virtual DbSet<YarnInspectionAttachments> YarnInspectionAttachments { get; set; }
        public virtual DbSet<KnittedFabricInspection> KnittedFabricInspections { get; set;}
        public virtual DbSet<KnittedFabricInspGrey> KnittedFabricInspGrey { get; set;}
        public virtual DbSet<KnittedFabricInspBleached> KnittedFabricInspBleacheds { get; set;}
        public virtual DbSet<KnittedFabricInspDyed> KnittedFabricInspDyed { get; set;}
        public virtual DbSet<KnittedFabricInspectionAttachment> KnittedFabricInspectionAttachment { get; set;}
        public virtual DbSet<FabricInspRptExp4PFormat2> FabricInspRptExp4PFormat2 { get; set;}
        public virtual DbSet<FabricInspReportExport4PointResults> FabricInspReportExport4PointResults { get; set;}
        public virtual DbSet<FabricInspReportExport4PointDetails> FabricInspReportExport4PointDetails { get; set;}
        public virtual DbSet<FabricInspReportExport> FabricInspReportExport { get; set;}

        #endregion

        #region ExportIndent  

        public virtual DbSet<IndExportShipmentScheduleMaster> IndExportShipmentScheduleMaster { get; set; }
        public virtual DbSet<IndExportShipmentScheduleDetail> IndExportShipmentScheduleDetail { get; set;}

        public virtual DbSet<FNLAccount> FNLAccounts { get; set; }
        public virtual DbSet<FNLCommissionBill> FNLCommissionBills { get; set; }
        public virtual DbSet<FNL_CommissionPaymentDetail> FNL_CommissionPaymentDetails { get; set; }
        public virtual DbSet<IndExportLCDetail> IndExportLCDetails { get; set; }

        #endregion


        #region Indents Common (Brand, GeneralDescriptions, GoodsForwarders, ShipingLines)
        public virtual DbSet<DeptDealsInCommodityType> DeptDealsInCommodityType{ get; set;}
        public virtual DbSet<DeptDealsInMarkeet> DeptDealsInMarkeet { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<IndGeneralDescriptions> GeneralDescriptions { get; set; }
        public virtual DbSet<GoodsForwarder> GoodsForwarder { get; set; }
        public virtual DbSet<ShipingLine> ShipingLines { get; set; }
        public virtual DbSet<IndPriceTerms> IndPriceTerms { get; set; }
        public virtual DbSet<IndPaymentTerms> IndPaymentTermses { get; set; }
        public virtual DbSet<IndUnitOfMeasure> IndUnitOfMeasures { get; set; }
        public virtual DbSet<CommodityType> CommodityTypes { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<IndSize> IndSize { get; set; }
        public virtual DbSet<IndDesign> IndDesign { get; set; }
        public virtual DbSet<IndSizeGroup> IndSizeGroup { get; set; }
        public virtual DbSet<UnitOfRate> UnitOfRate { get; set; }
        public virtual DbSet<UnitOfSale> UnitOfSale { get; set; }
        public virtual DbSet<IndColour> IndColour { get; set; }
        public virtual DbSet<EmailContractApproval> EmailContractApprovals { get; set;}
        public virtual DbSet<IndDelayShipmentCategory> IndDelayShipmentCategory { get; set; }
        public virtual DbSet<IndDelayShipmentReason> IndDelayShipmentReason { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<IndDomesticDispatchSchedule> IndDomesticDispatchSchedules { get; set; }
        public virtual DbSet<IndCommission> IndCommission { get; set; }

        public virtual DbSet<IndDomesticPaymentAddOn> IndDomesticPaymentAddOn { get; set; }
        public virtual DbSet<IndDomesticAddOnTemplate> IndDomesticAddOnTemplate { get; set;}
        public virtual DbSet<IndDomesticPaymentsAddOnList> IndDomesticPaymentsAddOnLists { get; set;}
        public virtual DbSet<IndDomesticInquiry> IndDomesticInquires { get; set; }
        
        public virtual DbSet<IndDomesticInquiryDetail> IndDomesticInquiryDetails { get; set; }
        public virtual DbSet<IndDomesticInquiryOffer> IndDomesticInquiryOffers { get; set; }
        public virtual DbSet<IndDomesticInquiryReview> IndDomesticInquiryReviews { get; set; }
        public virtual DbSet<IndInquiryReviewQuestion> IndInquiryReviewQuestions { get; set; }
        public virtual DbSet<IndDomestic> IndDomestic { get; set; }
        public virtual DbSet<IndDomesticDetail> IndDomesticDetail { get; set; }

        public virtual DbSet<IndLeadTime> IndLeadTime { get; set; }
        public virtual DbSet<ExchangeRates> ExchangeRates { get; set; }
        public virtual DbSet<IndCommissionInvoice> IndCommissionInvoice { get; set; }
        public virtual DbSet<IndCommissionInvoiceDetail> IndCommissionInvoiceDetail { get; set; }
        public virtual DbSet<IndentInfo> IndentInfos { get; set; }
        public virtual DbSet<IndentAgent> IndentAgents { get; set; }
        public virtual DbSet<CommInvoiceAgentComm> CommInvoiceAgentComm { get; set; }
        public virtual DbSet<FabricSample> FabricSample { get; set;}

        //Export Indent
        public virtual DbSet<IndExportInquiry> IndExportInquiries { get; set; }
        public virtual DbSet<IndExportInquiryDetail> IndExportInquiryDetails { get; set; }
        public virtual DbSet<IndExportInquiryOffer> IndExportInquiryOffers { get; set; }
        public virtual DbSet<IndExportInquiryReview> IndExportInquiryReviews { get; set; }
        public virtual DbSet<IndExportInquiryReviewQuestion> IndExportInquiryReviewQuestions { get; set; }
        public virtual DbSet<IndAccessories> IndAccessories { get; set; }

        

        public virtual DbSet<DocumentEFilingType> DocumentEFilingTypes { get; set;}
        public virtual DbSet<EFilingSystem> EFilingSystems { get; set; }

        public virtual DbSet<Cpa> Cpas { get; set;}
        public virtual DbSet<CPAAttachments_2BDeleted> CPAAttachments_2BDeleted { get; set;}
        public virtual DbSet<CpaFcl> CpaFcl { get; set; }
        public virtual DbSet<CPAFindingNature> CPAFindingNatures { get; set;}
        public virtual DbSet<CPAFindingNCType> CpaFindingNcTypes { get; set; }
        public virtual DbSet<CPAFindingNCTypeSub> CPAFindingNCTypeSubs { get; set; }
        public virtual DbSet<CPAFindingType> CPAFindingTypes { get; set; }
        public virtual DbSet<CPALogSheet> CPALogSheets { get; set; }
        public virtual DbSet<CpaNcType> CpaNcTypes { get; set; }
        public virtual DbSet<CpaTypes> CpaTypes { get; set; }

        #endregion

        #region Company
        

        public DbSet<BusinessTypes> BusinessTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        
        /* Inventory Database Objects  */
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Certifications> Certifications { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set;}
        public virtual DbSet<SpecialInstruction> SpecialInstruction{ get; set; }
        public virtual DbSet<Social> Social { get; set; }

        #endregion


        #region General
        public virtual DbSet<VM_FinLedger> VM_FinLedger { get; set; }
        public object SystemOption { get; internal set; }

        #endregion  General


        #region HR

        public virtual DbSet<HR_AllowanceModes> HR_AllowanceModes { get; set; }
        public virtual DbSet<HR_Allowances> HR_Allowances { get; set; }
        public virtual DbSet<HR_AttendanceTimings> HR_AttendanceTimings { get; set; }
        public virtual DbSet<HR_CINCR> HR_CINCR { get; set; }
        public virtual DbSet<HR_DayStatus> HR_DayStatus { get; set; }
        public virtual DbSet<HR_Degree> HR_Degree { get; set; }
        public virtual DbSet<HR_Designation> HR_Designation { get; set; }
        public virtual DbSet<HrEmployee> HrEmployee { get; set; }
        public virtual DbSet<HR_EmployeeAllowances> HR_EmployeeAllowances { get; set; }
        public virtual DbSet<HR_EmployeeExperience> HR_EmployeeExperience { get; set; }
        public virtual DbSet<HR_EmployeeLeaveBalance> HR_EmployeeLeaveBalance { get; set; }
        public virtual DbSet<HR_EmployeeLoanAdvanceBalance> HR_EmployeeLoanAdvanceBalance { get; set; }
        public virtual DbSet<HR_EmployeeQualification> HR_EmployeeQualification { get; set; }
        public virtual DbSet<HR_EmployeeType> HR_EmployeeType { get; set; }
        public virtual DbSet<HR_GazzettedDays> HR_GazzettedDays { get; set; }
        public virtual DbSet<HR_History> HR_History { get; set; }
        public virtual DbSet<HR_HistoryDetails> HR_HistoryDetails { get; set; }
        public virtual DbSet<HR_LeaveRequest> HR_LeaveRequests { get; set; }
        public virtual DbSet<HR_LoanAdvance> HR_LoanAdvance { get; set; }
        public virtual DbSet<HR_LoanAdvanceApplication> HR_LoanAdvanceApplication { get; set; }
        public virtual DbSet<HR_MonthlyAttendance> HR_MonthlyAttendance { get; set; }
        public virtual DbSet<HR_SalaryDetail> HR_SalaryDetail { get; set; }
        public virtual DbSet<HR_SalaryMaster> HR_SalaryMaster { get; set; }
        public virtual DbSet<HR_ShortLeaves> HR_ShortLeaves { get; set; }

        /* HR Database Objects  */
        public DbSet<HrDepartment> HrDepartments { get; set; }
        public DbSet<HrTaskRegister> HrTaskRegister { get; set; }
        public DbSet<HrTaskProgress> HrTaskProgress { get; set; }
        public DbSet<GeneralTask> GeneralTasks { get; set; }
        public DbSet<MinutesOfMeeting> MinutesOfMeetings { get; set; }
        public DbSet<MinutesOfMeetingOfficial> MinutesOfMeetingOfficials { get; set; }
        public DbSet<TaskAttachments_2BDeleted> TaskAttachments_2BDeleted { get; set; }
        public DbSet<ManualActionLog> ManualActionLogs { get; set; }
         
        #endregion
        
    }
}
