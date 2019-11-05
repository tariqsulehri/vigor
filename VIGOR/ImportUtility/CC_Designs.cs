namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Designs
    {
        [Key]
        [StringLength(4)]
        public string DesignID { get; set; }

        [Required]
        [StringLength(50)]
        public string DesignDescription { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
