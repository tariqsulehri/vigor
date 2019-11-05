namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FCTTLedger")]
    public partial class FCTTLedger
    {
        [Key]
        [StringLength(12)]
        public string TTTransectionID { get; set; }

        public DateTime Dated { get; set; }

        [StringLength(12)]
        public string RefTRanID { get; set; }

        [Required]
        [StringLength(1)]
        public string IsRequest { get; set; }

        [StringLength(10)]
        public string RequestID { get; set; }

        [StringLength(8)]
        public string FNLAccount { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [StringLength(3)]
        public string TranType { get; set; }

        [Required]
        [StringLength(250)]
        public string Narration { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TTAmountToBeReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TTAmountReceived { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExchangeRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TTAmountCredit { get; set; }

        public decimal? AmountAsServiceCharges { get; set; }

        public decimal? AmountAsBankCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TaxDeductedPercent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AccountAsTaxDeducted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AccountAsReceivedinBankAccount { get; set; }

        [StringLength(350)]
        public string TTRouting { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_createdBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(1)]
        public string IsPosted { get; set; }
    }
}
