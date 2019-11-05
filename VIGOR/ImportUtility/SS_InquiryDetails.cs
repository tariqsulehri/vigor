namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_InquiryDetails
    {
        [Key]
        [StringLength(16)]
        public string InquiryNoDetailID { get; set; }

        [Required]
        [StringLength(13)]
        public string InquiryNo { get; set; }

        [StringLength(6)]
        public string CommodityCode { get; set; }

        [StringLength(200)]
        public string Commodity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(3)]
        public string UOSID { get; set; }

        [StringLength(20)]
        public string CostingSheetRef { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CostingPrice { get; set; }

        [StringLength(150)]
        public string InquiryLineItemRemarks { get; set; }

        [StringLength(10)]
        public string SalesContractIssued { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(200)]
        public string SizeAndSpecification { get; set; }

        public bool? IsSampleReceived { get; set; }

        public bool? FabricDetails { get; set; }

        public bool? PackingDetails { get; set; }

        public bool? TrimDetails { get; set; }

        public bool? ColourPantoneCodes { get; set; }

        public bool? InternalCosting { get; set; }
    }
}
