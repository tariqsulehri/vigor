namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReferenceRegister")]
    public partial class ReferenceRegister
    {
        [StringLength(10)]
        public string RefSr_no { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string ReferenceID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ReferenceDate { get; set; }

        public int? NoOfDoc { get; set; }

        [StringLength(2)]
        public string DOCTYPE { get; set; }

        [StringLength(2)]
        public string MESSTYPE { get; set; }

        [StringLength(6)]
        public string CustomerID { get; set; }

        [StringLength(5)]
        public string UserId { get; set; }

        [StringLength(3)]
        public string CompanyId { get; set; }
    }
}
