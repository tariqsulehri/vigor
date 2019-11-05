namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DelayShipmentReason
    {
        [Key]
        [StringLength(2)]
        public string DelayShipmentReasonID { get; set; }

        [Required]
        [StringLength(50)]
        public string DelayShipmentReasonDescription { get; set; }

        [StringLength(1)]
        public string DelayShipmentCategory { get; set; }
    }
}
