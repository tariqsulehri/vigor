namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyEOBISetting
    {
        [Key]
        [StringLength(4)]
        public string EoBiSettingID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EOBISalaryLowLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EOBISalaryHighLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployeeContribution { get; set; }

        [Column(TypeName = "numeric")]
        public decimal EmployerContribution { get; set; }

        public bool IsActive { get; set; }
    }
}
