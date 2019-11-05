namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_ContactTypes
    {
        [Key]
        [StringLength(2)]
        public string ContactTypeID { get; set; }

        [Required]
        [StringLength(25)]
        public string ContactTypeDescription { get; set; }
    }
}
