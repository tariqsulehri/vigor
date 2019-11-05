namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LinkedUser
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string MacAddress { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Login { get; set; }
    }
}
