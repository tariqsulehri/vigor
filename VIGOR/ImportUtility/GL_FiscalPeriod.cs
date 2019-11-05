namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_FiscalPeriod
    {
        [Key]
        [StringLength(4)]
        public string FiscalPeriodID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Required]
        [StringLength(4)]
        public string FiscalYearID { get; set; }

        [Required]
        [StringLength(20)]
        public string FiscalPeriodDescription { get; set; }

        public DateTime FiscalPeriodStart { get; set; }

        public DateTime FiscalPeriodEnd { get; set; }

        [Required]
        [StringLength(1)]
        public string IsCurrent { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string CreatedBy { get; set; }
    }
}
