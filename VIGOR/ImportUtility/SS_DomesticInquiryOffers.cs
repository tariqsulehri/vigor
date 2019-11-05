namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DomesticInquiryOffers
    {
        [Key]
        [StringLength(16)]
        public string OfferID { get; set; }

        [StringLength(13)]
        public string InquiryNo { get; set; }

        [StringLength(6)]
        public string OfferedBy { get; set; }

        public DateTime? OfferMadeOn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OfferedRate { get; set; }

        [StringLength(4)]
        public string PaymentTerms { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }
    }
}
