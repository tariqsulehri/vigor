namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskAttachments-2BDeleted")]
    public partial class TaskAttachments_2BDeleted
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string TaskID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreatedOn { get; set; }

        public virtual TaskRegister TaskRegister { get; set; }
    }
}
