namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_GazzettedDays
    {
        [Key]
        [StringLength(6)]
        public string GazzettedDateId { get; set; }

        public DateTime? GazzettedDateFrom { get; set; }

        public DateTime? GazzettedDateTo { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(4)]
        public string TranYear { get; set; }

        [StringLength(3)]
        public string Company { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
