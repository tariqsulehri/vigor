namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DocumentEFilingType
    {
        [Key]
        [StringLength(2)]
        public string DocumentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(1)]
        public string Scope { get; set; }
    }
}
