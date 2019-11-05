using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class EmailContractApproval
    {
        public int Id { get; set; }

        // [ForeignKey("IndentDomestic")]
        [Required(ErrorMessage = "Field is required....")]
        public int IndentId { get; set; }
        //public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [StringLength(10)]
        public string IndentKey { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [StringLength(50)]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [StringLength(50)]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        //[ForeignKey("HrDepartment")]
        public int DepartmentId { get; set; }
        //public virtual HrDepartment HrDepartment { get; set; }

        [StringLength(1000)]
        public string comments { get; set; }

        public bool approved { get; set; }
        public bool emailComments { get; set;}
        
        public int ApprovedBy { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ApprovedOn { get; set; }



    }
}
