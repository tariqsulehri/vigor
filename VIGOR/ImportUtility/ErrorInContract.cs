namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ErrorInContract
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SalesContract { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string Customer { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string SellerOrBuyer { get; set; }
    }
}
