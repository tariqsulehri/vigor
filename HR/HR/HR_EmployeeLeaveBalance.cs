using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_EmployeeLeaveBalance
    {
        public int Id { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "Field is required....")]
        public string EmployeeNo { get; set; }

        [StringLength(3)]
        [Required(ErrorMessage = "Field is required....")]
        public string Company { get; set; }

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
    }
}
