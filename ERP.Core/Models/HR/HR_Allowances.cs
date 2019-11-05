using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_Allowances
    {
        [Key]
        [StringLength(4)]
        public string AllowanceID { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(1)]
        public string Type { get; set; }

        [StringLength(1)]
        public string SubType { get; set; }

        [StringLength(1)]
        public string TaxStatus { get; set; }

        [StringLength(1)]
        public string ApplyOn { get; set; }

        public virtual ICollection<HR_EmployeeAllowances> HR_EmployeeAllowances { get; set;}
        public virtual ICollection<HR_HistoryDetails> HR_HistoryDetails { get; set; }
        //public virtual ICollection<HR_SalaryDetail> HR_SalaryDetail { get; set; }
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

 
