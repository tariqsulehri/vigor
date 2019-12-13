using ERP.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.ViewModels
{
    public class LeaveApprove_VM
    {
        public int Id { get; set; }

        [ForeignKey("HrEmployee")]
        public int EmployeeId { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [ForeignKey("Company")]
        [Required]
        public int companyID { get; set; }
        public virtual Company Company { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyKey { get; set; }

        [StringLength(4)]
        public string TransactionYear { get; set; }
        public decimal LeavespenBalance { get; set; }
        public decimal LeavesConsumed { get; set; }
        public decimal LeavesInBalance { get; set; }
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

        public string EmpName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string IntimationType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Reason { get; set; }
        public string IntNo { get; set; }
        public string Status { get; set; }
        public DateTime AppDate { get; set; }
        public DateTime AppOn { get; set; }

        public bool Pending { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }
    }
}
