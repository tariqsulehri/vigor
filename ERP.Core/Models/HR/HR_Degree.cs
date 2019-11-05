using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_Degree
    {
        [Key]
        [StringLength(2)]
        [Required(ErrorMessage = "Field is required....")]
        public string DegreeID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Field is required....")]
        public string Description { get; set; }
        public ICollection<HR_EmployeeQualification> HR_EmployeeQualification { get; set;}

    }
}
