namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FabInspStatu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string InspectionStatusID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string InspectionStatusDescription { get; set; }
    }
}
