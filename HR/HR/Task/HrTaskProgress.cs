using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class HrTaskProgress
    {

        public int Id { get; set;}

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(11)]
        public string TaskProgressKey { get; set; }

        [ForeignKey("HrTaskRegister")]
        public int DeptId { get; set; }
        public virtual HrTaskRegister HrTaskRegister { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(9)]
        public string TaskKey { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2500)]
        public string Comments { get; set; }

        public Boolean isActive { get; set;}
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
