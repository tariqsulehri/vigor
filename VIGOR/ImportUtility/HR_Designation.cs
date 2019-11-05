namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Designation
    {
        [Key]
        [StringLength(3)]
        public string DesignationId { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string RequiredEducation { get; set; }

        [StringLength(500)]
        public string Experience { get; set; }

        [StringLength(1000)]
        public string SkillsRequired { get; set; }

        [StringLength(1000)]
        public string Remarks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal HirarchyPriority { get; set; }

        public bool? IsActive { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserID_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
