namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoreItemBalance")]
    public partial class StoreItemBalance
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string FiscalYear { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal StoreItem { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string StoreLocation { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal OpeningBal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OpeningAmount { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LastPurchaseRate { get; set; }

        public DateTime? LastPurchaseDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LastPurchaseQty { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal BalanceQty { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal BalanceAmount { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal AverageRate { get; set; }
    }
}
