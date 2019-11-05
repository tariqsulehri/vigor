namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_MarketDealsIn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string MarketDealID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string MarketDealsDescription { get; set; }
    }
}
