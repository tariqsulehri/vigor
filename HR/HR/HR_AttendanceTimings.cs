using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_AttendanceTimings
    {
        [Key]
        [StringLength(9)]
        public string EmployeeAttendanceID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Column(TypeName = "numeric")]
        public int AttendanceMonth { get; set; }

        [Column(TypeName = "numeric")]
        public int AttendanceYear { get; set; }

        public DateTime? AttendanceDate { get; set; }

        [StringLength(1)]
        public string InputType { get; set; }

        [StringLength(1)]
        public string IsLate { get; set; }

        public DateTime? Checkin { get; set; }

        [StringLength(8)]
        public string TimeCheckin { get; set; }

        public DateTime? CheckOut { get; set; }

        [StringLength(8)]
        public string TimeCheckout { get; set; }

        [Column(TypeName = "numeric")]
        public int Hours { get; set; }

        [Column(TypeName = "numeric")]
        public int Minutes { get; set; }
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
