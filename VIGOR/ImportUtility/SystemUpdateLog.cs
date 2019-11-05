namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemUpdateLog")]
    public partial class SystemUpdateLog
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Dated { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1000)]
        public string SustemUpdate { get; set; }
    }
}
