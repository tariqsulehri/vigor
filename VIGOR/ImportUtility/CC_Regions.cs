namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Regions
    {
        [Key]
        [StringLength(4)]
        public string RegionID { get; set; }

        [Required]
        [StringLength(100)]
        public string RegionDescription { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
