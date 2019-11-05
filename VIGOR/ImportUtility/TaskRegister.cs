namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskRegister")]
    public partial class TaskRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskRegister()
        {
            TaskAttachments_2BDeleted = new HashSet<TaskAttachments_2BDeleted>();
        }

        [Key]
        [StringLength(9)]
        public string TaskID { get; set; }

        public DateTime Dated { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [StringLength(5)]
        public string AssignedTo { get; set; }

        [StringLength(4)]
        public string DepartmentID { get; set; }

        [StringLength(5)]
        public string AssignedBy { get; set; }

        public DateTime? ReqTargetDate { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public DateTime? ExpectedCompletionDate { get; set; }

        public DateTime? TaskCompletionDate { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(3)]
        public string Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskAttachments_2BDeleted> TaskAttachments_2BDeleted { get; set; }
    }
}
