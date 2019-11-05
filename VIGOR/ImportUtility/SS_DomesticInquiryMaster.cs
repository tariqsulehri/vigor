namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DomesticInquiryMaster
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string InquiryNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string Companyid { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string DepartmentID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime InquiryDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string InquiryMarket { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2)]
        public string CommType { get; set; }

        [StringLength(1)]
        public string InquiryStatus { get; set; }

        [StringLength(1)]
        public string IsClosed { get; set; }

        public DateTime? InquiryClosedDate { get; set; }

        [StringLength(100)]
        public string Customer { get; set; }

        [StringLength(6)]
        public string CustomerasBuyer { get; set; }

        [StringLength(4)]
        public string PaymentTerm { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
