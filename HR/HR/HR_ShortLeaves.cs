namespace ERP.Core.Models.HR
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

        public int AttendanceYear { get; set; }

        public int AttendanceMonth { get; set; }

        public DateTime AttendanceDate { get; set; }

        [StringLength(8)]
        public string TimeCheckin { get; set; }

        [StringLength(8)]
        public string TimeCheckout { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }

    }
}
