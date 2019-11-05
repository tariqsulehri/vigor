namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_InquiryReviewQuestions
    {
        [Key]
        [StringLength(2)]
        public string InquiryReviewQuestionID { get; set; }

        [Required]
        [StringLength(150)]
        public string InquiryReviewQuestion { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(1)]
        public string ForMarket { get; set; }
    }
}
