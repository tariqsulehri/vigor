using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class GeneralTask
    {
        [Key]
        public int Id { get; set; }

        [StringLength(9)]
        public string GeneralTaskIDKey { get; set; }
        public DateTime TaskDate { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string TaskProgress { get; set; }


        [ForeignKey("HrEmployee")]
        public int TaskAssignedById { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }
        
        [ForeignKey("HrDepartment")]
        public int TaskAssignedByDeptID { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }
        
        public DateTime? TaskCompletionDate { get; set; }

        [StringLength(1)]
        public string IsApproved { get; set; }

        [StringLength(1)]
        public string IsCompleted { get; set; }

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
