namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FabInspStandard")]
    public partial class FabInspStandard
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal FabricInspectionStd { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string FabricInspectionStdDesc { get; set; }
    }
}
