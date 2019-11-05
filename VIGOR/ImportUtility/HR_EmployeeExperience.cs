namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EmployeeExperience
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Organization { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string Designation { get; set; }

        public DateTime? JoinigDate { get; set; }

        public DateTime? ResignedOn { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string ReasonToLeave { get; set; }
    }
}
