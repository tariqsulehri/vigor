using ERP.Core.Models.Common;

namespace ERP.Core.Models.HR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_LoanAdvanceApplication
    {
        [Key]
        [StringLength(8)]
        public string LoanAdvanceID { get; set; }

        public DateTime ApplicationDate { get; set; }

        [ForeignKey("HrEmployee")]
        public int EmployeeId { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [ForeignKey("Company")]
        [Required]
        public int companyID { get; set; }
        public virtual Company Company { get; set; }

        [StringLength(3)]
        [Required(ErrorMessage = "Field is required....")]
        public string CompanyKey { get; set; }

        [StringLength(250)]
        public string Reason { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RequiredAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LoanInstalment { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ApprovedAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ApprovedLoanInstalment { get; set; }

        [StringLength(1)]
        public string isActive { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        [Required]
        [StringLength(1)]
        public string IsPending { get; set; }

        [Required]
        [StringLength(1)]
        public string IsApproved { get; set; }

        [Required]
        [StringLength(1)]
        public string IsPosted { get; set; }

        public DateTime PostedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_PostedBy { get; set; }

        public double oldAppId { get; set; }
    }
}
