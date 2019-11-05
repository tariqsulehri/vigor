namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StoreUnit
    {
        [Key]
        [StringLength(3)]
        public string UnitId { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitDescription { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime Createdon { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? Modifiedon { get; set; }
    }
}
