namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventLog")]
    public partial class EventLog
    {
        [Key]
        [Column(Order = 0)]
        public DateTime EventDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string EventTime { get; set; }

        [Key]
        [Column("EventLog", Order = 2)]
        [StringLength(500)]
        public string EventLog1 { get; set; }
    }
}
