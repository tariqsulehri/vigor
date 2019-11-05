namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FNL_CommissionPaymentDetail
    {
        [StringLength(12)]
        public string FNLCommissionBillID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string FNLCommission_invoice { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AmountReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsBankCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsMiscCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetAmountReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsBankChargesLC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsMiscChargesLC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetAmountReceivedLC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountAsIncomeTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReturnableCurrencyRate { get; set; }

        [StringLength(3)]
        public string ReturnableCurency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReturnableAmountinFCafterDeductBCharges { get; set; }
    }
}
