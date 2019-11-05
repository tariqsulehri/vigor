namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_InquiryReview
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string InquiryReviewQuestionCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string InquiryNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Companyid { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Status { get; set; }
    }
}
