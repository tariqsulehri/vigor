namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CustomerMachineryDetails
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CustomerCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string MachineryDetails { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Qauntity { get; set; }
    }
}
