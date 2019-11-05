namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_ShortLeaves
    {
        [Key]
        [StringLength(9)]
        public string EmployeeAttendanceID { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AttendanceYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AttendanceMonth { get; set; }

        public DateTime AttendanceDate { get; set; }

        [StringLength(8)]
        public string TimeCheckin { get; set; }

        [StringLength(8)]
        public string TimeCheckout { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Hours { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Minutes { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [StringLength(4)]
        public string UserID_As_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
