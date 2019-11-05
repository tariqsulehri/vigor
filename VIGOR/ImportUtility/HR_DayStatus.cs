namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_DayStatus
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal DayStatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(2)]
        public string Abbreviation { get; set; }

        public decimal WorkingDays { get; set; }

        public decimal DeductDays { get; set; }

        public bool AllowedInAttendance { get; set; }

        public bool isActive { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CountAs { get; set; }

        public bool? ListedAsLeave { get; set; }
    }
}
