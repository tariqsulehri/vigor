using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class HrTaskRegister
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(9)]
        public string TaskKey { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2000)]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Field is required....")]
        public int AssignedTo { get; set; }

        //[Required(ErrorMessage = "Field is required....")]
        public int AssignedBy { get; set; }

        [ForeignKey("HrDepartment")]
        public int DeptId { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }


        //[Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]
        public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ExpectedCompletionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }
        
        //public ICollection<HrTaskRegister> HrTaskRegisters { get; set; }

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
