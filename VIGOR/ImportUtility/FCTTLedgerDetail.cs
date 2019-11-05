namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FCTTLedgerDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string TTTransectionCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string TTTransectionSrNo { get; set; }

        [StringLength(10)]
        public string CommissionInvoiceNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CommissionAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ClearedAmount { get; set; }

        public DateTime? ClearedAmountReceiveDate { get; set; }

        [StringLength(12)]
        public string RefTTTransectionCode { get; set; }

        [StringLength(15)]
        public string RefTTTransectionCodeSrNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsBankCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetAmountReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsBankChargesLC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetAmountReceivedLC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsIncomeTax { get; set; }
    }
}
