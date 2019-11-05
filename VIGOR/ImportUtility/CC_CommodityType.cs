namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CommodityType
    {
        [Key]
        [StringLength(2)]
        public string CommodityTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string CommodityTypeDescription { get; set; }

        [StringLength(1)]
        public string ScheduleType { get; set; }

        [StringLength(1)]
        public string DomesticMarket { get; set; }

        [StringLength(1)]
        public string ScheduleTypeDomestic { get; set; }

        [StringLength(1)]
        public string InternationalMarket { get; set; }

        [StringLength(1)]
        public string ScheduleTypeInternational { get; set; }
    }
}
