namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SoftwareModule
    {
        [StringLength(2)]
        public string SoftwareModuleID { get; set; }

        [Required]
        [StringLength(30)]
        public string ModuleDescription { get; set; }
    }
}
