namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Counter
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal NoOfUsers { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfCompanies { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfDepartments { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FiscalYears { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FiscalPeriods { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AccountID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SystemOptions { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FNLAccountID { get; set; }
    }
}
