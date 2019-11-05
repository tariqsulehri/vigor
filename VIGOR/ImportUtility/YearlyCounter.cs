namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YearlyCounter
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Year { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LocalInquiryNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExportInquiryNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LocalindentNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExportIndentNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FNLCommissionBill { get; set; }
    }
}
