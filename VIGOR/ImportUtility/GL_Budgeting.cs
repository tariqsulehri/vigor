namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_Budgeting
    {
        [Key]
        [StringLength(10)]
        public string BudgetID { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [Required]
        [StringLength(4)]
        public string FiscalYear { get; set; }

        public int AccountID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AllocatedBudget { get; set; }
    }
}
