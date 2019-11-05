namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_SalaryDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string EmployeeSalaryMasterId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EmployeeAllowanceID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string Mode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LoanAdvanceID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DeductedAmount { get; set; }

        [StringLength(1)]
        public string DeductionType { get; set; }

        [StringLength(1)]
        public string IsDeductedBySystem { get; set; }

        [StringLength(3)]
        public string Deduction_ChangedBy { get; set; }

        public DateTime? ChangedOn { get; set; }
    }
}
