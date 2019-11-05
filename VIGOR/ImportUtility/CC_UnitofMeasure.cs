namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_UnitofMeasure
    {
        [Key]
        [StringLength(2)]
        public string UOMID { get; set; }

        [Required]
        [StringLength(50)]
        public string UOMDescription { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
