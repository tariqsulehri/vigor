using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_EmployeeQualification
    {
        public int Id { get; set; }

        [ForeignKey("HrEmployee")]
        public int EmployeeId { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [ForeignKey("HR_Degree")]
        [StringLength(2)]
        public string DegreeId { get; set; }
        public virtual HR_Degree HR_Degree { get; set;}

        [StringLength(100)]
        public string Institution { get; set; }

        [StringLength(10)]
        public string Marks_gpa { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "Field is required....")]
        public string Grade { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "Field is required....")]
        public string Division { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "Field is required....")]
        public string Status { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Field is required....")]
        public string DegreeSession { get; set; }
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
