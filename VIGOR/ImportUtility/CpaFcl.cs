namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CpaFcl
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string CPaNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string ShipmentScheduleid { get; set; }
    }
}
