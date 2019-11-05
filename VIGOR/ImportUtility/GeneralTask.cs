namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GeneralTask")]
    public partial class GeneralTask
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string GeneralTaskID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime TaskDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Subject { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string TaskProgress { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(5)]
        public string TaskAssignedBy { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string TaskAssignedByDept { get; set; }

        public DateTime? TaskCompletionDate { get; set; }

        [StringLength(1)]
        public string IsApproved { get; set; }

        [StringLength(1)]
        public string IsCompleted { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(5)]
        public string Userid_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime CreatedOn { get; set; }

        [StringLength(5)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
