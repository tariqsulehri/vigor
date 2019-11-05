namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EmployeeLeaveBalance
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string TransectionYear { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal LeavespenBalance { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal LeavesConsumed { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal LeavesInBalance { get; set; }
    }
}
