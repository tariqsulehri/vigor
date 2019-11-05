using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Indenting
{
    public class IndPaymentTerms
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        public int MaturityDays { get; set; }


        [Required(ErrorMessage = "This is Required field....")]
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

        public ICollection<IndDomesticInquiry> IndDomesticInquires { get; set; }
        public ICollection<IndExportInquiry> IndExportInquires { get; set; }
        public ICollection<IndDomesticInquiryOffer> IndDomesticInquiryOffer { get; set; }
        public ICollection<IndDomestic> IndDomestic { get; set; }


    }
}




