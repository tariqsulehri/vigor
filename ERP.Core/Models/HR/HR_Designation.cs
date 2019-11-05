using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_Designation
    {
        [Key]
        [StringLength(2)]
        [Required(ErrorMessage = "Field is required....")]
        public string DesignationId { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Field is required....")]
        public string Description { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Field is required....")]
        public string RequiredEducation { get; set; }

        [StringLength(500)]
        public string Experience { get; set; }

        [StringLength(1000)]
        public string SkillsRequired { get; set; }

        [StringLength(1000)]
        public string Remarks { get; set; }

        public long HirarchyPriority { get; set; }
        public bool isactive { get; set; }

        public virtual ICollection<HrEmployee> HrEmployees { get; set;}
        public virtual ICollection<HR_SalaryMaster> HR_SalaryMaster { get; set; }

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
