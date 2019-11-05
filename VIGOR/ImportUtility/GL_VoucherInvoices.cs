namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_VoucherInvoices
    {
        [StringLength(18)]
        public string VoucherID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string InvoiceNo { get; set; }

        [StringLength(14)]
        public string StaxInvNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string InvoiceID { get; set; }

        public decimal? AmountReceived { get; set; }

        public decimal? Deduction { get; set; }

        public decimal? RateDiff { get; set; }

        [StringLength(1)]
        public string ReceiveableOrPayable { get; set; }

        [StringLength(18)]
        public string VoucherDeduction { get; set; }

        [StringLength(18)]
        public string VoucherRateDiff { get; set; }

        [StringLength(18)]
        public string VoucherSalesTaxAmount { get; set; }
    }
}
