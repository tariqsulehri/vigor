using ERP.Core.Models.HR;
using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportInquiry
    {
        public int Id { get; set; }

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }  // 13 Digit Keu =  VIL + Q + 2013 + XXXXX   

        [Required]
        [StringLength(3)]
        public string Companyid { get; set; }

        [ForeignKey("HrDepartment")]
        public int DepartmentID { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InquiryDate { get; set; }

        [ForeignKey("CommodityType")]
        public int CommodityTypeId { get; set; }
        public virtual CommodityType CommodityType { get; set; }

        [MaxLength(2)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryMarket { get; set; }

        [ForeignKey("FinParty")]
        public int CustomerId { get; set; }
        public virtual FinParty FinParty { get; set; }

        [StringLength(100)]
        public string Customer { get; set; }
        public int CustomerasBuyer { get; set; }
        public char InquiryStatus { get; set; }

                
        [ForeignKey("IndPaymentTerms")]
        public int PaymenTermsId { get; set; }
        public virtual IndPaymentTerms IndPaymentTerms { get; set; }

        [ForeignKey("IndPriceTerms")]
        public int PriceTermsId { get; set; }
        public virtual IndPriceTerms IndPriceTerms { get; set; }

        [MaxLength(200)]
        public string Destination { get; set; }


        [MaxLength(200)]
        public string Shipment { get; set; }

        [MaxLength(250)]
        public string Programm { get; set; }

        [MaxLength(1000)]
        public string Remarks { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? InquiryInfoCompletedOn { get; set; }
        
        [StringLength(1)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquieryStatus { get; set; }

        [StringLength(1)]
        public string IsClosed { get; set; }
        public DateTime? InquiryClosedDate { get; set; }

//        [Required(ErrorMessage = "Field is required....")]
//        [NotMapped]
//        public decimal Quantity { get; set; }
//
//        [Required(ErrorMessage = "Field is required....")]
//        [NotMapped]
//        public int ProductId { get; set; }
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

        // public virtual ICollection<IndDomestic> IndDomestic { get; set; }
          public virtual ICollection<IndExportInquiryDetail> IndExportInquiryDetail { get; set; }
          public virtual ICollection<IndExportInquiryOffer> IndExportInquiryOffer { get; set; }
          public virtual ICollection<IndExportInquiryReview> IndExportInquiryReview { get; set; }

    }
}
