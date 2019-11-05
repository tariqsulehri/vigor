namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_AllowanceModes
    {
        [Key]
        [StringLength(1)]
        public string AllowanceMode { get; set; }

        [Required]
        [StringLength(10)]
        public string Description { get; set; }
    }
}
