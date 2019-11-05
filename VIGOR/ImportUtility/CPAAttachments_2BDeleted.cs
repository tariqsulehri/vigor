namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CPAAttachments-2BDeleted")]
    public partial class CPAAttachments_2BDeleted
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string CpaNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string FileName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreatedOn { get; set; }
    }
}
