namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManualActionLog")]
    public partial class ManualActionLog
    {
        [Key]
        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(1500)]
        public string ActionLog { get; set; }
    }
}
