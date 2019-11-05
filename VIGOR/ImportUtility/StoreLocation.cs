namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StoreLocation
    {
        [StringLength(2)]
        public string StoreLocationID { get; set; }

        [Required]
        [StringLength(15)]
        public string StoreLocationDescription { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }
    }
}
