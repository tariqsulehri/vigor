using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.ViewModels
{
    public class CINCRViewModel
    {
        [Key]
        [StringLength(8)]
        [Required(ErrorMessage = "Field is required....")]
        public string id { get; set; }


        [ForeignKey("HrEmployee")]
        public int EmployeeId { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [StringLength(4)]
        public string EmpDept { get; set; }
        public string Designation { get; set; }
        
        [StringLength(4)]
        [Required(ErrorMessage = "Field is required....")]
        public string ReportedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        public DateTime ReportedDate { get; set; }

        [StringLength(2000)]
        [Required(ErrorMessage = "Field is required....")]
        public string Incident { get; set; }

        [StringLength(2)]
        [Required(ErrorMessage = "Field is required....")]
        public string TypeOfIncident { get; set; }

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
