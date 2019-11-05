namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EmployeeQualification
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string DegreeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Institution { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string Marks_gpa { get; set; }

        [StringLength(5)]
        public string Grade { get; set; }

        [StringLength(5)]
        public string Division { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(15)]
        public string DegreeSession { get; set; }
    }
}
