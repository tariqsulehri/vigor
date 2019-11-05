using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
   public class IndInquiryReviewQuestion
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(150)]
        public string InquiryReviewQuestion { get; set; }
        public Boolean IsActive { get; set; }
        [MaxLength(1)]
        public string ForMarket { get; set; }
        public virtual ICollection<IndDomesticInquiryReview> IndDomesticInquiryReviews { get; set; }

        public static implicit operator IndInquiryReviewQuestion(HashSet<IndInquiryReviewQuestion> v)
        {
            throw new NotImplementedException();
        }
    }
}
