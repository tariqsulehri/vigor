namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FNLESI")]
    public partial class FNLESI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string ESINo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string FiscalPeriodCode { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime FromPeriod { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime ToPeriod { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string Companycode { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(8)]
        public string FNLAccountCode { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime CreatedOn { get; set; }
    }
}
