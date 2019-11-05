namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Products
    {
        [Key]
        [StringLength(6)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(2)]
        public string CommodityType { get; set; }

        [StringLength(1)]
        public string IsValueAdded { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? StuffedQty { get; set; }

        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
