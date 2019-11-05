namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValidNTN")]
    public partial class ValidNTN
    {
        [Key]
        [Column(Order = 0)]
        public DateTime FromDate { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Todate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string NTN { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Pntn { get; set; }

        [StringLength(3)]
        public string Company { get; set; }
    }
}
