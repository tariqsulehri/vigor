namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_PriceTerms
    {
        [Key]
        [StringLength(4)]
        public string PriceTermID { get; set; }

        [Required]
        [StringLength(50)]
        public string PriceTermDescription { get; set; }

        [Required]
        [StringLength(15)]
        public string PriceTermAbbrv { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
