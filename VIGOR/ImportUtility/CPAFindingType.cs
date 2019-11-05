namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CPAFindingType")]
    public partial class CPAFindingType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CPAFindingID { get; set; }

        [Column("CPAFindingType")]
        [Required]
        [StringLength(10)]
        public string CPAFindingType1 { get; set; }
    }
}
