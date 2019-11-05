namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_AccountBalance
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string FiscalYearID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AccountID { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal OpeningBalance { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string IsManualUpdated { get; set; }

        public DateTime? BalanceUpdatedOn { get; set; }

        [StringLength(4)]
        public string BalanceUpdatedBy { get; set; }
    }
}
