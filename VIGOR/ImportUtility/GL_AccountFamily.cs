namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_AccountFamily
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string AccountTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string AccountDescription { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AccountFamilyID { get; set; }
    }
}
