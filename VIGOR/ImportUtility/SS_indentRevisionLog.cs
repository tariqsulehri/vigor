namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_indentRevisionLog
    {
        [Key]
        [Column(Order = 0)]
        public DateTime LogDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string Userid_RevisedBy { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime EditStart { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Editend { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string RevisedReason { get; set; }
    }
}
