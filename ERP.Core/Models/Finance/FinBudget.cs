using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Finance
{
    public class FinBudget
    {
        public int Id { get; set; }

        [ForeignKey("CoaL5")]
        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(20)]
        public string GlCode { get; set;}
        public virtual CoaL5 CoaL5 {get; set;}
        public decimal Amount { get; set;}
        public bool IsDel { get; set; }

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
