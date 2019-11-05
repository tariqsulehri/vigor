using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_EmployeeLoanAdvanceBalance
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LoanAdvanceID { get; set;}

        [StringLength(5)]
        [Required(ErrorMessage = "Field is required....")]
        public string EmployeeNo { get; set; }

        [StringLength(3)]
        [Required(ErrorMessage = "Field is required....")]
        public string Company { get; set; }

        public double LoanOpenBalance { get; set; }
        public double AdvanceOpenBalance { get; set; }
        public double LoanAmountBalance { get; set; }
        public double AdvanceAmountBalance { get; set; }
        public double LoanInstalment {get; set; }
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
