using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_HistoryDetails
    {
        [Key]
        [StringLength(8)]
        public string HistoryID { get; set; }

        [ForeignKey("HrEmployee")]
        public int EmployeeId { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [ForeignKey("HR_Allowances")]
        [Required]
        [StringLength(4)]
        public string AllowanceID { get; set; }
        public virtual HR_Allowances HR_Allowances { get; set;}

        public decimal Amount { get; set; }

        [StringLength(1)]
        public string Mode { get; set; }
        public decimal AllowanceValue { get; set; }
    }
}
