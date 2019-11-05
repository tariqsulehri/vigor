namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ADM_SystemOptions
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string OptionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string OptionDescription { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OptionLevel { get; set; }

        [StringLength(9)]
        public string ParentID { get; set; }

        [StringLength(1)]
        public string IsMenuOption { get; set; }

        public bool? Allowed { get; set; }

        [StringLength(50)]
        public string FormObject { get; set; }

        [StringLength(1)]
        public string IsFunction { get; set; }
    }
}
