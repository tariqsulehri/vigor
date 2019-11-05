namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_SizeGroups
    {
        [Key]
        [StringLength(3)]
        public string SizeGroupID { get; set; }

        [Required]
        [StringLength(15)]
        public string SizeGroupDescription { get; set; }
    }
}
