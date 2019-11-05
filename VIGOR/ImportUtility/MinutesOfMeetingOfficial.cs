namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MinutesOfMeetingOfficial
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string MeetingCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string CompanyOfficial { get; set; }
    }
}
