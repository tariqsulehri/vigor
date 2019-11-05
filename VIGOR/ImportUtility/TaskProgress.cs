namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskProgress")]
    public partial class TaskProgress
    {
        [StringLength(11)]
        public string TaskProgressID { get; set; }

        [Key]
        [StringLength(9)]
        public string TaskID { get; set; }

        [StringLength(2500)]
        public string Comments { get; set; }

        [StringLength(5)]
        public string PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        public bool? IsActive { get; set; }
    }
}
