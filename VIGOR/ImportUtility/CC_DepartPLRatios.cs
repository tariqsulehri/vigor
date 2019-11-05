namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DepartPLRatios
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string FiscalPeriod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string GeneralDepartCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string MarketingDepartCode { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal PercentageOfExpences { get; set; }
    }
}
