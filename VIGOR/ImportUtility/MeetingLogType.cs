namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeetingLogType")]
    public partial class MeetingLogType
    {
        [Key]
        [StringLength(2)]
        public string Type { get; set; }

        [StringLength(25)]
        public string MeetingDesc { get; set; }
    }
}
