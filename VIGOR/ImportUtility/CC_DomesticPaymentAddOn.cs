namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DomesticPaymentAddOn
    {
        [Key]
        [StringLength(2)]
        public string AddonID { get; set; }

        [Required]
        [StringLength(50)]
        public string AddonDescription { get; set; }
    }
}
