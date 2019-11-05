namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_MessageType
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string MESSTYPE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MESSNAME { get; set; }
    }
}
