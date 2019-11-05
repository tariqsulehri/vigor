namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tempabc")]
    public partial class tempabc
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CommissionInvoiceNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(3)]
        public string UOSID { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal Rate { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal Total { get; set; }

        [StringLength(3)]
        public string companyId { get; set; }
    }
}
