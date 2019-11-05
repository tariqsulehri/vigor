namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KnittedFabricInspectionAttachment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string InspectionCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string FileDescription { get; set; }

        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
