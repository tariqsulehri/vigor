namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemUser")]
    public partial class SystemUser
    {
        [Key]
        [Column("SystemUser", Order = 0)]
        [StringLength(15)]
        public string SystemUser1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string UserPassword { get; set; }
    }
}
