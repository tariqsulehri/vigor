namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QEmail")]
    public partial class QEmail
    {
        [Key]
        [StringLength(9)]
        public string AlertID { get; set; }

        public DateTime Dated { get; set; }

        [Required]
        [StringLength(500)]
        public string ToEmailIDs { get; set; }

        [StringLength(500)]
        public string SMSTo { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailSubject { get; set; }

        [Required]
        [StringLength(2500)]
        public string EmailText { get; set; }

        [Required]
        [StringLength(1)]
        public string IsSent { get; set; }

        [Required]
        [StringLength(1)]
        public string Email { get; set; }

        [Required]
        [StringLength(1)]
        public string SMS { get; set; }

        public DateTime? AlertSentOn { get; set; }
    }
}
