namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CPAFindingNature")]
    public partial class CPAFindingNature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CPAFindingNatureID { get; set; }

        [Required]
        [StringLength(15)]
        public string CPAFindingNatureDesc { get; set; }
    }
}
