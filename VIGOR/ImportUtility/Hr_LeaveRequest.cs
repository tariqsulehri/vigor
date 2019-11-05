namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hr_LeaveRequest
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string LeaveRequestMasterID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FortheYear { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime ApplicationDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime LeaveRequiredFrom { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime LeaveRequestedTo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeaveType { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsPending { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool IsApproved { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(1)]
        public string ApplicationType { get; set; }
    }
}
