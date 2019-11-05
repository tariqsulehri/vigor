namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Currency
    {
        [Key]
        [StringLength(3)]
        public string CurrencyID { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyDescription { get; set; }

        [Required]
        [StringLength(5)]
        public string CurrencySymbol { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserID_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
