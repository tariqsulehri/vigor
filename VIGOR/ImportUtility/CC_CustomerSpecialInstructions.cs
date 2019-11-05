namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_CustomerSpecialInstructions
    {
        [Key]
        [StringLength(6)]
        public string CustomerCode { get; set; }

        [StringLength(400)]
        public string SpecialInstructions { get; set; }
    }
}
