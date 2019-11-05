using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Common
{
    public class MarkeetDealsIn
    {
        public int Id { get; set; }

        [StringLength(1)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "Description is Required Field...")]
        [StringLength(30)]
        public string Description { get; set; }
        public ICollection<DeptDealsInMarkeet> DeptDealsInMarkeet { get; set;}
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
