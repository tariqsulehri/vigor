using ERP.Core.Models.Party;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticInquiryOffer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("IndDomesticInquiry")]
        public int InquiryId { get; set; }
        public virtual IndDomesticInquiry IndDomesticInquiry { get; set; }

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }

        public DateTime OfferMadeOn { get; set; }


        [ForeignKey("FinParty")]
        public int CustomerId { get; set; }
        public virtual FinParty FinParty { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string OfferedBy { get; set; }

        public decimal OfferedRate { get; set; }

        [ForeignKey("IndPaymentTerms")]
        public int PaymentTermsId { get; set;}
        public virtual IndPaymentTerms IndPaymentTerms { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(200)]
        public string Remarks { get; set; }
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
