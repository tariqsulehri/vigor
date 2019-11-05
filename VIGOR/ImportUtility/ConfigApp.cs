namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigApp")]
    public partial class ConfigApp
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConfigAppID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
