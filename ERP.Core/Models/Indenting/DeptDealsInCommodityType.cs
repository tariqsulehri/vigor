using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class DeptDealsInCommodityType
    {
        public int id { get; set; }


        [MaxLength(6)]
        [Required(ErrorMessage = "This is Required Field")]
        public string mkey { get; set; }

        [Required(ErrorMessage = "Department Id is required field..")]
        [ForeignKey("HrDepartment")]
        public int DepartmentId { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }

        [Required(ErrorMessage = "State Id is required field..")]
        [ForeignKey("CommodityType")]
        public int ComodityType { get; set; }
        public virtual CommodityType CommodityType { get; set;}
        public String ComodityTypeName { get; set;}
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
