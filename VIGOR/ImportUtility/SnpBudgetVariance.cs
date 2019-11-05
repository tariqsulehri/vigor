namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SnpBudgetVariance")]
    public partial class SnpBudgetVariance
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string AccountCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Amount { get; set; }

        public decimal? Jul { get; set; }

        public decimal? Aug { get; set; }

        public decimal? Sep { get; set; }

        public decimal? Oct { get; set; }

        public decimal? Nov { get; set; }

        public decimal? Dec { get; set; }

        public decimal? Jan { get; set; }

        public decimal? Feb { get; set; }

        public decimal? Mar { get; set; }

        public decimal? Apr { get; set; }

        public decimal? May { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Jun { get; set; }
    }
}
