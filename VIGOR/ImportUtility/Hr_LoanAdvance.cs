namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hr_LoanAdvance
    {
        [Key]
        [StringLength(8)]
        public string LoanAdvLedID { get; set; }

        [StringLength(5)]
        public string EmployeeNo { get; set; }

        public DateTime TransectionDate { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Amount { get; set; }

        [StringLength(1)]
        public string IsDeduction { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LoanAdvanceApplicationNo { get; set; }

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
