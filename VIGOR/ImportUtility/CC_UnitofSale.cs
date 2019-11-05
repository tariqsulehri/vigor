namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_UnitofSale
    {
        [Key]
        [StringLength(3)]
        public string UOSID { get; set; }

        [Required]
        [StringLength(50)]
        public string UOSDescription { get; set; }

        [Required]
        [StringLength(2)]
        public string UOMID { get; set; }

        [Required]
        [StringLength(2)]
        public string UORID { get; set; }

        [StringLength(2)]
        public string StuffingUnit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Factor { get; set; }

        [StringLength(2)]
        public string StandardUOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? StandardUOMFactor { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(1)]
        public string ShipmentSchedule { get; set; }

        [StringLength(1)]
        public string RequireStuffing { get; set; }
    }
}
