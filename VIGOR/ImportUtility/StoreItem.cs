namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StoreItem
    {
        [Column(TypeName = "numeric")]
        public decimal ID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Required]
        [StringLength(13)]
        public string Code { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public int CodeLevel { get; set; }

        [StringLength(12)]
        public string ParentCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ParentID { get; set; }

        public bool IsItem { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MaxLevel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReorderLevel { get; set; }

        public decimal? UnitConvertFactor { get; set; }

        [StringLength(3)]
        public string PurchaseUnit { get; set; }

        [StringLength(3)]
        public string SaleUnit { get; set; }

        [Required]
        [StringLength(4)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int ChildAccounts { get; set; }
    }
}
