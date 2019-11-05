namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EmployeeLoanAdvanceBalance
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal LoanAdvanceID { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LoanOpenBalance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AdvanceopenBalance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LoanAmountBalance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AdvanceAmountBalance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LoanInstalment { get; set; }
    }
}
