namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_VoucherMaster
    {
        [Key]
        [StringLength(18)]
        public string VoucherID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VoucherNo { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VoucherTypeID { get; set; }

        [StringLength(4)]
        public string FiscalYearID { get; set; }

        [Required]
        [StringLength(4)]
        public string FiscalPeriodID { get; set; }

        public DateTime Voucherdate { get; set; }

        [StringLength(700)]
        public string Reference { get; set; }

        public decimal TotalDebit { get; set; }

        public decimal TotalCredit { get; set; }

        [StringLength(20)]
        public string ChqNo { get; set; }

        public DateTime? ChqDate { get; set; }

        public bool VoucherStatus { get; set; }

        public bool IspostedBySystem { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime Createdon { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BookDefinitionID { get; set; }

        public bool? IsInactive { get; set; }

        [StringLength(4)]
        public string InActiveBy { get; set; }

        public DateTime? InactiveOn { get; set; }

        [StringLength(13)]
        public string InActiveTime { get; set; }

        [StringLength(3)]
        public string JVVoucherType { get; set; }

        [StringLength(10)]
        public string PostDatedChqID { get; set; }

        public bool? ContainAttachment { get; set; }

        [StringLength(25)]
        public string OldVoucherID { get; set; }

        public bool? ContainSalesInvoices { get; set; }

        [StringLength(50)]
        public string Attachedfilename { get; set; }
    }
}
