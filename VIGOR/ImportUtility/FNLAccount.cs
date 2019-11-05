namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FNLAccount
    {
        [StringLength(8)]
        public string FNLAccountID { get; set; }

        [Required]
        [StringLength(6)]
        public string PartyAccount { get; set; }

        [Required]
        [StringLength(6)]
        public string DebtorAccount { get; set; }

        [Required]
        [StringLength(3)]
        public string CurrencyID { get; set; }

        public bool? Returnable { get; set; }

        [StringLength(3)]
        public string ReturnableCurrency { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InActiveSince { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LinkedAccount { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }
    }
}
