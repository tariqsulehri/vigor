using ERP.Core.Models.HR;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentExport;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomestic
    {
		  public IndDomestic()
        {
            this.IndDomesticDetails = new HashSet<IndDomesticDetail>();
            this.IndCommission = new HashSet<IndCommission>();
            this.CommInvoiceAgentComm = new List<CommInvoiceAgentComm>();

        } 
        public int Id { get; set; }

        [Required(ErrorMessage = "This is required filed...")]
        [MaxLength(10)]
        public string IndentKey { get; set; }
        [NotMapped]
        public bool IsAllow { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime IndentDate { get; set; }

        [MaxLength(3)]
        public string CompanyId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OfferDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime confirmDate { get; set; }

        [MaxLength(1)]
        public string IndentTypeId { get; set; } //L, E etc

        [ForeignKey("CommodityType")]
        public int CommodityTypeId { get; set; }
        public virtual CommodityType CommodityType { get; set; }

        public bool IsSample { get; set; }

        //[Required(ErrorMessage = "Field is required....")]
        //[ForeignKey("IndDomesticInquiry")]
        public int InquiryId { get; set; }
        //public virtual IndDomesticInquiry IndDomesticInquiry { get; set; }

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }

        [ForeignKey("HrDepartment")]
        public int DepartmentID { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }

        public int CommodityGroups { get; set; }

        [ForeignKey("FinParty")]
        public int CustomerId { get; set; }
        public virtual FinParty FinParty { get; set; }
        public int CustomerIDasSeller { get; set; }
        public string CustomerSellerName { get; set; }

        public int CustomerIDasBuyer { get; set; }
        public string CustomerBuyerName { get; set; }

        public int CustomerIDasLocalAgent { get; set; }
        public string CustomerAsLocalAgent { get; set; }

        [ForeignKey("IndPaymentTerms")]
        public int PaymenTermsId { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        
        [MaxLength(10)]
        public string QuantityVariance { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalValueOnCommRate { get; set; }

        [MaxLength(1500)]
        public string PackingRemarks { get; set; }

        [MaxLength(1500)]
        public string DeliveryRemarks { get; set; }

        [MaxLength(1000)]
        public string DeliveryRemarksBuyer { get; set; }

        [MaxLength(2000)]
        public string GeneralRemarks { get; set; }

        [MaxLength(1500)]
        public string SpecialConditions { get; set; }

        [MaxLength(1500)]
        public string SpecialConditionsBuyer { get; set; }

        [MaxLength(1500)]
        public string SpecialConditionsSeller { get; set; }

        [MaxLength(1500)]
        public string PicesLength { get; set; }

        [MaxLength(1500)]
        public string QualityRemarks { get; set; }

        [MaxLength(1500)]
        public string FinancialRemarks { get; set; }

        [MaxLength(1500)]
        public string Specificatiions { get; set; }

        [MaxLength(200)]
        public string PriceTerms { get; set; }

        [MaxLength(200)]
        public string Destination { get; set; }

        //[StringLength(1)]
        public bool IndentStatus { get; set; }

        [MaxLength(200)]
        public string CottonSource { get; set; }

        [MaxLength(50)]
        public string CostingSheetRef { get; set; }

      //  [MaxLength(1)]
        public bool NodePatch { get; set; }

        public int RevisionNumber { get; set; }
        [MaxLength(200)]
        public string ClosingRemaks { get; set; }

        //   [MaxLength(1)]
        public bool isClosed { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime closedDate { get; set; }
        public decimal ExecutedTotalValue { get; set; }
        public bool IsScheduleGenerated { get; set; }
        public bool isCancelled { get; set; }
        public bool isShipments { get; set; }
        public bool isInvoiced { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DelDateValidUpto { get; set; }
        public bool IsApproved { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastApprovedOn { get; set; }
        public int ApprovedBy { get; set; }
        public int MarketedBy { get; set; }

        //For Export
        [MaxLength(50)]
        public string FabricWeight { get; set; }

        [StringLength(50)]
        public string BlendRatio { get; set; }
        
       /// <summary>
       /// Need to Be Discussed About following fields
       /// </summary>
        [Required(ErrorMessage = "This is required filed...")]
        [MaxLength(13)]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDueDate { get; set; }
        //=====================================================


        public virtual IndPaymentTerms IndPaymentTerms { get; set; }
        public virtual ICollection<IndDomesticDetail> IndDomesticDetails { get; set; }
        public virtual ICollection<IndDomesticDispatchSchedule> IndDomesticDispatchSchedule { get; set; }
        public virtual ICollection<IndCommission> IndCommission { get; set; }
        public virtual ICollection<FabricInspReportLocal> FabricInspReportLocal { get; set; }
        public virtual ICollection<IndCommissionInvoice> IndCommissionInvoice { get; set; }
        public virtual ICollection<CommInvoiceAgentComm> CommInvoiceAgentComm { get; set; }
        public virtual ICollection<YarnInspection> YarnInspections { get; set; }
        public virtual ICollection<FabricSample> FabricSample { get; set; }
        public virtual ICollection<KnittedFabricInspection> KnittedFabricInspections { get; set; }
        public virtual ICollection<IndentInfo> IndentInfos { get; set; }
        public virtual ICollection<IndExportShipmentScheduleMaster> IndExportShipmentScheduleMaster { get; set; }
        public virtual ICollection<IndExportLCDetail> ExportLCDetails { get; set; }

        //============================================
        public bool IsSubmitForApproval { get; set; }
        [MaxLength(50)]
        public string SuppContract { get; set; }
        [MaxLength(30)]
        public string PONumber { get; set; }

        // [MaxLength(1)]
        public bool IsUpdated { get; set; }
        public int CreatedBy { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }

    }
}



     

