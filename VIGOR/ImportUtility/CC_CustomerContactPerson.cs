namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CustomerContactPerson
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CustomerCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ContactType { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }
    }
}
