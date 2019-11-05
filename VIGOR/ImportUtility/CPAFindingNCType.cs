namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CPAFindingNCType")]
    public partial class CPAFindingNCType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CPAFindingNCTypeID { get; set; }

        [Required]
        [StringLength(25)]
        public string CPAFindingNCTypeDesc { get; set; }
    }
}
