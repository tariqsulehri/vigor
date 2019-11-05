namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CPAFindingNCTypeSub")]
    public partial class CPAFindingNCTypeSub
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CPAFindingNCTypeSubID { get; set; }

        public int CPAFindingNCTypeID { get; set; }

        [StringLength(25)]
        public string DESCRIPTION { get; set; }
    }
}
