namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Certifications
    {
        [Key]
        [StringLength(4)]
        public string CertificationID { get; set; }

        [Required]
        [StringLength(200)]
        public string CertificationDescription { get; set; }
    }
}
