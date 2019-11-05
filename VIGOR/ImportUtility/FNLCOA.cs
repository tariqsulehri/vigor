namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FNLCOA")]
    public partial class FNLCOA
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal FNLAccountID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Required]
        [StringLength(24)]
        public string FNLAccountCode { get; set; }

        [StringLength(6)]
        public string AccountTitleID { get; set; }

        [Required]
        [StringLength(150)]
        public string AccountTitle { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ParentID { get; set; }

        [StringLength(24)]
        public string FNLParentCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LevelOfAccount { get; set; }

        public bool? IsTransectionLevel { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChildAccounts { get; set; }
    }
}
