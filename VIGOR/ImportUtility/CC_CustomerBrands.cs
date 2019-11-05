namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CustomerBrands
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CustomerCode { get; set; }

        [StringLength(4)]
        public string BrandID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BrandName { get; set; }
    }
}
