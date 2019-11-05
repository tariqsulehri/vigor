namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_FiscalYear
    {
        [Key]
        [StringLength(4)]
        public string FiscalYearID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(1)]
        public string IsFinalized { get; set; }

        [Required]
        [StringLength(1)]
        public string IsCurrent { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InvoicePosted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChqCounter { get; set; }
    }
}
