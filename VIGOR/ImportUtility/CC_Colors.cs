namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Colors
    {
        [Key]
        [StringLength(5)]
        public string ColourCodeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CodeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ColourID { get; set; }

        [Required]
        [StringLength(25)]
        public string ColorCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ColorDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
