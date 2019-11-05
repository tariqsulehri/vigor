namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_CommissionInvoiceAgentComm
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
        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(13)]
        public string SalesContractCommCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(6)]
        public string CustomerIDCommPaidTo { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(6)]
        public string CustomerIDCommPaidFrom { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal CommissionRate { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool IsinLocalCurrency { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string CommissionType { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal CommissionValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CommissionDiscountValue { get; set; }

        [StringLength(100)]
        public string CommissionDiscountRemarks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SalesTaxValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CommissionNetValue { get; set; }
    }
}
