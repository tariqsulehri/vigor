namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_QualityControlInspectors
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string QcInspectorID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string InspectorFullName { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(2)]
        public string CommoditytypeCode { get; set; }
    }
}
