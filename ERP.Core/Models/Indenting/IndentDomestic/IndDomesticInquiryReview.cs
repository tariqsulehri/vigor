using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticInquiryReview
    {
        public IndDomesticInquiry indDomesticInquiry;
        public List<IndInquiryReviewQuestion> indInquiryReviewQuestion;

        public IndDomesticInquiryReview()
        {
              indDomesticInquiry =  new IndDomesticInquiry();
              indInquiryReviewQuestion = new List<IndInquiryReviewQuestion>();
        } 
        public int Id { get; set; }

        [ForeignKey("IndInquiryReviewQuestions")]
        public int InqReviewQuestionId { get; set; }
        public virtual IndInquiryReviewQuestion IndInquiryReviewQuestions { get; set; }

        [ForeignKey("IndDomesticInquiry")]
        public int InquiryId { get; set; } 
        public virtual IndDomesticInquiry IndDomesticInquiry { get; set; }

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }

        public int BuyerId { get; set; }
        public int SellerId { get; set; }
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

    }
}
