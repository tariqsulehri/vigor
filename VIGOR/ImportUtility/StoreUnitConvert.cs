namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoreUnitConvert")]
    public partial class StoreUnitConvert
    {
        [Key]
        [StringLength(4)]
        public string UnitConvertID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(3)]
        public string PurchaseUnit { get; set; }

        [Required]
        [StringLength(3)]
        public string IssueUnit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ConvertFactor { get; set; }

        [Required]
        [StringLength(4)]
        public string userid_as_createdby { get; set; }

        public DateTime createdon { get; set; }

        [StringLength(4)]
        public string userid_as_modifiedby { get; set; }

        public DateTime? modifiedon { get; set; }
    }
}
