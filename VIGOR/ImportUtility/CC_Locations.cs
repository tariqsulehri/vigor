namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Locations
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string LocationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string LocationDescription { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Company { get; set; }
    }
}
