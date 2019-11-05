namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gl_PostDatedChq
    {
        [Key]
        [StringLength(10)]
        public string PostDatedChqID { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(4)]
        public string FiscalYearID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FromAccountID { get; set; }

        [StringLength(20)]
        public string ChqNo { get; set; }

        [StringLength(150)]
        public string BankName { get; set; }

        public DateTime? ChqDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? chqAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChequeStatusID { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        [StringLength(18)]
        public string VoucherID { get; set; }

        [StringLength(4)]
        public string Userid_Inactive_By { get; set; }

        public DateTime? InactiveDate { get; set; }

        [StringLength(4)]
        public string Userid_Last_Modified { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? isReceivable { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PostToAccountID { get; set; }
    }
}
