namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CustomerContact
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CustomerCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string ContactType { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string ContactNumber { get; set; }
    }
}
