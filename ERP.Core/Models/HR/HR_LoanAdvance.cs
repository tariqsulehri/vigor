namespace ERP.Core.Models.HR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_LoanAdvance
    {
        [Key]
        [StringLength(8)]
        public string LoanAdvLedID { get; set; }

        [ForeignKey("HrEmployee")]
        public int EmployeeId { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }
        public DateTime TransectionDate { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; }

        public double Amount { get; set; }

        [StringLength(1)]
        public string IsDeduction { get; set; }

        public double LoanAdvanceApplicationNo { get; set; }

        [StringLength(11)]
        public string SalarySlipNo { get; set; }

        [StringLength(10)]
        public string BonusMasterID { get; set; }

        [StringLength(18)]
        public string VoucherNo { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(3)]
        public string Company { get; set; }
    }
}
