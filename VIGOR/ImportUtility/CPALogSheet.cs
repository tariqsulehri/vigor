namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CPALogSheet")]
    public partial class CPALogSheet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string CpaNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Remarks { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Dated { get; set; }
    }
}
