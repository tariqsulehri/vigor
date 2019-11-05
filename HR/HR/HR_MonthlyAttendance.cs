namespace ERP.Core.Models.HR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_MonthlyAttendance
    {
        [Key]
        [StringLength(11)]
        public string EmployeeAttendanceId { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyId { get; set; }

        public DateTime AttendanceMonth { get; set; }

        public int Forthemonth { get; set; }

        public int Fortheyear { get; set; }

        [Required]
        [StringLength(4)]
        public string Department { get; set; }

        [Required]
        [StringLength(3)]
        public string Designation { get; set; }

        public DateTime ValidDateStart { get; set; }

        public DateTime ValidDateEnd { get; set; }

        public bool IsSeparated { get; set; }

        public int TotalMonthDays { get; set; }

        public int TotalWorkingDays { get; set; }

        public int WithPay { get; set; }

        public int WithOutPay { get; set; }

        public int Leaves { get; set; }

        public int Visits { get; set; }

        [StringLength(2)]
        public string Day01 { get; set; }

        [StringLength(2)]
        public string Day02 { get; set; }

        [StringLength(2)]
        public string Day03 { get; set; }

        [StringLength(2)]
        public string Day04 { get; set; }

        [StringLength(2)]
        public string Day05 { get; set; }

        [StringLength(2)]
        public string Day06 { get; set; }

        [StringLength(2)]
        public string Day07 { get; set; }

        [StringLength(2)]
        public string Day08 { get; set; }

        [StringLength(2)]
        public string Day09 { get; set; }

        [StringLength(2)]
        public string Day10 { get; set; }

        [StringLength(2)]
        public string Day11 { get; set; }

        [StringLength(2)]
        public string Day12 { get; set; }

        [StringLength(2)]
        public string Day13 { get; set; }

        [StringLength(2)]
        public string Day14 { get; set; }

        [StringLength(2)]
        public string Day15 { get; set; }

        [StringLength(2)]
        public string Day16 { get; set; }

        [StringLength(2)]
        public string Day17 { get; set; }

        [StringLength(2)]
        public string Day18 { get; set; }

        [StringLength(2)]
        public string Day19 { get; set; }

        [StringLength(2)]
        public string Day20 { get; set; }

        [StringLength(2)]
        public string Day21 { get; set; }

        [StringLength(2)]
        public string Day22 { get; set; }

        [StringLength(2)]
        public string Day23 { get; set; }

        [StringLength(2)]
        public string Day24 { get; set; }

        [StringLength(2)]
        public string Day25 { get; set; }

        [StringLength(2)]
        public string Day26 { get; set; }

        [StringLength(2)]
        public string Day27 { get; set; }

        [StringLength(2)]
        public string Day28 { get; set; }

        [StringLength(2)]
        public string Day29 { get; set; }

        [StringLength(2)]
        public string Day30 { get; set; }

        [StringLength(2)]
        public string Day31 { get; set; }
    }
}
