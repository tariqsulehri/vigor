namespace ERP.Core.Models.HR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_SalaryDetail
    {
        [Key]
        [StringLength(11)]
        public string EmployeeSalaryMasterId { get; set; }

        public int EmployeeAllowanceID { get; set; }

        public decimal Amount { get; set; }

        [StringLength(1)]
        public string Mode { get; set; }

        public int LoanAdvanceID { get; set; }

        public decimal DeductedAmount { get; set; }

        [StringLength(1)]
        public string DeductionType { get; set; }

        [StringLength(1)]
        public string IsDeductedBySystem { get; set; }

        [StringLength(3)]
        public string Deduction_ChangedBy { get; set; }
        public DateTime ChangedOn { get; set; }
    }
}
