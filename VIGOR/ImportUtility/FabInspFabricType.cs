namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FabInspFabricType")]
    public partial class FabInspFabricType
    {
        [Key]
        [StringLength(2)]
        public string TypeofFabric { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
