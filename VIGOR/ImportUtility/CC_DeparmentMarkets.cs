namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DeparmentMarkets
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string MarketDeal { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }
    }
}
