namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_VoucherType
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal VoucherTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string VoucherType { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(1)]
        public string Abbreviation { get; set; }
    }
}
