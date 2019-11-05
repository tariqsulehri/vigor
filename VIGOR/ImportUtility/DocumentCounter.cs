namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentCounter")]
    public partial class DocumentCounter
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Year { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal LocalSalesContract { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal ExportSalesContract { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FNL_CommissionBill { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FNL_CommissinPayment { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LocalCommissionInvoice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExportCommissionInvoice { get; set; }
    }
}
