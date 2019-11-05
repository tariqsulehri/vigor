namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DomesticInquiryDetails
    {
        [Key]
        [StringLength(16)]
        public string InquiryNoDetailID { get; set; }

        [Required]
        [StringLength(13)]
        public string InquiryNo { get; set; }

        [StringLength(200)]
        public string CommodityCode { get; set; }

        [StringLength(200)]
        public string Commodity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(3)]
        public string UOSID { get; set; }
    }
}
