namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Sizes
    {
        [Key]
        [StringLength(4)]
        public string SizeID { get; set; }

        [Required]
        [StringLength(50)]
        public string SizeDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PriorityinGroup { get; set; }

        [Required]
        [StringLength(3)]
        public string SizeGroup { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
