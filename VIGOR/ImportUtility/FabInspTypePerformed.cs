namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FabInspTypePerformed")]
    public partial class FabInspTypePerformed
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string InspTypePerformedID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string InspTypePerformedDesc { get; set; }
    }
}
