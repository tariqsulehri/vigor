namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MinutesOfMeeting")]
    public partial class MinutesOfMeeting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MinutesOfMeeting()
        {
            MinutesOfMeetingAttachments2bDeleted = new HashSet<MinutesOfMeetingAttachments2bDeleted>();
        }

        [StringLength(9)]
        public string Id { get; set; }

        [StringLength(2)]
        public string Type { get; set; }

        public DateTime? IDDATE { get; set; }

        [StringLength(500)]
        public string SUBJECT { get; set; }

        [StringLength(500)]
        public string Agenda { get; set; }

        [StringLength(100)]
        public string Venue { get; set; }

        [Column(TypeName = "text")]
        public string Minuts { get; set; }

        [StringLength(1000)]
        public string Participants { get; set; }

        [StringLength(5)]
        public string ReportedBy { get; set; }

        [StringLength(4)]
        public string Department { get; set; }

        [StringLength(4)]
        public string Userid_as_Createdby { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MinutesOfMeetingAttachments2bDeleted> MinutesOfMeetingAttachments2bDeleted { get; set; }
    }
}
