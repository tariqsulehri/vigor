namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YarnInspectionReportType
    {
        [Key]
        [StringLength(1)]
        public string InspectionReportType { get; set; }

        [Required]
        [StringLength(25)]
        public string InspectionReportTypeDescription { get; set; }
    }
}
