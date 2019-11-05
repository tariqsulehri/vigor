namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransectionYear")]
    public partial class TransectionYear
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string TranYearID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime StartDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime EndDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string IsFinalized { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1)]
        public string IsCurrent { get; set; }

        public DateTime? CurrentMonthStart { get; set; }

        public DateTime? CurrentMonthEnd { get; set; }
    }
}
