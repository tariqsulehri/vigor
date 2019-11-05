namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_LeadTime
    {
        [Key]
        [StringLength(2)]
        public string LeadTimeID { get; set; }

        [Required]
        [StringLength(50)]
        public string LeadTimeDescription { get; set; }
    }
}
