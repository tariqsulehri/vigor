namespace ERP.Core.Models.HR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_LeaveRequest
    {
        [Key]
        [StringLength(8)]
        public string LeaveRequestMasterID { get; set; }

        public int FortheYear { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(5)]
        public string EmployeeNo { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime LeaveRequiredFrom { get; set; }

        public DateTime LeaveRequestedTo { get; set; }

        public int LeaveType { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        public int Userid_as_ApprovedBy { get; set; }

        public DateTime ApprovedOn { get; set; }

        public bool IsPending { get; set; }

        public bool IsApproved { get; set; }

        public bool IsActive { get; set; }

        [StringLength(1)]
        public string ApplicationType { get; set; }

        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
    }
}
