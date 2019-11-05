namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YarnInspectionAttachment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string InspectionSerialID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string FileDescription { get; set; }

        [StringLength(1)]
        public string IsActive { get; set; }

        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_DeletedBy { get; set; }

        public DateTime? DeletedBy { get; set; }
    }
}
