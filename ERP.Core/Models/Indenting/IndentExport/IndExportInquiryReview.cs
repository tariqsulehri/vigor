using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportInquiryReview
    {
        public IndExportInquiryReview()
        {
            //this.IndExportInquiry = new IndExportInquiry();
            this.IndExportInquiryReviewQuestion = new HashSet<IndExportInquiryReviewQuestion>();

        }
        public int Id { get; set; }


        [ForeignKey("IndInquiryReviewQuestions")]
        public int InqReviewQuestionId { get; set; }
        public virtual IndInquiryReviewQuestion IndInquiryReviewQuestions { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(250)]
        public string InquiryReviewQuestion { get; set; }

        [ForeignKey("IndExportInquiry")]
        public int InquiryId { get; set; }
        public virtual IndExportInquiry IndExportInquiry { get; set; }

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }

        [StringLength(3)]
        public string CompanyKey { get; set; }

        public Boolean Status { get; set; }

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
        public ICollection<IndExportInquiryReviewQuestion> IndExportInquiryReviewQuestion { get; set; }
    }
}
