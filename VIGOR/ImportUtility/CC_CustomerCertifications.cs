namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CustomerCertifications
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CustomerCode { get; set; }

        [StringLength(4)]
        public string CertificationCode { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? Validity { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string IsActive { get; set; }
    }
}
