namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EmployeeAllowances
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string AllowanceID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Amount { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string Mode { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal AllowanceValue { get; set; }
    }
}
