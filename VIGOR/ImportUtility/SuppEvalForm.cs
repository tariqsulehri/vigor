namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuppEvalForm")]
    public partial class SuppEvalForm
    {
        [StringLength(2)]
        public string SuppEvalformId { get; set; }

        [Required]
        [StringLength(250)]
        public string FormDescription { get; set; }

        [Required]
        [StringLength(1)]
        public string IsActive { get; set; }

        public DateTime? implementedSince { get; set; }
    }
}
