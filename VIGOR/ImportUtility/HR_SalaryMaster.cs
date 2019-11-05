namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_SalaryMaster
    {
        [Key]
        [StringLength(11)]
        public string EmployeeSalaryMasterId { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        public DateTime? SalaryMonth { get; set; }

        public int ForTheYear { get; set; }

        public int fortheMonth { get; set; }

        [Required]
        [StringLength(4)]
        public string DepartmentCode { get; set; }

        [Required]
        [StringLength(3)]
        public string DesignationCode { get; set; }

        [StringLength(1)]
        public string Isterminated { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CurrentMonthGrossSalary { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurrentMonthBasicSalary { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CurrentMonthAllowances { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurrentMonthNetSalary { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LoanAdjusted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AdvanceAdjusted { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IncomeTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? HealthInsurance { get; set; }

        [StringLength(1)]
        public string SalaryMode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Arrears { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fine { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MiscDeductions { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EOBIEmployerContribution { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EOBIEmployeeContribution { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoticePeriod { get; set; }

        public bool? IsHold { get; set; }
    }
}
