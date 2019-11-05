namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_InquiryMaster
    {
        [Key]
        [StringLength(13)]
        public string InquiryNo { get; set; }

        [Required]
        [StringLength(3)]
        public string Companyid { get; set; }

        [Required]
        [StringLength(4)]
        public string DepartmentID { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

        public DateTime InquiryDate { get; set; }

        [Required]
        [StringLength(2)]
        public string CommType { get; set; }

        [Required]
        [StringLength(1)]
        public string InquiryMarket { get; set; }

        [StringLength(100)]
        public string Customer { get; set; }

        [StringLength(6)]
        public string CustomerasBuyer { get; set; }

        [StringLength(4)]
        public string PaymentTerm { get; set; }

        [StringLength(4)]
        public string PriceTerm { get; set; }

        [StringLength(200)]
        public string Destination { get; set; }

        [StringLength(200)]
        public string Shipment { get; set; }

        [StringLength(250)]
        public string Program { get; set; }

        [StringLength(1000)]
        public string InquiryRemarks { get; set; }

        public DateTime? InquiryInfoComletedOn { get; set; }

        [StringLength(1)]
        public string InquiryStatus { get; set; }

        [StringLength(1)]
        public string IsClosed { get; set; }

        public DateTime? InquiryClosedDate { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
