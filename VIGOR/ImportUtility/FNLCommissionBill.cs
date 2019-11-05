namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FNLCommissionBill
    {
        [StringLength(12)]
        public string FNLCommissionBillID { get; set; }

        public DateTime BillDate { get; set; }

        [Required]
        [StringLength(8)]
        public string FNLAccount { get; set; }

        public bool? IsPostedBySystem { get; set; }

        public bool? IsOpeningBalance { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

        [StringLength(3)]
        public string TranType { get; set; }

        [StringLength(4)]
        public string Department { get; set; }

        [StringLength(10)]
        public string CommissionInvoiceNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CommissionAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ClearedAmount { get; set; }

        public DateTime? ClearedAmountReceiveDate { get; set; }

        public bool? IsCleared { get; set; }

        [StringLength(6)]
        public string Responsibility { get; set; }

        public decimal? AmountCredited { get; set; }

        public decimal? AmountAsCharges { get; set; }

        public decimal? AmountAsMiscCharges { get; set; }

        public decimal? ExchangeRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TaxDeductedPercent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AccountAsTaxDeducted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AccountAsReceivedinBankAccount { get; set; }

        [StringLength(250)]
        public string Narration { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReturnableCurrencyRate { get; set; }

        [StringLength(3)]
        public string ReturnableCurency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReturnableFCAmount { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_createdBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(1)]
        public string RequirePosting { get; set; }

        [StringLength(1)]
        public string PaymentPosted { get; set; }

        [StringLength(50)]
        public string SenderRefNo { get; set; }

        public DateTime? SenderRefNoDate { get; set; }
    }
}
