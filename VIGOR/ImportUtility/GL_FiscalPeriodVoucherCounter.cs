namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_FiscalPeriodVoucherCounter
    {
        [Key]
        public int CounterID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Required]
        [StringLength(4)]
        public string FiscalYearID { get; set; }

        [Required]
        [StringLength(4)]
        public string FiscalPeriodID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VoucherTypeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LastVoucherNumber { get; set; }
    }
}
