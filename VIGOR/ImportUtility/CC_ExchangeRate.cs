namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_ExchangeRate
    {
        [Key]
        [Column(Order = 0)]
        public DateTime ExchangeRateDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string CurrencyID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Exchanged_CurrencyID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal ExchangeRateSelling { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExchangeRateBuying { get; set; }

        [StringLength(10)]
        public string ExchangeRate120Selling { get; set; }

        [StringLength(10)]
        public string ExchangeRate120Buying { get; set; }

        [StringLength(10)]
        public string ExchangeRateOpenMktBuying { get; set; }

        [StringLength(10)]
        public string ExchangeRateOpenMktSelling { get; set; }
    }
}
