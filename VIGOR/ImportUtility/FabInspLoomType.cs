namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FabInspLoomType
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal LoomTypeID { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
