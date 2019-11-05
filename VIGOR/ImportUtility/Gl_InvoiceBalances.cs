namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gl_InvoiceBalances
    {
        [Key]
        [StringLength(15)]
        public string InvoiceID { get; set; }

        [Required]
        [StringLength(4)]
        public string DepartmentId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AccountID { get; set; }

        [Required]
        [StringLength(10)]
        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountCleared { get; set; }

        public DateTime PostedOn { get; set; }

        [StringLength(4)]
        public string CreatedBy { get; set; }

        [StringLength(1)]
        public string ReceiveableOrPayable { get; set; }

        [StringLength(1)]
        public string IncludeInSalesTax { get; set; }

        [StringLength(1)]
        public string StInvIssued { get; set; }

        [StringLength(2)]
        public string SalestaxOfficeCode { get; set; }

        [StringLength(4)]
        public string FinYear { get; set; }

        [StringLength(4)]
        public string FinMonth { get; set; }

        public DateTime? STINVDate { get; set; }

        [StringLength(14)]
        public string STInvNo { get; set; }

        public DateTime? STInvNoCreatedOn { get; set; }

        [StringLength(4)]
        public string STInvNoCreatedBy { get; set; }

        [StringLength(18)]
        public string Voucher { get; set; }

        public bool? WithHeldSalesTax { get; set; }

        public virtual GL_COA GL_COA { get; set; }
    }
}
