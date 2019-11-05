namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_PoDetails
    {
        [Key]
        [StringLength(14)]
        public string PODetailID { get; set; }

        [Required]
        [StringLength(12)]
        public string PoNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal StoreItemID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(3)]
        public string UnitID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal QuantityReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalAmount { get; set; }

        public virtual Store_Po Store_Po { get; set; }
    }
}
