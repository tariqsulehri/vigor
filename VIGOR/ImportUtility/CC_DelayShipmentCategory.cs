namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DelayShipmentCategory
    {
        [Key]
        [StringLength(1)]
        public string DelayShipmentCategoryID { get; set; }

        [Required]
        [StringLength(10)]
        public string DelayShipmentCategoryDescription { get; set; }
    }
}
