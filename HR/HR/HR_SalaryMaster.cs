namespace ERP.Core.Models.HR
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

        public DateTime SalaryMonth { get; set; }

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

        public decimal CurrentMonthGrossSalary { get; set; }

        public decimal CurrentMonthBasicSalary { get; set; }

        public decimal CurrentMonthAllowances { get; set; }

        public decimal CurrentMonthNetSalary { get; set; }

        public decimal LoanAdjusted { get; set; }

        public decimal AdvanceAdjusted { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal HealthInsurance { get; set; }

        [StringLength(1)]
        public string SalaryMode { get; set; }

        public decimal Arrears { get; set; }

        public decimal Fine { get; set; }

        public decimal MiscDeductions { get; set; }

        public decimal EOBIEmployerContribution { get; set; }

        public decimal EOBIEmployeeContribution { get; set; }

        public decimal NoticePeriod { get; set; }

        public bool IsHold { get; set; }
    }
}
