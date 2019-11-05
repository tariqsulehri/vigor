namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StoreCounter
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal StoreItemCode { get; set; }
    }
}
