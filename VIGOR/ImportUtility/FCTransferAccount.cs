namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FCTransferAccount
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string FNLAccountID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string PartyAccount { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string DebtorAccount { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3)]
        public string CurrencyID { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LinkedAccount { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InActiveSince { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }
    }
}
