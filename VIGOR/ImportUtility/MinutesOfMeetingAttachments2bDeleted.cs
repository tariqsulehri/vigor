namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MinutesOfMeetingAttachments2bDeleted
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string MeetingID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string FileDescription { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public virtual MinutesOfMeeting MinutesOfMeeting { get; set; }
    }
}
