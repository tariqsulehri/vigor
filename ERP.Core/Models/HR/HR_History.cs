using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.Models.HR
{
    public class HR_History
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
        
        [ForeignKey("Company")]
        [Required]
        public int companyID { get; set; }
        public virtual Company Company { get; set; }

        [StringLength(3)]
        [Required(ErrorMessage = "Field is required....")]
        public string CompanyKey { get; set; }

        [Required]
        [StringLength(1)]
        public string PromotionType { get; set; }

        public DateTime Dated { get; set; }

        public double? psBasic { get; set; }

        public double? psAllowance { get; set; }

        public double? psCurrent { get; set; }

        public double? nsBasic { get; set; }

        public double? nsAllowance { get; set; }

        public double? nsCurrent { get; set; }

        [StringLength(4)]
        public string PreviousDepartment { get; set; }

        [StringLength(3)]
        public string PreviousDesignation { get; set; }

        [StringLength(3)]
        public string PreviousCompany { get; set; }

        [StringLength(4)]
        public string NewDepartment { get; set; }

        [StringLength(3)]
        public string NewDesignation { get; set; }

        [StringLength(3)]
        public string NewCompany { get; set; }

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
