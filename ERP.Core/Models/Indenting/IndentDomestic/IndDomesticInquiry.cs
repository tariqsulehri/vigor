using ERP.Core.Models.HR;
using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticInquiry
    {

		 public IndDomesticInquiry()
        {
            this.IndDomesticInquiryOffers =new HashSet<IndDomesticInquiryOffer>();
            this.IndDomesticInquiryDetails= new HashSet<IndDomesticInquiryDetail>();
            this.IndDomesticInquiryReviews= new HashSet<IndDomesticInquiryReview>();
        } 
        [Key]
        public int Id { get; set;}

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }  // 13 Digit Keu =  VIL + Q + 2013 + XXXXX   

        [StringLength(3)]
        public string Companyid { get; set;}

        [ForeignKey("HrDepartment")]
        public int DepartmentID { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }

        [StringLength(4)]
        public string DepartmentID_Key { get; set; }

        [ForeignKey("CommodityType")]
        public int CommodityTypeId { get; set; }
        public virtual CommodityType CommodityType { get; set; }

        [MaxLength(200)]
        public string Delivery { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryMarket { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InquiryDate { get; set; }
        public DateTime? InquiryClosedDate { get; set; }

        [ForeignKey("FinParty")]
        public int CustomerId { get; set; }
        public virtual FinParty FinParty { get; set; }

        [MaxLength(100)]
        public string CustomerAsBuyer { get; set; }

        [ForeignKey("IndPaymentTerms")]
        public int PaymenTermsId { get; set;}
        public virtual IndPaymentTerms IndPaymentTerms { get; set; }
        public string Remarks { get; set; }

        //[ForeignKey("Currency")]
        //public int CurrencyId { get; set; }
        //public virtual Currency Currency { get; set; }

        [StringLength(1)]
        public string InquiryStatus { get; set; }

        [StringLength(1)]
        public string IsClosed { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [NotMapped]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [NotMapped]

        public int UosId { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [NotMapped]

        public int ProductId { get; set; }	   
        public int CreatedBy { get; set; }


        [MaxLength(100)]
        public string WalkingCustomer { get; set; }     // Vigor Customer


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
        public virtual ICollection<IndDomesticInquiryDetail> IndDomesticInquiryDetails { get; set; }
        public virtual ICollection<IndDomesticInquiryOffer> IndDomesticInquiryOffers { get; set; }
        public virtual ICollection<IndDomesticInquiryReview> IndDomesticInquiryReviews { get; set; }



    }
}
